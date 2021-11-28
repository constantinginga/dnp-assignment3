using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1_Server.Migrations
{
    public partial class _3_UpdateJobId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Job_JobTitleId",
                table: "Adults");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Job",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "JobTitleId",
                table: "Adults",
                newName: "JobTitleJobId");

            migrationBuilder.RenameIndex(
                name: "IX_Adults_JobTitleId",
                table: "Adults",
                newName: "IX_Adults_JobTitleJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Job_JobTitleJobId",
                table: "Adults",
                column: "JobTitleJobId",
                principalTable: "Job",
                principalColumn: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Job_JobTitleJobId",
                table: "Adults");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Job",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "JobTitleJobId",
                table: "Adults",
                newName: "JobTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Adults_JobTitleJobId",
                table: "Adults",
                newName: "IX_Adults_JobTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Job_JobTitleId",
                table: "Adults",
                column: "JobTitleId",
                principalTable: "Job",
                principalColumn: "Id");
        }
    }
}
