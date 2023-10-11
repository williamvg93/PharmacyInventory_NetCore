using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Management;
using Core.Entities.Product;

namespace Core.Entities.Inventory;

public class CInventory : BaseEntity
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public int MinStock { get; set; }
    public int MaxStock { get; set; }
    /* ----------------------------------------- */
    /* Foreign Key for Product */
    public int IdProductFk { get; set; }
    public CProduct Products { get; set; }
    /* ----------------------------------------- */
    /* Foreign Key for Presentation Type */
    public int IdPresTypeFk { get; set; }
    public PresentationType PresentationTypes { get; set; }

    /* Relationship whit InventoryManagement -> Many to Many */
    public ICollection<MovementDetail> MovementDetails { get; set; }
    /* ----------------------------------------- */

}
