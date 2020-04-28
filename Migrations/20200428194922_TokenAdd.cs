using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiNew3.Migrations
{
    public partial class TokenAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Account_customerId",
                table: "Account");

            migrationBuilder.CreateIndex(
                name: "IX_Account_customerId",
                table: "Account",
                column: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Account_customerId",
                table: "Account");

            migrationBuilder.CreateIndex(
                name: "IX_Account_customerId",
                table: "Account",
                column: "customerId",
                unique: true);
        }
    }
}
