using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesSystem.Migrations
{
    /// <inheritdoc />
    public partial class sec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_ResourceType_ResourceTypeId",
                table: "Resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceType",
                table: "ResourceType");

            migrationBuilder.RenameTable(
                name: "ResourceType",
                newName: "resourceTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_resourceTypes",
                table: "resourceTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_resourceTypes_ResourceTypeId",
                table: "Resources",
                column: "ResourceTypeId",
                principalTable: "resourceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_resourceTypes_ResourceTypeId",
                table: "Resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_resourceTypes",
                table: "resourceTypes");

            migrationBuilder.RenameTable(
                name: "resourceTypes",
                newName: "ResourceType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceType",
                table: "ResourceType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_ResourceType_ResourceTypeId",
                table: "Resources",
                column: "ResourceTypeId",
                principalTable: "ResourceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
