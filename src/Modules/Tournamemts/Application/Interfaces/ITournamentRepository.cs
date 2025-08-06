using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Teams.Domain.Entities;

namespace torneos.src.Modules.Teams.Application.Interfaces
{
    public interface ITournamentRepository
    {
    Task<Tournament?> GetByIdAsync(int id);
    Task<IEnumerable<Tournament>> GetAllAsync();
    void Add(Tournament entity);
    void Remove(Tournament entity);
    void Update(Tournament entity);
    Task SaveAsync();
    }
}