using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "documenttype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documenttype", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InitialInvoice = table.Column<int>(type: "int", nullable: false),
                    FinalInvoice = table.Column<int>(type: "int", nullable: false),
                    CurrentInvoice = table.Column<int>(type: "int", nullable: false),
                    ResolutionNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movementtype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movementtype", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "paymentmethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentmethod", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "presentationtype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_presentationtype", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "productbrand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productbrand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "roleperson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roleperson", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "typecontact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typecontact", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "typeperson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeperson", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCountryFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_department_country_IdCountryFk",
                        column: x => x.IdCountryFk,
                        principalTable: "country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdProdBrandFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_productbrand_IdProdBrandFk",
                        column: x => x.IdProdBrandFk,
                        principalTable: "productbrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistreDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdDocuTypeFk = table.Column<int>(type: "int", nullable: false),
                    IdRolePersonFk = table.Column<int>(type: "int", nullable: false),
                    IdTypePersonFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_person_documenttype_IdDocuTypeFk",
                        column: x => x.IdDocuTypeFk,
                        principalTable: "documenttype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_roleperson_IdRolePersonFk",
                        column: x => x.IdRolePersonFk,
                        principalTable: "roleperson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_typeperson_IdTypePersonFk",
                        column: x => x.IdTypePersonFk,
                        principalTable: "typeperson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    IdDepartFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.Id);
                    table.ForeignKey(
                        name: "FK_city_department_IdDepartFk",
                        column: x => x.IdDepartFk,
                        principalTable: "department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    MinStock = table.Column<int>(type: "int", nullable: false),
                    MaxStock = table.Column<int>(type: "int", nullable: false),
                    IdProductFk = table.Column<int>(type: "int", nullable: false),
                    IdPresTypeFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_presentationtype_IdPresTypeFk",
                        column: x => x.IdPresTypeFk,
                        principalTable: "presentationtype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventory_product_IdProductFk",
                        column: x => x.IdProductFk,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inventorymanagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MovementDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdPersSellerFk = table.Column<int>(type: "int", nullable: false),
                    IdPersReciFk = table.Column<int>(type: "int", nullable: false),
                    IdMoveTypeFk = table.Column<int>(type: "int", nullable: false),
                    IdPayMethodFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventorymanagement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventorymanagement_movementtype_IdMoveTypeFk",
                        column: x => x.IdMoveTypeFk,
                        principalTable: "movementtype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventorymanagement_paymentmethod_IdPayMethodFk",
                        column: x => x.IdPayMethodFk,
                        principalTable: "paymentmethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventorymanagement_person_IdPersReciFk",
                        column: x => x.IdPersReciFk,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventorymanagement_person_IdPersSellerFk",
                        column: x => x.IdPersSellerFk,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personcontact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersonFk = table.Column<int>(type: "int", nullable: false),
                    IdTypeContactFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personcontact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personcontact_person_IdPersonFk",
                        column: x => x.IdPersonFk,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_personcontact_typecontact_IdTypeContactFk",
                        column: x => x.IdTypeContactFk,
                        principalTable: "typecontact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoadType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstNumber = table.Column<short>(type: "smallint", nullable: false),
                    FirstLetter = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bis = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondLetter = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cardinal = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondNumber = table.Column<short>(type: "smallint", nullable: false),
                    ThirdLetter = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ThirdNumber = table.Column<short>(type: "smallint", nullable: false),
                    SecondCardinal = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complement = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPersonFk = table.Column<int>(type: "int", nullable: false),
                    IdCityFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_address_city_IdCityFk",
                        column: x => x.IdCityFk,
                        principalTable: "city",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_address_person_IdPersonFk",
                        column: x => x.IdPersonFk,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movementdetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuantityUnits = table.Column<short>(type: "smallint", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    IdInventManagFk = table.Column<int>(type: "int", nullable: false),
                    IdInventoryFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movementdetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movementdetail_inventory_IdInventoryFk",
                        column: x => x.IdInventoryFk,
                        principalTable: "inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movementdetail_inventorymanagement_IdInventManagFk",
                        column: x => x.IdInventManagFk,
                        principalTable: "inventorymanagement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_address_IdCityFk",
                table: "address",
                column: "IdCityFk");

            migrationBuilder.CreateIndex(
                name: "IX_address_IdPersonFk",
                table: "address",
                column: "IdPersonFk");

            migrationBuilder.CreateIndex(
                name: "IX_city_IdDepartFk",
                table: "city",
                column: "IdDepartFk");

            migrationBuilder.CreateIndex(
                name: "IX_department_IdCountryFk",
                table: "department",
                column: "IdCountryFk");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_IdPresTypeFk",
                table: "inventory",
                column: "IdPresTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_IdProductFk",
                table: "inventory",
                column: "IdProductFk");

            migrationBuilder.CreateIndex(
                name: "IX_inventorymanagement_IdMoveTypeFk",
                table: "inventorymanagement",
                column: "IdMoveTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_inventorymanagement_IdPayMethodFk",
                table: "inventorymanagement",
                column: "IdPayMethodFk");

            migrationBuilder.CreateIndex(
                name: "IX_inventorymanagement_IdPersReciFk",
                table: "inventorymanagement",
                column: "IdPersReciFk");

            migrationBuilder.CreateIndex(
                name: "IX_inventorymanagement_IdPersSellerFk",
                table: "inventorymanagement",
                column: "IdPersSellerFk");

            migrationBuilder.CreateIndex(
                name: "IX_movementdetail_IdInventManagFk",
                table: "movementdetail",
                column: "IdInventManagFk");

            migrationBuilder.CreateIndex(
                name: "IX_movementdetail_IdInventoryFk",
                table: "movementdetail",
                column: "IdInventoryFk");

            migrationBuilder.CreateIndex(
                name: "IX_person_Code",
                table: "person",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_person_IdDocuTypeFk",
                table: "person",
                column: "IdDocuTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_person_IdRolePersonFk",
                table: "person",
                column: "IdRolePersonFk");

            migrationBuilder.CreateIndex(
                name: "IX_person_IdTypePersonFk",
                table: "person",
                column: "IdTypePersonFk");

            migrationBuilder.CreateIndex(
                name: "IX_personcontact_IdPersonFk",
                table: "personcontact",
                column: "IdPersonFk");

            migrationBuilder.CreateIndex(
                name: "IX_personcontact_IdTypeContactFk",
                table: "personcontact",
                column: "IdTypeContactFk");

            migrationBuilder.CreateIndex(
                name: "IX_product_Code",
                table: "product",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_IdProdBrandFk",
                table: "product",
                column: "IdProdBrandFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "movementdetail");

            migrationBuilder.DropTable(
                name: "personcontact");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "inventorymanagement");

            migrationBuilder.DropTable(
                name: "typecontact");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "presentationtype");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "movementtype");

            migrationBuilder.DropTable(
                name: "paymentmethod");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "productbrand");

            migrationBuilder.DropTable(
                name: "documenttype");

            migrationBuilder.DropTable(
                name: "roleperson");

            migrationBuilder.DropTable(
                name: "typeperson");
        }
    }
}
