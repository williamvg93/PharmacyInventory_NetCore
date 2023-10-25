using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Post.Person;

public class PersonContPDto
{
    public int Id { get; set; }
    public int IdPersonFk { get; set; }
    public int IdTypeContactFk { get; set; }
}
