using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.MedicalBody.Domain.Entities;

namespace torneos.src.Modules.MedicalBody.Application.Interfaces
{
    public interface IMedicalBodyService
    {
        Task RegistrarCuerpoMedicoAsync(CuerpoMedico cuerpoMedico);
        Task<CuerpoMedico?> ObtenerCuerpoMedicoPorIdAsync(int id);
        Task<IEnumerable<CuerpoMedico>> ConsultarCuerposMedicosAsync();
    }
}