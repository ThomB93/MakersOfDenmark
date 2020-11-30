using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MakersOfDenmark.Data.Migrations
{
    public partial class badges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 280, nullable: true),
                    Image = table.Column<string>(nullable: false),
                    IssuerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Badges_Makerspaces_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "Makerspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MakerspaceBadges",
                columns: table => new
                {
                    BadgeId = table.Column<int>(nullable: false),
                    MakerspaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakerspaceBadges", x => new { x.BadgeId, x.MakerspaceId });
                    table.ForeignKey(
                        name: "FK_MakerspaceBadges_Badges_BadgeId",
                        column: x => x.BadgeId,
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MakerspaceBadges_Makerspaces_MakerspaceId",
                        column: x => x.MakerspaceId,
                        principalTable: "Makerspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Badges_IssuerId",
                table: "Badges",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_MakerspaceBadges_MakerspaceId",
                table: "MakerspaceBadges",
                column: "MakerspaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MakerspaceBadges");

            migrationBuilder.DropTable(
                name: "Badges");
        }
    }
}
