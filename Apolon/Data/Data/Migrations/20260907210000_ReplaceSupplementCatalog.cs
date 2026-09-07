using Apolon.Data.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apolon.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20260907210000_ReplaceSupplementCatalog")]
public partial class ReplaceSupplementCatalog : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("""
            DELETE FROM "Supplements";

            INSERT INTO "Supplements"
                ("SupplementId", "Name", "Price", "BrandId", "CategoryId", "Description")
            VALUES
                ('90000000-0000-0000-0000-000000000001', 'Gold Standard Whey Vanilla 2.27kg', 149.99, '33333333-3333-3333-3333-333333333333', '66666666-6666-6666-6666-666666666666', 'Smooth vanilla whey blend with 24g of protein per serving for everyday recovery.'),
                ('90000000-0000-0000-0000-000000000002', 'Gold Standard Whey Chocolate 2.27kg', 149.99, '33333333-3333-3333-3333-333333333333', '66666666-6666-6666-6666-666666666666', 'Rich chocolate whey blend designed to support muscle growth and recovery.'),
                ('90000000-0000-0000-0000-000000000003', 'Impact Whey Protein Strawberry 1kg', 69.99, '44444444-4444-4444-4444-444444444444', '66666666-6666-6666-6666-666666666666', 'Light strawberry whey protein for convenient post-workout nutrition.'),
                ('90000000-0000-0000-0000-000000000004', 'Creatine Monohydrate Pure 500g', 45.00, '44444444-4444-4444-4444-444444444444', '77777777-7777-7777-7777-777777777777', 'Unflavored micronized creatine monohydrate to support strength and power.'),
                ('90000000-0000-0000-0000-000000000005', 'Creatine Capsules 120 Count', 39.99, '33333333-3333-3333-3333-333333333333', '77777777-7777-7777-7777-777777777777', 'Convenient creatine capsules for consistent daily supplementation.'),
                ('90000000-0000-0000-0000-000000000006', 'C4 Original Pre-Workout 390g', 59.90, '55555555-5555-5555-5555-555555555555', '88888888-8888-8888-8888-888888888888', 'Classic energy and endurance formula with caffeine and beta-alanine.'),
                ('90000000-0000-0000-0000-000000000007', 'Ultimate Energy Pre-Workout 300g', 54.99, '55555555-5555-5555-5555-555555555555', '88888888-8888-8888-8888-888888888888', 'Focused pre-workout energy formula for demanding training sessions.'),
                ('90000000-0000-0000-0000-000000000008', 'Clear Whey Isolate Lemon 500g', 64.99, '44444444-4444-4444-4444-444444444444', '66666666-6666-6666-6666-666666666666', 'Refreshing clear whey isolate that mixes like a light fruit drink.'),
                ('90000000-0000-0000-0000-000000000009', 'Gold Standard Whey Coffee 907g', 79.99, '33333333-3333-3333-3333-333333333333', '66666666-6666-6666-6666-666666666666', 'Coffee-flavored whey protein for recovery with a morning boost.'),
                ('90000000-0000-0000-0000-000000000010', 'C4 Ripped Sport Pre-Workout 270g', 62.99, '55555555-5555-5555-5555-555555555555', '88888888-8888-8888-8888-888888888888', 'Pre-workout blend for energy, focus, and intense training performance.');
            """);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("""
            DELETE FROM "Supplements";

            INSERT INTO "Supplements"
                ("SupplementId", "Name", "Price", "BrandId", "CategoryId", "Description")
            VALUES
                ('99999999-9999-9999-9999-999999999999', 'Gold Standard 100% Whey 2.27kg', 149.99, '33333333-3333-3333-3333-333333333333', '66666666-6666-6666-6666-666666666666', 'High-quality whey protein isolate and concentrate supplying 24g of protein per serving.'),
                ('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'Creatine Monohydrate Unflavored 500g', 45.00, '44444444-4444-4444-4444-444444444444', '77777777-7777-7777-7777-777777777777', '100% pure micronized creatine monohydrate proven to increase physical performance.'),
                ('bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'C4 Original Pre-Workout 390g', 59.90, '55555555-5555-5555-5555-555555555555', '88888888-8888-8888-8888-888888888888', 'Explosive energy and endurance formula enriched with Beta-Alanine and Caffeine.');
            """);
    }
}
