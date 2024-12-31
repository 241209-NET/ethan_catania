using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantSeating.Migrations
{
    /// <inheritdoc />
    public partial class addedNum_Seats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Num_seats",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Num_seats",
                table: "Tables");
        }
    }
}
