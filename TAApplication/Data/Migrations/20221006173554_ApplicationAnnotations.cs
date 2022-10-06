using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAApplication.Data.Migrations
{
    public partial class ApplicationAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Application");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Application",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "lastModified",
                table: "Application",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "Creation",
                table: "Application",
                newName: "CreationDate");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Application",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Application",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Application");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Application",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Application",
                newName: "lastModified");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Application",
                newName: "Creation");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Application",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
