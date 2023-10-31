using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CodeBaseIOStudy.Migrations
{
    /// <inheritdoc />
    public partial class DropTableBookTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookTypes_BookTypeId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Books_BookId",
                table: "Stocks");

            migrationBuilder.DropTable(
                name: "BookTypes");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_BookId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookTypeId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "BookTypeId",
                table: "Books",
                newName: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_StockId",
                table: "Books",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Stocks_StockId",
                table: "Books",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Stocks_StockId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_StockId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "StockId",
                table: "Books",
                newName: "BookTypeId");

            migrationBuilder.CreateTable(
                name: "BookTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_BookId",
                table: "Stocks",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookTypeId",
                table: "Books",
                column: "BookTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookTypes_BookTypeId",
                table: "Books",
                column: "BookTypeId",
                principalTable: "BookTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Books_BookId",
                table: "Stocks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
