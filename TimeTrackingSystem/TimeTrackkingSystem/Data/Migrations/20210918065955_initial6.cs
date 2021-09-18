using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTrackkingSystem.Data.Migrations
{
    public partial class initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Projects_ProjectId",
                schema: "Identity",
                table: "Activities");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Projects_ProjectId",
                schema: "Identity",
                table: "Activities",
                column: "ProjectId",
                principalSchema: "Identity",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Projects_ProjectId",
                schema: "Identity",
                table: "Activities");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Projects_ProjectId",
                schema: "Identity",
                table: "Activities",
                column: "ProjectId",
                principalSchema: "Identity",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
