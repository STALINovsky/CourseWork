using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseAccess.Migrations
{
    public partial class PhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumner",
                table: "Clients",
                newName: "PhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Clients",
                newName: "PhoneNumner");
        }
    }
}
