using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using torneos.src.Modules.MedicalBody.Domain.Entities;
namespace torneos.src.Shared.Configurations
{


    public class MedicalBodyConfiguration 
    {
        public void Configure(EntityTypeBuilder<CuerpoMedico> builder)
        {
            builder.ToTable("CuerposMedicos");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Nombre)
                   .IsRequired()
                   .HasMaxLength(500);
            builder.Property(m => m.Especialidad)
                   .IsRequired()
                   .HasMaxLength(100);
            // Puedes agregar más configuraciones aquí
        }
    }
}