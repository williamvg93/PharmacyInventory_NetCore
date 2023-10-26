using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Inventory;
using Core.Entities.Person;

namespace Core.Entities.Person;

public class CPerson : BaseEntity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public DateTime RegistreDate { get; set; }

    /* Foreign Key for Document Type */
    public int IdDocuTypeFk { get; set; }
    public DocumentType DocumentTypes { get; set; }
    /* --------------------------------- */
    /* Foreign Key for Role Person */
    public int IdRolePersonFk { get; set; }
    public RolePerson RolePeople { get; set; }

    /* --------------------------------- */
    /* Foreign Key for Type Person */
    public int IdTypePersonFk { get; set; }
    public TypePerson TypePeople { get; set; }

    /* Relationship whit Address -> One to Many */
    public ICollection<Address> Addresses { get; set; }
    /* --------------------------------- */
    /* Relationship whit Inventory Manage -> One to Many */
    public ICollection<InventoryManagement> InventoryManagementsSeller { get; set; }
    public ICollection<InventoryManagement> InventoryManagementsReci { get; set; }
    /* --------------------------------- */
    /* Relationship whit TypeContacts -> Many to Many */
    public ICollection<PersonContact> PersonContacts { get; set; }
    /* --------------------------------- */

}
