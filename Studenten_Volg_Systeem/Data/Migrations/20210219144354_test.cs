using Microsoft.EntityFrameworkCore.Migrations;

namespace Studenten_Volg_Systeem.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "Middelname");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Middelname",
                table: "Students",
                newName: "Name");
        }
    }
}
