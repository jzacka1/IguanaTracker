using Microsoft.EntityFrameworkCore.Migrations;

namespace IguanaTracker.Data.Migrations
{
    public partial class updateRemovedIpAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IP_Address",
                table: "Iguanas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IP_Address",
                table: "Iguanas",
                type: "varchar(max)",
                unicode: false,
                nullable: true);
        }
    }
}
