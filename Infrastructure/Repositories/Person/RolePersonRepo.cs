using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Core.Interfaces.Person;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Person;

public class RolePersonRepo : GenericRepository<RolePerson>, IRolePerson
{
    private readonly PharmaInventContext _context;

    public RolePersonRepo(PharmaInventContext context) : base(context)
    {
        _context = context;
    }
}