using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsWebsite.Api.Migrations
{
    public partial class addVideoArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "CmsArticle",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Video",
                table: "CmsArticle");
        }
    }
}
