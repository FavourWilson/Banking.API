using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banking.API.Migrations
{
    public partial class recreatingusersAcctDetailsAccountBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accountDetails_accountBalance_AccountBalId",
                table: "accountDetails");

            migrationBuilder.DropColumn(
                name: "accountBalance",
                table: "accountDetails");

            migrationBuilder.RenameColumn(
                name: "AccountBalId",
                table: "accountDetails",
                newName: "AccountBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_accountDetails_AccountBalId",
                table: "accountDetails",
                newName: "IX_accountDetails_AccountBalanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_accountDetails_accountBalance_AccountBalanceId",
                table: "accountDetails",
                column: "AccountBalanceId",
                principalTable: "accountBalance",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accountDetails_accountBalance_AccountBalanceId",
                table: "accountDetails");

            migrationBuilder.RenameColumn(
                name: "AccountBalanceId",
                table: "accountDetails",
                newName: "AccountBalId");

            migrationBuilder.RenameIndex(
                name: "IX_accountDetails_AccountBalanceId",
                table: "accountDetails",
                newName: "IX_accountDetails_AccountBalId");

            migrationBuilder.AddColumn<Guid>(
                name: "accountBalance",
                table: "accountDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_accountDetails_accountBalance_AccountBalId",
                table: "accountDetails",
                column: "AccountBalId",
                principalTable: "accountBalance",
                principalColumn: "Id");
        }
    }
}
