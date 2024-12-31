using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantSeating.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_tables = table.Column<int>(type: "int", nullable: false),
                    Server_FK = table.Column<int>(type: "int", nullable: false),
                    Access = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id_PK);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvalible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id_PK);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Table_numPK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section_FK = table.Column<int>(type: "int", nullable: false),
                    Access = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionId_PK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Table_numPK);
                    table.ForeignKey(
                        name: "FK_Tables_Sections_SectionId_PK",
                        column: x => x.SectionId_PK,
                        principalTable: "Sections",
                        principalColumn: "Id_PK");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tables_SectionId_PK",
                table: "Tables",
                column: "SectionId_PK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
