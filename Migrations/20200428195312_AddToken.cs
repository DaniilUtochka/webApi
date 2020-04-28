using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiNew3.Migrations
{
    public partial class AddToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    tokenId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    token = table.Column<string>(nullable: false),
                    expiredIn = table.Column<int>(nullable: false),
                    accountId = table.Column<long>(nullable: false),
                    accountId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.tokenId);
                    table.ForeignKey(
                        name: "FK_Token_Account_accountId1",
                        column: x => x.accountId1,
                        principalTable: "Account",
                        principalColumn: "accountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Token_accountId1",
                table: "Token",
                column: "accountId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Token");
        }
    }
}
