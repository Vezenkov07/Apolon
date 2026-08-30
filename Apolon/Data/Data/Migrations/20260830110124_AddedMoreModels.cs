using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apolon.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Splits",
                columns: table => new
                {
                    SplitId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Unique identifier for the workout split"),
                    SplitName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Name of the workout split (e.g., Push/Pull/Legs, Upper/Lower)"),
                    TargetedMuscles = table.Column<int[]>(type: "integer[]", nullable: false, comment: "List of targeted muscle groups included in this split")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Splits", x => x.SplitId);
                });

            migrationBuilder.CreateTable(
                name: "SupplementsBrands",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Unique identifier for the supplement brand"),
                    BrandName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Name of the supplement brand"),
                    Email = table.Column<string>(type: "text", nullable: false, comment: "Contact email of the brand"),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false, comment: "Contact phone number of the brand"),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true, comment: "Description of the brand and its products")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementsBrands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "SupplementsCategories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Unique identifier for the supplement category"),
                    Category = table.Column<int>(type: "integer", nullable: false, comment: "The category type (e.g., Protein, Creatine, Pre-Workout)"),
                    CategoryDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "Description detailing the category and its intended benefits")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementsCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Unique identifier for the user"),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "First name of the user"),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Last name of the user"),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Date of birth of the user"),
                    Weight = table.Column<double>(type: "double precision", nullable: false, comment: "Weight of the user in kilograms"),
                    Height = table.Column<double>(type: "double precision", nullable: false, comment: "Height of the user in centimeters")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    WorkoutId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Unique identifier for the workout session"),
                    SplitId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Foreign key referencing the workout split"),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Start date and time of the workout session"),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "End date and time of the workout session"),
                    TrainerId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Optional foreign key referencing an assigned trainer")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.WorkoutId);
                    table.ForeignKey(
                        name: "FK_Workouts_Splits_SplitId",
                        column: x => x.SplitId,
                        principalTable: "Splits",
                        principalColumn: "SplitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workouts_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId");
                });

            migrationBuilder.CreateTable(
                name: "Supplements",
                columns: table => new
                {
                    SupplementId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Unique identifier for the supplement"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Name of the supplement"),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false, comment: "Price of the supplement"),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Foreign key referencing the supplement brand"),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Foreign key referencing the supplement category"),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true, comment: "Description detailing the supplement's ingredients and usage")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplements", x => x.SupplementId);
                    table.ForeignKey(
                        name: "FK_Supplements_SupplementsBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "SupplementsBrands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplements_SupplementsCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SupplementsCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Unique identifier for the card"),
                    CardType = table.Column<int>(type: "integer", nullable: false, comment: "Type of membership/subscription card"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Foreign key referencing the associated user"),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false, comment: "Price of the card")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId",
                table: "Cards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplements_BrandId",
                table: "Supplements",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplements_CategoryId",
                table: "Supplements",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_SplitId",
                table: "Workouts",
                column: "SplitId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_TrainerId",
                table: "Workouts",
                column: "TrainerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Supplements");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SupplementsBrands");

            migrationBuilder.DropTable(
                name: "SupplementsCategories");

            migrationBuilder.DropTable(
                name: "Splits");
        }
    }
}
