using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using torneos.src.Modules.Transferencias.Application.Interfaces;
using torneos.src.Modules.Transferencias.Domain.Entities;
using torneos.src.Shared.Context;

namespace torneos.src.Modules.Transferencias.Infrastructure.Repositories
{
    public class TransferenciaRepository : ITransferenciaRepository
    {
        private readonly AppDbContext _context;

        public TransferenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transferencia?>> GetAllAsync()
        {
            return await _context.Transferencias.ToListAsync();
        }

        public async Task<Transferencia?> GetByIdAsync(int id)
        {
            return await _context.Transferencias.FindAsync(id);
        }

        public async Task AddAsync(Transferencia transferencia)
        {
try
{
    _context.Transferencias.Add(transferencia);
    await _context.SaveChangesAsync();
    Console.WriteLine("✅ Transferencia registrada con éxito.");
}
catch (Exception ex)
{
    Console.WriteLine("❌ Error al guardar transferencia:");
    Console.WriteLine(ex.Message);

    if (ex.InnerException != null)
    {
        Console.WriteLine("➡ InnerException:");
        Console.WriteLine(ex.InnerException.Message);
    }
}
        }

        public async Task UpdateAsync(Transferencia transferencia)
        {
            _context.Transferencias.Update(transferencia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var transferencia = await GetByIdAsync(id);
            if (transferencia != null)
            {
                _context.Transferencias.Remove(transferencia);
                await _context.SaveChangesAsync();
            }
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}