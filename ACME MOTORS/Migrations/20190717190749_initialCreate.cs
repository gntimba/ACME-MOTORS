using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACME_MOTORS.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    AmendedOn = table.Column<DateTime>(nullable: false),
                    EngineId = table.Column<string>(nullable: true),
                    ManufacturerId = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    QuantityInStock = table.Column<int>(nullable: false),
                    HasRustDamage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "engines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    AmendedOn = table.Column<DateTime>(nullable: false),
                    ManufacturerId = table.Column<Guid>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Mileage = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    FuelType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "manufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    AmendedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "motorbikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    AmendedOn = table.Column<DateTime>(nullable: false),
                    EngineId = table.Column<string>(nullable: true),
                    ManufacturerId = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    QuantityInStock = table.Column<int>(nullable: false),
                    HasWindVisor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_motorbikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trucks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    AmendedOn = table.Column<DateTime>(nullable: false),
                    EngineId = table.Column<string>(nullable: true),
                    ManufacturerId = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    QuantityInStock = table.Column<int>(nullable: false),
                    NumberOfWheels = table.Column<string>(nullable: true),
                    MaximumLoad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trucks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "engines");

            migrationBuilder.DropTable(
                name: "manufacturers");

            migrationBuilder.DropTable(
                name: "motorbikes");

            migrationBuilder.DropTable(
                name: "trucks");
        }
    }
}
