using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using torneos.src.Modules.TechnicalStaff.Application.Interfaces;
using torneos.src.Modules.TechnicalStaff.Domain.Entities;
using torneos.src.Modules.TechnicalStaff.Infrastructure.Repositories;
using torneos.src.Shared.Context;

namespace torneos.src.Modules.TechnicalStaff.Infrastructure.Repositories
{
    public class TechnicalStaffRepository : ITechnicalStaffRepository
    {
        private readonly AppDbContext _context;

        public TechnicalStaffRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CuerpoTecnico?> GetByIdAsync(int id)
        {
            return await _context.CuerposTecnicos // opcional, si quieres traer las tareas asociadas
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<CuerpoTecnico>> GetAllAsync()
        {
            return await _context.CuerposTecnicos.ToListAsync();
        }

        public void Add(CuerpoTecnico entity)
        {
            _context.CuerposTecnicos.Add(entity);
        }

        public async Task SaveAsync() =>
        await _context.SaveChangesAsync();
    }
}