using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsWebsite.Api.Migrations
{
    public partial class updatesoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "taked",
                table: "CmsArticle",
                newName: "isDeleted");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CmsCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "CmsCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "CmsCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "CmsArticle",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CmsArticle",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "CmsArticle",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CmsCategories");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "CmsCategories");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "CmsCategories");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "CmsArticle");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "CmsArticle",
                newName: "taked");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "CmsArticle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CmsArticle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
