using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trendify.Api.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorHex",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ColorRal",
                table: "Materials");

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "Materials",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "Materials");

            migrationBuilder.AddColumn<string>(
                name: "ColorHex",
                table: "Materials",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ColorRal",
                table: "Materials",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
