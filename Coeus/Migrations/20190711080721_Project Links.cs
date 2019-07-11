using Microsoft.EntityFrameworkCore.Migrations;

namespace Coeus.Migrations
{
    public partial class ProjectLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GitHubLink",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectLink",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GitHubLink",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ProjectLink",
                table: "Posts");
        }
    }
}
