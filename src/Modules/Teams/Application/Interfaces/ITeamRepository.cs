using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.Teams.Domain.Entities;

namespace torneos.src.Modules.Teams.Application.Interfaces
{
    public interface ITeamRepository
    {
    Task<Team?> GetByIdAsync(int id);
    Task<IEnumerable<Team>> GetAllAsync();
    void Add(Team entity);
    void Remove(Team entity);
    void Update(Team entity);
    Task SaveAsync();
    }
}