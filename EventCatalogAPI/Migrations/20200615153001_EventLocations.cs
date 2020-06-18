using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class EventLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "EventLocations");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "EventLocations");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "EventLocations",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "EventLocations");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "EventLocations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "EventLocations",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
