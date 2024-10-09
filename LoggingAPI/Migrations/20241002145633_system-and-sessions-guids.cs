using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoggingAPI.Migrations
{
    /// <inheritdoc />
    public partial class systemandsessionsguids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SessionIdentifier",
                table: "Log",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SystemIdentifier",
                table: "Log",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionIdentifier",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "SystemIdentifier",
                table: "Log");
        }
    }
}
