using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Location;
using Core.Entities.Management;
using Core.Interfaces.Location;
using Core.Interfaces.Management;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Management;

public class InvoiceRepo : GenericRepository<Invoice>, IInvoice
{
    private readonly PharmaInventContext _context;

    public InvoiceRepo(PharmaInventContext context) : base(context)
    {
        _context = context;
    }
}
