using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Core.Interfaces.Person;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Person;

public class TypePersRepo : GenericRepository<TypePerson>, ITypePerson
{
    private readonly PharmaInventContext _context;

    public TypePersRepo(PharmaInventContext context) : base(context)
    {
        _context = context;
    }
}