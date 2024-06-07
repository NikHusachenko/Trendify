using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trendify.Api.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDeliveryProductRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Delivery materials",
                table: "Delivery materials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Delivery materials",
                table: "Delivery materials",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery materials_SupplyId",
                table: "Delivery materials",
                column: "SupplyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Delivery materials",
                table: "Delivery materials");

            migrationBuilder.DropIndex(
                name: "IX_Delivery materials_SupplyId",
                table: "Delivery materials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Delivery materials",
                table: "Delivery materials",
                columns: new[] { "SupplyId", "MaterialId" });
        }
    }
}
