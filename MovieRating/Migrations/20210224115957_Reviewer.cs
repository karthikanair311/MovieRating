using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRating.Migrations
{
    public partial class Reviewer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviewer",
                columns: table => new
                {
                    ReviewerId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewer", x => x.ReviewerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviewer");
        }
    }
}
