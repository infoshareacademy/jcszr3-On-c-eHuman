using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTrackingSystem.Infrastructure.Migrations
{
    public partial class leaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_Activities_ActivityId",
                table: "TimeSheets");

            migrationBuilder.AddColumn<string>(
                name: "Full_Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Leave_type = table.Column<int>(nullable: false),
                    Start_date = table.Column<DateTime>(nullable: false),
                    End_date = table.Column<DateTime>(nullable: false),
                    Other_details = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_ApplicationUserId",
                table: "Leaves",
                column: "ApplicationUserId");

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

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropColumn(
                name: "Full_Name",
                table: "AspNetUsers");

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
