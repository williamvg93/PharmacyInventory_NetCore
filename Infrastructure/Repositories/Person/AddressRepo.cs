using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Core.Interfaces.Person;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Person;

public class AddressRepo : GenericRepository<Address>, IAddress
{
    private readonly PharmaInventContext _context;

    public AddressRepo(PharmaInventContext context) : base(context)
    {
        _context = context;
    }
}