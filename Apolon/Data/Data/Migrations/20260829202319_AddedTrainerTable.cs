using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apolon.Migrations
{
    /// <inheritdoc />
    public partial class AddedTrainerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Unique identifier"),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "First name of the trainer"),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Last name of the trainer"),
                    Gender = table.Column<char>(type: "character(1)", nullable: false, comment: "Trainer sex"),
                    Email = table.Column<string>(type: "text", nullable: false, comment: "Email of the trainer"),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false, comment: "Phone number of the trainer"),
                    ImageUrl = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The Image Of The Trainer"),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "Description for the trainer")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
