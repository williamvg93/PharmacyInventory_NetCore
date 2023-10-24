using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Product;
using Core.Interfaces.Product;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Product;

public class ProdBrandRepo : GenericRepository<ProductBrand>, IProductBrand
{
    private readonly PharmaInventContext _context;

    public ProdBrandRepo(PharmaInventContext context) : base(context)
    {
        _context = context;
    }
}