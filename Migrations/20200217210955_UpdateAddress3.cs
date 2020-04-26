using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiNew3.Migrations
{
    public partial class UpdateAddress3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customers_customerId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_customerId",
                table: "Account");

            migrationBuilder.AlterColumn<long>(
                name: "customerId",
                table: "Account",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_customerId",
                table: "Account",
                column: "customerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customers_customerId",
                table: "Account",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "customerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customers_customerId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_customerId",
                table: "Account");

            migrationBuilder.AlterColumn<long>(
                name: "customerId",
                table: "Account",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_Account_customerId",
                table: "Account",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customers_customerId",
                table: "Account",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "customerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
