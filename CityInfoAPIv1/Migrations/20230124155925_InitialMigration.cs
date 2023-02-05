using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfoAPIv1.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "PointOfInterest",
                columns: table => new
                {
                    PointOfInterestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointOfInterestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointOfInterestDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfInterest", x => x.PointOfInterestId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "PointOfInterest");
        }
    }
}
