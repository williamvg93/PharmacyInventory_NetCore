using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Post.Location;
public class DepartmentPDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IdCountryFk { get; set; }
}
