using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.TechnicalStaff.Domain.Entities;

namespace torneos.src.Modules.TechnicalStaff.Application.Interfaces
{
    public interface ITechnicalStaffService
    {
        Task RegistrarCuerpoTecnicoAsync(CuerpoTecnico cuerpoTecnico);
        Task<CuerpoTecnico?> ObtenerCuerpoTecnicoPorIdAsync(int id);
        Task<IEnumerable<CuerpoTecnico>> ConsultarCuerposTecnicosAsync();
    }
}