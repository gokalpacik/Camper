using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Camper.Web.CampFinder.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CampSites",
                columns: table => new
                {
                    CampSiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampSites", x => x.CampSiteId);
                    table.ForeignKey(
                        name: "FK_CampSites_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { new Guid("686697fd-b67e-42b5-bf75-52bbc27417a2"), "Private Camps" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { new Guid("2b0be458-4d86-4db1-93e0-136da5c63f20"), "Naitonal Park Camps" });

            migrationBuilder.InsertData(
                table: "CampSites",
                columns: new[] { "CampSiteId", "CategoryId", "CreateTime", "Description", "ImageUrl", "Location", "Name" },
                values: new object[] { new Guid("5e532fe7-cbb1-49e4-bfc2-5878d57f3423"), new Guid("686697fd-b67e-42b5-bf75-52bbc27417a2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstanbul'un Silivri ilçesinde bulunan bir kamp alanı", "https://blog.flypgs.com/wp-content/uploads/2018/05/istanbul-yakini-kamp-yapilacak-yerler.jpg", "İstanbul", "Semizkum Tabiat Parkı" });

            migrationBuilder.InsertData(
                table: "CampSites",
                columns: new[] { "CampSiteId", "CategoryId", "CreateTime", "Description", "ImageUrl", "Location", "Name" },
                values: new object[] { new Guid("b09d7e41-38f6-4980-bef1-38908e3383bd"), new Guid("2b0be458-4d86-4db1-93e0-136da5c63f20"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edirne'nin Keşan ilçesinde bulunan bir milli park ve tabiat parkı", "https://gokcetepetabiatparki.com/wp-content/uploads/2020/03/Zipline.jpg", "Edirne", "Gökçetepe Tabiat Parkı" });

            migrationBuilder.CreateIndex(
                name: "IX_CampSites_CategoryId",
                table: "CampSites",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampSites");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
