using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRating.Migrations
{
    public partial class Reviewer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviewer",
                table: "Reviewer");

            migrationBuilder.DropColumn(
                name: "ReviewerId",
                table: "Reviewer");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Reviewer",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviewer",
                table: "Reviewer",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviewer",
                table: "Reviewer");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reviewer");

            migrationBuilder.AddColumn<string>(
                name: "ReviewerId",
                table: "Reviewer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviewer",
                table: "Reviewer",
                column: "ReviewerId");
        }
    }
}
