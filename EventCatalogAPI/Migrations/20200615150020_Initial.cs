using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "event_item_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_location_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "EventLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    DateTime = table.Column<DateTime>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: false),
                    DateTime = table.Column<DateTime>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: true),
                    EventTypeId = table.Column<int>(nullable: false),
                    EventLocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventItems_EventLocations_EventLocationId",
                        column: x => x.EventLocationId,
                        principalTable: "EventLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventItems_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventItems_EventLocationId",
                table: "EventItems",
                column: "EventLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventItems_EventTypeId",
                table: "EventItems",
                column: "EventTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventItems");

            migrationBuilder.DropTable(
                name: "EventLocations");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropSequence(
                name: "event_item_hilo");

            migrationBuilder.DropSequence(
                name: "event_location_hilo");

            migrationBuilder.DropSequence(
                name: "event_type_hilo");
        }
    }
}
