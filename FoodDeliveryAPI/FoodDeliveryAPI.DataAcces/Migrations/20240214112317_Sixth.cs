using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryAPI.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class Sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Customers_CustomerId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CustomerId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Items");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerUserId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CustomerUserId",
                table: "Items",
                column: "CustomerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Customers_CustomerUserId",
                table: "Items",
                column: "CustomerUserId",
                principalTable: "Customers",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Customers_CustomerUserId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CustomerUserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CustomerUserId",
                table: "Items");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Items_CustomerId",
                table: "Items",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Customers_CustomerId",
                table: "Items",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
