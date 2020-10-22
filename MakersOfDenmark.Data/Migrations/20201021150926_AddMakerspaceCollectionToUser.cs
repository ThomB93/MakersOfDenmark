using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MakersOfDenmark.Data.Migrations
{
    public partial class AddMakerspaceCollectionToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "userFK",
                table: "Makerspaces");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Makerspaces",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Makerspaces_OwnerId",
                table: "Makerspaces",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Makerspaces_AspNetUsers_OwnerId",
                table: "Makerspaces",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makerspaces_AspNetUsers_OwnerId",
                table: "Makerspaces");

            migrationBuilder.DropIndex(
                name: "IX_Makerspaces_OwnerId",
                table: "Makerspaces");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Makerspaces");

            migrationBuilder.AddColumn<Guid>(
                name: "userFK",
                table: "Makerspaces",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
