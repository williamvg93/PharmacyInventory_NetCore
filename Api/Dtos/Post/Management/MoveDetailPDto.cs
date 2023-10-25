using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Post.Management;

public class MoveDetailPDto
{
    public int Id { get; set; }
    public ushort QuantityUnits { get; set; }
    public double Price { get; set; }
    public int IdInventManagFk { get; set; }
    public int IdInventoryFk { get; set; }
}
