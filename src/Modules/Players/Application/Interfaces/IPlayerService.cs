using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Players.Domain.Entities;

namespace torneos.src.Modules.Players.Application.Interfaces
{
    public interface IPlayerService
    {
        Task RegistrarJugadorAsync(string nombre, int edad, string posicion, decimal valorMercado, int asistencias, int goles);
        Task ActualizarJugador(int id, string nuevoNombre, int nuevaEdad, string nuevaPosicion, decimal nuevoValorMercado, int nuevasAsistencias, int nuevosGoles);
        Task EliminarJugador(int id);
        Task<Player?> ObtenerJugadorPorIdAsync(int id);
        Task<IEnumerable<Player>> ConsultarJugadoresAsync();
    }
}