using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addColumnToTeacherTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RemainingCredit",
                table: "Teachers",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainingCredit",
                table: "Teachers");
        }
    }
}
