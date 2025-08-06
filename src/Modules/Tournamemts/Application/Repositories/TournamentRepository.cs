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
    public class TournamentRepository : ITournamentRepository
    {
        private readonly AppDbContext _context;

    public TournamentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Tournament?> GetByIdAsync(int id)
    {
        return await _context.Tournaments // opcional, si quieres traer las tareas asociadas
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<Tournament>> GetAllAsync()
    {
        return await _context.Tournaments.ToListAsync();
    }

    public void Add(Tournament entity)
    {
        _context.Tournaments.Add(entity);
    }

    public void Remove(Tournament entity) =>
        _context.Tournaments.Remove(entity);

    public void Update(Tournament entity) =>
        _context.SaveChanges();
    public async Task SaveAsync() =>
    await _context.SaveChangesAsync(); // ⬅️ Implementación
    }
}