using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trendify.Api.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedStartMaterialCountToDelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Delivery materials",
                newName: "Left");

            migrationBuilder.AddColumn<int>(
                name: "Delivered",
                table: "Delivery materials",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delivered",
                table: "Delivery materials");

            migrationBuilder.RenameColumn(
                name: "Left",
                table: "Delivery materials",
                newName: "Count");
        }
    }
}
