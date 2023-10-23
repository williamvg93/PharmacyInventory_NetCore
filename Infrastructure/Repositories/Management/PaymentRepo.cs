using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Location;
using Core.Interfaces.Location;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Management;

public class PaymentRepo : GenericRepository<City>, ICity
{
    private readonly PharmaInventContext _context;

    public PaymentRepo(PharmaInventContext context) : base(context)
    {
        _context = context;
    }
}
