using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Apolon.Migrations
{
    /// <inheritdoc />
    public partial class SeedTrainers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "TrainerId", "Description", "Email", "FirstName", "Gender", "ImageUrl", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Most muscular man in history!", "vezenkov07@gmail.com", "Luboslav", 'M', "/Users/luboslavvezenkov/RiderProjects/Apolon/Apolon/Web/wwwroot/images/trainers/me.jpg", "Vezenkov", "+359888747824" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "The best dog in the world. Can teach you how to hunt cats.", "ornelamuti@gmail.com", "Ornela", 'F', "/Users/luboslavvezenkov/RiderProjects/Apolon/Apolon/Web/wwwroot/images/trainers/ornela.jpg", "Muti", "+3596969696969" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "TrainerId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "TrainerId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));
        }
    }
}
