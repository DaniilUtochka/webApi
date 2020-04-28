using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiNew3.Migrations
{
    public partial class TokenUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "accountId",
                table: "Token",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Token_accountId",
                table: "Token",
                column: "accountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Token_Account_accountId",
                table: "Token",
                column: "accountId",
                principalTable: "Account",
                principalColumn: "accountId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Token_Account_accountId",
                table: "Token");

            migrationBuilder.DropIndex(
                name: "IX_Token_accountId",
                table: "Token");

            migrationBuilder.AlterColumn<long>(
                name: "accountId",
                table: "Token",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
