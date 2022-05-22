using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseAccess.Migrations
{
    public partial class RemoveOrderedBookClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedBooks_Clients_ClientId",
                table: "OrderedBooks");

            migrationBuilder.DropIndex(
                name: "IX_OrderedBooks_ClientId",
                table: "OrderedBooks");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "OrderedBooks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "OrderedBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderedBooks_ClientId",
                table: "OrderedBooks",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedBooks_Clients_ClientId",
                table: "OrderedBooks",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
