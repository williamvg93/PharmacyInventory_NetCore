using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Inventory;

namespace Api.Dtos.Post.Product;

public class ProductPDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int IdProdBrandFk { get; set; }
}
