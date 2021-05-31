using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCore.Mvc.CrudSample.Migrations
{
    public partial class TeacherCourseRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Teacher",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_CourseId",
                table: "Teacher",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Course_CourseId",
                table: "Teacher",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Course_CourseId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_CourseId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Teacher");
        }
    }
}
