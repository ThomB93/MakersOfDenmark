using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MakersOfDenmark.Data.Migrations
{
    public partial class makerspacerelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makerspaces_AspNetUsers_OwnerId",
                table: "Makerspaces");

            migrationBuilder.DropIndex(
                name: "IX_Makerspaces_OwnerId",
                table: "Makerspaces");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Makerspaces",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Makerspaces",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "X_Coords",
                table: "Makerspaces",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Y_Coords",
                table: "Makerspaces",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MakerspaceUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    MakerspaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakerspaceUsers", x => new { x.UserId, x.MakerspaceId });
                    table.ForeignKey(
                        name: "FK_MakerspaceUsers_Makerspaces_MakerspaceId",
                        column: x => x.MakerspaceId,
                        principalTable: "Makerspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MakerspaceUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Makerspaces_UserId",
                table: "Makerspaces",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MakerspaceUsers_MakerspaceId",
                table: "MakerspaceUsers",
                column: "MakerspaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Makerspaces_AspNetUsers_UserId",
                table: "Makerspaces",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makerspaces_AspNetUsers_UserId",
                table: "Makerspaces");

            migrationBuilder.DropTable(
                name: "MakerspaceUsers");

            migrationBuilder.DropIndex(
                name: "IX_Makerspaces_UserId",
                table: "Makerspaces");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Makerspaces");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Makerspaces");

            migrationBuilder.DropColumn(
                name: "X_Coords",
                table: "Makerspaces");

            migrationBuilder.DropColumn(
                name: "Y_Coords",
                table: "Makerspaces");

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
    }
}
