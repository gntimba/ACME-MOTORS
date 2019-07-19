using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACME_MOTORS.Migrations
{
    public partial class _321nditera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "engines");

            migrationBuilder.DropTable(
                name: "manufacturers");

            migrationBuilder.DropTable(
                name: "motorbikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trucks",
                table: "trucks");

            migrationBuilder.RenameTable(
                name: "trucks",
                newName: "BaseTable");

            migrationBuilder.AlterColumn<int>(
                name: "QuantityInStock",
                table: "BaseTable",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MaximumLoad",
                table: "BaseTable",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "BaseTable",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AmendedOn",
                table: "BaseTable",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseTable",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasRustDamage",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EngineModel_ManufacturerId",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineModel_Model",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineModel_Year",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotorbikeModel_Color",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotorbikeModel_EngineId",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasWindVisor",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotorbikeModel_ManufacturerId",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotorbikeModel_Model",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotorbikeModel_QuantityInStock",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotorbikeModel_Year",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TruckModel_Color",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TruckModel_EngineId",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TruckModel_ManufacturerId",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TruckModel_Model",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TruckModel_QuantityInStock",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TruckModel_Year",
                table: "BaseTable",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseTable",
                table: "BaseTable",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseTable",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "HasRustDamage",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "EngineModel_ManufacturerId",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "EngineModel_Model",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "EngineModel_Year",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "MotorbikeModel_Color",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "MotorbikeModel_EngineId",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "HasWindVisor",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "MotorbikeModel_ManufacturerId",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "MotorbikeModel_Model",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "MotorbikeModel_QuantityInStock",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "MotorbikeModel_Year",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "TruckModel_Color",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "TruckModel_EngineId",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "TruckModel_ManufacturerId",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "TruckModel_Model",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "TruckModel_QuantityInStock",
                table: "BaseTable");

            migrationBuilder.DropColumn(
                name: "TruckModel_Year",
                table: "BaseTable");

            migrationBuilder.RenameTable(
                name: "BaseTable",
                newName: "trucks");

            migrationBuilder.AlterColumn<int>(
                name: "MaximumLoad",
                table: "trucks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuantityInStock",
                table: "trucks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "trucks",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AmendedOn",
                table: "trucks",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_trucks",
                table: "trucks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AmendedOn = table.Column<DateTime>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EngineId = table.Column<string>(nullable: true),
                    HasRustDamage = table.Column<bool>(nullable: false),
                    ManufacturerId = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    QuantityInStock = table.Column<int>(nullable: false),
                    Year = table.Column<string>(nullable: true)
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
                    AmendedOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    FuelType = table.Column<string>(nullable: true),
                    ManufacturerId = table.Column<Guid>(nullable: false),
                    Mileage = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Year = table.Column<string>(nullable: true)
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
                    AmendedOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
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
                    AmendedOn = table.Column<DateTime>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EngineId = table.Column<string>(nullable: true),
                    HasWindVisor = table.Column<bool>(nullable: false),
                    ManufacturerId = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    QuantityInStock = table.Column<int>(nullable: false),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_motorbikes", x => x.Id);
                });
        }
    }
}
