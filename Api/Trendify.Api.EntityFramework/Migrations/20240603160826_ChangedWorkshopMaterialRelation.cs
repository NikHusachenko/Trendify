using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trendify.Api.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ChangedWorkshopMaterialRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Material Blueprints");

            migrationBuilder.DropTable(
                name: "Material Workshops");

            migrationBuilder.DropTable(
                name: "Blueprints");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "Materials");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkshopId",
                table: "Supplies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_WorkshopId",
                table: "Supplies",
                column: "WorkshopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Workshops_WorkshopId",
                table: "Supplies",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Workshops_WorkshopId",
                table: "Supplies");

            migrationBuilder.DropIndex(
                name: "IX_Supplies_WorkshopId",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "WorkshopId",
                table: "Supplies");

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "Materials",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Blueprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BlueprintURL = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blueprints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material Workshops",
                columns: table => new
                {
                    MaterialId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkshopId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material Workshops", x => new { x.MaterialId, x.WorkshopId });
                    table.ForeignKey(
                        name: "FK_Material Workshops_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Material Workshops_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material Blueprints",
                columns: table => new
                {
                    MaterialId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlueprintId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material Blueprints", x => new { x.MaterialId, x.BlueprintId });
                    table.ForeignKey(
                        name: "FK_Material Blueprints_Blueprints_BlueprintId",
                        column: x => x.BlueprintId,
                        principalTable: "Blueprints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Material Blueprints_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material Blueprints_BlueprintId",
                table: "Material Blueprints",
                column: "BlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_Material Workshops_WorkshopId",
                table: "Material Workshops",
                column: "WorkshopId");
        }
    }
}
