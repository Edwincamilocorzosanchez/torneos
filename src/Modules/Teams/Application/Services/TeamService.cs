using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Teams.Application.Interfaces;
using torneos.src.Modules.Teams.Domain.Entities;

namespace torneos.src.Modules.Teams.Application.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _repo;

    public TeamService(ITeamRepository repo)
    {
        _repo = repo;
    }
    public Task<IEnumerable<Team>> ConsultarEquiposAsync()
    {
        return _repo.GetAllAsync();
    }

    public async Task RegistrarEquipoAsync(string nombre)
    {
        var existentes = await _repo.GetAllAsync();
        if (existentes.Any(u => u.Nombre == nombre))
            throw new Exception("El equipo ya existe.");

        var team = new Team
        {
            Nombre = nombre,
        };

        _repo.Add(team);
        _repo.Update(team); // puede omitirse si Add guarda en memoria
    }
    public async Task ActualizarEquipo(int id, string nuevoNombre)
    {
        var team = await _repo.GetByIdAsync(id);

        if (team == null)
            throw new Exception($"❌ Equipo con ID {id} no encontrado.");

        team.Nombre = nuevoNombre;

        _repo.Update(team);
        await _repo.SaveAsync();
    }

    public async Task EliminarEquipo(int id)
    {
        var team = await _repo.GetByIdAsync(id);
        if (team == null)
            throw new Exception($"❌ Equipo con ID {id} no encontrado.");
        _repo.Remove(team);
        await _repo.SaveAsync();
    }

    public async Task<Team?> ObtenerEquipoPorIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }
}
