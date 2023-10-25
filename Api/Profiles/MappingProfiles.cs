using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Inventory;
using Api.Dtos.Get.Location;
using Api.Dtos.Get.Management;
using Api.Dtos.Get.Person;
using Api.Dtos.Get.Product;
using Api.Dtos.Post.Inventory;
using Api.Dtos.Post.Location;
using Api.Dtos.Post.Management;
using Api.Dtos.Post.Person;
using Api.Dtos.Post.Product;
using AutoMapper;
using Core.Entities.Inventory;
using Core.Entities.Location;
using Core.Entities.Management;
using Core.Entities.Person;
using Core.Entities.Product;

namespace Api.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CInventory, InventoryDto>()
        .ReverseMap();
        CreateMap<CInventory, InventoryPDto>()
        .ReverseMap();

        CreateMap<InventoryManagement, InventManagDto>()
        .ReverseMap();
        CreateMap<InventoryManagement, InventManagPDto>()
        .ReverseMap();

        CreateMap<City, CityDto>()
        .ReverseMap();
        CreateMap<City, CityPDto>()
        .ReverseMap();

        CreateMap<Country, CountryDto>()
        .ReverseMap();

        CreateMap<Department, DepartmentDto>()
        .ReverseMap();
        CreateMap<Department, DepartmentPDto>()
        .ReverseMap();

        CreateMap<Invoice, InvoiceDto>()
        .ReverseMap();

        CreateMap<MovementDetail, MoveDetailDto>()
        .ReverseMap();
        CreateMap<MovementDetail, MoveDetailPDto>()
        .ReverseMap();

        CreateMap<MovementType, MoveTypeDto>()
        .ReverseMap();

        CreateMap<PaymentMethod, PayMethodDto>()
        .ReverseMap();

        CreateMap<Address, AddressDto>()
        .ReverseMap();
        CreateMap<Address, AddressPDto>()
        .ReverseMap();

        CreateMap<DocumentType, DocuTypeDto>()
        .ReverseMap();

        CreateMap<CPerson, PersonDto>()
        .ReverseMap();
        CreateMap<CPerson, PersonPDto>()
        .ReverseMap();

        CreateMap<PersonContact, PersonContDto>()
        .ReverseMap();
        CreateMap<PersonContact, PersonContPDto>()
        .ReverseMap();

        CreateMap<RolePerson, RolePersonDto>()
        .ReverseMap();

        CreateMap<TypeContact, TypeContDto>()
        .ReverseMap();

        CreateMap<TypePerson, TypePersonDto>()
        .ReverseMap();

        CreateMap<PresentationType, PresenTypeDto>()
        .ReverseMap();

        CreateMap<ProductBrand, ProdBrandDto>()
        .ReverseMap();

        CreateMap<CProduct, ProductDto>()
        .ReverseMap();
        CreateMap<CProduct, ProductPDto>()
        .ReverseMap();
    }
}