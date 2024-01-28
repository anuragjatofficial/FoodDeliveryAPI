using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_orders_RestaurantId",
                table: "orders",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Restaurants_RestaurantId",
                table: "orders",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Restaurants_RestaurantId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_RestaurantId",
                table: "orders");
        }
    }
}
