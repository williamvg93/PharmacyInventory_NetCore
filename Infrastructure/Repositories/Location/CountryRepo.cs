using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Location;
using Core.Interfaces.Location;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Location;

public class CountryRepo : GenericRepository<Country>, ICountry
{
    private readonly PharmaInventContext _context;

    public AuditorRepo(PharmaInventContext context) : base(context)
    {
        _context = context;
    }
}
