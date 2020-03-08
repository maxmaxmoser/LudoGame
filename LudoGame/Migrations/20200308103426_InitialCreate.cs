using Microsoft.EntityFrameworkCore.Migrations;

namespace LudoGame.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jeu",
                columns: table => new
                {
                    IdJeu = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Editeur = table.Column<string>(nullable: true),
                    NbJoueursMin = table.Column<int>(nullable: false),
                    NbJoueursMax = table.Column<int>(nullable: false),
                    AgeMin = table.Column<int>(nullable: false),
                    Prix = table.Column<double>(nullable: false),
                    DureeMoyenne = table.Column<int>(nullable: false),
                    CheminImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jeu", x => x.IdJeu);
                });

            migrationBuilder.CreateTable(
                name: "Extension",
                columns: table => new
                {
                    IdExtension = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Editeur = table.Column<string>(nullable: true),
                    NbJoueursMin = table.Column<int>(nullable: false),
                    NbJoueursMax = table.Column<int>(nullable: false),
                    AgeMin = table.Column<int>(nullable: false),
                    Prix = table.Column<double>(nullable: false),
                    DureeMoyenne = table.Column<int>(nullable: false),
                    CheminImage = table.Column<string>(nullable: true),
                    IdJeu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extension", x => x.IdExtension);
                    table.ForeignKey(
                        name: "FK_Extension_Jeu_IdJeu",
                        column: x => x.IdJeu,
                        principalTable: "Jeu",
                        principalColumn: "IdJeu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Extension_IdJeu",
                table: "Extension",
                column: "IdJeu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Extension");

            migrationBuilder.DropTable(
                name: "Jeu");
        }
    }
}
