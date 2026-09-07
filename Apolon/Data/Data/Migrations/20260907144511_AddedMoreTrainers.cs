using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Apolon.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreTrainers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "TrainerId", "Description", "Email", "FirstName", "Gender", "ImageUrl", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Expert in powerlifting and heavy compound movements with over 10 years of coaching experience.", "georgi.petrov@apolon.com", "Georgi", 'M', "/images/trainers/georgi.jpeg", "Petrov", "+359888111222" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Specialized in functional fitness, HIIT training, and core transformation.", "elena.stoyanova@apolon.com", "Elena", 'F', "/images/trainers/elena.jpeg", "Stoyanova", "+359888333444" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Bodybuilding coach focused on hyper-trophy optimization and strict diet structuring.", "nikola.dimitrov@apolon.com", "Nikola", 'M', "/images/trainers/nikola.jpeg", "Dimitrov", "+359888555666" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Yoga instructor and mobility expert helping athletes prevent injury and recover faster.", "maria.ivanova@apolon.com", "Maria", 'F', "/images/trainers/maria.jpeg", "Ivanova", "+359888777888" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "TrainerId",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "TrainerId",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "TrainerId",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "TrainerId",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));
        }
    }
}
