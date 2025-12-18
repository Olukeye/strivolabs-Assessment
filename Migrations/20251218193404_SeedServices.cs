using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace strivolabs_Assessment.Migrations
{
    /// <inheritdoc />
    public partial class SeedServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 12, 18, 19, 34, 3, 729, DateTimeKind.Utc).AddTicks(2978), "$2a$11$tr15Zt8qUvb7aEq2FQb77.PhiFZy5ilPhx/oxwnxRhSwnfLwAVxuW" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 12, 18, 19, 31, 58, 617, DateTimeKind.Utc).AddTicks(2346), "$2a$11$673DBKGbqtx5xyPDuBdVDO48U3YVRepF9RoKgdfb0F8LUqQ1G6CPa" });
        }
    }
}
