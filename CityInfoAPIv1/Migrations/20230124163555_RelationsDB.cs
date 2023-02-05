using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfoAPIv1.Migrations
{
    public partial class RelationsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "PointOfInterest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PointOfInterest_CityId",
                table: "PointOfInterest",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PointOfInterest_City_CityId",
                table: "PointOfInterest",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointOfInterest_City_CityId",
                table: "PointOfInterest");

            migrationBuilder.DropIndex(
                name: "IX_PointOfInterest_CityId",
                table: "PointOfInterest");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "PointOfInterest");
        }
    }
}
