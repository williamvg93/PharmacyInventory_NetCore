using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Person;

public class CPersonConfig : IEntityTypeConfiguration<CPerson>
{
    public void Configure(EntityTypeBuilder<CPerson> builder)
    {
        /* Assign Table name */
        builder.ToTable("person");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);

        /* Assign Colums */
        /* -------------------------------- */

        builder.Property(c => c.Code)
        .IsRequired()
        .HasMaxLength(20);
        /* Add Unique attribute */
        builder.HasIndex(c => c.Code)
        .IsUnique();

        builder.Property(n => n.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(rd => rd.RegistreDate)
        .HasColumnType("datetime");

        /* -------------------------------- */

        /* Assign Foreign Key */
        /* -------------------------------- */
        builder.HasOne(fk => fk.DocumentTypes)
        .WithMany(fk => fk.People)
        .HasForeignKey(fk => fk.IdDocuTypeFk);

        builder.HasOne(fk => fk.RolePeople)
        .WithMany(fk => fk.People)
        .HasForeignKey(fk => fk.IdRolePersonFk);

        builder.HasOne(fk => fk.TypePeople)
        .WithMany(fk => fk.People)
        .HasForeignKey(fk => fk.IdTypePersonFk);
        /* -------------------------------- */


    }
}
