using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTrackkingSystem.Data.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_Account_AccountId",
                schema: "Identity",
                table: "TimeSheets");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Identity",
                table: "User",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                schema: "Identity",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Last_Name",
                schema: "Identity",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoProfile",
                schema: "Identity",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "Identity",
                table: "User",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                schema: "Identity",
                table: "TimeSheets",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                schema: "Identity",
                table: "TimeSheets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                schema: "Identity",
                table: "TimeSheets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                schema: "Identity",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_EmployeeId1",
                schema: "Identity",
                table: "TimeSheets",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EmployeeId",
                schema: "Identity",
                table: "Projects",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_User_EmployeeId",
                schema: "Identity",
                table: "Projects",
                column: "EmployeeId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_Account_AccountId",
                schema: "Identity",
                table: "TimeSheets",
                column: "AccountId",
                principalSchema: "Identity",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_User_EmployeeId1",
                schema: "Identity",
                table: "TimeSheets",
                column: "EmployeeId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_User_EmployeeId",
                schema: "Identity",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_Account_AccountId",
                schema: "Identity",
                table: "TimeSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_User_EmployeeId1",
                schema: "Identity",
                table: "TimeSheets");

            migrationBuilder.DropIndex(
                name: "IX_TimeSheets_EmployeeId1",
                schema: "Identity",
                table: "TimeSheets");

            migrationBuilder.DropIndex(
                name: "IX_Projects_EmployeeId",
                schema: "Identity",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "First_Name",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Last_Name",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PhotoProfile",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "Identity",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                schema: "Identity",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "Identity",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                schema: "Identity",
                table: "TimeSheets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_Account_AccountId",
                schema: "Identity",
                table: "TimeSheets",
                column: "AccountId",
                principalSchema: "Identity",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
