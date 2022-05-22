using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseAccess.Migrations
{
    public partial class Clients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedBooks_Consumers_ClientId",
                table: "OrderedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Consumers_ClientId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consumers",
                table: "Consumers");

            migrationBuilder.RenameTable(
                name: "Consumers",
                newName: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedBooks_Clients_ClientId",
                table: "OrderedBooks",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedBooks_Clients_ClientId",
                table: "OrderedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Consumers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consumers",
                table: "Consumers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedBooks_Consumers_ClientId",
                table: "OrderedBooks",
                column: "ClientId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Consumers_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
