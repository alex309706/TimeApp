using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeApp.Migrations
{
    public partial class AddedRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeginOfWork = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfWork = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Employment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");
        }
    }
}
