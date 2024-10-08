﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Secop.Core.Domain.Enums;
using Secop.Score.Persistence.DbContexts;

#nullable disable

namespace Secop.Score.Persistence.Migrations
{
    [DbContext(typeof(ScoreDbContext))]
    partial class ScoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("score")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "score", "credit_risk_level_type", new[] { "none", "very_high_risk", "high_risk", "medium_risk", "good", "excellent" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "score", "entity_status_type", new[] { "active", "passive", "deleted" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Secop.Core.Domain.Entities.ScoreEntities.CreditScore", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasColumnOrder(3)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by_id")
                        .HasColumnOrder(2);

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id")
                        .HasColumnOrder(7);

                    b.Property<EntityStatusType>("EntityStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("score.entity_status_type")
                        .HasDefaultValue(EntityStatusType.Active)
                        .HasColumnName("entity_status")
                        .HasColumnOrder(6);

                    b.Property<CreditRiskLevelType>("RiskLevel")
                        .HasColumnType("score.credit_risk_level_type")
                        .HasColumnName("risk_level")
                        .HasColumnOrder(10);

                    b.Property<int>("Score")
                        .HasColumnType("integer")
                        .HasColumnName("score")
                        .HasColumnOrder(8);

                    b.Property<DateTime>("ScoreDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("score_date")
                        .HasColumnOrder(9);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(5);

                    b.Property<Guid?>("UpdatedById")
                        .HasColumnType("uuid")
                        .HasColumnName("updated_by_id")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("credit_score", "score");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8cfe3c9b-3d6b-4f68-8c1f-7eaf6e0df84a"),
                            CreatedAt = new DateTime(2024, 8, 25, 9, 0, 0, 0, DateTimeKind.Utc),
                            CreatedById = new Guid("e0f2f77a-b7d4-4b8a-9f35-b0f60d1bdf6e"),
                            CustomerId = new Guid("c12eaf70-8c4a-4b1d-8b63-3f4eacfd28ef"),
                            EntityStatus = EntityStatusType.Active,
                            RiskLevel = CreditRiskLevelType.HighRisk,
                            Score = 750,
                            ScoreDate = new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("0a09c2d2-897a-4a6f-bbf4-9825b9e0ff43"),
                            CreatedAt = new DateTime(2024, 8, 25, 10, 0, 0, 0, DateTimeKind.Utc),
                            CreatedById = new Guid("e0f2f77a-b7d4-4b8a-9f35-b0f60d1bdf6e"),
                            CustomerId = new Guid("c12eaf70-8c4a-4b1d-8b63-3f4eacfd28ef"),
                            EntityStatus = EntityStatusType.Active,
                            RiskLevel = CreditRiskLevelType.VeryHighRisk,
                            Score = 620,
                            ScoreDate = new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("Secop.Core.Domain.Entities.ScoreEntities.RiskLevelRange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasColumnOrder(3)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by_id")
                        .HasColumnOrder(2);

                    b.Property<EntityStatusType>("EntityStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("score.entity_status_type")
                        .HasDefaultValue(EntityStatusType.Active)
                        .HasColumnName("entity_status")
                        .HasColumnOrder(6);

                    b.Property<int>("MaxScore")
                        .HasColumnType("integer")
                        .HasColumnName("max_score")
                        .HasColumnOrder(9);

                    b.Property<int>("MinScore")
                        .HasColumnType("integer")
                        .HasColumnName("min_score")
                        .HasColumnOrder(8);

                    b.Property<CreditRiskLevelType>("RiskLevel")
                        .HasColumnType("score.credit_risk_level_type")
                        .HasColumnName("risk_level")
                        .HasColumnOrder(7);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(5);

                    b.Property<Guid?>("UpdatedById")
                        .HasColumnType("uuid")
                        .HasColumnName("updated_by_id")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("risk_level_range", "score", t =>
                        {
                            t.HasCheckConstraint("CHK_risk_level_range_min_score_max_score", "min_score <= max_score");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("1f9e3b9e-1e44-4d6d-8f98-6bfa5e8c12ed"),
                            CreatedAt = new DateTime(2024, 8, 25, 11, 0, 0, 0, DateTimeKind.Utc),
                            CreatedById = new Guid("e0f2f77a-b7d4-4b8a-9f35-b0f60d1bdf6e"),
                            EntityStatus = EntityStatusType.Active,
                            MaxScore = 1199,
                            MinScore = 1000,
                            RiskLevel = CreditRiskLevelType.VeryHighRisk
                        },
                        new
                        {
                            Id = new Guid("3d9f8d5e-6476-4dbe-85db-6d7879fc317d"),
                            CreatedAt = new DateTime(2024, 8, 25, 12, 0, 0, 0, DateTimeKind.Utc),
                            CreatedById = new Guid("e0f2f77a-b7d4-4b8a-9f35-b0f60d1bdf6e"),
                            EntityStatus = EntityStatusType.Active,
                            MaxScore = 1399,
                            MinScore = 1200,
                            RiskLevel = CreditRiskLevelType.HighRisk
                        },
                        new
                        {
                            Id = new Guid("0190d4db-25b9-4e34-bf03-737035a3e916"),
                            CreatedAt = new DateTime(2024, 8, 25, 12, 0, 0, 0, DateTimeKind.Utc),
                            CreatedById = new Guid("e0f2f77a-b7d4-4b8a-9f35-b0f60d1bdf6e"),
                            EntityStatus = EntityStatusType.Active,
                            MaxScore = 1599,
                            MinScore = 1400,
                            RiskLevel = CreditRiskLevelType.MediumRisk
                        },
                        new
                        {
                            Id = new Guid("fb14b253-61ea-4118-8e41-e8cddce4e0a3"),
                            CreatedAt = new DateTime(2024, 8, 25, 12, 0, 0, 0, DateTimeKind.Utc),
                            CreatedById = new Guid("e0f2f77a-b7d4-4b8a-9f35-b0f60d1bdf6e"),
                            EntityStatus = EntityStatusType.Active,
                            MaxScore = 1799,
                            MinScore = 1600,
                            RiskLevel = CreditRiskLevelType.Good
                        },
                        new
                        {
                            Id = new Guid("81f6a5c4-2c1e-4fed-9387-2774321feb30"),
                            CreatedAt = new DateTime(2024, 8, 25, 12, 0, 0, 0, DateTimeKind.Utc),
                            CreatedById = new Guid("e0f2f77a-b7d4-4b8a-9f35-b0f60d1bdf6e"),
                            EntityStatus = EntityStatusType.Active,
                            MaxScore = 1999,
                            MinScore = 1800,
                            RiskLevel = CreditRiskLevelType.Excellent
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
