using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Players.Domain.Entities;

namespace torneos.src.Modules.Players.Application.Interfaces
{
    public interface IPlayerRepository
    {
        Task<Player?> GetByIdAsync(int id);
        Task<IEnumerable<Player>> GetAllAsync();
        Task AddAsync(Player entity);
        Task RemoveAsync(Player entity);
        Task UpdateAsync(Player entity);
        Task SaveAsync();
    }
}