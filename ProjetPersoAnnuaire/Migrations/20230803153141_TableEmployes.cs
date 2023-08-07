using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetPersoAnnuaire.Migrations
{
    /// <inheritdoc />
    public partial class TableEmployes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employes",
                columns: table => new
                {
                    EmployeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneFixe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephonePortable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteID = table.Column<int>(type: "int", nullable: false),
                    DepartementID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.EmployeID);
                    table.ForeignKey(
                        name: "FK_Employes_Departements_DepartementID",
                        column: x => x.DepartementID,
                        principalTable: "Departements",
                        principalColumn: "DepartementID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employes_Sites_SiteID",
                        column: x => x.SiteID,
                        principalTable: "Sites",
                        principalColumn: "SiteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employes_DepartementID",
                table: "Employes",
                column: "DepartementID");

            migrationBuilder.CreateIndex(
                name: "IX_Employes_SiteID",
                table: "Employes",
                column: "SiteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employes");
        }
    }
}
