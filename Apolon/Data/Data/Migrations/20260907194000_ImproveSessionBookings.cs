using Microsoft.EntityFrameworkCore.Migrations;
using Apolon.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace Apolon.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20260907194000_ImproveSessionBookings")]
public partial class ImproveSessionBookings : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("""
            ALTER TABLE "Sessions"
            ALTER COLUMN "BookingTime" TYPE time without time zone
            USING "BookingTime"::time;
            """);

        migrationBuilder.CreateIndex(
            name: "IX_Sessions_TrainerId_BookingDate_BookingTime",
            table: "Sessions",
            columns: new[] { "TrainerId", "BookingDate", "BookingTime" },
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_Sessions_TrainerId_BookingDate_BookingTime",
            table: "Sessions");

        migrationBuilder.Sql("""
            ALTER TABLE "Sessions"
            ALTER COLUMN "BookingTime" TYPE text
            USING "BookingTime"::text;
            """);
    }
}
