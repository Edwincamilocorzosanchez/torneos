using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.MedicalBody.Domain.Entities;

namespace torneos.src.Modules.MedicalBody.Application.Interfaces
{
    public interface IMedicalBodyRepository
    {
        Task<CuerpoMedico?> GetByIdAsync(int id);
        Task<IEnumerable<CuerpoMedico>> GetAllAsync();
        void Add(CuerpoMedico entity);
        Task SaveAsync();
    }
}