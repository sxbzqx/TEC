using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tecBackend.Models;

//

#region

public partial class SiteContext : DbContext
{
    public SiteContext() { }

    public SiteContext(DbContextOptions<SiteContext> options)
        : base(options) { }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

    public virtual DbSet<Announ> Announs { get; set; }

    public virtual DbSet<AnnounOld> AnnounOlds { get; set; }

    public virtual DbSet<Archiveld> Archivelds { get; set; }

    public virtual DbSet<Archivelk> Archivelks { get; set; }

    public virtual DbSet<BiznesplanVariant> BiznesplanVariants { get; set; }

    public virtual DbSet<BiznesplanoksVariant> BiznesplanoksVariants { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CompsHistory> CompsHistories { get; set; }

    public virtual DbSet<Computer> Computers { get; set; }

    public virtual DbSet<ComputersOriginaldo31012022> ComputersOriginaldo31012022s { get; set; }

    public virtual DbSet<ComputersSpisano> ComputersSpisanos { get; set; }

    public virtual DbSet<ComputersSpisanoDel> ComputersSpisanoDels { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Documents01062021> Documents01062021s { get; set; }

    public virtual DbSet<Documents201612> Documents201612s { get; set; }

    public virtual DbSet<Documents201701> Documents201701s { get; set; }

    public virtual DbSet<Documents201702> Documents201702s { get; set; }

    public virtual DbSet<Documents201703> Documents201703s { get; set; }

    public virtual DbSet<Documents201704> Documents201704s { get; set; }

    public virtual DbSet<Documents201705> Documents201705s { get; set; }

    public virtual DbSet<Documents201706> Documents201706s { get; set; }

    public virtual DbSet<Documents201707> Documents201707s { get; set; }

    public virtual DbSet<Documents201708> Documents201708s { get; set; }

    public virtual DbSet<Documents201709> Documents201709s { get; set; }

    public virtual DbSet<Documents201710> Documents201710s { get; set; }

    public virtual DbSet<Documents201711> Documents201711s { get; set; }

    public virtual DbSet<Documents201712> Documents201712s { get; set; }

    public virtual DbSet<Documents201801> Documents201801s { get; set; }

    public virtual DbSet<Documents201802> Documents201802s { get; set; }

    public virtual DbSet<Documents201803> Documents201803s { get; set; }

    public virtual DbSet<Documents201804> Documents201804s { get; set; }

    public virtual DbSet<Documents201805> Documents201805s { get; set; }

    public virtual DbSet<Documents201806> Documents201806s { get; set; }

    public virtual DbSet<Documents201807> Documents201807s { get; set; }

    public virtual DbSet<Documents201808> Documents201808s { get; set; }

    public virtual DbSet<Documents201809> Documents201809s { get; set; }

    public virtual DbSet<Documents201810> Documents201810s { get; set; }

    public virtual DbSet<Documents201811> Documents201811s { get; set; }

    public virtual DbSet<Documents201812> Documents201812s { get; set; }

    public virtual DbSet<Documents201901> Documents201901s { get; set; }

    public virtual DbSet<Documents201902> Documents201902s { get; set; }

    public virtual DbSet<Documents201903> Documents201903s { get; set; }

    public virtual DbSet<Documents201904> Documents201904s { get; set; }

    public virtual DbSet<Documents201905> Documents201905s { get; set; }

    public virtual DbSet<Documents201906> Documents201906s { get; set; }

    public virtual DbSet<Documents201907> Documents201907s { get; set; }

    public virtual DbSet<Documents201908> Documents201908s { get; set; }

    public virtual DbSet<Documents201909> Documents201909s { get; set; }

    public virtual DbSet<Documents201910> Documents201910s { get; set; }

    public virtual DbSet<Documents201911> Documents201911s { get; set; }

    public virtual DbSet<Documents201912> Documents201912s { get; set; }

    public virtual DbSet<Documents202001> Documents202001s { get; set; }

    public virtual DbSet<Documents202002> Documents202002s { get; set; }

    public virtual DbSet<Documents202003> Documents202003s { get; set; }

    public virtual DbSet<Documents202004> Documents202004s { get; set; }

    public virtual DbSet<Documents202005> Documents202005s { get; set; }

    public virtual DbSet<Documents202006> Documents202006s { get; set; }

    public virtual DbSet<Documents202007> Documents202007s { get; set; }

    public virtual DbSet<Documents202008> Documents202008s { get; set; }

    public virtual DbSet<Documents202009> Documents202009s { get; set; }

    public virtual DbSet<Documents202010> Documents202010s { get; set; }

    public virtual DbSet<Documents202011> Documents202011s { get; set; }

    public virtual DbSet<Documents202012> Documents202012s { get; set; }

    public virtual DbSet<Documents202101> Documents202101s { get; set; }

    public virtual DbSet<Documents202102> Documents202102s { get; set; }

    public virtual DbSet<Documents202103> Documents202103s { get; set; }

    public virtual DbSet<Documents202104> Documents202104s { get; set; }

    public virtual DbSet<Documents202105> Documents202105s { get; set; }

    public virtual DbSet<Documents202106> Documents202106s { get; set; }

    public virtual DbSet<Documents202107> Documents202107s { get; set; }

    public virtual DbSet<Documents202108> Documents202108s { get; set; }

    public virtual DbSet<Documents202109> Documents202109s { get; set; }

    public virtual DbSet<Documents202110> Documents202110s { get; set; }

    public virtual DbSet<Documents202111> Documents202111s { get; set; }

    public virtual DbSet<Documents202112> Documents202112s { get; set; }

    public virtual DbSet<Documents202201> Documents202201s { get; set; }

    public virtual DbSet<Documents202202> Documents202202s { get; set; }

    public virtual DbSet<Documents202203> Documents202203s { get; set; }

    public virtual DbSet<Documents202204> Documents202204s { get; set; }

    public virtual DbSet<Documents202205> Documents202205s { get; set; }

    public virtual DbSet<Documents202206> Documents202206s { get; set; }

    public virtual DbSet<Documents202207> Documents202207s { get; set; }

    public virtual DbSet<Documents202208> Documents202208s { get; set; }

    public virtual DbSet<Documents202209> Documents202209s { get; set; }

    public virtual DbSet<Documents202210> Documents202210s { get; set; }

    public virtual DbSet<Documents202211> Documents202211s { get; set; }

    public virtual DbSet<Documents202212> Documents202212s { get; set; }

    public virtual DbSet<Documents202301> Documents202301s { get; set; }

    public virtual DbSet<Documents202302> Documents202302s { get; set; }

    public virtual DbSet<Documents202303> Documents202303s { get; set; }

    public virtual DbSet<Documents202304> Documents202304s { get; set; }

    public virtual DbSet<Documents202305> Documents202305s { get; set; }

    public virtual DbSet<Documents202306> Documents202306s { get; set; }

    public virtual DbSet<Documents202307> Documents202307s { get; set; }

    public virtual DbSet<Documents202308> Documents202308s { get; set; }

    public virtual DbSet<Documents202309> Documents202309s { get; set; }

    public virtual DbSet<Documents202310> Documents202310s { get; set; }

    public virtual DbSet<Documents202311> Documents202311s { get; set; }

    public virtual DbSet<Documents202312> Documents202312s { get; set; }

    public virtual DbSet<Documents202401> Documents202401s { get; set; }

    public virtual DbSet<Documents202402> Documents202402s { get; set; }

    public virtual DbSet<Documents202403> Documents202403s { get; set; }

    public virtual DbSet<Documents202404> Documents202404s { get; set; }

    public virtual DbSet<Documents202405> Documents202405s { get; set; }

    public virtual DbSet<Documents202406> Documents202406s { get; set; }

    public virtual DbSet<Documents202407> Documents202407s { get; set; }

    public virtual DbSet<Documents202408> Documents202408s { get; set; }

    public virtual DbSet<Documents202409> Documents202409s { get; set; }

    public virtual DbSet<Documents202410> Documents202410s { get; set; }

    public virtual DbSet<Documents202411> Documents202411s { get; set; }

    public virtual DbSet<Documents202412> Documents202412s { get; set; }

    public virtual DbSet<Documents202501> Documents202501s { get; set; }

    public virtual DbSet<Documents202502> Documents202502s { get; set; }

    public virtual DbSet<Documents202503> Documents202503s { get; set; }

    public virtual DbSet<Documents202504> Documents202504s { get; set; }

    public virtual DbSet<Documents202505> Documents202505s { get; set; }

    public virtual DbSet<Documents202506> Documents202506s { get; set; }

    public virtual DbSet<Documents202507> Documents202507s { get; set; }

    public virtual DbSet<Documents202508> Documents202508s { get; set; }

    public virtual DbSet<Documents202509> Documents202509s { get; set; }

    public virtual DbSet<Documents202510> Documents202510s { get; set; }

    public virtual DbSet<Documents202511> Documents202511s { get; set; }

    public virtual DbSet<Documents202512> Documents202512s { get; set; }

    public virtual DbSet<Documents202601> Documents202601s { get; set; }

    public virtual DbSet<Documents202602> Documents202602s { get; set; }

    public virtual DbSet<Documents202603> Documents202603s { get; set; }

    public virtual DbSet<Gallery> Galleries { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Link> Links { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Movement> Movements { get; set; }

    public virtual DbSet<MovementsDo31012022> MovementsDo31012022s { get; set; }

    public virtual DbSet<MovementsSpisano> MovementsSpisanos { get; set; }

    public virtual DbSet<Oborotki> Oborotkis { get; set; }

    public virtual DbSet<OfficeOborud> OfficeOboruds { get; set; }

    public virtual DbSet<OfficeRepair> OfficeRepairs { get; set; }

    public virtual DbSet<OfficeRepairDo31012022> OfficeRepairDo31012022s { get; set; }

    public virtual DbSet<OfficeRepairSpisano> OfficeRepairSpisanos { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Ordertype> Ordertypes { get; set; }

    public virtual DbSet<Otdel> Otdels { get; set; }

    public virtual DbSet<PerMe> PerMes { get; set; }

    public virtual DbSet<PerifHistory> PerifHistories { get; set; }

    public virtual DbSet<Perifer> Perifers { get; set; }

    public virtual DbSet<Perifer01022022> Perifer01022022s { get; set; }

    public virtual DbSet<PeriferSpisano> PeriferSpisanos { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<Right> Rights { get; set; }

    public virtual DbSet<RightsDel> RightsDels { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Sootv> Sootvs { get; set; }

    public virtual DbSet<SootvOldForDel> SootvOldForDels { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<StatisticMonth> StatisticMonths { get; set; }

    public virtual DbSet<StatisticYear> StatisticYears { get; set; }

    public virtual DbSet<StatisticYear2023> StatisticYear2023s { get; set; }

    public virtual DbSet<Techdoc> Techdocs { get; set; }

    public virtual DbSet<TypeDoc> TypeDocs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSession> UserSessions { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    public virtual DbSet<Workers18062024> Workers18062024s { get; set; }

    public virtual DbSet<Workers1otdel> Workers1otdels { get; set; }

    public virtual DbSet<WorkersCopy> WorkersCopies { get; set; }

    public virtual DbSet<WorkersEmpty> WorkersEmpties { get; set; }

    public virtual DbSet<Zayavkatmc> Zayavkatmcs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("site_db");

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName()?.ToLowerInvariant());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToLowerInvariant());
            }
        }

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admin");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity.Property(e => e.Answer).HasColumnType("text").HasColumnName("answer");
            entity.Property(e => e.Login).HasColumnType("text").HasColumnName("login");
            entity.Property(e => e.Name).HasColumnType("text").HasColumnName("name");
            entity.Property(e => e.Password).HasColumnType("text").HasColumnName("password");
            entity.Property(e => e.Question).HasColumnType("text").HasColumnName("question");
        });

        modelBuilder.Entity<Announ>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("announ");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity
                .Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.IdAuthor).HasColumnType("int(11)").HasColumnName("id_author");
            entity
                .Property(e => e.IdAuthorEdit)
                .HasColumnType("int(11)")
                .HasColumnName("id_author_edit");
            entity.Property(e => e.Name).HasColumnType("text").HasColumnName("name");
            entity.Property(e => e.Text).HasColumnType("text").HasColumnName("text");
        });

        modelBuilder.Entity<AnnounOld>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("announ_old");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity
                .Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.IdAuthor).HasColumnType("int(11)").HasColumnName("id_author");
            entity
                .Property(e => e.IdAuthorEdit)
                .HasColumnType("int(11)")
                .HasColumnName("id_author_edit");
            entity.Property(e => e.Name).HasColumnType("text").HasColumnName("name");
            entity.Property(e => e.Text).HasColumnType("text").HasColumnName("text");
        });

        modelBuilder.Entity<Archiveld>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("archiveld");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Comment).HasMaxLength(500).HasColumnName("comment");
            entity.Property(e => e.DatePriem).HasColumnType("date").HasColumnName("datePRIEM");
            entity.Property(e => e.DateUvol).HasColumnType("date").HasColumnName("dateUVOL");
            entity.Property(e => e.Fio).HasMaxLength(100).HasColumnName("FIO");
            entity
                .Property(e => e.KodOk)
                .HasComment("ссылка на таблицу уволенных OK_TESB")
                .HasColumnType("int(11)")
                .HasColumnName("kod_OK");
            entity.Property(e => e.Tabel).HasMaxLength(5).HasColumnName("tabel");
        });

        modelBuilder.Entity<Archivelk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("archivelk");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Comment).HasMaxLength(500).HasColumnName("comment");
            entity.Property(e => e.DatePriem).HasColumnType("date").HasColumnName("datePRIEM");
            entity.Property(e => e.DateUvol).HasColumnType("date").HasColumnName("dateUVOL");
            entity.Property(e => e.Fio).HasMaxLength(100).HasColumnName("FIO");
            entity
                .Property(e => e.KodOk)
                .HasComment("ссылка на таблицу уволенных OK_TESB")
                .HasColumnType("int(11)")
                .HasColumnName("kod_OK");
            entity.Property(e => e.Tabel).HasMaxLength(5).HasColumnName("tabel");
        });

        modelBuilder.Entity<BiznesplanVariant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("biznesplan_variants");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Comment).HasMaxLength(400).HasColumnName("comment");
            entity
                .Property(e => e.Datecreate)
                .HasComment("дата создания копии БП")
                .HasColumnType("datetime")
                .HasColumnName("datecreate");
            entity
                .Property(e => e.Main)
                .HasMaxLength(1)
                .HasComment("=1 -тот БП, с которым работаем сейчас")
                .HasColumnName("main");
            entity
                .Property(e => e.TypeBp)
                .HasMaxLength(1)
                .HasComment("ТИП БП: 1 - Ремонты, 2 - ОКС")
                .HasColumnName("type_bp");
            entity.Property(e => e.Variant).HasColumnType("tinyint(4)").HasColumnName("variant");
            entity.Property(e => e.Year).HasMaxLength(4).HasColumnName("year");
        });

        modelBuilder.Entity<BiznesplanoksVariant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("biznesplanoks_variants");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Comment).HasMaxLength(400).HasColumnName("comment");
            entity
                .Property(e => e.Datecreate)
                .HasComment("дата создания копии БП")
                .HasColumnType("datetime")
                .HasColumnName("datecreate");
            entity
                .Property(e => e.Main)
                .HasMaxLength(1)
                .HasComment("=1 -тот БП, с которым работаем сейчас")
                .HasColumnName("main");
            entity
                .Property(e => e.TypeBp)
                .HasMaxLength(1)
                .HasComment("ТИП БП: 1 - Ремонты, 2 - ОКС")
                .HasColumnName("type_bp");
            entity.Property(e => e.Variant).HasColumnType("tinyint(4)").HasColumnName("variant");
            entity.Property(e => e.Year).HasMaxLength(4).HasColumnName("year");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("chat");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Date).HasColumnType("datetime").HasColumnName("date");
            entity.Property(e => e.Message).HasColumnType("text").HasColumnName("message");
            entity.Property(e => e.User).HasColumnType("int(11)").HasColumnName("user");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("comments");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Comment1).HasColumnType("text").HasColumnName("comment");
            entity.Property(e => e.Date).HasColumnType("datetime").HasColumnName("date");
            entity.Property(e => e.DateEdit).HasColumnType("datetime").HasColumnName("date_edit");
            entity.Property(e => e.FioUser).HasMaxLength(100).HasColumnName("fio_user");
            entity.Property(e => e.FioUserEdit).HasMaxLength(100);
            entity.Property(e => e.IdState).HasColumnType("smallint(6)").HasColumnName("id_state");
            entity.Property(e => e.IdUser).HasColumnType("smallint(6)").HasColumnName("id_user");
            entity.Property(e => e.ReasonEdit).HasMaxLength(150);
        });

        modelBuilder.Entity<CompsHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("comps_history");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity
                .Property(e => e.Date)
                .HasComment("дата изменения")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity
                .Property(e => e.Field)
                .HasMaxLength(20)
                .HasComment("имя столбца")
                .HasColumnName("field");
            entity
                .Property(e => e.IdStr)
                .HasComment("id записи в таблице")
                .HasColumnType("smallint(6)")
                .HasColumnName("id_str");
            entity
                .Property(e => e.New)
                .HasMaxLength(150)
                .HasComment("новое значение")
                .HasColumnName("new");
            entity
                .Property(e => e.Old)
                .HasMaxLength(150)
                .HasComment("старое значение")
                .HasColumnName("old");
            entity
                .Property(e => e.User)
                .HasMaxLength(100)
                .HasComment("ФИО изменившего пользователя")
                .HasColumnName("user");
        });

        modelBuilder.Entity<Computer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("computers");

            entity.Property(e => e.Id).HasColumnType("smallint(11)").HasColumnName("id");
            entity.Property(e => e.Audio).HasMaxLength(100).HasColumnName("audio");
            entity.Property(e => e.Cpu).HasMaxLength(255).HasColumnName("cpu");
            entity.Property(e => e.DateEdit).HasColumnType("datetime").HasColumnName("date_edit");
            entity
                .Property(e => e.DopInfo)
                .HasMaxLength(255)
                .HasComment("доп. информация, комментарий")
                .HasColumnName("dopInfo");
            entity.Property(e => e.Fdd).HasMaxLength(10).HasColumnName("fdd");
            entity.Property(e => e.Hdd1).HasMaxLength(100).HasColumnName("hdd_1");
            entity.Property(e => e.Hdd2).HasMaxLength(100).HasColumnName("hdd_2");
            entity.Property(e => e.IdOtd).HasMaxLength(4).HasColumnName("id_otd");
            entity
                .Property(e => e.InputMonth)
                .HasColumnType("smallint(2)")
                .HasColumnName("input_month");
            entity
                .Property(e => e.InputYear)
                .HasColumnType("smallint(4)")
                .HasColumnName("input_year");
            entity.Property(e => e.InvNum).HasMaxLength(15).HasColumnName("inv_num");
            entity
                .Property(e => e.LastUserEdit)
                .HasMaxLength(5)
                .HasComment("юзер, который внёс последнюю информацию")
                .HasColumnName("last_user_edit");
            entity.Property(e => e.Monitor).HasMaxLength(10).HasColumnName("monitor");
            entity
                .Property(e => e.Motherboard)
                .HasMaxLength(50)
                .HasComment("мат.плата")
                .HasColumnName("motherboard");
            entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            entity.Property(e => e.NameObj).HasMaxLength(50).HasColumnName("name_obj");
            entity
                .Property(e => e.Nout)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasComment("если комп=0, если ноут=1")
                .HasColumnName("nout");
            entity.Property(e => e.Optical1).HasMaxLength(255).HasColumnName("optical_1");
            entity.Property(e => e.Phone).HasMaxLength(20).HasColumnName("phone");
            entity
                .Property(e => e.PowerUnit)
                .HasMaxLength(50)
                .HasComment("блок питания")
                .HasColumnName("powerUnit");
            entity.Property(e => e.Ram1).HasMaxLength(10).HasColumnName("ram_1");
            entity.Property(e => e.Ram2).HasMaxLength(10).HasColumnName("ram_2");
            entity.Property(e => e.Speakers).HasMaxLength(10).HasColumnName("speakers");
            entity.Property(e => e.UserDep).HasMaxLength(50).HasColumnName("user_dep");
            entity.Property(e => e.UserFio).HasMaxLength(5).HasColumnName("user_fio");
            entity.Property(e => e.Video).HasMaxLength(255).HasColumnName("video");
        });

        modelBuilder.Entity<ComputersOriginaldo31012022>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("computers_originaldo31-01-2022");

            entity.Property(e => e.Id).HasColumnType("smallint(11)").HasColumnName("id");
            entity.Property(e => e.Audio).HasMaxLength(10).HasColumnName("audio");
            entity.Property(e => e.Cpu).HasMaxLength(255).HasColumnName("cpu");
            entity.Property(e => e.Fdd).HasMaxLength(10).HasColumnName("fdd");
            entity.Property(e => e.Hdd1).HasMaxLength(10).HasColumnName("hdd_1");
            entity.Property(e => e.Hdd2).HasMaxLength(10).HasColumnName("hdd_2");
            entity.Property(e => e.IdOtd).HasMaxLength(4).HasColumnName("id_otd");
            entity
                .Property(e => e.InputMonth)
                .HasColumnType("smallint(2)")
                .HasColumnName("input_month");
            entity
                .Property(e => e.InputYear)
                .HasColumnType("smallint(4)")
                .HasColumnName("input_year");
            entity.Property(e => e.InvNum).HasColumnType("int(15)").HasColumnName("inv_num");
            entity.Property(e => e.Monitor).HasMaxLength(10).HasColumnName("monitor");
            entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            entity.Property(e => e.NameObj).HasMaxLength(50).HasColumnName("name_obj");
            entity
                .Property(e => e.Nout)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasComment("если комп=0, если ноут=1")
                .HasColumnName("nout");
            entity.Property(e => e.Optical1).HasMaxLength(255).HasColumnName("optical_1");
            entity.Property(e => e.Ram1).HasMaxLength(10).HasColumnName("ram_1");
            entity.Property(e => e.Ram2).HasMaxLength(10).HasColumnName("ram_2");
            entity.Property(e => e.Speakers).HasMaxLength(10).HasColumnName("speakers");
            entity.Property(e => e.UserDep).HasMaxLength(50).HasColumnName("user_dep");
            entity.Property(e => e.UserFio).HasMaxLength(5).HasColumnName("user_fio");
            entity.Property(e => e.Video).HasMaxLength(255).HasColumnName("video");
        });

        modelBuilder.Entity<ComputersSpisano>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("computers_spisano");

            entity.Property(e => e.Id).HasColumnType("smallint(11)").HasColumnName("id");
            entity.Property(e => e.Audio).HasMaxLength(100).HasColumnName("audio");
            entity.Property(e => e.Cpu).HasMaxLength(255).HasColumnName("cpu");
            entity.Property(e => e.DateEdit).HasColumnType("datetime").HasColumnName("date_edit");
            entity
                .Property(e => e.DopInfo)
                .HasMaxLength(255)
                .HasComment("доп. информация, комментарий")
                .HasColumnName("dopInfo");
            entity.Property(e => e.Fdd).HasMaxLength(10).HasColumnName("fdd");
            entity.Property(e => e.Hdd1).HasMaxLength(100).HasColumnName("hdd_1");
            entity.Property(e => e.Hdd2).HasMaxLength(100).HasColumnName("hdd_2");
            entity.Property(e => e.IdOtd).HasMaxLength(4).HasColumnName("id_otd");
            entity
                .Property(e => e.InputMonth)
                .HasColumnType("smallint(2)")
                .HasColumnName("input_month");
            entity
                .Property(e => e.InputYear)
                .HasColumnType("smallint(4)")
                .HasColumnName("input_year");
            entity.Property(e => e.InvNum).HasColumnType("int(15)").HasColumnName("inv_num");
            entity
                .Property(e => e.LastUserEdit)
                .HasMaxLength(5)
                .HasComment("юзер, который внёс последнюю информацию")
                .HasColumnName("last_user_edit");
            entity.Property(e => e.Monitor).HasMaxLength(10).HasColumnName("monitor");
            entity
                .Property(e => e.Motherboard)
                .HasMaxLength(50)
                .HasComment("мат.плата")
                .HasColumnName("motherboard");
            entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            entity.Property(e => e.NameObj).HasMaxLength(50).HasColumnName("name_obj");
            entity
                .Property(e => e.Nout)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasComment("если комп=0, если ноут=1")
                .HasColumnName("nout");
            entity.Property(e => e.Optical1).HasMaxLength(255).HasColumnName("optical_1");
            entity.Property(e => e.Phone).HasMaxLength(20).HasColumnName("phone");
            entity
                .Property(e => e.PowerUnit)
                .HasMaxLength(50)
                .HasComment("блок питания")
                .HasColumnName("powerUnit");
            entity.Property(e => e.Ram1).HasMaxLength(10).HasColumnName("ram_1");
            entity.Property(e => e.Ram2).HasMaxLength(10).HasColumnName("ram_2");
            entity.Property(e => e.Speakers).HasMaxLength(10).HasColumnName("speakers");
            entity.Property(e => e.UserDep).HasMaxLength(50).HasColumnName("user_dep");
            entity.Property(e => e.UserFio).HasMaxLength(5).HasColumnName("user_fio");
            entity.Property(e => e.Video).HasMaxLength(255).HasColumnName("video");
        });

        modelBuilder.Entity<ComputersSpisanoDel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("computers_spisano_del");

            entity.Property(e => e.Id).HasColumnType("smallint(11)").HasColumnName("id");
            entity.Property(e => e.Audio).HasMaxLength(100).HasColumnName("audio");
            entity.Property(e => e.Cpu).HasMaxLength(255).HasColumnName("cpu");
            entity.Property(e => e.DateEdit).HasColumnType("datetime").HasColumnName("date_edit");
            entity
                .Property(e => e.DopInfo)
                .HasMaxLength(255)
                .HasComment("доп. информация, комментарий")
                .HasColumnName("dopInfo");
            entity.Property(e => e.Fdd).HasMaxLength(10).HasColumnName("fdd");
            entity.Property(e => e.Hdd1).HasMaxLength(100).HasColumnName("hdd_1");
            entity.Property(e => e.Hdd2).HasMaxLength(100).HasColumnName("hdd_2");
            entity.Property(e => e.IdOtd).HasMaxLength(4).HasColumnName("id_otd");
            entity
                .Property(e => e.InputMonth)
                .HasColumnType("smallint(2)")
                .HasColumnName("input_month");
            entity
                .Property(e => e.InputYear)
                .HasColumnType("smallint(4)")
                .HasColumnName("input_year");
            entity.Property(e => e.InvNum).HasColumnType("int(15)").HasColumnName("inv_num");
            entity
                .Property(e => e.LastUserEdit)
                .HasMaxLength(5)
                .HasComment("юзер, который внёс последнюю информацию")
                .HasColumnName("last_user_edit");
            entity.Property(e => e.Monitor).HasMaxLength(10).HasColumnName("monitor");
            entity
                .Property(e => e.Motherboard)
                .HasMaxLength(50)
                .HasComment("мат.плата")
                .HasColumnName("motherboard");
            entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            entity.Property(e => e.NameObj).HasMaxLength(50).HasColumnName("name_obj");
            entity
                .Property(e => e.Nout)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasComment("если комп=0, если ноут=1")
                .HasColumnName("nout");
            entity.Property(e => e.Optical1).HasMaxLength(255).HasColumnName("optical_1");
            entity.Property(e => e.Phone).HasMaxLength(20).HasColumnName("phone");
            entity
                .Property(e => e.PowerUnit)
                .HasMaxLength(50)
                .HasComment("блок питания")
                .HasColumnName("powerUnit");
            entity.Property(e => e.Ram1).HasMaxLength(10).HasColumnName("ram_1");
            entity.Property(e => e.Ram2).HasMaxLength(10).HasColumnName("ram_2");
            entity.Property(e => e.Speakers).HasMaxLength(10).HasColumnName("speakers");
            entity.Property(e => e.UserDep).HasMaxLength(50).HasColumnName("user_dep");
            entity.Property(e => e.UserFio).HasMaxLength(5).HasColumnName("user_fio");
            entity.Property(e => e.Video).HasMaxLength(255).HasColumnName("video");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("departments");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity.Property(e => e.Name).HasColumnType("text").HasColumnName("name");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents01062021>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents-01-06-2021");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201612>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201612");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201701>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201701");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201702>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201702");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201703>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201703");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201704>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201704");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201705>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201705");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201706>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201706");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201707>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201707");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201708>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201708");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201709>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201709");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201710>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201710");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201711>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201711");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201712>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201712");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201801>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201801");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201802>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201802");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201803>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201803");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201804>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201804");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201805>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201805");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201806>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201806");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("date")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("date").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201807>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201807");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201808>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201808");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201809>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201809");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
        });

        modelBuilder.Entity<Documents201810>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201810");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201811>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201811");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201812>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201812");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201901>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201901");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201902>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201902");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201903>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201903");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201904>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201904");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201905>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201905");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201906>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201906");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201907>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201907");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201908>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201908");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201909>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201909");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201910>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201910");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201911>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201911");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents201912>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_201912");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202001>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202001");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202002>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202002");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202003>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202003");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202004>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202004");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202005>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202005");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202006>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202006");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202007>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202007");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202008>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202008");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202009>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202009");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202010>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202010");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202011>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202011");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202012>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202012");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202101>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202101");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202102>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202102");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202103>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202103");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202104>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202104");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202105>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202105");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202106>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202106");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202107>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202107");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202108>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202108");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202109>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202109");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202110>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202110");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202111>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202111");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202112>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202112");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202201>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202201");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202202>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202202");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202203>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202203");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202204>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202204");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202205>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202205");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202206>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202206");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202207>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202207");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202208>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202208");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202209>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202209");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202210>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202210");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202211>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202211");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202212>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202212");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202301>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202301");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202302>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202302");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202303>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202303");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202304>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202304");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202305>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202305");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202306>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202306");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202307>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202307");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202308>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202308");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202309>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202309");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202310>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202310");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202311>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202311");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202312>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202312");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202401>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202401");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202402>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202402");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202403>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202403");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202404>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202404");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202405>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202405");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202406>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202406");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202407>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202407");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202408>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202408");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202409>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202409");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202410>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202410");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202411>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202411");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202412>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202412");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202501>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202501");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202502>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202502");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202503>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202503");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202504>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202504");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202505>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202505");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202506>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202506");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202507>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202507");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202508>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202508");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202509>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202509");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202510>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202510");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202511>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202511");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202512>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202512");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202601>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202601");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202602>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202602");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Documents202603>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documents_202603");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint(6)").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint(6)").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0000-00-00 00:00:00'")
                .HasColumnType("datetime")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("datetime")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("datetime").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("int(11)").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint(6)").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Gallery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("gallery");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity.Property(e => e.DateAdd).HasColumnType("date").HasColumnName("date_add");
            entity.Property(e => e.Directory).HasMaxLength(50).HasColumnName("directory");
            entity.Property(e => e.IdState).HasColumnType("smallint(6)").HasColumnName("id_state");
            entity.Property(e => e.NameFolder).HasMaxLength(50).HasColumnName("name_folder");
            entity.Property(e => e.NameGallery).HasMaxLength(50).HasColumnName("name_gallery");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("groups");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(20).HasColumnName("name");
        });

        modelBuilder.Entity<Link>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("links");

            entity.Property(e => e.Id).HasColumnType("tinyint(4)").HasColumnName("id");
            entity.Property(e => e.IdGroup).HasColumnName("id_group");
            entity.Property(e => e.IdGroupAll).HasMaxLength(100).HasColumnName("id_groupAll");
            entity.Property(e => e.Link1).HasMaxLength(150).HasColumnName("link");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.Nn).HasColumnType("tinyint(4)").HasColumnName("nn");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("messages");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity
                .Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.IdAuthor).HasColumnType("int(11)").HasColumnName("id_author");
            entity.Property(e => e.Text).HasColumnType("text").HasColumnName("text");
        });

        modelBuilder.Entity<Movement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("movements");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity.Property(e => e.FromDep).HasMaxLength(4).HasColumnName("from_dep");
            entity.Property(e => e.FromNetname).HasMaxLength(50).HasColumnName("from_netname");
            entity.Property(e => e.FromUser).HasMaxLength(50).HasColumnName("from_user");
            entity.Property(e => e.FromUserFio).HasMaxLength(5).HasColumnName("from_user_fio");
            entity.Property(e => e.IdUstr).HasColumnType("int(11)").HasColumnName("id_ustr");
            entity.Property(e => e.IntoDep).HasMaxLength(4).HasColumnName("into_dep");
            entity.Property(e => e.IntoNetname).HasMaxLength(50).HasColumnName("into_netname");
            entity.Property(e => e.IntoUser).HasMaxLength(50).HasColumnName("into_user");
            entity.Property(e => e.IntoUserFio).HasMaxLength(5).HasColumnName("into_user_fio");
            entity.Property(e => e.InvNum).HasColumnType("int(10)").HasColumnName("inv_num");
            entity.Property(e => e.MoveDate).HasColumnType("date").HasColumnName("move_date");
            entity.Property(e => e.MoveUser).HasMaxLength(5).HasColumnName("move_user");
            entity.Property(e => e.TypeUstr).HasMaxLength(10).HasColumnName("type_ustr");
        });

        modelBuilder.Entity<MovementsDo31012022>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("movements_do31-01-2022");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity.Property(e => e.FromDep).HasMaxLength(4).HasColumnName("from_dep");
            entity.Property(e => e.FromNetname).HasMaxLength(50).HasColumnName("from_netname");
            entity.Property(e => e.FromUser).HasMaxLength(50).HasColumnName("from_user");
            entity.Property(e => e.FromUserFio).HasMaxLength(5).HasColumnName("from_user_fio");
            entity.Property(e => e.IdUstr).HasColumnType("int(11)").HasColumnName("id_ustr");
            entity.Property(e => e.IntoDep).HasMaxLength(4).HasColumnName("into_dep");
            entity.Property(e => e.IntoNetname).HasMaxLength(50).HasColumnName("into_netname");
            entity.Property(e => e.IntoUser).HasMaxLength(50).HasColumnName("into_user");
            entity.Property(e => e.IntoUserFio).HasMaxLength(5).HasColumnName("into_user_fio");
            entity.Property(e => e.InvNum).HasColumnType("int(10)").HasColumnName("inv_num");
            entity.Property(e => e.MoveDate).HasColumnType("date").HasColumnName("move_date");
            entity.Property(e => e.TypeUstr).HasMaxLength(10).HasColumnName("type_ustr");
        });

        modelBuilder.Entity<MovementsSpisano>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("movements_spisano");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity.Property(e => e.FromDep).HasMaxLength(4).HasColumnName("from_dep");
            entity.Property(e => e.FromNetname).HasMaxLength(50).HasColumnName("from_netname");
            entity.Property(e => e.FromUser).HasMaxLength(50).HasColumnName("from_user");
            entity.Property(e => e.FromUserFio).HasMaxLength(5).HasColumnName("from_user_fio");
            entity.Property(e => e.IdUstr).HasColumnType("int(11)").HasColumnName("id_ustr");
            entity.Property(e => e.IntoDep).HasMaxLength(4).HasColumnName("into_dep");
            entity.Property(e => e.IntoNetname).HasMaxLength(50).HasColumnName("into_netname");
            entity.Property(e => e.IntoUser).HasMaxLength(50).HasColumnName("into_user");
            entity.Property(e => e.IntoUserFio).HasMaxLength(5).HasColumnName("into_user_fio");
            entity.Property(e => e.InvNum).HasColumnType("int(10)").HasColumnName("inv_num");
            entity.Property(e => e.MoveDate).HasColumnType("date").HasColumnName("move_date");
            entity.Property(e => e.MoveUser).HasMaxLength(5).HasColumnName("move_user");
            entity.Property(e => e.TypeUstr).HasMaxLength(10).HasColumnName("type_ustr");
        });

        modelBuilder.Entity<Oborotki>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("oborotki");

            entity.HasIndex(e => e.Name, "name");

            entity.HasIndex(e => e.Otdel, "otdel");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity
                .Property(e => e.AmountKonec)
                .HasComment("Количество")
                .HasColumnName("amount_konec");
            entity
                .Property(e => e.AmountNa4alo)
                .HasComment("Количество")
                .HasColumnName("amount_na4alo");
            entity
                .Property(e => e.AmountPrihod)
                .HasComment("Количество")
                .HasColumnName("amount_prihod");
            entity
                .Property(e => e.AmountRashod)
                .HasComment("Количество")
                .HasColumnName("amount_rashod");
            entity.Property(e => e.Cena).HasComment("Цена").HasColumnName("cena");
            entity
                .Property(e => e.Date)
                .HasMaxLength(10)
                .HasComment("Дата поступления")
                .HasColumnName("date");
            entity
                .Property(e => e.Edizm)
                .HasMaxLength(15)
                .HasComment("Ед.изм.")
                .HasColumnName("edizm");
            entity
                .Property(e => e.Name)
                .HasMaxLength(60)
                .HasComment("Наименование")
                .HasColumnName("name");
            entity
                .Property(e => e.Number)
                .HasMaxLength(7)
                .HasComment("Ном.№")
                .HasColumnName("number");
            entity
                .Property(e => e.Otdel)
                .HasMaxLength(50)
                .HasComment("Подразделение")
                .HasColumnName("otdel");
            entity
                .Property(e => e.Schet)
                .HasMaxLength(60)
                .HasComment("Счет")
                .HasColumnName("schet");
            entity.Property(e => e.SummaKonec).HasComment("Сумма").HasColumnName("summa_konec");
            entity.Property(e => e.SummaNa4alo).HasComment("Сумма").HasColumnName("summa_na4alo");
            entity.Property(e => e.SummaPrihod).HasComment("Сумма").HasColumnName("summa_prihod");
            entity.Property(e => e.SummaRashod).HasComment("Сумма").HasColumnName("summa_rashod");
        });

        modelBuilder.Entity<OfficeOborud>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("office_oborud");

            entity.Property(e => e.Id).HasColumnType("smallint(11)").HasColumnName("id");
            entity
                .Property(e => e.Comment)
                .HasMaxLength(300)
                .HasComment("комментарий")
                .HasColumnName("comment");
            entity.Property(e => e.IdOtd).HasMaxLength(4).HasColumnName("id_otd");
            entity
                .Property(e => e.InputMonth)
                .HasColumnType("smallint(2)")
                .HasColumnName("input_month");
            entity.Property(e => e.InputYear).HasColumnType("year(4)").HasColumnName("input_year");
            entity.Property(e => e.InvNum).HasMaxLength(15).HasColumnName("inv_num");
            entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            entity.Property(e => e.SerialNumber).HasMaxLength(14).HasColumnName("serial_number");
            entity.Property(e => e.UserDep).HasMaxLength(50).HasColumnName("user_dep");
        });

        modelBuilder.Entity<OfficeRepair>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("office_repair");

            entity.Property(e => e.Id).HasColumnType("smallint(11)").HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity.Property(e => e.DateRepair).HasColumnType("date").HasColumnName("date_repair");
            entity.Property(e => e.IdClaim).HasColumnType("smallint(6)").HasColumnName("id_claim");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("smallint(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUstr).HasColumnType("smallint(11)").HasColumnName("id_ustr");
            entity.Property(e => e.OtherOption).HasMaxLength(50).HasColumnName("other_option");
            entity
                .Property(e => e.TypeUstr)
                .HasColumnType("enum('','comp','print')")
                .HasColumnName("type_ustr");
            entity.Property(e => e.UserRepare).HasMaxLength(5).HasColumnName("user_repare");
        });

        modelBuilder.Entity<OfficeRepairDo31012022>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("office_repair_do31-01-2022");

            entity.Property(e => e.Id).HasColumnType("smallint(11)").HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity.Property(e => e.DateRepair).HasColumnType("date").HasColumnName("date_repair");
            entity.Property(e => e.IdClaim).HasColumnType("smallint(6)").HasColumnName("id_claim");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("smallint(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUstr).HasColumnType("smallint(11)").HasColumnName("id_ustr");
            entity.Property(e => e.OtherOption).HasMaxLength(50).HasColumnName("other_option");
            entity
                .Property(e => e.TypeUstr)
                .HasColumnType("enum('','comp','print')")
                .HasColumnName("type_ustr");
        });

        modelBuilder.Entity<OfficeRepairSpisano>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("office_repair_spisano");

            entity.Property(e => e.Id).HasColumnType("smallint(11)").HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity.Property(e => e.DateRepair).HasColumnType("date").HasColumnName("date_repair");
            entity.Property(e => e.IdClaim).HasColumnType("smallint(6)").HasColumnName("id_claim");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("smallint(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUstr).HasColumnType("smallint(11)").HasColumnName("id_ustr");
            entity.Property(e => e.OtherOption).HasMaxLength(50).HasColumnName("other_option");
            entity
                .Property(e => e.TypeUstr)
                .HasColumnType("enum('','comp','print')")
                .HasColumnName("type_ustr");
            entity.Property(e => e.UserRepare).HasMaxLength(5).HasColumnName("user_repare");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders", tb => tb.HasComment("prikazy"));

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Date).HasColumnType("date").HasColumnName("date");
            entity.Property(e => e.Number).HasMaxLength(10).HasColumnName("number");
            entity.Property(e => e.Text).HasMaxLength(200).HasColumnName("text");
            entity.Property(e => e.Type).HasColumnType("tinyint(4)").HasColumnName("type");
        });

        modelBuilder.Entity<Ordertype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ordertypes");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
        });

        modelBuilder.Entity<Otdel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("otdel");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.IdDep).HasColumnType("int(11)").HasColumnName("id_dep");
            entity.Property(e => e.IdOtd).HasColumnType("smallint(3)").HasColumnName("id_otd");
            entity
                .Property(e => e.IdOtdBuhgalter)
                .HasColumnType("tinyint(2)")
                .HasColumnName("idotd_buhgalter");
            entity
                .Property(e => e.NameOtd)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("name_otd");
        });

        modelBuilder.Entity<PerMe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("per_mes");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity.Property(e => e.Date).HasColumnType("date").HasColumnName("date");
            entity.Property(e => e.IdDoc).HasColumnType("smallint(6)").HasColumnName("id_doc");
            entity
                .Property(e => e.IdReceiver)
                .HasColumnType("int(11)")
                .HasColumnName("id_receiver");
            entity.Property(e => e.IdSender).HasMaxLength(4).HasColumnName("id_sender");
            entity.Property(e => e.Knopka).HasColumnType("text").HasColumnName("knopka");
            entity.Property(e => e.Readed).HasColumnType("int(11)").HasColumnName("readed");
            entity.Property(e => e.Text).HasColumnType("text").HasColumnName("text");
        });

        modelBuilder.Entity<PerifHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("perif_history");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity
                .Property(e => e.Date)
                .HasComment("дата изменения")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity
                .Property(e => e.Field)
                .HasMaxLength(20)
                .HasComment("имя столбца")
                .HasColumnName("field");
            entity
                .Property(e => e.IdStr)
                .HasComment("id записи в таблице")
                .HasColumnType("smallint(6)")
                .HasColumnName("id_str");
            entity
                .Property(e => e.New)
                .HasMaxLength(150)
                .HasComment("новое значение")
                .HasColumnName("new");
            entity
                .Property(e => e.Old)
                .HasMaxLength(150)
                .HasComment("старое значение")
                .HasColumnName("old");
            entity
                .Property(e => e.User)
                .HasMaxLength(100)
                .HasComment("ФИО изменившего пользователя")
                .HasColumnName("user");
        });

        modelBuilder.Entity<Perifer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("perifer");

            entity.Property(e => e.Id).HasColumnType("smallint(11)").HasColumnName("id");
            entity.Property(e => e.IdOtd).HasMaxLength(4).HasColumnName("id_otd");
            entity
                .Property(e => e.InputMonth)
                .HasColumnType("smallint(2)")
                .HasColumnName("input_month");
            entity.Property(e => e.InputYear).HasColumnType("year(4)").HasColumnName("input_year");
            entity.Property(e => e.InvNum).HasMaxLength(15).HasColumnName("inv_num");
            entity
                .Property(e => e.KolToner)
                .HasColumnType("smallint(4)")
                .HasColumnName("kol_toner");
            entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            entity
                .Property(e => e.NumZapr)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(3)")
                .HasColumnName("num_zapr");
            entity
                .Property(e => e.NumZaprSelen)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(3)")
                .HasColumnName("num_zapr_selen");
            entity
                .Property(e => e.ReplaceSelen)
                .HasColumnType("smallint(3)")
                .HasColumnName("replace_selen");
            entity.Property(e => e.SerialNumber).HasMaxLength(15).HasColumnName("serial_number");
            entity.Property(e => e.TypeCartr).HasMaxLength(15).HasColumnName("type_cartr");
            entity.Property(e => e.TypeSelen).HasMaxLength(15).HasColumnName("type_selen");
            entity.Property(e => e.TypeToner).HasMaxLength(15).HasColumnName("type_toner");
            entity.Property(e => e.UserDep).HasMaxLength(50).HasColumnName("user_dep");
        });

        modelBuilder.Entity<Perifer01022022>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("perifer_01-02-2022");

            entity.Property(e => e.Id).HasColumnType("smallint(11)").HasColumnName("id");
            entity.Property(e => e.IdOtd).HasMaxLength(4).HasColumnName("id_otd");
            entity
                .Property(e => e.InputMonth)
                .HasColumnType("smallint(2)")
                .HasColumnName("input_month");
            entity.Property(e => e.InputYear).HasColumnType("year(4)").HasColumnName("input_year");
            entity.Property(e => e.InvNum).HasMaxLength(15).HasColumnName("inv_num");
            entity
                .Property(e => e.KolToner)
                .HasColumnType("smallint(4)")
                .HasColumnName("kol_toner");
            entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            entity
                .Property(e => e.NumZapr)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(3)")
                .HasColumnName("num_zapr");
            entity
                .Property(e => e.NumZaprSelen)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(3)")
                .HasColumnName("num_zapr_selen");
            entity
                .Property(e => e.ReplaceSelen)
                .HasColumnType("smallint(3)")
                .HasColumnName("replace_selen");
            entity.Property(e => e.SerialNumber).HasMaxLength(15).HasColumnName("serial_number");
            entity.Property(e => e.TypeCartr).HasMaxLength(15).HasColumnName("type_cartr");
            entity.Property(e => e.TypeSelen).HasMaxLength(15).HasColumnName("type_selen");
            entity.Property(e => e.TypeToner).HasMaxLength(15).HasColumnName("type_toner");
            entity.Property(e => e.UserDep).HasMaxLength(50).HasColumnName("user_dep");
        });

        modelBuilder.Entity<PeriferSpisano>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("perifer_spisano");

            entity.Property(e => e.Id).HasColumnType("smallint(11)").HasColumnName("id");
            entity.Property(e => e.IdOtd).HasMaxLength(4).HasColumnName("id_otd");
            entity
                .Property(e => e.InputMonth)
                .HasColumnType("smallint(2)")
                .HasColumnName("input_month");
            entity.Property(e => e.InputYear).HasColumnType("year(4)").HasColumnName("input_year");
            entity.Property(e => e.InvNum).HasMaxLength(15).HasColumnName("inv_num");
            entity
                .Property(e => e.KolToner)
                .HasColumnType("smallint(4)")
                .HasColumnName("kol_toner");
            entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            entity
                .Property(e => e.NumZapr)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(3)")
                .HasColumnName("num_zapr");
            entity
                .Property(e => e.NumZaprSelen)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(3)")
                .HasColumnName("num_zapr_selen");
            entity
                .Property(e => e.ReplaceSelen)
                .HasColumnType("smallint(3)")
                .HasColumnName("replace_selen");
            entity.Property(e => e.SerialNumber).HasMaxLength(15).HasColumnName("serial_number");
            entity.Property(e => e.TypeCartr).HasMaxLength(15).HasColumnName("type_cartr");
            entity.Property(e => e.TypeSelen).HasMaxLength(15).HasColumnName("type_selen");
            entity.Property(e => e.TypeToner).HasMaxLength(15).HasColumnName("type_toner");
            entity.Property(e => e.UserDep).HasMaxLength(50).HasColumnName("user_dep");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable(
                "positions",
                tb => tb.HasComment("statusy user'ov (na4al'stvo, rabo4ie) -dlya DR")
            );

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(30).IsFixedLength().HasColumnName("name");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("news_posts_pkey");

            entity.ToTable("news_posts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt).HasColumnName("createdat");
            entity.Property(e => e.CreatedByUserId).HasColumnName("createdbyuserid");
            entity.Property(e => e.CreatorName).HasColumnName("creatorname");
            entity.Property(e => e.CreatorDepartment).HasColumnName("creatordepartment");
            entity.Property(e => e.CategoryId).HasColumnName("categoryid");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");
            entity.ToTable("categories");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("resources");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity
                .Property(e => e.IdOtd)
                .HasMaxLength(4)
                .HasComment("Код отдела, который исполняет эту заявку")
                .HasColumnName("id_otd");
            entity
                .Property(e => e.IdParent)
                .HasColumnType("smallint(6)")
                .HasColumnName("id_parent");
            entity.Property(e => e.Name).HasColumnType("text").HasColumnName("name");
            entity
                .Property(e => e.Priznak)
                .HasMaxLength(1)
                .HasComment("1=замена, 2=установка")
                .HasColumnName("priznak");
        });

        modelBuilder.Entity<Right>(entity =>
        {
            entity.HasNoKey().ToTable("rights");

            entity.Property(e => e.IdLink).HasColumnType("tinyint(4)").HasColumnName("id_link");
            entity.Property(e => e.IdUser).HasColumnType("int(11)").HasColumnName("id_user");
            entity
                .Property(e => e.Type)
                .HasMaxLength(1)
                .HasComment("тип права")
                .HasColumnName("type");
        });

        modelBuilder.Entity<RightsDel>(entity =>
        {
            entity.HasNoKey().ToTable("rights_del");

            entity.Property(e => e.IdLink).HasColumnType("tinyint(4)").HasColumnName("id_link");
            entity.Property(e => e.IdUser).HasColumnType("int(11)").HasColumnName("id_user");
            entity
                .Property(e => e.Type)
                .HasMaxLength(1)
                .HasComment("тип права")
                .HasColumnName("type");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sections");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity.Property(e => e.IdLink).HasColumnType("smallint(6)").HasColumnName("id_link");
            entity.Property(e => e.ImgLink).HasColumnType("text").HasColumnName("img_link");
            entity.Property(e => e.Link).HasColumnType("text").HasColumnName("link");
            entity.Property(e => e.Name).HasColumnType("text").HasColumnName("name");
            entity.Property(e => e.ParentId).HasColumnType("int(11)").HasColumnName("parent_id");
            entity.Property(e => e.Sort).HasColumnType("int(11)").HasColumnName("sort");
        });

        modelBuilder.Entity<Sootv>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sootv");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity.Property(e => e.IdDep).HasColumnType("smallint(6)").HasColumnName("id_dep");
            entity
                .Property(e => e.IdDepNo)
                .HasColumnType("smallint(6)")
                .HasColumnName("  id_dep_no");
            entity.Property(e => e.IdDepOld).HasMaxLength(4).HasColumnName("id_dep_old");
            entity
                .Property(e => e.IdOtdBuhgalter)
                .HasColumnType("int(2)")
                .HasColumnName("idOTD_buhgalter");
            entity.Property(e => e.Name).HasColumnType("text").HasColumnName("name");
        });

        modelBuilder.Entity<SootvOldForDel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sootv_old_for_del");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity.Property(e => e.IdDep).HasColumnType("smallint(6)").HasColumnName("id_dep");
            entity
                .Property(e => e.IdOtdBuhgalter)
                .HasColumnType("int(2)")
                .HasColumnName("idOTD_buhgalter");
            entity.Property(e => e.Name).HasColumnType("text").HasColumnName("name");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("states");

            entity.Property(e => e.Id).HasColumnType("smallint(6)").HasColumnName("id");
            entity.Property(e => e.About).HasColumnType("text").HasColumnName("about");
            entity
                .Property(e => e.Date)
                .HasDefaultValueSql("'0000-00-00'")
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.DateEdit).HasColumnType("date").HasColumnName("date_edit");
            entity.Property(e => e.IdAuthor).HasColumnType("int(11)").HasColumnName("id_author");
            entity
                .Property(e => e.IdAuthorEdit)
                .HasColumnType("int(11)")
                .HasColumnName("id_author_edit");
            entity
                .Property(e => e.IdHozState)
                .HasColumnType("int(11)")
                .HasColumnName("id_hoz_state");
            entity.Property(e => e.MainPage).HasColumnType("int(1)").HasColumnName("mainPage");
            entity.Property(e => e.Name).HasColumnType("text").HasColumnName("name");
            entity.Property(e => e.Section).HasColumnType("smallint(6)").HasColumnName("section");
            entity.Property(e => e.Text).HasColumnName("text");
        });

        modelBuilder.Entity<StatisticMonth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("statistic_month");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Date).HasColumnType("date").HasColumnName("date");
            entity.Property(e => e.IdDep).HasMaxLength(4).HasColumnName("id_dep");
            entity.Property(e => e.IdDepReceiver).HasMaxLength(4).HasColumnName("id_dep_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.Month).HasColumnType("smallint(6)").HasColumnName("month");
            entity.Property(e => e.Year).HasColumnType("smallint(6)").HasColumnName("year");
        });

        modelBuilder.Entity<StatisticYear>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("statistic_year");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Date).HasColumnType("date").HasColumnName("date");
            entity.Property(e => e.IdDep).HasMaxLength(4).HasColumnName("id_dep");
            entity.Property(e => e.IdDepReceiver).HasMaxLength(4).HasColumnName("id_dep_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.Year).HasColumnType("smallint(6)").HasColumnName("year");
        });

        modelBuilder.Entity<StatisticYear2023>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("statistic_year2023");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnType("smallint(6)").HasColumnName("amount");
            entity.Property(e => e.Date).HasColumnType("date").HasColumnName("date");
            entity.Property(e => e.IdDep).HasMaxLength(4).HasColumnName("id_dep");
            entity.Property(e => e.IdDepReceiver).HasMaxLength(4).HasColumnName("id_dep_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("int(11)")
                .HasColumnName("id_resource");
            entity.Property(e => e.Year).HasColumnType("smallint(6)").HasColumnName("year");
        });

        modelBuilder.Entity<Techdoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("techdocs");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.DateFirst).HasColumnType("date").HasColumnName("date_first");
            entity.Property(e => e.DateNext).HasColumnType("date").HasColumnName("date_next");
            entity.Property(e => e.Department).HasMaxLength(255).HasColumnName("department");
            entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("name");
            entity.Property(e => e.OtdId).HasColumnType("int(11)").HasColumnName("otd_id");
            entity.Property(e => e.Shifr).HasMaxLength(255).HasColumnName("shifr");
            entity.Property(e => e.Type).HasMaxLength(255).HasColumnName("type");
            entity.Property(e => e.User).HasMaxLength(255).HasColumnName("user");
        });

        modelBuilder.Entity<TypeDoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("type_docs");

            entity.Property(e => e.Id).HasColumnType("tinyint(4)").HasColumnName("id");
            entity.Property(e => e.IdParent).HasColumnType("tinyint(4)").HasColumnName("idParent");
            entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Answer).HasColumnType("text").HasColumnName("answer");
            entity.Property(e => e.Ban).HasColumnType("tinyint(4)").HasColumnName("ban");
            entity
                .Property(e => e.BanAmount)
                .HasColumnType("tinyint(4)")
                .HasColumnName("ban_amount");
            entity.Property(e => e.BanComment).HasMaxLength(500).HasColumnName("ban_comment");
            entity.Property(e => e.BanDate).HasColumnType("date").HasColumnName("ban_date");
            entity
                .Property(e => e.ComeDate)
                .HasComment("время и дата загрузки чата")
                .HasColumnType("datetime")
                .HasColumnName("comedate");
            entity.Property(e => e.IdGroup).HasColumnType("smallint(6)").HasColumnName("id_group");
            entity.Property(e => e.IdPost).HasColumnType("smallint(6)").HasColumnName("id_post");
            entity
                .Property(e => e.Login)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("login");
            entity.Property(e => e.Mail).HasMaxLength(30).HasColumnName("mail");
            entity
                .Property(e => e.Password)
                .HasMaxLength(80)
                .HasDefaultValueSql("''")
                .HasColumnName("password");
            entity.Property(e => e.Question).HasColumnType("text").HasColumnName("question");
            entity.Property(e => e.Tabel).HasMaxLength(5).HasColumnName("tabel");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("workers", tb => tb.HasComment("Справочник сотрудников"));

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(250).HasColumnName("address");
            entity.Property(e => e.DatePriem).HasColumnType("date").HasColumnName("datepriem");
            entity.Property(e => e.Doljnost).HasMaxLength(150).HasColumnName("doljnost");
            entity.Property(e => e.Dr).HasColumnType("date").HasColumnName("dr");
            entity.Property(e => e.Fio).HasMaxLength(50).HasColumnName("fio");
            entity.Property(e => e.Ids).HasMaxLength(9).HasColumnName("ids");
            entity
                .Property(e => e.KategoriyaId)
                .HasMaxLength(9)
                .HasComment("категория работника (начальники/мастера и т.д.)")
                .HasColumnName("kategoriyaid");
            entity
                .Property(e => e.KategoriyaName)
                .HasMaxLength(20)
                .HasComment("наименование категории работника")
                .HasColumnName("kategoriyaname");
            entity
                .Property(e => e.Otdel)
                .HasMaxLength(120)
                .HasComment("отдел рус.полностью")
                .HasColumnName("otdel");
            entity.Property(e => e.OtdelId).HasMaxLength(6).HasColumnName("otdelid");
            entity
                .Property(e => e.OtdelKyrB)
                .HasMaxLength(120)
                .HasComment("отдел кирг. полностью")
                .HasColumnName("otdelkyrb");
            entity
                .Property(e => e.OtdelKyrS)
                .HasMaxLength(120)
                .HasComment("отдел кирг.кратко")
                .HasColumnName("otdelkyrs");
            entity
                .Property(e => e.OtdelRusS)
                .HasMaxLength(120)
                .HasComment("отдел рус. кратко")
                .HasColumnName("otdelruss");
            entity.Property(e => e.Phone).HasMaxLength(150).HasColumnName("phone");
            entity.Property(e => e.Tabel).HasMaxLength(4).HasColumnName("tabel");
        });

        modelBuilder.Entity<Workers18062024>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("workers18-06-2024", tb => tb.HasComment("Справочник сотрудников"));

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(250).HasColumnName("address");
            entity.Property(e => e.DatePriem).HasColumnType("date").HasColumnName("datePriem");
            entity.Property(e => e.Doljnost).HasMaxLength(150).HasColumnName("doljnost");
            entity.Property(e => e.Dr).HasColumnType("date").HasColumnName("DR");
            entity.Property(e => e.Fio).HasMaxLength(50).HasColumnName("FIO");
            entity.Property(e => e.Ids).HasMaxLength(9).HasColumnName("IDs");
            entity
                .Property(e => e.KategoriyaId)
                .HasMaxLength(9)
                .HasComment("категория работника (начальники/мастера и т.д.)")
                .HasColumnName("kategoriyaID");
            entity
                .Property(e => e.KategoriyaName)
                .HasMaxLength(20)
                .HasComment("наименование категории работника")
                .HasColumnName("kategoriyaName");
            entity.Property(e => e.Otdel).HasMaxLength(120).HasColumnName("otdel");
            entity.Property(e => e.OtdelId).HasMaxLength(6).HasColumnName("otdelID");
            entity.Property(e => e.Phone).HasMaxLength(150).HasColumnName("phone");
            entity.Property(e => e.Tabel).HasMaxLength(4).HasColumnName("TABEL");
        });

        modelBuilder.Entity<Workers1otdel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("workers_1otdel", tb => tb.HasComment("Справочник сотрудников"));

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(250).HasColumnName("address");
            entity.Property(e => e.DatePriem).HasColumnType("date").HasColumnName("datePriem");
            entity.Property(e => e.Doljnost).HasMaxLength(150).HasColumnName("doljnost");
            entity.Property(e => e.Dr).HasColumnType("date").HasColumnName("DR");
            entity.Property(e => e.Fio).HasMaxLength(50).HasColumnName("FIO");
            entity.Property(e => e.Ids).HasMaxLength(9).HasColumnName("IDs");
            entity
                .Property(e => e.KategoriyaId)
                .HasMaxLength(9)
                .HasComment("категория работника (начальники/мастера и т.д.)")
                .HasColumnName("kategoriyaID");
            entity
                .Property(e => e.KategoriyaName)
                .HasMaxLength(20)
                .HasComment("наименование категории работника")
                .HasColumnName("kategoriyaName");
            entity
                .Property(e => e.Otdel)
                .HasMaxLength(120)
                .HasComment("отдел рус.полностью")
                .HasColumnName("otdel");
            entity.Property(e => e.OtdelId).HasMaxLength(6).HasColumnName("otdelID");
            entity.Property(e => e.Phone).HasMaxLength(150).HasColumnName("phone");
            entity.Property(e => e.Tabel).HasMaxLength(4).HasColumnName("TABEL");
        });

        modelBuilder.Entity<WorkersCopy>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("workers_copy", tb => tb.HasComment("Справочник сотрудников"));

            entity.Property(e => e.Address).HasMaxLength(250).HasColumnName("address");
            entity.Property(e => e.DatePriem).HasColumnType("date").HasColumnName("datePriem");
            entity.Property(e => e.Doljnost).HasMaxLength(150).HasColumnName("doljnost");
            entity.Property(e => e.Dr).HasColumnType("date").HasColumnName("DR");
            entity.Property(e => e.Fio).HasMaxLength(50).HasColumnName("FIO");
            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Ids).HasMaxLength(9).HasColumnName("IDs");
            entity
                .Property(e => e.KategoriyaId)
                .HasMaxLength(9)
                .HasComment("категория работника (начальники/мастера и т.д.)")
                .HasColumnName("kategoriyaID");
            entity.Property(e => e.Mphone).HasMaxLength(30).HasColumnName("mphone");
            entity.Property(e => e.Otdel).HasMaxLength(120).HasColumnName("otdel");
            entity.Property(e => e.OtdelId).HasMaxLength(6).HasColumnName("otdelID");
            entity.Property(e => e.Phone).HasMaxLength(30).HasColumnName("phone");
            entity.Property(e => e.Tabel).HasMaxLength(4).HasColumnName("TABEL");
        });

        modelBuilder.Entity<WorkersEmpty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("workers_empty", tb => tb.HasComment("Справочник сотрудников"));

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(250).HasColumnName("address");
            entity.Property(e => e.DatePriem).HasColumnType("date").HasColumnName("datePriem");
            entity.Property(e => e.Doljnost).HasMaxLength(150).HasColumnName("doljnost");
            entity.Property(e => e.Dr).HasColumnType("date").HasColumnName("DR");
            entity.Property(e => e.Fio).HasMaxLength(50).HasColumnName("FIO");
            entity.Property(e => e.Ids).HasMaxLength(9).HasColumnName("IDs");
            entity
                .Property(e => e.KategoriyaId)
                .HasMaxLength(9)
                .HasComment("категория работника (начальники/мастера и т.д.)")
                .HasColumnName("kategoriyaID");
            entity.Property(e => e.KategoriyaName).HasMaxLength(20).HasColumnName("kategoriyaName");
            entity.Property(e => e.Mphone).HasMaxLength(30).HasColumnName("mphone");
            entity.Property(e => e.Otdel).HasMaxLength(120).HasColumnName("otdel");
            entity.Property(e => e.OtdelId).HasMaxLength(6).HasColumnName("otdelID");
            entity.Property(e => e.Phone).HasMaxLength(30).HasColumnName("phone");
            entity.Property(e => e.Tabel).HasMaxLength(4).HasColumnName("TABEL");
        });

        modelBuilder.Entity<Zayavkatmc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("zayavkatmc");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity
                .Property(e => e.Action)
                .HasMaxLength(1)
                .HasComment("действие: 0-новая,1-прочитанная,2-выполненная,3-отложенная,4-отказная")
                .HasColumnName("action");
            entity.Property(e => e.Date).HasColumnType("datetime").HasColumnName("date");
            entity
                .Property(e => e.DateAction)
                .HasComment("дата разрешения заявки")
                .HasColumnType("datetime")
                .HasColumnName("dateAction");
            entity.Property(e => e.IdDep).HasMaxLength(4).HasColumnName("id_dep");
            entity.Property(e => e.IdOborud).HasMaxLength(10).HasColumnName("idOborud");
            entity.Property(e => e.IdWork).HasMaxLength(10).HasColumnName("idWork");
            entity.Property(e => e.Kvartal).HasMaxLength(1).HasColumnName("kvartal");
            entity.Property(e => e.Name).HasMaxLength(700).HasColumnName("name");
            entity.Property(e => e.Rem).HasMaxLength(1).HasColumnName("rem");
            entity.Property(e => e.Sposob).HasMaxLength(1).HasColumnName("sposob");
        });

        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("activity_log");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Action).HasMaxLength(50).HasColumnName("action");
            entity.Property(e => e.Title).HasMaxLength(255).HasColumnName("title");
            entity.Property(e => e.Subtitle).HasMaxLength(255).HasColumnName("subtitle");
            entity
                .Property(e => e.ActorUserId)
                .HasColumnType("int(11)")
                .HasColumnName("actor_user_id");
            entity.Property(e => e.CreatedAt).HasColumnType("timestamp").HasColumnName("created_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

#endregion
