using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiNew3.Migrations
{
    public partial class UpdateAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_customerId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_customerId",
                table: "Addresses");
        }
    }
}
