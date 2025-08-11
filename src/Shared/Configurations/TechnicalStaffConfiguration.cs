using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using torneos.src.Modules.TechnicalStaff.Domain.Entities;
namespace torneos.src.Shared.Configurations
{


    public class TechnicalStaffConfiguration 
    {
        public void Configure(EntityTypeBuilder<CuerpoTecnico> builder)
        {
            builder.ToTable("CuerposTecnicos");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Nombre)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(t => t.Rol)
                   .IsRequired()
                   .HasMaxLength(100);
            // Puedes agregar más configuraciones aquí
        }
    }
}