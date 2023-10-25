using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Get.Inventory;

public class InventManagDto
{
    public int Id { get; set; }
    public DateTime MovementDate { get; set; }
    public DateTime ExpirationDate { get; set; }
}
