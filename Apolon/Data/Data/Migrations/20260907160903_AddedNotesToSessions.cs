using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apolon.Migrations
{
    /// <inheritdoc />
    public partial class AddedNotesToSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Sessions",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Sessions");
        }
    }
}
