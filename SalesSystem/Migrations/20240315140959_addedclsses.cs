using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesSystem.Migrations
{
    /// <inheritdoc />
    public partial class addedclsses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResourceTypeId",
                table: "Resources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResourceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ResourceTypeId",
                table: "Resources",
                column: "ResourceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_ResourceType_ResourceTypeId",
                table: "Resources",
                column: "ResourceTypeId",
                principalTable: "ResourceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_ResourceType_ResourceTypeId",
                table: "Resources");

            migrationBuilder.DropTable(
                name: "ResourceType");

            migrationBuilder.DropIndex(
                name: "IX_Resources_ResourceTypeId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ResourceTypeId",
                table: "Resources");
        }
    }
}
