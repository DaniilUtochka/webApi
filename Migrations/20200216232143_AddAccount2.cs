using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiNew3.Migrations
{
    public partial class AddAccount2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_customerId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_customerId",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Addresses_customerId",
                table: "Addresses",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customers_customerId",
                table: "Addresses",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "customerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
