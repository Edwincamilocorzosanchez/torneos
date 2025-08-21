using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Transferencias.Domain.Entities;

namespace torneos.src.Modules.Transferencias.Application.Interfaces
{
    public interface ITransferenciaService
    {
     Task ComprarJugadorAsync(int jugadorId, int equipoDestinoId, decimal monto);
    Task PrestarJugadorAsync(int jugadorId, int equipoDestinoId, DateTime fechaFin);
    Task<IEnumerable<Transferencia?>> ObtenerTransferenciasPorJugadorAsync(int jugadorId);
    Task<IEnumerable<Transferencia?>> ObtenerTransferenciasPorEquipoAsync(int equipoId);

    }
}