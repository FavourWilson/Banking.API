using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banking.API.Migrations
{
    public partial class newAccountBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountDetailsId",
                table: "accountBalance",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_accountBalance_AccountDetailsId",
                table: "accountBalance",
                column: "AccountDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_accountBalance_accountDetails_AccountDetailsId",
                table: "accountBalance",
                column: "AccountDetailsId",
                principalTable: "accountDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accountBalance_accountDetails_AccountDetailsId",
                table: "accountBalance");

            migrationBuilder.DropIndex(
                name: "IX_accountBalance_AccountDetailsId",
                table: "accountBalance");

            migrationBuilder.DropColumn(
                name: "AccountDetailsId",
                table: "accountBalance");
        }
    }
}
