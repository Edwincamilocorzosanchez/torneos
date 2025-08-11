using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.InscripcionTorneo.Application.Interfaces;
using torneos.src.Modules.InscripcionTorneo.Domain.Entities;
using torneos.src.Shared.Context;
namespace torneos.src.Modules.InscripcionTorneo.Application.Services
{


    public class InscripcionTorneoService : IInscripcionTorneoService
    {
        private readonly IInscripcionTorneoRepository _inscripcionRepository;

        public InscripcionTorneoService(IInscripcionTorneoRepository inscripcionRepository)
        {
            _inscripcionRepository = inscripcionRepository;
        }
    
        public async Task InscribirEquipoAsync(int equipoId, int torneoId)
        {
            var inscripcion = new Inscripcion
            {
                TeamId = equipoId,
                TournamentId = torneoId,
                FechaInscripcion = DateTime.Now
            };
            await _inscripcionRepository.CreateAsync(inscripcion);
        }

        public async Task InscribirCuerpoMedicoAsync(int equipoId, int torneoId, int cuerpoMedicoId)
        {
            var inscripcion = new Inscripcion
            {
                TeamId = equipoId,
                TournamentId = torneoId,
                CuerpoMedicoId = cuerpoMedicoId,
                FechaInscripcion = DateTime.Now
            };
            await _inscripcionRepository.CreateAsync(inscripcion);
        }

        public async Task InscribirCuerpoTecnicoAsync(int equipoId, int torneoId, int cuerpoTecnicoId)
        {
            var inscripcion = new Inscripcion
            {
                TeamId = equipoId,
                TournamentId = torneoId,
                CuerpoTecnicoId = cuerpoTecnicoId,
                FechaInscripcion = DateTime.Now
            };
            await _inscripcionRepository.CreateAsync(inscripcion);
        }
    }
}