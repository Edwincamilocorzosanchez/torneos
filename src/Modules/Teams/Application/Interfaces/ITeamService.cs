using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Teams.Domain.Entities;

namespace torneos.src.Modules.Teams.Application.Interfaces
{
    public interface ITeamService
    {
    Task RegistrarEquipoAsync(Team team);
    Task ActualizarEquipoAsync(int id, Team team);
    Task EliminarEquipoAsync(int id);
    Task<Team?> ObtenerEquipoPorIdAsync(int id);
    Task<IEnumerable<Team>> ConsultarEquiposAsync();
    }
}