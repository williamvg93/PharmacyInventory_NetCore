using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Management;

public class MovementDetConfig : IEntityTypeConfiguration<MovementDetail>
{
    public void Configure(EntityTypeBuilder<MovementDetail> builder)
    {
        /* Assign Table name */
        builder.ToTable("movementdetail");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);

        /* Assign Colums */
        builder.Property(qu => qu.QuantityUnits)
        .IsRequired()
        .HasColumnType("smallint");

        builder.Property(p => p.Price)
        .IsRequired()
        .HasColumnType("double");

        /* Assign Foreign Key */
        builder.HasOne(fk => fk.InventoryManagements)
        .WithMany(fk => fk.MovementDetails)
        .HasForeignKey(fk => fk.IdInventManagFk);

        builder.HasOne(fk => fk.Inventories)
        .WithMany(fk => fk.MovementDetails)
        .HasForeignKey(fk => fk.IdInventoryFk);

    }
}
