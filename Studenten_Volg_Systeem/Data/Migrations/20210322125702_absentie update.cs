using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Studenten_Volg_Systeem.Data.Migrations
{
    public partial class absentieupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Present",
                table: "Absenties");

            migrationBuilder.AddColumn<int>(
                name: "PresentId",
                table: "Absenties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Absenties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Absenties_PresentId",
                table: "Absenties",
                column: "PresentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absenties_Absenties_PresentId",
                table: "Absenties",
                column: "PresentId",
                principalTable: "Absenties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absenties_Absenties_PresentId",
                table: "Absenties");

            migrationBuilder.DropIndex(
                name: "IX_Absenties_PresentId",
                table: "Absenties");

            migrationBuilder.DropColumn(
                name: "PresentId",
                table: "Absenties");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Absenties");

            migrationBuilder.AddColumn<bool>(
                name: "Present",
                table: "Absenties",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
