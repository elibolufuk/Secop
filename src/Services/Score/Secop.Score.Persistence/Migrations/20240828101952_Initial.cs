using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Secop.Core.Domain.Enums;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Secop.Score.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "score");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:score.credit_risk_level_type", "very_high_risk,high_risk,medium_risk,good,excellent")
                .Annotation("Npgsql:Enum:score.entity_status_type", "active,passive,deleted");

            migrationBuilder.CreateTable(
                name: "credit_score",
                schema: "score",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    entity_status = table.Column<EntityStatusType>(type: "score.entity_status_type", nullable: false, defaultValue: EntityStatusType.Active),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false),
                    score_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    risk_level = table.Column<CreditRiskLevelType>(type: "score.credit_risk_level_type", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credit_score", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "risk_level_range",
                schema: "score",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    entity_status = table.Column<EntityStatusType>(type: "score.entity_status_type", nullable: false, defaultValue: EntityStatusType.Active),
                    risk_level = table.Column<CreditRiskLevelType>(type: "score.credit_risk_level_type", nullable: false),
                    min_score = table.Column<int>(type: "integer", nullable: false),
                    max_score = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_risk_level_range", x => x.id);
                    table.CheckConstraint("CHK_risk_level_range_min_score_max_score", "min_score <= max_score");
                });

            migrationBuilder.InsertData(
                schema: "score",
                table: "credit_score",
                columns: new[] { "id", "created_at", "created_by_id", "customer_id", "entity_status", "risk_level", "score", "score_date", "updated_at", "updated_by_id" },
                values: new object[,]
                {
                    { new Guid("0a09c2d2-897a-4a6f-bbf4-9825b9e0ff43"), new DateTime(2024, 8, 25, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("e0f2f77a-b7d4-4b8a-9f35-b0f60d1bdf6e"), new Guid("c12eaf70-8c4a-4b1d-8b63-3f4eacfd28ef"), EntityStatusType.Active, CreditRiskLevelType.VeryHighRisk, 620, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc), null, null },
                    { new Guid("8cfe3c9b-3d6b-4f68-8c1f-7eaf6e0df84a"), new DateTime(2024, 8, 25, 9, 0, 0, 0, DateTimeKind.Utc), new Guid("e0f2f77a-b7d4-4b8a-9f35-b0f60d1bdf6e"), new Guid("c12eaf70-8c4a-4b1d-8b63-3f4eacfd28ef"), EntityStatusType.Active, CreditRiskLevelType.HighRisk, 750, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc), null, null }
                });

            migrationBuilder.InsertData(
                schema: "score",
                table: "risk_level_range",
                columns: new[] { "id", "created_at", "created_by_id", "entity_status", "max_score", "min_score", "risk_level", "updated_at", "updated_by_id" },
                values: new object[,]
                {
                    { new Guid("1f9e3b9e-1e44-4d6d-8f98-6bfa5e8c12ed"), new DateTime(2024, 8, 25, 11, 0, 0, 0, DateTimeKind.Utc), new Guid("e0f2f77a-b7d4-4b8a-9f35-b0f60d1bdf6e"), EntityStatusType.Active, 599, 300, CreditRiskLevelType.VeryHighRisk, null, null },
                    { new Guid("3d9f8d5e-6476-4dbe-85db-6d7879fc317d"), new DateTime(2024, 8, 25, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("e0f2f77a-b7d4-4b8a-9f35-b0f60d1bdf6e"), EntityStatusType.Active, 799, 600, CreditRiskLevelType.HighRisk, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_credit_score_id",
                schema: "score",
                table: "credit_score",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_risk_level_range_id",
                schema: "score",
                table: "risk_level_range",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "credit_score",
                schema: "score");

            migrationBuilder.DropTable(
                name: "risk_level_range",
                schema: "score");
        }
    }
}
