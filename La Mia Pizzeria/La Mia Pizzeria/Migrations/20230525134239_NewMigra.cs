using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace La_Mia_Pizzeria.Migrations
{
    /// <inheritdoc />
    public partial class NewMigra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CathegoryId",
                table: "Pizze",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizze_CathegoryId",
                table: "Pizze",
                column: "CathegoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_Categorie_CathegoryId",
                table: "Pizze",
                column: "CathegoryId",
                principalTable: "Categorie",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_Categorie_CathegoryId",
                table: "Pizze");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Pizze_CathegoryId",
                table: "Pizze");

            migrationBuilder.DropColumn(
                name: "CathegoryId",
                table: "Pizze");
        }
    }
}
