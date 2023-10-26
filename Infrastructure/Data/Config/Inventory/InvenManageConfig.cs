using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Inventory;

public class InvenManageConfig : IEntityTypeConfiguration<InventoryManagement>
{
    public void Configure(EntityTypeBuilder<InventoryManagement> builder)
    {
        /* Assign Table name */
        builder.ToTable("inventorymanagement");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);

        /* Assign Colums */
        builder.Property(md => md.MovementDate)
        .IsRequired()
        .HasColumnType("datetime");

        builder.Property(ed => ed.ExpirationDate)
        .IsRequired()
        .HasColumnType("datetime");

        /* Assign Foreign Key */
        /* ----------------------------------------- */
        builder.HasOne(fk => fk.PeopleSellers)
        .WithMany(fk => fk.InventoryManagementsReci)
        .HasForeignKey(fk => fk.IdPersSellerFk);

        builder.HasOne(fk => fk.PeopleReceive)
        .WithMany(fk => fk.InventoryManagementsSeller)
        .HasForeignKey(fk => fk.IdPersReciFk);

        builder.HasOne(fk => fk.MovementTypes)
        .WithMany(fk => fk.InventoryManagements)
        .HasForeignKey(fk => fk.IdMoveTypeFk);

        builder.HasOne(fk => fk.PaymentMethods)
        .WithMany(fk => fk.InventoryManagements)
        .HasForeignKey(fk => fk.IdPayMethodFk);
        /* ----------------------------------------- */

    }
}
