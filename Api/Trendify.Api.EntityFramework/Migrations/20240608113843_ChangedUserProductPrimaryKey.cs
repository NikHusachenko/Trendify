using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trendify.Api.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserProductPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User Products",
                table: "User Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User Products",
                table: "User Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User Products_UserId",
                table: "User Products",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User Products",
                table: "User Products");

            migrationBuilder.DropIndex(
                name: "IX_User Products_UserId",
                table: "User Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User Products",
                table: "User Products",
                columns: new[] { "UserId", "ProductId" });
        }
    }
}
