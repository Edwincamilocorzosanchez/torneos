using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Teams.Infraestructure.Repositories;
using torneos.src.Modules.Teams.Domain.Entities;
using torneos.src.Modules.Teams.Application.Interfaces;

namespace torneos.src.Modules.Teams.Application.Services
{
    public class TeamService : ITeamService
    {
    private readonly ITeamRepository _countryRepository;

    public TeamService(ITeamRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }
    public Task<IEnumerable<Team>> ConsultarEquiposAsync()
    {
        return _countryRepository.GetAllAsync();
    }

    public async Task RegistrarEquipoAsync(Team team)
    {
        _countryRepository.Add(team);
        await _countryRepository.SaveAsync();
    }
    public async Task ActualizarEquipoAsync(int id, Team team)
    {
        var existingTeam = await _countryRepository.GetByIdAsync(id);
        if (existingTeam != null)
        {
            existingTeam.Nombre = team.Nombre;
            _countryRepository.Update(existingTeam);
            await _countryRepository.SaveAsync();
        }
    }

    public async Task EliminarEquipoAsync(int id)
    {
        var equipo = await _countryRepository.GetByIdAsync(id);
        if (equipo == null)
            throw new Exception($"❌ Equipo con ID {id} no encontrado.");
        _countryRepository.Remove(equipo);
        await _countryRepository.SaveAsync();
    }

    public async Task<Team?> ObtenerEquipoPorIdAsync(int id)
    {
        return await _countryRepository.GetByIdAsync(id);
    }
    }
}