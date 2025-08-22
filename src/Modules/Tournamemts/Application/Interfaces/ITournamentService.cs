using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Teams.Domain.Entities;

namespace torneos.src.Modules.Teams.Application.Interfaces
{
    public interface ITournamentService
    {
    Task RegistrarTorneoAsync(string nombre, DateTime fechaInicio, DateTime fechaFin, string ubicacion);
    Task ActualizarTorneo(int id, string nuevoNombre, DateTime nuevaFechaInicio, DateTime nuevaFechaFin, string nuevaUbicacion);
    Task EliminarTorneo(int id);
    Task<Tournament?> ObtenerTorneoPorIdAsync(int id);
    Task<IEnumerable<Tournament>> ConsultarTorneosAsync();
    }
}