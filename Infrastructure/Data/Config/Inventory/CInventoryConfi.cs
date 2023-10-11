using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Inventory;

public class CInventoryConfi : IEntityTypeConfiguration<CInventory>
{
    public void Configure(EntityTypeBuilder<CInventory> builder)
    {
        /* Assign Table name */
        builder.ToTable("inventory");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);

        /* Assign Colums */
        builder.Property(n => n.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(d => d.Price)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(s => s.Stock)
        .IsRequired();

        builder.Property(ms => ms.MinStock)
        .IsRequired();

        builder.Property(mxs => mxs.MaxStock)
        .IsRequired();

        /* Assign Foreign Key */
        builder.HasOne(fk => fk.Products)
        .WithMany(fk => fk.Inventories)
        .HasForeignKey(fk => fk.IdProductFk);

        builder.HasOne(fk => fk.PresentationTypes)
        .WithMany(fk => fk.Inventories)
        .HasForeignKey(fk => fk.IdPresTypeFk);
    }
}
