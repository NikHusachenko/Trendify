using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trendify.Api.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSupplierCredentialsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Credentials_CredentialsId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_CredentialsId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CredentialsId",
                table: "Suppliers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CredentialsId",
                table: "Suppliers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CredentialsId",
                table: "Suppliers",
                column: "CredentialsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Credentials_CredentialsId",
                table: "Suppliers",
                column: "CredentialsId",
                principalTable: "Credentials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
