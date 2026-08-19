using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tecBackend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUselessTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "site_db");

            migrationBuilder.CreateTable(
                name: "activity_log",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    action = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    subtitle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    actor_user_id = table.Column<int>(type: "int(11)", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("categories_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint(6)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201612",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201701",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201702",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201703",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201704",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201705",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201706",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201707",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201708",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201709",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201710",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201711",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201712",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201801",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201802",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201803",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201804",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201805",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201806",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'0000-00-00'"),
                    date_reshenie = table.Column<DateTime>(type: "date", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "date", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201807",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201808",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201809",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201810",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201811",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201812",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201901",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201902",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201903",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201904",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201905",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201906",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201907",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201908",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201909",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201910",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201911",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_201912",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202001",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202002",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202003",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202004",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202005",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202006",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202007",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202008",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202009",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202010",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202011",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202012",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202101",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202102",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202103",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202104",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202105",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202106",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202107",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202108",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202109",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202110",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202111",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202112",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202201",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202202",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202203",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202204",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202205",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202206",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202207",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202208",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202209",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202210",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202211",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202212",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202301",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202302",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202303",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202304",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202305",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202306",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202307",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202308",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202309",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202310",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202311",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202312",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202401",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202402",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202403",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202404",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202405",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202406",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202407",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202408",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202409",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202410",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202411",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202412",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202501",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202502",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202503",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202504",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202505",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202506",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202507",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202508",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202509",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202510",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202511",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202512",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202601",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202602",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents_202603",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents-01-06-2021",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "int(11)", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    id_resource = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<short>(type: "smallint(6)", nullable: true),
                    date_first = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'0000-00-00 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint(6)", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    archive = table.Column<short>(type: "smallint(6)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint(6)", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "datetime", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "otdel",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_otd = table.Column<short>(type: "smallint(3)", nullable: false),
                    name_otd = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValueSql: "''"),
                    id_dep = table.Column<int>(type: "int(11)", nullable: true),
                    idotd_buhgalter = table.Column<short>(type: "tinyint(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "resources",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint(6)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    id_otd = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Код отдела, который исполняет эту заявку"),
                    id_parent = table.Column<short>(type: "smallint(6)", nullable: true),
                    priznak = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false, comment: "1=замена, 2=установка")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_sessions",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    refreshtoken = table.Column<string>(type: "text", nullable: false),
                    expirytime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_sessions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workers",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ids = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    tabel = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    fio = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    phone = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    doljnost = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    otdel = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false, comment: "отдел рус.полностью"),
                    otdelid = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    kategoriyaid = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false, comment: "категория работника (начальники/мастера и т.д.)"),
                    kategoriyaname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "наименование категории работника"),
                    dr = table.Column<DateTime>(type: "date", nullable: false),
                    datepriem = table.Column<DateTime>(type: "date", nullable: false),
                    otdelruss = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false, comment: "отдел рус. кратко"),
                    otdelkyrb = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false, comment: "отдел кирг. полностью"),
                    otdelkyrs = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false, comment: "отдел кирг.кратко")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                },
                comment: "Справочник сотрудников");

            migrationBuilder.CreateTable(
                name: "workers_1otdel",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IDs = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    TABEL = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    FIO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    phone = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    doljnost = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    otdel = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false, comment: "отдел рус.полностью"),
                    otdelID = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    kategoriyaID = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false, comment: "категория работника (начальники/мастера и т.д.)"),
                    kategoriyaName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "наименование категории работника"),
                    DR = table.Column<DateTime>(type: "date", nullable: false),
                    datePriem = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                },
                comment: "Справочник сотрудников");

            migrationBuilder.CreateTable(
                name: "workers_copy",
                schema: "site_db",
                columns: table => new
                {
                    IDs = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    TABEL = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    FIO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    mphone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    doljnost = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    otdel = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    otdelID = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    kategoriyaID = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false, comment: "категория работника (начальники/мастера и т.д.)"),
                    DR = table.Column<DateTime>(type: "date", nullable: false),
                    datePriem = table.Column<DateTime>(type: "date", nullable: false),
                    id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                },
                comment: "Справочник сотрудников");

            migrationBuilder.CreateTable(
                name: "workers_empty",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IDs = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    TABEL = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    FIO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    mphone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    doljnost = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    otdel = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    otdelID = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    kategoriyaID = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false, comment: "категория работника (начальники/мастера и т.д.)"),
                    kategoriyaName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DR = table.Column<DateTime>(type: "date", nullable: false),
                    datePriem = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                },
                comment: "Справочник сотрудников");

            migrationBuilder.CreateTable(
                name: "workers18-06-2024",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IDs = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    TABEL = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    FIO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    phone = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    doljnost = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    otdel = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    otdelID = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    kategoriyaID = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false, comment: "категория работника (начальники/мастера и т.д.)"),
                    kategoriyaName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "наименование категории работника"),
                    DR = table.Column<DateTime>(type: "date", nullable: false),
                    datePriem = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                },
                comment: "Справочник сотрудников");

            migrationBuilder.CreateTable(
                name: "zayavkatmc",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(700)", maxLength: 700, nullable: false),
                    id_dep = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    action = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false, comment: "действие: 0-новая,1-прочитанная,2-выполненная,3-отложенная,4-отказная"),
                    dateAction = table.Column<DateTime>(type: "datetime", nullable: false, comment: "дата разрешения заявки"),
                    rem = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    sposob = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    kvartal = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    idOborud = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    idWork = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news_posts",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    createdbyuserid = table.Column<int>(type: "integer", nullable: true),
                    creatorname = table.Column<string>(type: "text", nullable: true),
                    creatordepartment = table.Column<string>(type: "text", nullable: true),
                    categoryid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("news_posts_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_news_posts_categories_categoryid",
                        column: x => x.categoryid,
                        principalSchema: "site_db",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "site_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValueSql: "''"),
                    password = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false, defaultValueSql: "''"),
                    role = table.Column<string>(type: "text", nullable: true),
                    otdelid = table.Column<int>(type: "int(11)", nullable: true),
                    question = table.Column<string>(type: "text", nullable: true),
                    answer = table.Column<string>(type: "text", nullable: true),
                    id_group = table.Column<short>(type: "smallint(6)", nullable: true),
                    id_post = table.Column<short>(type: "smallint(6)", nullable: false),
                    tabel = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    mail = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ban = table.Column<short>(type: "tinyint(4)", nullable: false),
                    ban_date = table.Column<DateTime>(type: "date", nullable: true),
                    ban_comment = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ban_amount = table.Column<short>(type: "tinyint(4)", nullable: false),
                    comedate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "время и дата загрузки чата")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_otdel_otdelid",
                        column: x => x.otdelid,
                        principalSchema: "site_db",
                        principalTable: "otdel",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_news_posts_categoryid",
                schema: "site_db",
                table: "news_posts",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_users_otdelid",
                schema: "site_db",
                table: "users",
                column: "otdelid");

            migrationBuilder.CreateIndex(
                name: "id",
                schema: "site_db",
                table: "workers",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id2",
                schema: "site_db",
                table: "workers_1otdel",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id3",
                schema: "site_db",
                table: "workers_empty",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id1",
                schema: "site_db",
                table: "workers18-06-2024",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity_log",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "departments",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201612",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201701",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201702",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201703",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201704",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201705",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201706",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201707",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201708",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201709",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201710",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201711",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201712",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201801",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201802",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201803",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201804",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201805",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201806",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201807",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201808",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201809",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201810",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201811",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201812",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201901",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201902",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201903",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201904",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201905",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201906",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201907",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201908",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201909",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201910",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201911",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_201912",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202001",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202002",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202003",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202004",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202005",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202006",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202007",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202008",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202009",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202010",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202011",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202012",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202101",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202102",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202103",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202104",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202105",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202106",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202107",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202108",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202109",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202110",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202111",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202112",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202201",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202202",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202203",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202204",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202205",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202206",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202207",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202208",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202209",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202210",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202211",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202212",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202301",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202302",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202303",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202304",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202305",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202306",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202307",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202308",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202309",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202310",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202311",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202312",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202401",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202402",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202403",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202404",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202405",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202406",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202407",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202408",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202409",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202410",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202411",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202412",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202501",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202502",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202503",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202504",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202505",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202506",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202507",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202508",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202509",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202510",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202511",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202512",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202601",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202602",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents_202603",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "documents-01-06-2021",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "news_posts",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "resources",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "user_sessions",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "users",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "workers",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "workers_1otdel",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "workers_copy",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "workers_empty",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "workers18-06-2024",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "zayavkatmc",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "site_db");

            migrationBuilder.DropTable(
                name: "otdel",
                schema: "site_db");
        }
    }
}
