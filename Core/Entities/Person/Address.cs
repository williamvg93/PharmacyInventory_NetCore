using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Location;

namespace Core.Entities.Person;

public class Address : BaseEntity
{
    public string RoadType { get; set; }
    public int FirstNumber { get; set; }
    public string FirstLetter { get; set; }
    public string Bis { get; set; }
    public string SecondLetter { get; set; }
    public string Cardinal { get; set; }
    public int SecondNumber { get; set; }
    public string ThirdLetter { get; set; }
    public int ThirdNumber { get; set; }
    public string SecondCardinal { get; set; }
    public string Complement { get; set; }

    /* Foreign Key for Person */
    public int IdPersonFk { get; set; }
    public CPerson People { get; set; }
    /* --------------------------------- */
    /* Foreign Key for City */
    public int IdCityFk { get; set; }
    public City Cities { get; set; }
    /* --------------------------------- */

}
