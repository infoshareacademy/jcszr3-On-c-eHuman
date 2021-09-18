using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTrackkingSystem.Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_Activities_ActivityId",
                schema: "Identity",
                table: "TimeSheets");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_Activities_ActivityId",
                schema: "Identity",
                table: "TimeSheets",
                column: "ActivityId",
                principalSchema: "Identity",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_Activities_ActivityId",
                schema: "Identity",
                table: "TimeSheets");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_Activities_ActivityId",
                schema: "Identity",
                table: "TimeSheets",
                column: "ActivityId",
                principalSchema: "Identity",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
