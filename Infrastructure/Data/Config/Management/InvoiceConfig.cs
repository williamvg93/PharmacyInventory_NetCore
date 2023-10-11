using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.Management;

public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        /* Assign Table name */
        builder.ToTable("invoice");

        /* Assign Primary Key */
        builder.HasKey(pk => pk.Id);

        /* Assign Colums */
        builder.Property(iv => iv.InitialInvoice)
        .IsRequired();

        builder.Property(fi => fi.FinalInvoice)
        .IsRequired();

        builder.Property(ci => ci.CurrentInvoice)
        .IsRequired();

        builder.Property(rn => rn.ResolutionNumber)
        .IsRequired();
    }
}
