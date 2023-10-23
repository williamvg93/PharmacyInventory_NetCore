using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Location;
using Core.Interfaces.Location;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Location;

public class DepartmentRepo : GenericRepository<Department>, IDepartment
{
    private readonly PharmaInventContext _context;

    public DepartmentRepo(PharmaInventContext context) : base(context)
    {
        _context = context;
    }
}
