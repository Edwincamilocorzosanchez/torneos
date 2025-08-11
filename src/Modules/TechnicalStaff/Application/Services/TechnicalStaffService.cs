using Microsoft.EntityFrameworkCore;
using torneos.src.Modules.TechnicalStaff.Application.Interfaces;
using torneos.src.Modules.TechnicalStaff.Domain.Entities;
using torneos.src.Modules.TechnicalStaff.Infrastructure.Repositories;

namespace torneos.src.Modules.TechnicalStaff.Application.Services
{
    public class TechnicalStaffService : ITechnicalStaffService
    {
        private readonly ITechnicalStaffRepository _technicalStaffRepository;

        public TechnicalStaffService(ITechnicalStaffRepository technicalStaffRepository)
        {
            _technicalStaffRepository = technicalStaffRepository;
        }

        public async Task RegistrarCuerpoTecnicoAsync(CuerpoTecnico cuerpoTecnico)
        {
            _technicalStaffRepository.Add(cuerpoTecnico);
            await _technicalStaffRepository.SaveAsync();
        }

        public Task<IEnumerable<CuerpoTecnico>> ConsultarCuerposTecnicosAsync()
        {
            return _technicalStaffRepository.GetAllAsync();
        }
        public async Task<CuerpoTecnico?> ObtenerCuerpoTecnicoPorIdAsync(int id)
        {
            return await _technicalStaffRepository.GetByIdAsync(id);
        }


        /*public async Task RegistrarCuerpoMedicoAsync(string nombre, string especialidad)
        {
            var medico = new CuerpoMedico { Nombre = nombre, Especialidad = especialidad };
            _context.Set<CuerpoMedico>().Add(medico);
            await _context.SaveChangesAsync();
        }*/
    }
}


