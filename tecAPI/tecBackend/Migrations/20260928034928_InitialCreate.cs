using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tecBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "activity_log",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    action = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    subtitle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    actor_user_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
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
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_per_user = table.Column<int>(type: "integer", nullable: false),
                    id_user = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    id_resource = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<short>(type: "smallint", nullable: true),
                    date_first = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "'0001-01-01 00:00:00'"),
                    date_reshenie = table.Column<DateTime>(type: "timestamp", nullable: true),
                    user_reshenie = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Пользователь, который разрешил/отклонил заявку"),
                    comment_reshenie = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    action = table.Column<short>(type: "smallint", nullable: false),
                    id_receiver = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    archive = table.Column<short>(type: "smallint", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    made = table.Column<short>(type: "smallint", nullable: false),
                    date_vyp = table.Column<DateTime>(type: "timestamp", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "otdel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_otd = table.Column<short>(type: "smallint", nullable: false),
                    name_otd = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValueSql: "''"),
                    id_dep = table.Column<int>(type: "integer", nullable: true),
                    idotd_buhgalter = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_otdel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "resources",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    id_otd = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false, comment: "Код отдела, который исполняет эту заявку"),
                    id_parent = table.Column<short>(type: "smallint", nullable: true),
                    priznak = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false, comment: "1=замена, 2=установка")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_sessions",
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
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_workers", x => x.id);
                },
                comment: "Справочник сотрудников");

            migrationBuilder.CreateTable(
                name: "workers_1otdel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_workers_1otdel", x => x.id);
                },
                comment: "Справочник сотрудников");

            migrationBuilder.CreateTable(
                name: "workers_copy",
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
                    id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                },
                comment: "Справочник сотрудников");

            migrationBuilder.CreateTable(
                name: "workers_empty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_workers_empty", x => x.id);
                },
                comment: "Справочник сотрудников");

            migrationBuilder.CreateTable(
                name: "workers18-06-2024",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_workers18-06-2024", x => x.id);
                },
                comment: "Справочник сотрудников");

            migrationBuilder.CreateTable(
                name: "zayavkatmc",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(700)", maxLength: 700, nullable: false),
                    id_dep = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    date = table.Column<DateTime>(type: "timestamp", nullable: false),
                    action = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false, comment: "действие: 0-новая,1-прочитанная,2-выполненная,3-отложенная,4-отказная"),
                    dateAction = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "дата разрешения заявки"),
                    rem = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    sposob = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    kvartal = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    idOborud = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    idWork = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zayavkatmc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news_posts",
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
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValueSql: "''"),
                    password = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false, defaultValueSql: "''"),
                    role = table.Column<string>(type: "text", nullable: true),
                    otdelid = table.Column<int>(type: "integer", nullable: true),
                    question = table.Column<string>(type: "text", nullable: true),
                    answer = table.Column<string>(type: "text", nullable: true),
                    id_group = table.Column<short>(type: "smallint", nullable: true),
                    id_post = table.Column<short>(type: "smallint", nullable: false),
                    tabel = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    mail = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ban = table.Column<short>(type: "smallint", nullable: false),
                    ban_date = table.Column<DateTime>(type: "date", nullable: true),
                    ban_comment = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ban_amount = table.Column<short>(type: "smallint", nullable: false),
                    comedate = table.Column<DateTime>(type: "timestamp", nullable: true, comment: "время и дата загрузки чата")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_otdel_otdelid",
                        column: x => x.otdelid,
                        principalTable: "otdel",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_news_posts_categoryid",
                table: "news_posts",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_users_otdelid",
                table: "users",
                column: "otdelid");

            migrationBuilder.CreateIndex(
                name: "id",
                table: "workers",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id2",
                table: "workers_1otdel",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id3",
                table: "workers_empty",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id1",
                table: "workers18-06-2024",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity_log");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "documents");

            migrationBuilder.DropTable(
                name: "news_posts");

            migrationBuilder.DropTable(
                name: "resources");

            migrationBuilder.DropTable(
                name: "user_sessions");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "workers");

            migrationBuilder.DropTable(
                name: "workers_1otdel");

            migrationBuilder.DropTable(
                name: "workers_copy");

            migrationBuilder.DropTable(
                name: "workers_empty");

            migrationBuilder.DropTable(
                name: "workers18-06-2024");

            migrationBuilder.DropTable(
                name: "zayavkatmc");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "otdel");
        }
    }
}
