using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;

namespace Core.Entities.Location;

public class City : BaseEntity
{
    public nuint Name { get; set; }
    /* --------- Foreign Keys ---------- */

    /* Foreign Key for Department */
    
    /* --------------------------------- */

    /*    Relationship whit Address -> One to Many    */
    public ICollection<Address> Addresses { get; set; }
    /* --------------------------------------------- */

}
