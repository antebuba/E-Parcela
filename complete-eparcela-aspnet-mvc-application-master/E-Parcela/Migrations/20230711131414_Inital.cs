using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Parcela.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sadnice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FUllName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sadnice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suradnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suradnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FUllName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcele",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParcelaCategory = table.Column<int>(type: "int", nullable: false),
                    SuradniciID = table.Column<int>(type: "int", nullable: false),
                    ZaposleniciID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcele", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcele_Suradnici_SuradniciID",
                        column: x => x.SuradniciID,
                        principalTable: "Suradnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcele_Zaposlenici_ZaposleniciID",
                        column: x => x.ZaposleniciID,
                        principalTable: "Zaposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sadnice_Parcele",
                columns: table => new
                {
                    ParceleID = table.Column<int>(type: "int", nullable: false),
                    SadniceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sadnice_Parcele", x => new { x.SadniceID, x.ParceleID });
                    table.ForeignKey(
                        name: "FK_Sadnice_Parcele_Parcele_ParceleID",
                        column: x => x.ParceleID,
                        principalTable: "Parcele",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sadnice_Parcele_Sadnice_SadniceID",
                        column: x => x.SadniceID,
                        principalTable: "Sadnice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcele_SuradniciID",
                table: "Parcele",
                column: "SuradniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Parcele_ZaposleniciID",
                table: "Parcele",
                column: "ZaposleniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Sadnice_Parcele_ParceleID",
                table: "Sadnice_Parcele",
                column: "ParceleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sadnice_Parcele");

            migrationBuilder.DropTable(
                name: "Parcele");

            migrationBuilder.DropTable(
                name: "Sadnice");

            migrationBuilder.DropTable(
                name: "Suradnici");

            migrationBuilder.DropTable(
                name: "Zaposlenici");
        }
    }
}
