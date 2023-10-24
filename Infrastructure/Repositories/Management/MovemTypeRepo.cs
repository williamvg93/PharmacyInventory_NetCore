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

public class MovemTypeRepo : GenericRepository<MovementType>, IMovementType
{
    private readonly PharmaInventContext _context;

    public MovemTypeRepo(PharmaInventContext context) : base(context)
    {
        _context = context;
    }
}
