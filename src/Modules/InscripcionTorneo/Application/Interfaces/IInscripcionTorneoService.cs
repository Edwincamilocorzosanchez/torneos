using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torneos.src.Modules.InscripcionTorneo.Application.Interfaces
{
    public interface IInscripcionTorneoService
    {
        Task InscribirEquipoAsync(int equipoId, int torneoId);
        Task InscribirCuerpoMedicoAsync(int equipoId, int torneoId, int cuerpoMedicoId);
        Task InscribirCuerpoTecnicoAsync(int equipoId, int torneoId, int cuerpoTecnicoId);
    }
}