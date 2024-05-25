using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trendify.Api.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMaterialOrderRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Orders_OrderId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_OrderId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Materials");

            migrationBuilder.CreateTable(
                name: "Material Orders",
                columns: table => new
                {
                    MaterialId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material Orders", x => new { x.MaterialId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_Material Orders_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Material Orders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material Orders_OrderId",
                table: "Material Orders",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Material Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Materials",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_OrderId",
                table: "Materials",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Orders_OrderId",
                table: "Materials",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
