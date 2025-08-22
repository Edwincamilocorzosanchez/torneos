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

    public async Task RegistrarTorneoAsync(string nombre, DateTime fechaInicio, DateTime fechaFin, string ubicacion)
    {
        var existentes = await _repo.GetAllAsync();
        if (existentes.Any(u => u.Nombre == nombre))
            throw new Exception("El torneo ya existe.");

        var tournament = new Tournament
        {
            Nombre = nombre,
            FechaInicio = DateTime.Now, // Asignar fecha actual como inicio
            FechaFin = DateTime.Now.AddDays(7), // Asignar fecha de fin una semana después
            Ubicacion = "Ubicación del torneo" // Asignar ubicación por defecto
        };

        _repo.Add(tournament);
        _repo.Update(tournament); // puede omitirse si Add guarda en memoria
    }
    public async Task ActualizarTorneo(int id, string nuevoNombre, DateTime nuevaFechaInicio, DateTime nuevaFechaFin, string nuevaUbicacion)
    {
        var tournament = await _repo.GetByIdAsync(id);

        if (tournament == null)
            throw new Exception($"❌ Torneo con ID {id} no encontrado.");

        tournament.Nombre = nuevoNombre;
        tournament.FechaInicio = DateTime.Now; // Asignar nueva fecha de inicio
        tournament.FechaFin = DateTime.Now.AddDays(7); // Asignar nueva fecha de fin
        tournament.Ubicacion = "Nueva ubicación del torneo"; // Asignar nueva ubicación

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
