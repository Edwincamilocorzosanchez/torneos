using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using torneos.src.Modules.InscripcionTorneo.Domain.Entities;
using torneos.src.Modules.MedicalBody.Domain.Entities;
using torneos.src.Modules.Players.Domain.Entities;
using torneos.src.Modules.Teams.Domain.Entities;

using torneos.src.Modules.TechnicalStaff.Domain.Entities;

namespace torneos.src.Shared.Context
{
    public class AppDbContext : DbContext
    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Tournament> Tournaments => Set<Tournament>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<CuerpoTecnico> CuerposTecnicos => Set<CuerpoTecnico>();
    public DbSet<CuerpoMedico> CuerposMedicos => Set<CuerpoMedico>();
    public DbSet<Inscripcion> Inscripciones => Set<Inscripcion>();
    public DbSet<Player> Players => Set<Player>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}