using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsWebsite.Api.Migrations
{
    public partial class ArticleCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CmsArticleCategories",
                table: "CmsArticleCategories");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "CmsArticleCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CmsArticleCategories",
                table: "CmsArticleCategories",
                columns: new[] { "ArticleID", "CategoryID" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CmsArticleCategories_CmsArticle_ArticleID",
                table: "CmsArticleCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_CmsArticleCategories_CmsCategories_CategoryID",
                table: "CmsArticleCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CmsArticleCategories",
                table: "CmsArticleCategories");

            migrationBuilder.DropIndex(
                name: "IX_CmsArticleCategories_CategoryID",
                table: "CmsArticleCategories");

            migrationBuilder.AddColumn<long>(
                name: "ID",
                table: "CmsArticleCategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CmsArticleCategories",
                table: "CmsArticleCategories",
                column: "ID");
        }
    }
}
