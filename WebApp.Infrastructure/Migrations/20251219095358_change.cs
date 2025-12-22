using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_LeavePeriod_PeriodId",
                table: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "LeavePeriod");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequests_PeriodId",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PeriodId",
                table: "LeaveRequests",
                newName: "Period_Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "LeaveRequests");

            migrationBuilder.RenameColumn(
                name: "Period_Id",
                table: "LeaveRequests",
                newName: "PeriodId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "LeavePeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeavePeriod", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_PeriodId",
                table: "LeaveRequests",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_LeavePeriod_PeriodId",
                table: "LeaveRequests",
                column: "PeriodId",
                principalTable: "LeavePeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
