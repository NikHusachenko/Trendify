using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trendify.Api.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class changedWorkshopOrderRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Workshops_WorkshopId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "WorkshopId",
                table: "Orders",
                newName: "RequesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_WorkshopId",
                table: "Orders",
                newName: "IX_Orders_RequesterId");

            migrationBuilder.AddColumn<Guid>(
                name: "CloserId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CloserId",
                table: "Orders",
                column: "CloserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Workshops_CloserId",
                table: "Orders",
                column: "CloserId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Workshops_RequesterId",
                table: "Orders",
                column: "RequesterId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Workshops_CloserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Workshops_RequesterId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CloserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CloserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "RequesterId",
                table: "Orders",
                newName: "WorkshopId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_RequesterId",
                table: "Orders",
                newName: "IX_Orders_WorkshopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Workshops_WorkshopId",
                table: "Orders",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
