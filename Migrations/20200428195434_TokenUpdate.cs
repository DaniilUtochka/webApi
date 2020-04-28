using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiNew3.Migrations
{
    public partial class TokenUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Token_Account_accountId1",
                table: "Token");

            migrationBuilder.DropIndex(
                name: "IX_Token_accountId1",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "accountId1",
                table: "Token");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "accountId1",
                table: "Token",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Token_accountId1",
                table: "Token",
                column: "accountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Token_Account_accountId1",
                table: "Token",
                column: "accountId1",
                principalTable: "Account",
                principalColumn: "accountId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
