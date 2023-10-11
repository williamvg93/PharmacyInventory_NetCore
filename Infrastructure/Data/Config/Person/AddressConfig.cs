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

        builder.Property(fl => fl.FirstLetter)
        .IsRequired()
        .HasMaxLength(2);

        builder.Property(b => b.Bis)
        .HasMaxLength(4);

        builder.Property(sl => sl.SecondLetter)
        .HasMaxLength(2);

        builder.Property(c => c.Cardinal)
        .HasMaxLength(4);

        builder.Property(sn => sn.SecondNumber)
        .HasColumnType("short");

        builder.Property(tl => tl.ThirdLetter)
        .HasMaxLength(2);

        builder.Property(tn => tn.ThirdNumber)
        .HasColumnType("short");

        builder.Property(sc => sc.SecondCardinal)
        .HasMaxLength(2);

        builder.Property(c => c.Complement)
        .HasMaxLength(50);

        /* Assign Foreign Key */
        builder.HasOne(fk => fk.People)
        .WithMany(fk => fk.Addresses)
        .HasForeignKey(fk => fk.IdPersonFk);

        builder.HasOne(fk => fk.Cities)
        .WithMany(fk => fk.Addresses)
        .HasForeignKey(fk => fk.IdCityFk);
    }
}
