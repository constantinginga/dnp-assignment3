using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1_Server.Migrations
{
    public partial class _2_AddJobTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Job_JobTitleJobId",
                table: "Adults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Jobs_JobTitleJobId",
                table: "Adults",
                column: "JobTitleJobId",
                principalTable: "Jobs",
                principalColumn: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Jobs_JobTitleJobId",
                table: "Adults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Job_JobTitleJobId",
                table: "Adults",
                column: "JobTitleJobId",
                principalTable: "Job",
                principalColumn: "JobId");
        }
    }
}
