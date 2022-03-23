using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banking.API.Migrations
{
    public partial class newDatatoUserTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RegisterId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "registerUserId",
                table: "User",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_registerUserId",
                table: "User",
                column: "registerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_AspNetUsers_registerUserId",
                table: "User",
                column: "registerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_AspNetUsers_registerUserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_registerUserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "registerUserId",
                table: "User");
        }
    }
}
