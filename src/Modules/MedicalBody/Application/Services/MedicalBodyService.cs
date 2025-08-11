using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.MedicalBody.Application.Interfaces;
using torneos.src.Modules.MedicalBody.Domain.Entities;

namespace torneos.src.Modules.MedicalBody.Application.Services
{
    public class MedicalBodyService : IMedicalBodyService
    {
        private readonly IMedicalBodyRepository _medicalBodyRepository;

        public MedicalBodyService(IMedicalBodyRepository medicalBodyRepository)
        {
            _medicalBodyRepository = medicalBodyRepository;
        }

        public async Task RegistrarCuerpoMedicoAsync(CuerpoMedico cuerpoMedico)
        {
            _medicalBodyRepository.Add(cuerpoMedico);
            await _medicalBodyRepository.SaveAsync();
        }

        public Task<IEnumerable<CuerpoMedico>> ConsultarCuerposMedicosAsync()
        {
            return _medicalBodyRepository.GetAllAsync();
        }
        public async Task<CuerpoMedico?> ObtenerCuerpoMedicoPorIdAsync(int id)
        {
            return await _medicalBodyRepository.GetByIdAsync(id);
        }
    }
}