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

        modelBuilder.HasDefaultSchema("site_db");

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
