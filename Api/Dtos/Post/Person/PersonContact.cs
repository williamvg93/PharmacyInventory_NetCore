using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Person;

public class PersonContact : BaseEntity
{
    /* Foreign Key for Person */
    public int IdPersonFk { get; set; }
    public CPerson People { get; set; }
    /* --------------------------------- */
    /* Foreign Key for Person */
    public int IdTypeContactFk { get; set; }
    public TypeContact TypeContacts { get; set; }
    /* --------------------------------- */
}
