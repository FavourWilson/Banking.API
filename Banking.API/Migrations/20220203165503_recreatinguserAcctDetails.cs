using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banking.API.Migrations
{
    public partial class recreatinguserAcctDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_accountDetails_AccountId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AccountId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "accountDetailsId",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "accountDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User",
                table: "accountDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "accountDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_accountDetails_AccountId",
                table: "accountDetails",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_accountDetails_UserId",
                table: "accountDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_accountDetails_Users_AccountId",
                table: "accountDetails",
                column: "AccountId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_accountDetails_Users_UserId",
                table: "accountDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accountDetails_Users_AccountId",
                table: "accountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_accountDetails_Users_UserId",
                table: "accountDetails");

            migrationBuilder.DropIndex(
                name: "IX_accountDetails_AccountId",
                table: "accountDetails");

            migrationBuilder.DropIndex(
                name: "IX_accountDetails_UserId",
                table: "accountDetails");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "accountDetails");

            migrationBuilder.DropColumn(
                name: "User",
                table: "accountDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "accountDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "accountDetailsId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountId",
                table: "Users",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_accountDetails_AccountId",
                table: "Users",
                column: "AccountId",
                principalTable: "accountDetails",
                principalColumn: "Id");
        }
    }
}
