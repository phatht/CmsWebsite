using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsWebsite.Api.Migrations
{
    public partial class updateaddFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_CmsArticleCategories_CmsArticle_ArticleID",
            //    table: "CmsArticleCategories");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_CmsArticleCategories_CmsCategories_CategoryID",
            //    table: "CmsArticleCategories");

            //migrationBuilder.DropIndex(
            //    name: "IX_CmsArticleCategories_ArticleID",
            //    table: "CmsArticleCategories");

            //migrationBuilder.DropIndex(
            //    name: "IX_CmsArticleCategories_CategoryID",
            //    table: "CmsArticleCategories");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_CmsArticleCategories_ArticleID",
                table: "CmsArticleCategories",
                column: "ArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_CmsArticleCategories_CategoryID",
                table: "CmsArticleCategories",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_CmsArticleCategories_CmsArticle_ArticleID",
                table: "CmsArticleCategories",
                column: "ArticleID",
                principalTable: "CmsArticle",
                principalColumn: "ArticleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CmsArticleCategories_CmsCategories_CategoryID",
                table: "CmsArticleCategories",
                column: "CategoryID",
                principalTable: "CmsCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
