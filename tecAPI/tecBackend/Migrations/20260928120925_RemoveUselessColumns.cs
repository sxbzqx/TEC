using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tecBackend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUselessColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_dep",
                table: "otdel");

            migrationBuilder.DropColumn(
                name: "id_otd",
                table: "otdel");

            migrationBuilder.DropColumn(
                name: "idotd_buhgalter",
                table: "otdel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_dep",
                table: "otdel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "id_otd",
                table: "otdel",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "idotd_buhgalter",
                table: "otdel",
                type: "smallint",
                nullable: true);
        }
    }
}
