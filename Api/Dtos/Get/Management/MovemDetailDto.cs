using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Get.Management;
public class MovemDetailDto
{
    public int Id { get; set; }
    public ushort QuantityUnits { get; set; }
    public double Price { get; set; }
}
