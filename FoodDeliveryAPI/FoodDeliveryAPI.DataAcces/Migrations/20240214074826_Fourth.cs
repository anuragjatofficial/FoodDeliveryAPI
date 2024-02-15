using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryAPI.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class Fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Customers_CustomerUserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CustomerUserId",
                table: "Items",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CustomerUserId",
                table: "Items",
                newName: "IX_Items_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Customers_CustomerId",
                table: "Items",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Customers_CustomerId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Items",
                newName: "CustomerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CustomerId",
                table: "Items",
                newName: "IX_Items_CustomerUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Customers_CustomerUserId",
                table: "Items",
                column: "CustomerUserId",
                principalTable: "Customers",
                principalColumn: "UserId");
        }
    }
}
