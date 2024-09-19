using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Secop.Core.Domain.Enums;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Secop.Approval.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "approval");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:approval.application_status_type", "application_received,approved,rejected")
                .Annotation("Npgsql:Enum:approval.credit_risk_level_type", "none,very_high_risk,high_risk,medium_risk,good,excellent")
                .Annotation("Npgsql:Enum:approval.entity_status_type", "active,passive,deleted");

            migrationBuilder.CreateTable(
                name: "loan_approval",
                schema: "approval",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    entity_status = table.Column<EntityStatusType>(type: "approval.entity_status_type", nullable: false, defaultValue: EntityStatusType.Active),
                    credit_application_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    term_months = table.Column<int>(type: "integer", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false),
                    risk_level = table.Column<CreditRiskLevelType>(type: "approval.credit_risk_level_type", nullable: false),
                    application_status = table.Column<ApplicationStatusType>(type: "approval.application_status_type", nullable: false),
                    comment = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loan_approval", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "approval",
                table: "loan_approval",
                columns: new[] { "id", "amount", "application_status", "comment", "created_at", "created_by_id", "credit_application_id", "entity_status", "risk_level", "score", "term_months", "updated_at", "updated_by_id" },
                values: new object[,]
                {
                    { new Guid("8fa83e6f-9b17-42e9-9a69-5f9b7b3e7d31"), 35000.00m, ApplicationStatusType.Rejected, "Orta düzeyde risk nedeniyle inceleme bekleniyor", new DateTime(2024, 8, 25, 10, 15, 0, 0, DateTimeKind.Utc), new Guid("c93b2f1a-a9a6-4d3a-a356-579c03e3b7a9"), new Guid("12b4556d-8c2d-42f1-a125-e1d13a3d7c4b"), EntityStatusType.Passive, CreditRiskLevelType.MediumRisk, 1200, 12, new DateTime(2024, 8, 26, 9, 20, 0, 0, DateTimeKind.Utc), new Guid("d52e0297-d9cc-46c2-b3d2-cf5b5b9b11bc") },
                    { new Guid("b3d6f3a0-3a29-45f8-b4d9-bbb5b4385b9e"), 20000.50m, ApplicationStatusType.Approved, "İyi kredi notuyla onaylandı", new DateTime(2024, 8, 25, 14, 32, 0, 0, DateTimeKind.Utc), new Guid("a3b72e9d-b27c-41a7-99d9-e2f9327c446d"), new Guid("b6e7d8c9-d2c7-4f0e-a3fc-76fa0d579123"), EntityStatusType.Active, CreditRiskLevelType.HighRisk, 1600, 24, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_loan_approval_id",
                schema: "approval",
                table: "loan_approval",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loan_approval",
                schema: "approval");
        }
    }
}
