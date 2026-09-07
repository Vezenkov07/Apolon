using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Apolon.Migrations
{
    /// <inheritdoc />
    public partial class SeedSupplements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "SupplementsCategories",
                type: "text",
                nullable: false,
                comment: "The category type (e.g., Protein, Creatine, Pre-Workout)",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "The category type (e.g., Protein, Creatine, Pre-Workout)");

            migrationBuilder.InsertData(
                table: "SupplementsBrands",
                columns: new[] { "BrandId", "BrandName", "Description", "Email", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Optimum Nutrition", "World leader in premium sports nutrition supplements.", "support@optimumnutrition.com", "+18007055226" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "MyProtein", "Leading European sports nutrition brand offering high-quality products.", "info@myprotein.com", "+359888123456" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Cellucor", "Industry leader in high-performance pre-workout and energy formulas.", "support@cellucor.com", "+18669279686" }
                });

            migrationBuilder.InsertData(
                table: "SupplementsCategories",
                columns: new[] { "CategoryId", "Category", "CategoryDescription" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Protein", "Protein supplements for muscle repair, growth, and daily dietary support." },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Creatine", "Creatine formulas to increase strength, power output, and muscle cell volume." },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "PreWorkout", "High-energy pre-workout formulas designed to maximize focus, endurance, and performance." }
                });

            migrationBuilder.InsertData(
                table: "Supplements",
                columns: new[] { "SupplementId", "BrandId", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("99999999-9999-9999-9999-999999999999"), new Guid("33333333-3333-3333-3333-333333333333"), new Guid("66666666-6666-6666-6666-666666666666"), "High-quality whey protein isolate and concentrate supplying 24g of protein per serving.", "Gold Standard 100% Whey 2.27kg", 149.99m },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("44444444-4444-4444-4444-444444444444"), new Guid("77777777-7777-7777-7777-777777777777"), "100% pure micronized creatine monohydrate proven to increase physical performance.", "Creatine Monohydrate Unflavored 500g", 45.00m },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("55555555-5555-5555-5555-555555555555"), new Guid("88888888-8888-8888-8888-888888888888"), "Explosive energy and endurance formula enriched with Beta-Alanine and Caffeine.", "C4 Original Pre-Workout 390g", 59.90m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "SupplementId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "SupplementId",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "SupplementId",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "SupplementsBrands",
                keyColumn: "BrandId",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "SupplementsBrands",
                keyColumn: "BrandId",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "SupplementsBrands",
                keyColumn: "BrandId",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "SupplementsCategories",
                keyColumn: "CategoryId",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "SupplementsCategories",
                keyColumn: "CategoryId",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "SupplementsCategories",
                keyColumn: "CategoryId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "SupplementsCategories",
                type: "integer",
                nullable: false,
                comment: "The category type (e.g., Protein, Creatine, Pre-Workout)",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "The category type (e.g., Protein, Creatine, Pre-Workout)");
        }
    }
}
