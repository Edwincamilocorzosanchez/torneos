using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using torneos.src.Modules.Teams.Application.Interfaces;
using torneos.src.Modules.Teams.Domain.Entities;
using torneos.src.Shared.Context;

namespace torneos.src.Modules.Teams.Application.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _context;

    public TeamRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Team?> GetByIdAsync(int id)
    {
        return await _context.Teams // opcional, si quieres traer las tareas asociadas
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<Team>> GetAllAsync()
    {
        return await _context.Teams.ToListAsync();
    }

    public void Add(Team entity)
    {
        _context.Teams.Add(entity);
    }

    public void Remove(Team entity) =>
        _context.Teams.Remove(entity);

    public void Update(Team entity) =>
        _context.SaveChanges();
    public async Task SaveAsync() =>
    await _context.SaveChangesAsync(); // ⬅️ Implementación
    }
}