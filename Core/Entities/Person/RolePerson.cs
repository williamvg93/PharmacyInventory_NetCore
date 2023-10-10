using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Person;

public class RolePerson : BaseEntity
{
    public string Name { get; set; }

    /*   Relationship whit Person -> One to Many    */
    public ICollection<CPerson> People { get; set; }

    /* -------------------------------------------- */

}