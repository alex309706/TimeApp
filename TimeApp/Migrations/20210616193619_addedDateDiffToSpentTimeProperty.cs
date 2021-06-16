using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeApp.Migrations
{
    public partial class addedDateDiffToSpentTimeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SpentTime",
                table: "Records",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "DATEDIFF(MINUTE,[BeginOfWork], [EndOfWork])",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SpentTime",
                table: "Records",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComputedColumnSql: "DATEDIFF(MINUTE,[BeginOfWork], [EndOfWork])");
        }
    }
}
