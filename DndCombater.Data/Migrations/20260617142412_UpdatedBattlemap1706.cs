using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndCombater.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBattlemap1706 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Battlemaps",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Battlemaps");
        }
    }
}
