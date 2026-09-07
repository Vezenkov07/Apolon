using Apolon.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apolon.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20260907203000_AddPaymentTransactions")]
public partial class AddPaymentTransactions : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "PaymentTransactions",
            columns: table => new
            {
                PaymentId = table.Column<Guid>(type: "uuid", nullable: false),
                UserId = table.Column<Guid>(type: "uuid", nullable: false),
                Amount = table.Column<decimal>(type: "numeric", nullable: false),
                Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                PaymentMethod = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                LastFourDigits = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PaymentTransactions", x => x.PaymentId);
                table.ForeignKey(
                    name: "FK_PaymentTransactions_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "UserId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_PaymentTransactions_UserId",
            table: "PaymentTransactions",
            column: "UserId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "PaymentTransactions");
    }
}
