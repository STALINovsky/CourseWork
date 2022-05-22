using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseAccess.Migrations
{
    public partial class RemoveOrderedBookPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderingPrice",
                table: "OrderedBooks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OrderingPrice",
                table: "OrderedBooks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
