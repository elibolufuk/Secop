using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Secop.Core.Domain.Enums;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Secop.Credit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "credit");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:credit.credit_type", "personal,mortgage,auto,deposit")
                .Annotation("Npgsql:Enum:credit.entity_status_type", "active,passive,deleted");

            migrationBuilder.CreateTable(
                name: "condition",
                schema: "credit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    entity_status = table.Column<EntityStatusType>(type: "credit.entity_status_type", nullable: false, defaultValue: EntityStatusType.Active),
                    credit_type = table.Column<CreditType>(type: "credit.credit_type", maxLength: 50, nullable: false),
                    interest_rate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    min_amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    max_amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    min_month = table.Column<byte>(type: "smallint", maxLength: 120, nullable: false),
                    max_month = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_condition", x => x.id);
                    table.CheckConstraint("CHK_condition_max_month", "max_month >= 1 AND max_month <= 120");
                    table.CheckConstraint("CHK_condition_min_month", "min_month >= 1 AND min_month <= 120");
                });

            migrationBuilder.CreateTable(
                name: "credit_application",
                schema: "credit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    entity_status = table.Column<EntityStatusType>(type: "credit.entity_status_type", nullable: false, defaultValue: EntityStatusType.Active),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    term_months = table.Column<int>(type: "integer", nullable: false),
                    credit_type = table.Column<CreditType>(type: "credit.credit_type", nullable: false),
                    application_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credit_application", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "credit",
                table: "condition",
                columns: new[] { "id", "created_at", "created_by_id", "credit_type", "entity_status", "interest_rate", "max_amount", "max_month", "min_amount", "min_month", "updated_at", "updated_by_id" },
                values: new object[,]
                {
                    { new Guid("12b4556d-4c0e-42f1-a125-e1d13a2d6c2a"), new DateTime(2024, 8, 25, 10, 15, 0, 0, DateTimeKind.Utc), new Guid("d9aebd1a-36a5-4d3a-998b-d8fa9b0d1234"), CreditType.Mortgage, EntityStatusType.Active, 5.0m, 75000.00m, (byte)72, 10000.00m, (byte)12, null, null },
                    { new Guid("7e1d5c8d-c6f8-4a4d-bc6b-d2a5ec841b76"), new DateTime(2024, 8, 24, 18, 45, 0, 0, DateTimeKind.Utc), new Guid("f7b72d1c-36a5-489c-9989-d8fa9b0d8ea4"), CreditType.Personal, EntityStatusType.Active, 4.5m, 50000.00m, (byte)60, 5000.00m, (byte)6, null, null }
                });

            migrationBuilder.InsertData(
                schema: "credit",
                table: "credit_application",
                columns: new[] { "id", "amount", "application_date", "created_at", "created_by_id", "credit_type", "customer_id", "entity_status", "term_months", "updated_at", "updated_by_id" },
                values: new object[,]
                {
                    { new Guid("12b4556d-8c2d-42f1-a125-e1d13a3d7c4b"), 35000.00m, new DateTime(2024, 8, 25, 8, 45, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 25, 9, 0, 0, 0, DateTimeKind.Utc), new Guid("b2b3d1b2-56c1-439c-b88d-d9f9b2c4c123"), CreditType.Mortgage, new Guid("c12eaf70-8c4a-4b1d-8b63-3f4eacfd28ef"), EntityStatusType.Active, 36, null, null },
                    { new Guid("b6e7d8c9-d2c7-4f0e-a3fc-76fa0d579123"), 20000.00m, new DateTime(2024, 8, 24, 18, 30, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 24, 19, 0, 0, 0, DateTimeKind.Utc), new Guid("a1b72d1a-4c5a-439c-b88d-d8fa9b0d9ea4"), CreditType.Personal, new Guid("c12eaf70-8c4a-4b1d-8b63-3f4eacfd28ef"), EntityStatusType.Active, 24, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_condition_id",
                schema: "credit",
                table: "condition",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_credit_application_id",
                schema: "credit",
                table: "credit_application",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "condition",
                schema: "credit");

            migrationBuilder.DropTable(
                name: "credit_application",
                schema: "credit");
        }
    }
}
