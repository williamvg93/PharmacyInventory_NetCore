using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Post.Person;

public class PersonPDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public DateTime RegistreDate { get; set; }
    public int IdDocuTypeFk { get; set; }
    public int IdRolePersonFk { get; set; }
    public int IdTypePersonFk { get; set; }
}
