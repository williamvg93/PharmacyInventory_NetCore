using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Inventory;

namespace Api.Dtos.Get.Management;

public class MovemDetailDto
{
    public int Id { get; set; }
    public ushort QuantityUnits { get; set; }
    public double Price { get; set; }
}
