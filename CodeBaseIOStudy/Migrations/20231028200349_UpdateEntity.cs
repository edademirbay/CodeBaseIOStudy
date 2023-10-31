using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeBaseIOStudy.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Orders_OrderId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Orders_OrderId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Orders_OrderId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_OrderId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Books_OrderId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_OrderId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Addresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "Customers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "Books",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "Addresses",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OrderId",
                table: "Customers",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_OrderId",
                table: "Books",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_OrderId",
                table: "Addresses",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Orders_OrderId",
                table: "Addresses",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Orders_OrderId",
                table: "Books",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Orders_OrderId",
                table: "Customers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
