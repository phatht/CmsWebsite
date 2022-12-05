using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsWebsite.Api.Infrastructure.Migrations
{
    public partial class addViewArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "View",
                table: "CmsArticle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "View",
                table: "CmsArticle");
        }
    }
}
