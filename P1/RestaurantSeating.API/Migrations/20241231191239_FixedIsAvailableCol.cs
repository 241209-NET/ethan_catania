using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantSeating.Migrations
{
    /// <inheritdoc />
    public partial class FixedIsAvailableCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAvalible",
                table: "Servers",
                newName: "IsAvailable");

            migrationBuilder.AddColumn<int>(
                name: "Server_FK",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Server_FK",
                table: "Tables");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "Servers",
                newName: "IsAvalible");
        }
    }
}
