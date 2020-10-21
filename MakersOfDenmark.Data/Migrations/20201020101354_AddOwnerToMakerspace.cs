using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MakersOfDenmark.Data.Migrations
{
    public partial class AddOwnerToMakerspace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Makerspaces",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
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
        }
    }
}
