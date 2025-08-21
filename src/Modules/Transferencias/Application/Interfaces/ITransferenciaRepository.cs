using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Transferencias.Domain.Entities;

namespace torneos.src.Modules.Transferencias.Application.Interfaces
{
    public interface ITransferenciaRepository
    {
        Task<IEnumerable<Transferencia?>> GetAllAsync();
        Task<Transferencia?> GetByIdAsync(int id);
        Task AddAsync(Transferencia transferencia);
        Task UpdateAsync(Transferencia transferencia);
        Task DeleteAsync(int id);
    }
}