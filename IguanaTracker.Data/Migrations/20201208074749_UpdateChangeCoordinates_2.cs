using Microsoft.EntityFrameworkCore.Migrations;

namespace IguanaTracker.Data.Migrations
{
    public partial class UpdateChangeCoordinates_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Iguanas",
                type: "decimal(11,9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Iguanas",
                type: "decimal(11,9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,8)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Iguanas",
                type: "decimal(11,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,9)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Iguanas",
                type: "decimal(10,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,9)");
        }
    }
}
