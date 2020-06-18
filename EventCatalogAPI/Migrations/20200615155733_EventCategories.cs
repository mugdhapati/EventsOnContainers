using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class EventCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventItems_EventLocations_EventLocationId",
                table: "EventItems");

            migrationBuilder.DropTable(
                name: "EventLocations");

            migrationBuilder.DropIndex(
                name: "IX_EventItems_EventLocationId",
                table: "EventItems");

            migrationBuilder.DropSequence(
                name: "event_location_hilo");

            migrationBuilder.DropColumn(
                name: "EventLocationId",
                table: "EventItems");

            migrationBuilder.CreateSequence(
                name: "event_category_hilo",
                incrementBy: 10);

            migrationBuilder.AddColumn<int>(
                name: "EventCategoryId",
                table: "EventItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Category = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventItems_EventCategoryId",
                table: "EventItems",
                column: "EventCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventItems_EventCategories_EventCategoryId",
                table: "EventItems",
                column: "EventCategoryId",
                principalTable: "EventCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventItems_EventCategories_EventCategoryId",
                table: "EventItems");

            migrationBuilder.DropTable(
                name: "EventCategories");

            migrationBuilder.DropIndex(
                name: "IX_EventItems_EventCategoryId",
                table: "EventItems");

            migrationBuilder.DropSequence(
                name: "event_category_hilo");

            migrationBuilder.DropColumn(
                name: "EventCategoryId",
                table: "EventItems");

            migrationBuilder.CreateSequence(
                name: "event_location_hilo",
                incrementBy: 10);

            migrationBuilder.AddColumn<int>(
                name: "EventLocationId",
                table: "EventItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLocations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventItems_EventLocationId",
                table: "EventItems",
                column: "EventLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventItems_EventLocations_EventLocationId",
                table: "EventItems",
                column: "EventLocationId",
                principalTable: "EventLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
