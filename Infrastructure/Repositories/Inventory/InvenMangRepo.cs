using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Inventory;
using Core.Entities.Location;
using Core.Interfaces.Inventory;
using Core.Interfaces.Location;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Inventory;

public class InvenMangRepo : GenericRepository<InventoryManagement>, IInventoryManagement
{
    private readonly PharmaInventContext _context;

    public InvenMangRepo(PharmaInventContext context) : base(context)
    {
        _context = context;
    }
}
