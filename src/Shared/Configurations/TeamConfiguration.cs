using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using torneos.src.Modules.Teams.Domain.Entities;

namespace torneos.src.Shared.Configurations
{
    public class TeamConfiguration
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("team");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nombre)
                   .IsRequired()
                   .HasMaxLength(100);
        }    
    }
}