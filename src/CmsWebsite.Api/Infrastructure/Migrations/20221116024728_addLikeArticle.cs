using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsWebsite.Api.Migrations
{
    public partial class addLikeArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "CmsArticle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Like",
                table: "CmsArticle");
        }
    }
}
