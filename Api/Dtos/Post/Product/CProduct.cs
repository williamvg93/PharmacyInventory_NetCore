using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Inventory;

namespace Core.Entities.Product;

public class CProduct : BaseEntity
{
    public string Code { get; set; }
    public string Name { get; set; }

    /* --------- Foreign Keys ---------- */

    /* Foreign Key for ProductBrand */
    public int IdProdBrandFk { get; set; }
    public ProductBrand ProductBrands { get; set; }
    /* --------------------------------- */

    /*    Relationship whit CInventory -> One to Many    */
    public ICollection<CInventory> Inventories { get; set; }
}
