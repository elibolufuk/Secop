using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Secop.Core.Domain.Enums;

#nullable disable

namespace Secop.Customer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "customer");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:customer.customer_type", "individual,commercial")
                .Annotation("Npgsql:Enum:customer.entity_status_type", "active,passive,deleted");

            migrationBuilder.CreateTable(
                name: "member",
                schema: "customer",
                columns: table => new
                {
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    customer_type = table.Column<CustomerType>(type: "customer.customer_type", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    EntityStatus = table.Column<EntityStatusType>(type: "customer.entity_status_type", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "address",
                schema: "customer",
                columns: table => new
                {
                    address_line1 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    address_line2 = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    state = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    postal_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    EntityStatus = table.Column<EntityStatusType>(type: "customer.entity_status_type", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_address_member_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "customer",
                        principalTable: "member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contact",
                schema: "customer",
                columns: table => new
                {
                    phone_number = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    contact_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    EntityStatus = table.Column<EntityStatusType>(type: "customer.entity_status_type", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contact_member_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "customer",
                        principalTable: "member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "customer",
                table: "member",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "customer_type", "date_of_birth", "email", "EntityStatus", "first_name", "last_name", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("c12eaf70-8c4a-4b1d-8b63-3f4eacfd28ef"), new DateTime(2024, 8, 24, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("f7b72d1c-36a5-489c-9989-d8fa9b0d8ea4"), CustomerType.Individual, new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), "ahmet.yilmaz@example.com", EntityStatusType.Active, "Ahmet", "Yılmaz", null, null });

            migrationBuilder.InsertData(
                schema: "customer",
                table: "address",
                columns: new[] { "Id", "address_line1", "address_line2", "city", "country", "CreatedAt", "CreatedById", "EntityStatus", "MemberId", "postal_code", "state", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("9f93a20a-5e7e-41a6-a8e5-8c5efc73b3b4"), "123 Ana Cadde", "Daire 4B", "Bir Yer", "T�rkiye", new DateTime(2024, 8, 24, 10, 5, 0, 0, DateTimeKind.Utc), new Guid("f7b72d1c-36a5-489c-9989-d8fa9b0d8ea4"), EntityStatusType.Active, new Guid("c12eaf70-8c4a-4b1d-8b63-3f4eacfd28ef"), "90210", "CA", null, null });

            migrationBuilder.InsertData(
                schema: "customer",
                table: "contact",
                columns: new[] { "Id", "contact_type", "CreatedAt", "CreatedById", "EntityStatus", "MemberId", "phone_number", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("bc4f7557-f2ef-4d52-8b53-ef2d690b254e"), "Mobil", new DateTime(2024, 8, 24, 10, 10, 0, 0, DateTimeKind.Utc), new Guid("f7b72d1c-36a5-489c-9989-d8fa9b0d8ea4"), EntityStatusType.Active, new Guid("c12eaf70-8c4a-4b1d-8b63-3f4eacfd28ef"), "+90-555-1234", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_address_MemberId",
                schema: "customer",
                table: "address",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_contact_MemberId",
                schema: "customer",
                table: "contact",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address",
                schema: "customer");

            migrationBuilder.DropTable(
                name: "contact",
                schema: "customer");

            migrationBuilder.DropTable(
                name: "member",
                schema: "customer");
        }
    }
}
