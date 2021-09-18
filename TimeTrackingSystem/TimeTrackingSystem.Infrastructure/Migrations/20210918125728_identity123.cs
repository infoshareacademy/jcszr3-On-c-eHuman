using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTrackingSystem.Infrastructure.Migrations
{
    public partial class identity123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_Activities_ActivityId",
                table: "TimeSheets");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_Activities_ActivityId",
                table: "TimeSheets",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_Activities_ActivityId",
                table: "TimeSheets");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_Activities_ActivityId",
                table: "TimeSheets",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
