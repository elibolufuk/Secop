using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Secop.Repayment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "repayment");

            migrationBuilder.CreateTable(
                name: "payment_plan",
                schema: "repayment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    entity_status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    credit_application_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    installment_order = table.Column<byte>(type: "smallint", nullable: false),
                    last_payment_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    payment_status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_plan", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_payment_plan_id",
                schema: "repayment",
                table: "payment_plan",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment_plan",
                schema: "repayment");
        }
    }
}
