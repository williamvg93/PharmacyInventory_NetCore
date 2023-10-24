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

public class MovemDetaRepo : GenericRepository<MovementDetail>, IMovementDetail
{
    private readonly PharmaInventContext _context;

    public MovemDetaRepo(PharmaInventContext context) : base(context)
    {
        _context = context;
    }
}