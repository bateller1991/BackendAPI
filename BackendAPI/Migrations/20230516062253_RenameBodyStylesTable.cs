using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPI.Migrations
{
    public partial class RenameBodyStylesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "BodyStyles",
                newName: "NewBodyStyles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "NewBodyStyles",
                newName: "BodyStyles");
        }
    }
}
