using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Inventory;
using Core.Entities.Person;

namespace Api.Dtos.Get.Person;

public class CPersonDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public DateTime RegistreDate { get; set; }
}
