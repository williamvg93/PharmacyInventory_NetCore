using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Management;
using Core.Entities.Person;

namespace Api.Dtos.Post.Inventory;

public class InventManagPDto
{
    public int Id { get; set; }
    public DateTime MovementDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int IdPersSellerFk { get; set; }
    public int IdPersReciFk { get; set; }
    public int IdMoveTypeFk { get; set; }
    public int IdPayMethodFk { get; set; }
    /* ----------------------------------------- */

}
