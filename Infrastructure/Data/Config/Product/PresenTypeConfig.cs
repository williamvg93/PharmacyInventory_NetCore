using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Product;

public class PresenTypeConfig : IEntityTypeConfiguration<PresentationType>
{
    public void Configure(EntityTypeBuilder<PresentationType> builder)
    {
        /* Assign Table name */
        builder.ToTable("presentationtype");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);

        /* Assign Colums */
        builder.Property(n => n.Name)
        .IsRequired()
        .HasMaxLength(50);
    }
}
