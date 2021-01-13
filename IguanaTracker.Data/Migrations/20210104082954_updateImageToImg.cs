using Microsoft.EntityFrameworkCore.Migrations;

namespace IguanaTracker.Data.Migrations
{
    public partial class updateImageToImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Iguanas",
                newName: "Img");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Img",
                table: "Iguanas",
                newName: "Image");
        }
    }
}
