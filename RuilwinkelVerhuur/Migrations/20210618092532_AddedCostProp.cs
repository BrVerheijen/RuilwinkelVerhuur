using Microsoft.EntityFrameworkCore.Migrations;

namespace RuilwinkelVerhuur.Migrations
{
    public partial class AddedCostProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cost",
                table: "ProductNaarFactuur",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "ProductNaarFactuur");
        }
    }
}
