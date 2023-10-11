using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities.Inventory;
using Core.Entities.Location;
using Core.Entities.Management;
using Core.Entities.Person;
using Core.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class PharmaInventContext : DbContext
{
    public PharmaInventContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<RolePerson> RolePeople { get; set; }
    public DbSet<TypePerson> TypePeople { get; set; }
    public DbSet<TypeContact> TypeContacts { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<CPerson> People { get; set; }
    public DbSet<PersonContact> PersonContacts { get; set; }
    public DbSet<CProduct> Products { get; set; }
    public DbSet<PresentationType> PresentationTypes { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<CInventory> Inventories { get; set; }
    public DbSet<InventoryManagement> InventoryManagements { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<MovementDetail> MovementDetails { get; set; }
    public DbSet<MovementType> MovementTypes { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Cliente>()
       .HasOne(a => a.ClienteDireccion)
       .WithOne(b => b.Clientes)
       .HasForeignKey<ClienteDireccion>(b => b.IdCliente);*/

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
