using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banking.API.Migrations
{
    public partial class anotherMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accountDetails_MyProperty_AccountBalId",
                table: "accountDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "accountBalance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accountBalance",
                table: "accountBalance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_accountDetails_accountBalance_AccountBalId",
                table: "accountDetails",
                column: "AccountBalId",
                principalTable: "accountBalance",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accountDetails_accountBalance_AccountBalId",
                table: "accountDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accountBalance",
                table: "accountBalance");

            migrationBuilder.RenameTable(
                name: "accountBalance",
                newName: "MyProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_accountDetails_MyProperty_AccountBalId",
                table: "accountDetails",
                column: "AccountBalId",
                principalTable: "MyProperty",
                principalColumn: "Id");
        }
    }
}
