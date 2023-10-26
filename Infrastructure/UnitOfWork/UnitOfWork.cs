using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Inventory;
using Core.Interfaces;
using Core.Interfaces.Inventory;
using Core.Interfaces.Location;
using Core.Interfaces.Management;
using Core.Interfaces.Person;
using Core.Interfaces.Product;
using Infrastructure.Data;
using Infrastructure.Repositories.Inventory;
using Infrastructure.Repositories.Location;
using Infrastructure.Repositories.Management;
using Infrastructure.Repositories.Person;
using Infrastructure.Repositories.Product;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly PharmaInventContext _context;
    private InvenMangRepo _invenManagements;
    private CIventoryRepo _inventories;
    private CityRepo _cities;
    private CountryRepo _countries;
    private DepartmentRepo _departments;
    private InvoiceRepo _invoices;
    private MovemDetaRepo _moveDetails;
    private MovemTypeRepo _moveTypes;
    private PaymentRepo _payments;
    private AddressRepo _addresses;
    private CPersonRepo _people;
    private DocuTypeRepo _docuTypes;
    private PersonContRepo _personContacts;
    private RolePersonRepo _rolePeople;
    private TypeContRepo _typeContacts;
    private TypePersRepo _typePeople;
    private CProductRepo _products;
    private PresenTypeRepo _presenTypes;
    private ProdBrandRepo _prodBrands;




    public UnitOfWork(PharmaInventContext context)
    {
        _context = context;
    }

    public IInventoryManagement InvenManags
    {
        get
        {
            if (_invenManagements == null)
            {
                _invenManagements = new InvenMangRepo(_context);
            }
            return _invenManagements;
        }
    }
    public ICInventory Inventories
    {
        get
        {
            if (_inventories == null)
            {
                _inventories = new CIventoryRepo(_context);
            }
            return _inventories;
        }
    }
    public ICity Cities
    {
        get
        {
            if (_cities == null)
            {
                _cities = new CityRepo(_context);
            }
            return _cities;
        }
    }
    public ICountry Countries
    {
        get
        {
            if (_countries == null)
            {
                _countries = new CountryRepo(_context);
            }
            return _countries;
        }
    }
    public IDepartment Departments
    {
        get
        {
            if (_departments == null)
            {
                _departments = new DepartmentRepo(_context);
            }
            return _departments;
        }
    }
    public IInvoice Invoices
    {
        get
        {
            if (_invoices == null)
            {
                _invoices = new InvoiceRepo(_context);
            }
            return _invoices;
        }
    }
    public IMovementDetail MovemDetails
    {
        get
        {
            if (_moveDetails == null)
            {
                _moveDetails = new MovemDetaRepo(_context);
            }
            return _moveDetails;
        }
    }
    public IMovementType MovemTypes
    {
        get
        {
            if (_moveTypes == null)
            {
                _moveTypes = new MovemTypeRepo(_context);
            }
            return _moveTypes;
        }
    }
    public IPaymentMethod PayMethods
    {
        get
        {
            if (_payments == null)
            {
                _payments = new PaymentRepo(_context);
            }
            return _payments;
        }
    }
    public IAddress Addresses
    {
        get
        {
            if (_addresses == null)
            {
                _addresses = new AddressRepo(_context);
            }
            return _addresses;
        }
    }
    public ICPerson People
    {
        get
        {
            if (_people == null)
            {
                _people = new CPersonRepo(_context);
            }
            return _people;
        }
    }
    public IDocumentType DocumTypes
    {
        get
        {
            if (_docuTypes == null)
            {
                _docuTypes = new DocuTypeRepo(_context);
            }
            return _docuTypes;
        }
    }
    public IPersonContact PersContacts
    {
        get
        {
            if (_personContacts == null)
            {
                _personContacts = new PersonContRepo(_context);
            }
            return _personContacts;
        }
    }
    public IRolePerson RolePeople
    {
        get
        {
            if (_rolePeople == null)
            {
                _rolePeople = new RolePersonRepo(_context);
            }
            return _rolePeople;
        }
    }
    public ITypeContact TypeContacts
    {
        get
        {
            if (_typeContacts == null)
            {
                _typeContacts = new TypeContRepo(_context);
            }
            return _typeContacts;
        }
    }
    public ITypePerson TypePeople
    {
        get
        {
            if (_typePeople == null)
            {
                _typePeople = new TypePersRepo(_context);
            }
            return _typePeople;
        }
    }
    public ICProduct Products
    {
        get
        {
            if (_products == null)
            {
                _products = new CProductRepo(_context);
            }
            return _products;
        }
    }
    public IPresentationType PresType
    {
        get
        {
            if (_presenTypes == null)
            {
                _presenTypes = new PresenTypeRepo(_context);
            }
            return _presenTypes;
        }
    }
    public IProductBrand ProdBrands
    {
        get
        {
            if (_prodBrands == null)
            {
                _prodBrands = new ProdBrandRepo(_context);
            }
            return _prodBrands;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}