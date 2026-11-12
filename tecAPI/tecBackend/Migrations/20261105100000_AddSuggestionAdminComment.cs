using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using tecBackend.Models;

#nullable disable

namespace tecBackend.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(SiteContext))]
    [Migration("20261105100000_AddSuggestionAdminComment")]
    public partial class AddSuggestionAdminComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "admincomment",
                table: "suggestions",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "admincommentat",
                table: "suggestions",
                type: "timestamp",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "admincommentbyuserid",
                table: "suggestions",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "admincomment", table: "suggestions");
            migrationBuilder.DropColumn(name: "admincommentat", table: "suggestions");
            migrationBuilder.DropColumn(name: "admincommentbyuserid", table: "suggestions");
        }
    }
}