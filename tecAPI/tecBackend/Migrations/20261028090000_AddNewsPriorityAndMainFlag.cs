using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using tecBackend.Models;

#nullable disable

namespace tecBackend.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(SiteContext))]
    [Migration("20261028090000_AddNewsPriorityAndMainFlag")]
    public partial class AddNewsPriorityAndMainFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "summary",
                table: "news_posts",
                type: "text",
                nullable: true);

            // Все существующие новости остаются опубликованными.
            migrationBuilder.AddColumn<bool>(
                name: "ispublished",
                table: "news_posts",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "showonmain",
                table: "news_posts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                table: "news_posts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedat",
                table: "news_posts",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "summary", table: "news_posts");
            migrationBuilder.DropColumn(name: "ispublished", table: "news_posts");
            migrationBuilder.DropColumn(name: "showonmain", table: "news_posts");
            migrationBuilder.DropColumn(name: "priority", table: "news_posts");
            migrationBuilder.DropColumn(name: "updatedat", table: "news_posts");
        }
    }
}