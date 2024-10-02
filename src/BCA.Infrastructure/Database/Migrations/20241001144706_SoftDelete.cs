using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BCA.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class SoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "TodoLists",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_DeletedAt",
                table: "TodoLists",
                column: "DeletedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TodoLists_DeletedAt",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "TodoLists");
        }
    }
}
