using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IguanaTracker.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Iguanas",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Directory = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        City = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        State = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Latitude = table.Column<double>(type: "float", nullable: false),
            //        Longitude = table.Column<double>(type: "float", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Iguanas", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Iguanas");
        }
    }
}
