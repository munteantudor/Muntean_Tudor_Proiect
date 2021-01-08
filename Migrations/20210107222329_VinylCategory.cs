using Microsoft.EntityFrameworkCore.Migrations;

namespace Muntean_Tudor_Proiect.Migrations
{
    public partial class VinylCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorID",
                table: "Vinyl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VinylCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VinylID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinylCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VinylCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VinylCategory_Vinyl_VinylID",
                        column: x => x.VinylID,
                        principalTable: "Vinyl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vinyl_ColorID",
                table: "Vinyl",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_VinylCategory_CategoryID",
                table: "VinylCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_VinylCategory_VinylID",
                table: "VinylCategory",
                column: "VinylID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vinyl_Color_ColorID",
                table: "Vinyl",
                column: "ColorID",
                principalTable: "Color",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vinyl_Color_ColorID",
                table: "Vinyl");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "VinylCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Vinyl_ColorID",
                table: "Vinyl");

            migrationBuilder.DropColumn(
                name: "ColorID",
                table: "Vinyl");
        }
    }
}
