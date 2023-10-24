using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Product;

public class ProductBrand : BaseEntity
{
    public string Name { get; set; }

    /*    Relationship whit Product -> One to Many    */
    public ICollection<CProduct> Products { get; set; }
    /* --------------------------------------------- */
}
