using Microsoft.EntityFrameworkCore.Migrations;

namespace LudoGame.Migrations
{
    public partial class DbLudoGameCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jeu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Jeu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtensionJeu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    JeuAssocieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtensionJeu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtensionJeu_Jeu_JeuAssocieId",
                        column: x => x.JeuAssocieId,
                        principalTable: "Jeu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtensionJeu_JeuAssocieId",
                table: "ExtensionJeu",
                column: "JeuAssocieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtensionJeu");

            migrationBuilder.DropTable(
                name: "Jeu");
        }
    }
}
