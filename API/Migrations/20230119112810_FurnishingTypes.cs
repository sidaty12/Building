using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class FurnishingTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_FurnishingType_FurnishingTypeId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FurnishingType",
                table: "FurnishingType");

            migrationBuilder.RenameTable(
                name: "FurnishingType",
                newName: "FurnishingTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FurnishingTypes",
                table: "FurnishingTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_FurnishingTypes_FurnishingTypeId",
                table: "Properties",
                column: "FurnishingTypeId",
                principalTable: "FurnishingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_FurnishingTypes_FurnishingTypeId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FurnishingTypes",
                table: "FurnishingTypes");

            migrationBuilder.RenameTable(
                name: "FurnishingTypes",
                newName: "FurnishingType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FurnishingType",
                table: "FurnishingType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_FurnishingType_FurnishingTypeId",
                table: "Properties",
                column: "FurnishingTypeId",
                principalTable: "FurnishingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
