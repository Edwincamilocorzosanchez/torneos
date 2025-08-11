using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using torneos.src.Modules.MedicalBody.Application.Interfaces;
using torneos.src.Modules.MedicalBody.Domain.Entities;
using torneos.src.Shared.Context;

namespace torneos.src.Modules.MedicalBody.Infrastructure.Repositories
{
    public class MedicalBodyRepository : IMedicalBodyRepository
    {
        private readonly AppDbContext _context;

        public MedicalBodyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CuerpoMedico?> GetByIdAsync(int id)
        {
            return await _context.CuerposMedicos // opcional, si quieres traer las tareas asociadas
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<CuerpoMedico>> GetAllAsync()
        {
            return await _context.CuerposMedicos.ToListAsync();
        }

        public void Add(CuerpoMedico entity)
        {
            _context.CuerposMedicos.Add(entity);
        }

        public async Task SaveAsync() =>
        await _context.SaveChangesAsync();
    }
}