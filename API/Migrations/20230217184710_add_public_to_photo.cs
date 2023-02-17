using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class add_public_to_photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Photos",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_FurnishingType_FurnishingTypeId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FurnishingType",
                table: "FurnishingType");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Photos");

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
    }
}
