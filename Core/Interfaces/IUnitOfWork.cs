using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Inventory;
using Core.Interfaces.Location;
using Core.Interfaces.Management;
using Core.Interfaces.Person;
using Core.Interfaces.Product;

namespace Core.Interfaces;

public interface IUnitOfWork
{
    IInventoryManagement InvenManags { get; }
    ICInventory Inventories { get; }
    ICity Cities { get; }
    ICountry Countries { get; }
    IDepartment Departments { get; }
    IInvoice Invoices { get; }
    IMovementDetail MovemDetails { get; }
    IMovementType MovemTypes { get; }
    IPaymentMethod PaymMethods { get; }
    IAddress Addresses { get; }
    ICPerson People { get; }
    IDocumentType DocumTypes { get; }
    IPersonContact PersContacts { get; }
    IRolePerson RolePeople { get; }
    ITypeContact TypeContacts { get; }
    ITypePerson TypePeople { get; }
    ICProduct Products { get; }
    IPresentationType PresType { get; }
    IProductBrand ProdBrands { get; }
    Task<int> SaveAsync();
}