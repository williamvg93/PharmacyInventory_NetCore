using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Inventory;

namespace Core.Entities.Management;

public class MovementDetail : BaseEntity
{
    public ushort QuantityUnits { get; set; }
    public double Price { get; set; }
    public int IdInventManagFk { get; set; }
    public int IdInventoryFk { get; set; }
}
