using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Management;
using Core.Entities.Person;

namespace Core.Entities.Inventory;

public class InventoryManagement : BaseEntity
{
    public DateTime MovementDate { get; set; }
    public DateTime ExpirationDate { get; set; }

    /* ----------------------------------------- */
    /* Foreign Key for CPerson */
    public int IdPersSellerFk { get; set; }
    public CPerson PeopleSellers { get; set; }

    /* Foreign Key for CPerson */
    public int IdPersReciFk { get; set; }
    public CPerson PeopleReceive { get; set; }

    /* Foreign Key for Movement Type */
    public int IdMoveTypeFk { get; set; }
    public MovementType MovementTypes { get; set; }

    /* Foreign Key for Payment Method */
    public int IdPayMethodFk { get; set; }
    public PaymentMethod PaymentMethods { get; set; }

    /* ----------------------------------------- */

    /* Relationship whit CInventory -> Many to Many */
    public ICollection<CInventory> Inventories { get; set; }
    /* ----------------------------------------- */

}
