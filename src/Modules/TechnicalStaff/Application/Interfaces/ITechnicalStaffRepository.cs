using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.TechnicalStaff.Domain.Entities;

namespace torneos.src.Modules.TechnicalStaff.Application.Interfaces
{
    public interface ITechnicalStaffRepository
    {
        Task<CuerpoTecnico?> GetByIdAsync(int id);
        Task<IEnumerable<CuerpoTecnico>> GetAllAsync();
        void Add(CuerpoTecnico entity);
        Task SaveAsync();
    }
}