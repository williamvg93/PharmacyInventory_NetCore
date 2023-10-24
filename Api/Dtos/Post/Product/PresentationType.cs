using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Inventory;

namespace Core.Entities.Product;

public class PresentationType : BaseEntity
{
    public string Name { get; set; }

    /*    Relationship whit CInventory -> One to Many    */
    public ICollection<CInventory> Inventories { get; set; }
    /* --------------------------------------------- */
}
