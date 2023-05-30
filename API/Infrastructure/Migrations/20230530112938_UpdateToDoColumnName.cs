using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToDoColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Done",
                table: "ToDos",
                newName: "IsComplete");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsComplete",
                table: "ToDos",
                newName: "Done");
        }
    }
}
