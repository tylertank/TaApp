using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAApplication.Data.Migrations
{
    public partial class ApplicationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pursuing = table.Column<int>(type: "int", nullable: false),
                    Dept = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hours = table.Column<int>(type: "int", nullable: false),
                    avaliableBeforeSchoo = table.Column<bool>(type: "bit", nullable: false),
                    semestersCompleted = table.Column<int>(type: "int", nullable: false),
                    transferSchool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkedInURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resumeFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GPA = table.Column<double>(type: "float", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TAUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    personalStatement = table.Column<string>(type: "nvarchar(4000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application_AspNetUsers_TAUserId",
                        column: x => x.TAUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_TAUserId",
                table: "Application",
                column: "TAUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");
        }
    }
}
