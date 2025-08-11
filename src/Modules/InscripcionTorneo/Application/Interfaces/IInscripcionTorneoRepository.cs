using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torneos.src.Modules.InscripcionTorneo.Domain.Entities;

namespace torneos.src.Modules.InscripcionTorneo.Application.Interfaces
{
    public interface IInscripcionTorneoRepository
    {
        Task<Inscripcion?> GetByIdAsync(int id);
        Task<IEnumerable<Inscripcion>> GetAllAsync();
        Task CreateAsync(Inscripcion entity);
        Task UpdateAsync(Inscripcion entity);
        Task DeleteAsync(int id);
    }
}