using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Data.Migrations
{
    public partial class RenamedCarId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Cars",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cars",
                newName: "CarId");
        }
    }
}
