using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using torneos.src.Modules.Transferencias.Domain.Entities;

namespace torneos.src.Shared.Configurations
{
    public class TransferenciaConfiguration : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.ToTable("Transferencias");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.PlayerId)
                .IsRequired();

            builder.Property(t => t.TeamOrigenId)
                .IsRequired();

            builder.Property(t => t.TeamDestinoId)
                .IsRequired();

            builder.Property(t => t.Fecha)
                .IsRequired();
            builder.Property(t => t.Tipo)
                .IsRequired();

            builder.Property(t => t.Monto)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}