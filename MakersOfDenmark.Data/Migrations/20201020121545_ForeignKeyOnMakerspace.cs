using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MakersOfDenmark.Data.Migrations
{
    public partial class ForeignKeyOnMakerspace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userFK",
                table: "Makerspaces");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Makerspaces",
                type: "uniqueidentifier",
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
    }
}
