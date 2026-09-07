using Microsoft.EntityFrameworkCore.Migrations;
using Apolon.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace Apolon.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20260907200000_AddStorePurchasesAndWorkouts")]
public partial class AddStorePurchasesAndWorkouts : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "SupplementPurchases",
            columns: table => new
            {
                PurchaseId = table.Column<Guid>(type: "uuid", nullable: false),
                UserId = table.Column<Guid>(type: "uuid", nullable: false),
                SupplementId = table.Column<Guid>(type: "uuid", nullable: false),
                Quantity = table.Column<int>(type: "integer", nullable: false),
                UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                PurchasedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SupplementPurchases", x => x.PurchaseId);
                table.ForeignKey(
                    name: "FK_SupplementPurchases_Supplements_SupplementId",
                    column: x => x.SupplementId,
                    principalTable: "Supplements",
                    principalColumn: "SupplementId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_SupplementPurchases_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "UserId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_SupplementPurchases_SupplementId",
            table: "SupplementPurchases",
            column: "SupplementId");

        migrationBuilder.CreateIndex(
            name: "IX_SupplementPurchases_UserId",
            table: "SupplementPurchases",
            column: "UserId");

        migrationBuilder.Sql("""
            INSERT INTO "Splits" ("SplitId", "SplitName", "TargetedMuscles")
            VALUES
                ('10000000-0000-0000-0000-000000000001', 'Strength and Power', ARRAY[6, 2, 8]),
                ('10000000-0000-0000-0000-000000000002', 'Full Body Conditioning', ARRAY[8, 7, 2]);

            INSERT INTO "Workouts" ("WorkoutId", "EndTime", "SplitId", "StartTime", "TrainerId")
            VALUES
                ('20000000-0000-0000-0000-000000000001', '2026-09-10T19:00:00Z', '10000000-0000-0000-0000-000000000001', '2026-09-10T18:00:00Z', '33333333-3333-3333-3333-333333333333'),
                ('20000000-0000-0000-0000-000000000002', '2026-09-12T11:00:00Z', '10000000-0000-0000-0000-000000000002', '2026-09-12T10:00:00Z', '44444444-4444-4444-4444-444444444444');
            """);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("""
            DELETE FROM "Workouts"
            WHERE "WorkoutId" IN (
                '20000000-0000-0000-0000-000000000001',
                '20000000-0000-0000-0000-000000000002');

            DELETE FROM "Splits"
            WHERE "SplitId" IN (
                '10000000-0000-0000-0000-000000000001',
                '10000000-0000-0000-0000-000000000002');
            """);

        migrationBuilder.DropTable(name: "SupplementPurchases");
    }
}
