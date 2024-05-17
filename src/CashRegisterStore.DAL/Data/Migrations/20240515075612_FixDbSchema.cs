using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashRegisterStore.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixDbSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_BasketProducts_BasketId",
                table: "BasketProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketProducts_BasketId",
                table: "BasketProducts",
                column: "BasketId",
                unique: true);
        }
    }
}
