using Microsoft.EntityFrameworkCore.Migrations;

namespace IguanaTracker.Data.Migrations
{
    public partial class UpdateAddedCoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Iguanas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Iguanas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Iguanas");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Iguanas");
        }
    }
}
