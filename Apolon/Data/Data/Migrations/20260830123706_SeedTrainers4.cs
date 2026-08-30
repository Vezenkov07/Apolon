using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apolon.Migrations
{
    /// <inheritdoc />
    public partial class SeedTrainers4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "TrainerId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "ImageUrl",
                value: "/images/trainers/me.jpg");

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "TrainerId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "ImageUrl",
                value: "/images/trainers/ornela.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "TrainerId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "ImageUrl",
                value: "/Users/luboslavvezenkov/RiderProjects/Apolon/Apolon/Web/wwwroot/images/trainers/me.jpg");

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "TrainerId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "ImageUrl",
                value: "/Users/luboslavvezenkov/RiderProjects/Apolon/Apolon/Web/wwwroot/images/trainers/ornela.jpg");
        }
    }
}
