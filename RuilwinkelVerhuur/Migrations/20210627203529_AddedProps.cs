using Microsoft.EntityFrameworkCore.Migrations;

namespace RuilwinkelVerhuur.Migrations
{
    public partial class AddedProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "ProductNaarFactuur",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductPicture",
                table: "ProductNaarFactuur",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "ProductNaarFactuur");

            migrationBuilder.DropColumn(
                name: "ProductPicture",
                table: "ProductNaarFactuur");
        }
    }
}
