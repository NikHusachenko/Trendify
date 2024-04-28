using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trendify.Api.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMaterialSupplyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Supplies_SupplyId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_SupplyId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "SupplyId",
                table: "Materials");

            migrationBuilder.CreateTable(
                name: "Delivery materials",
                columns: table => new
                {
                    SupplyId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uuid", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery materials", x => new { x.SupplyId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_Delivery materials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Delivery materials_Supplies_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Delivery materials_MaterialId",
                table: "Delivery materials",
                column: "MaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Delivery materials");

            migrationBuilder.AddColumn<Guid>(
                name: "SupplyId",
                table: "Materials",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_SupplyId",
                table: "Materials",
                column: "SupplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Supplies_SupplyId",
                table: "Materials",
                column: "SupplyId",
                principalTable: "Supplies",
                principalColumn: "Id");
        }
    }
}
