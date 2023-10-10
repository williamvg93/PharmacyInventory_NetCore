using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Person;

public class TypeContact : BaseEntity
{
    public string Name { get; set; }

    /*   Relationship whit Person -> Many to Many    */
    public ICollection<CPerson> People { get; set; }

    /* -------------------------------------------- */
}
