using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTrackingSystem.Infrastructure.Migrations
{
    public partial class initial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Full_Name",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Full_Name",
                table: "AspNetUsers");
        }
    }
}
