using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trendify.Api.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ChangedConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMaterialsEntity_Materials_MaterialId",
                table: "ProductMaterialsEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductMaterialsEntity_Products_ProductId",
                table: "ProductMaterialsEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMaterialsEntity",
                table: "ProductMaterialsEntity");

            migrationBuilder.DropIndex(
                name: "IX_ProductMaterialsEntity_ProductId",
                table: "ProductMaterialsEntity");

            migrationBuilder.RenameTable(
                name: "ProductMaterialsEntity",
                newName: "Product Materials");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMaterialsEntity_MaterialId",
                table: "Product Materials",
                newName: "IX_Product Materials_MaterialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product Materials",
                table: "Product Materials",
                columns: new[] { "ProductId", "MaterialId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Product Materials_Materials_MaterialId",
                table: "Product Materials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product Materials_Products_ProductId",
                table: "Product Materials",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product Materials_Materials_MaterialId",
                table: "Product Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Product Materials_Products_ProductId",
                table: "Product Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product Materials",
                table: "Product Materials");

            migrationBuilder.RenameTable(
                name: "Product Materials",
                newName: "ProductMaterialsEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Product Materials_MaterialId",
                table: "ProductMaterialsEntity",
                newName: "IX_ProductMaterialsEntity_MaterialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMaterialsEntity",
                table: "ProductMaterialsEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMaterialsEntity_ProductId",
                table: "ProductMaterialsEntity",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMaterialsEntity_Materials_MaterialId",
                table: "ProductMaterialsEntity",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMaterialsEntity_Products_ProductId",
                table: "ProductMaterialsEntity",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
