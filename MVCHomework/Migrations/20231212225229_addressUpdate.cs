using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCHomework.Migrations
{
    public partial class addressUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Addresses",
                newName: "Adress1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress1",
                table: "Addresses",
                newName: "Adress");
        }
    }
}
