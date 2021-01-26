using Microsoft.EntityFrameworkCore.Migrations;

namespace IguanaTracker.Data.Migrations
{
    public partial class UpdateIguanaLatLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Iguanas",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,9)");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Iguanas",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,9)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Iguanas",
                type: "decimal(11,9)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Iguanas",
                type: "decimal(11,9)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
