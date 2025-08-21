using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using torneos.src.Modules.Players.Application.Interfaces;
using torneos.src.Modules.Players.Domain.Entities;
using torneos.src.Shared.Context;

namespace torneos.src.Modules.Players.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _context;

        public PlayerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Player?> GetByIdAsync(int id)
        {
            return await _context.Players // opcional, si quieres traer las tareas asociadas
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task AddAsync(Player entity)
        {
            await _context.Players.AddAsync(entity);
        }



        public Task UpdateAsync(Player entity) =>
            _context.SaveChangesAsync();
        public async Task SaveAsync() =>
        await _context.SaveChangesAsync(); // ⬅️ Implementació

        Task IPlayerRepository.RemoveAsync(Player entity)
        {
            _context.Players.Remove(entity);
            return Task.CompletedTask;
        }
    }
}