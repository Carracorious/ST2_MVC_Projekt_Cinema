using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST2_MVC_Projekt_Cinema.Migrations
{
    /// <inheritdoc />
    public partial class AddingColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Reservations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Reservations");
        }
    }
}
