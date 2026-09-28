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


    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
    
    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Otdel> Otdels { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }
   
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

        // modelBuilder.HasDefaultSchema("site_db");

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName()?.ToLowerInvariant());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToLowerInvariant());
            }
        }

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("departments");

            entity.Property(e => e.Id).HasColumnType("smallint").HasColumnName("id");
            entity.Property(e => e.Name).HasColumnType("text").HasColumnName("name");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("documents");

            entity.Property(e => e.Id).HasColumnType("integer").HasColumnName("id");
            entity.Property(e => e.Action).HasColumnType("smallint").HasColumnName("action");
            entity.Property(e => e.Amount).HasColumnType("smallint").HasColumnName("amount");
            entity.Property(e => e.Archive).HasColumnType("smallint").HasColumnName("archive");
            entity.Property(e => e.Comment).HasColumnType("text").HasColumnName("comment");
            entity
                .Property(e => e.CommentReshenie)
                .HasMaxLength(150)
                .HasColumnName("comment_reshenie");
            entity
                .Property(e => e.DateFirst)
                .HasDefaultValueSql("'0001-01-01 00:00:00'")
                .HasColumnType("timestamp")
                .HasColumnName("date_first");
            entity
                .Property(e => e.DateReshenie)
                .HasColumnType("timestamp")
                .HasColumnName("date_reshenie");
            entity.Property(e => e.DateVyp).HasColumnType("timestamp").HasColumnName("date_vyp");
            entity.Property(e => e.Format).HasColumnType("text").HasColumnName("format");
            entity.Property(e => e.IdPerUser).HasColumnType("integer").HasColumnName("id_per_user");
            entity.Property(e => e.IdReceiver).HasMaxLength(4).HasColumnName("id_receiver");
            entity
                .Property(e => e.IdResource)
                .HasColumnType("integer")
                .HasColumnName("id_resource");
            entity.Property(e => e.IdUser).HasMaxLength(4).HasColumnName("id_user");
            entity.Property(e => e.Made).HasColumnType("smallint").HasColumnName("made");
            entity
                .Property(e => e.UserReshenie)
                .HasMaxLength(4)
                .HasComment("Пользователь, который разрешил/отклонил заявку")
                .HasColumnName("user_reshenie");
        });

        modelBuilder.Entity<Otdel>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("otdel");

            entity.Property(e => e.Id).HasColumnType("integer").HasColumnName("id");
            entity
                .Property(e => e.NameOtd)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("name_otd");
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
            entity.HasKey(e => e.Id);

            entity.ToTable("resources");

            entity.Property(e => e.Id).HasColumnType("smallint").HasColumnName("id");
            entity
                .Property(e => e.IdOtd)
                .HasMaxLength(4)
                .HasComment("Код отдела, который исполняет эту заявку")
                .HasColumnName("id_otd");
            entity
                .Property(e => e.IdParent)
                .HasColumnType("smallint")
                .HasColumnName("id_parent");
            entity.Property(e => e.Name).HasColumnType("text").HasColumnName("name");
            entity
                .Property(e => e.Priznak)
                .HasMaxLength(1)
                .HasComment("1=замена, 2=установка")
                .HasColumnName("priznak");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnType("integer").HasColumnName("id");
            entity.Property(e => e.Answer).HasColumnType("text").HasColumnName("answer");
            entity.Property(e => e.Ban).HasColumnType("smallint").HasColumnName("ban");
            entity
                .Property(e => e.BanAmount)
                .HasColumnType("smallint")
                .HasColumnName("ban_amount");
            entity.Property(e => e.BanComment).HasMaxLength(500).HasColumnName("ban_comment");
            entity.Property(e => e.BanDate).HasColumnType("date").HasColumnName("ban_date");
            entity
                .Property(e => e.ComeDate)
                .HasComment("время и дата загрузки чата")
                .HasColumnType("timestamp")
                .HasColumnName("comedate");
            entity.Property(e => e.IdGroup).HasColumnType("smallint").HasColumnName("id_group");
            entity.Property(e => e.IdPost).HasColumnType("smallint").HasColumnName("id_post");
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
            entity.HasKey(e => e.Id);

            entity.ToTable("workers", tb => tb.HasComment("Справочник сотрудников"));

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.Property(e => e.Id).HasColumnType("integer").HasColumnName("id");
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
            entity.HasKey(e => e.Id);

            entity.ToTable("workers18-06-2024", tb => tb.HasComment("Справочник сотрудников"));

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.Property(e => e.Id).HasColumnType("integer").HasColumnName("id");
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
            entity.HasKey(e => e.Id);

            entity.ToTable("workers_1otdel", tb => tb.HasComment("Справочник сотрудников"));

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.Property(e => e.Id).HasColumnType("integer").HasColumnName("id");
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
            entity.Property(e => e.Id).HasColumnType("integer").HasColumnName("id");
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
            entity.HasKey(e => e.Id);

            entity.ToTable("workers_empty", tb => tb.HasComment("Справочник сотрудников"));

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.Property(e => e.Id).HasColumnType("integer").HasColumnName("id");
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
            entity.HasKey(e => e.Id);

            entity.ToTable("zayavkatmc");

            entity.Property(e => e.Id).HasColumnType("integer").HasColumnName("id");
            entity
                .Property(e => e.Action)
                .HasMaxLength(1)
                .HasComment("действие: 0-новая,1-прочитанная,2-выполненная,3-отложенная,4-отказная")
                .HasColumnName("action");
            entity.Property(e => e.Date).HasColumnType("timestamp").HasColumnName("date");
            entity
                .Property(e => e.DateAction)
                .HasComment("дата разрешения заявки")
                .HasColumnType("timestamp")
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
            entity.HasKey(e => e.Id);

            entity.ToTable("activity_log");

            entity.Property(e => e.Id).HasColumnType("integer").HasColumnName("id");
            entity.Property(e => e.Action).HasMaxLength(50).HasColumnName("action");
            entity.Property(e => e.Title).HasMaxLength(255).HasColumnName("title");
            entity.Property(e => e.Subtitle).HasMaxLength(255).HasColumnName("subtitle");
            entity
                .Property(e => e.ActorUserId)
                .HasColumnType("integer")
                .HasColumnName("actor_user_id");
            entity.Property(e => e.CreatedAt).HasColumnType("timestamp").HasColumnName("created_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

#endregion
