using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Person;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        /* Assign Table name */
        builder.ToTable("address");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);

        /* Assign Colums */
        builder.Property(rt => rt.RoadType)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(fn => fn.FirstNumber)
        .IsRequired()
        .HasColumnType("short");

    }
}
