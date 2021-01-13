using Microsoft.EntityFrameworkCore.Migrations;

namespace IguanaTracker.Data.Migrations
{
    public partial class updateIguanasDirectory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Directory",
                table: "Iguanas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Directory",
                table: "Iguanas");
        }
    }
}
