using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Inventory;

namespace Core.Entities.Management;

public class MovementType : BaseEntity
{
    public string Name { get; set; }

    /* Relationship whit Inventory Management -> Many to Many */
    public ICollection<InventoryManagement> InventoryManagements { get; set; }
    /* ----------------------------------------- */

}
