using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.InscripcionTorneo.Domain.Entities;
using torneos.src.Shared.Context;
using Microsoft.EntityFrameworkCore;
using torneos.src.Modules.InscripcionTorneo.Application.Interfaces;
namespace torneos.src.Modules.InscripcionTorneo.Infrastructure.Repositories
{
    

    public class InscripcionTorneoRepository : IInscripcionTorneoRepository
    {
        private readonly AppDbContext _context;

        public InscripcionTorneoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Inscripcion?> GetByIdAsync(int id)
        {
            return await _context.Inscripciones.FindAsync(id);
        }

        public async Task<IEnumerable<Inscripcion>> GetAllAsync()
        {
            return await _context.Inscripciones.ToListAsync();
        }

        public async Task CreateAsync(Inscripcion inscripcion)
        {
            _context.Inscripciones.Add(inscripcion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Inscripcion inscripcion)
        {
            _context.Inscripciones.Update(inscripcion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var inscripcion = await GetByIdAsync(id);
            if (inscripcion != null)
            {
                _context.Set<Inscripcion>().Remove(inscripcion);
                await _context.SaveChangesAsync();
            }
        }


    }
}