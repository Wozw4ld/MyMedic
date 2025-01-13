using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMedic.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class cATEGORYWithImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "ProductImages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_CategoryId",
                table: "ProductImages",
                column: "CategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Categories_CategoryId",
                table: "ProductImages",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Categories_CategoryId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_CategoryId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductImages");
        }
    }
}
