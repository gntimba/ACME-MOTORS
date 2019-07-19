using Microsoft.EntityFrameworkCore.Migrations;

namespace ACME_MOTORS.Migrations
{
    public partial class _5th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumberOfWheels",
                table: "trucks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumberOfWheels",
                table: "trucks",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
