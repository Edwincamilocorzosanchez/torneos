using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using torneos.src.Modules.InscripcionTorneo.Domain.Entities;
namespace torneos.src.Shared.Configurations
{


    public class InscripcionTorneoConfiguration 
    {
     public void Configure(EntityTypeBuilder<Inscripcion> builder)
     {
         builder.ToTable("Inscripciones");
         builder.HasKey(i => i.Id);
         builder.Property(i => i.FechaInscripcion).IsRequired();

         builder.HasOne(i => i.Team)
             .WithMany()
             .HasForeignKey(i => i.TeamId)
             .OnDelete(DeleteBehavior.Restrict);

         builder.HasOne(i => i.Tournament)
             .WithMany()
             .HasForeignKey(i => i.TournamentId)
             .OnDelete(DeleteBehavior.Restrict);

         builder.HasOne(i => i.CuerpoMedico)
             .WithMany()
             .HasForeignKey(i => i.CuerpoMedicoId)
             .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(i => i.CuerpoTecnico)
             .WithMany()
             .HasForeignKey(i => i.CuerpoTecnicoId)
             .OnDelete(DeleteBehavior.SetNull);
     }
    }
}