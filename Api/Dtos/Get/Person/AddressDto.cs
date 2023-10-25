using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Get.Person;
public class AddressDto
{
    public int Id { get; set; }
    public string RoadType { get; set; }
    public short FirstNumber { get; set; }
    public string FirstLetter { get; set; }
    public string Bis { get; set; }
    public string SecondLetter { get; set; }
    public string Cardinal { get; set; }
    public short SecondNumber { get; set; }
    public string ThirdLetter { get; set; }
    public short ThirdNumber { get; set; }
    public string SecondCardinal { get; set; }
    public string Complement { get; set; }
}
