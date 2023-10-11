using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Product;

public class CProductConfig : IEntityTypeConfiguration<CProduct>
{
    public void Configure(EntityTypeBuilder<CProduct> builder)
    {
        /* Assign Table name */
        builder.ToTable("product");

        /* Assign Primary Key */
        builder.HasKey(fk => fk.Id);

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

        builder.HasOne(fk => fk.ProductBrands)
        .WithMany(fk => fk.Products)
        .HasForeignKey(fk => fk.IdProdBrandFk);

        /* -------------------------------- */


    }
}
