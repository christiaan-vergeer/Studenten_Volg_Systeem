using Microsoft.EntityFrameworkCore.Migrations;

namespace Studenten_Volg_Systeem.Data.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Enddate",
                table: "Lessons",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Lessons",
                newName: "Enddate");
        }
    }
}
