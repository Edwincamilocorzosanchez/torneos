using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Teams.Application.Interfaces;
using torneos.src.Modules.Teams.Domain.Entities;

namespace torneos.src.Modules.Teams.Application.Services;

public class TournamentService : ITournamentService
{
    private readonly ITournamentRepository _repo;

    public TournamentService(ITournamentRepository repo)
    {
        _repo = repo;
    }
    public Task<IEnumerable<Tournament>> ConsultarTorneosAsync()
    {
        return _repo.GetAllAsync();
    }

    public async Task RegistrarTorneoAsync(string nombre)
    {
        var existentes = await _repo.GetAllAsync();
        if (existentes.Any(u => u.Nombre == nombre))
            throw new Exception("El torneo ya existe.");

        var tournament = new Tournament
        {
            Nombre = nombre,
        };

        _repo.Add(tournament);
        _repo.Update(tournament); // puede omitirse si Add guarda en memoria
    }
    public async Task ActualizarTorneo(int id, string nuevoNombre)
    {
        var tournament = await _repo.GetByIdAsync(id);

        if (tournament == null)
            throw new Exception($"❌ Torneo con ID {id} no encontrado.");

        tournament.Nombre = nuevoNombre;

        _repo.Update(tournament);
        await _repo.SaveAsync();
    }

    public async Task EliminarTorneo(int id)
    {
        var tournament = await _repo.GetByIdAsync(id);
        if (tournament == null)
            throw new Exception($"❌ Torneo con ID {id} no encontrado.");
        _repo.Remove(tournament);
        await _repo.SaveAsync();
    }

    public async Task<Tournament?> ObtenerTorneoPorIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }
}
