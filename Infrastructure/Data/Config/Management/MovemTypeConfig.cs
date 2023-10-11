using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Management;

public class MovemTypeConfig : IEntityTypeConfiguration<MovementType>
{
    public void Configure(EntityTypeBuilder<MovementType> builder)
    {
        /* Assign Table name */
        builder.ToTable("movementtype");

        /* Assign Colums */
        builder.HasKey(pk => pk.Id);

        /* Assign Foreign Key */
        builder.Property(n => n.Name)
        .IsRequired()
        .HasMaxLength(50);
    }
}
