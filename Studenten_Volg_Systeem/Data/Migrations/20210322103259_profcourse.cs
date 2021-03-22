using Microsoft.EntityFrameworkCore.Migrations;

namespace Studenten_Volg_Systeem.Data.Migrations
{
    public partial class profcourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseProffesor");

            migrationBuilder.AddColumn<int>(
                name: "CoursesId",
                table: "Proffesors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proffesors_CoursesId",
                table: "Proffesors",
                column: "CoursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proffesors_Courses_CoursesId",
                table: "Proffesors",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proffesors_Courses_CoursesId",
                table: "Proffesors");

            migrationBuilder.DropIndex(
                name: "IX_Proffesors_CoursesId",
                table: "Proffesors");

            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "Proffesors");

            migrationBuilder.CreateTable(
                name: "CourseProffesor",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    ProffesorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProffesor", x => new { x.CoursesId, x.ProffesorsId });
                    table.ForeignKey(
                        name: "FK_CourseProffesor_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProffesor_Proffesors_ProffesorsId",
                        column: x => x.ProffesorsId,
                        principalTable: "Proffesors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffesor_ProffesorsId",
                table: "CourseProffesor",
                column: "ProffesorsId");
        }
    }
}
