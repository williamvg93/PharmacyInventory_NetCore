using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Inventory;

namespace Core.Entities.Management;

public class MovementDetail : BaseEntity
{
    public int QuantityUnits { get; set; }
    public double Price { get; set; }

    /* Foreign Key for Inventory Management */
    public int IdInventManagFk { get; set; }
    public InventoryManagement InventoryManagements { get; set; }
    /* --------------------------------- */
    /* Foreign Key for Inventories */
    public int IdInventoryFk { get; set; }
    public CInventory Inventories { get; set; }
    /* --------------------------------- */

}
