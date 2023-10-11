using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Management;

public class PaymentMetConfig : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        /* Assign Table name */
        builder.ToTable("paymentmethod");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);

        /* Assign Colums */
        builder.Property(n => n.Name)
        .IsRequired()
        .HasMaxLength(50);
    }
}
