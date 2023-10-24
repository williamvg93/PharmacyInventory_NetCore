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

public class PaymentRepo : GenericRepository<PaymentMethod>, IPaymentMethod
{
    private readonly PharmaInventContext _context;

    public PaymentRepo(PharmaInventContext context) : base(context)
    {
        _context = context;
    }
}
