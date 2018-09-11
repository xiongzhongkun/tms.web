using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace tms.Models
{
    public partial class TMS_ADMINContext : DbContext
    {
        public TMS_ADMINContext()
        {
        }

        public TMS_ADMINContext(DbContextOptions<TMS_ADMINContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GpsCharge> GpsCharge { get; set; }
        public virtual DbSet<GpsEdi> GpsEdi { get; set; }
        public virtual DbSet<GpsUser> GpsUser { get; set; }
        public virtual DbSet<Pcctv> Pcctv { get; set; }
        public virtual DbSet<SysNav> SysNav { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysRoleValue> SysRoleValue { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }
        public virtual DbSet<VihicleData> VihicleData { get; set; }
        public virtual DbSet<VihiclePP> VihiclePP { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Startup.GetConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GpsCharge>(entity =>
            {
                entity.ToTable("GPS_CHARGE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(64)
                    .ValueGeneratedNever();

                entity.Property(e => e.GpsEdiCharge)
                    .HasColumnName("GPS_EDI_CHARGE")
                    .HasColumnType("decimal(16, 2)");

                entity.Property(e => e.GpsEdiId)
                    .HasColumnName("GPS_EDI_ID")
                    .HasMaxLength(32);

                entity.Property(e => e.GpsEdiStatus)
                    .HasColumnName("GPS_EDI_STATUS")
                    .HasMaxLength(8);

                entity.Property(e => e.GpsEdiTime)
                    .HasColumnName("GPS_EDI_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.GpsEdiType)
                    .HasColumnName("GPS_EDI_TYPE")
                    .HasMaxLength(32);

                entity.Property(e => e.GpsEdiVihicle)
                    .HasColumnName("GPS_EDI_VIHICLE")
                    .HasMaxLength(8);

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<GpsEdi>(entity =>
            {
                entity.ToTable("GPS_EDI");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(64)
                    .ValueGeneratedNever();

                entity.Property(e => e.GpsEdiCharge)
                    .HasColumnName("GPS_EDI_CHARGE")
                    .HasColumnType("decimal(16, 2)");

                entity.Property(e => e.GpsEdiId)
                    .HasColumnName("GPS_EDI_ID")
                    .HasMaxLength(32);

                entity.Property(e => e.GpsEdiStatus)
                    .HasColumnName("GPS_EDI_STATUS")
                    .HasMaxLength(8);

                entity.Property(e => e.GpsEdiTime)
                    .HasColumnName("GPS_EDI_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.GpsEdiType)
                    .HasColumnName("GPS_EDI_TYPE")
                    .HasMaxLength(32);

                entity.Property(e => e.GpsEdiVihicle)
                    .HasColumnName("GPS_EDI_VIHICLE")
                    .HasMaxLength(8);

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<GpsUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("GPS_USER");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(64)
                    .ValueGeneratedNever();

                entity.Property(e => e.AddTime)
                    .HasColumnName("ADD_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.EdiStatus)
                    .HasColumnName("EDI_STATUS")
                    .HasMaxLength(8);

                entity.Property(e => e.UserAddC)
                    .HasColumnName("USER_ADD_C")
                    .HasMaxLength(64);

                entity.Property(e => e.UserAddD).HasColumnName("USER_ADD_D");

                entity.Property(e => e.UserAddP)
                    .HasColumnName("USER_ADD_P")
                    .HasMaxLength(64);

                entity.Property(e => e.UserBalance)
                    .HasColumnName("USER_BALANCE")
                    .HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UserCode)
                    .HasColumnName("USER_CODE")
                    .HasMaxLength(64);

                entity.Property(e => e.UserCon)
                    .HasColumnName("USER_CON")
                    .HasMaxLength(32);

                entity.Property(e => e.UserConEmail)
                    .HasColumnName("USER_CON_EMAIL")
                    .HasMaxLength(64);

                entity.Property(e => e.UserConTel)
                    .HasColumnName("USER_CON_TEL")
                    .HasMaxLength(32);

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(64);

                entity.Property(e => e.UserShortname)
                    .HasColumnName("USER_SHORTNAME")
                    .HasMaxLength(32);

                entity.Property(e => e.UserStatus)
                    .HasColumnName("USER_STATUS")
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<Pcctv>(entity =>
            {
                entity.ToTable("PCCTV");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(12)
                    .ValueGeneratedNever();

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasColumnName("classification")
                    .HasMaxLength(3);

                entity.Property(e => e.Pcctvlevel).HasColumnName("pcctvlevel");

                entity.Property(e => e.Pcctvname)
                    .IsRequired()
                    .HasColumnName("pcctvname")
                    .HasMaxLength(30);

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasMaxLength(12);

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SysNav>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ActionType)
                    .HasColumnName("actionType")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsLock).HasColumnName("isLock");

                entity.Property(e => e.IsSys).HasColumnName("isSys");

                entity.Property(e => e.LinkUrl)
                    .HasColumnName("linkUrl")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NavName)
                    .HasColumnName("navName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parentID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SortId).HasColumnName("sortID");

                entity.Property(e => e.SubTitle)
                    .HasColumnName("subTitle")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateId)
                    .HasColumnName("createID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsSys).HasColumnName("is_sys");

                entity.Property(e => e.RoleName)
                    .HasColumnName("roleName")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RoleType)
                    .HasColumnName("roleType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateId)
                    .HasColumnName("updateID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysRoleValue>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ActionType)
                    .HasColumnName("actionType")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.CreateId)
                    .HasColumnName("createID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NavName)
                    .HasColumnName("navName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.UpdateId)
                    .HasColumnName("updateID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.ToTable("USER_ACCOUNT");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.GpsUserId)
                    .HasColumnName("GpsUserID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pwd)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VihicleData>(entity =>
            {
                entity.ToTable("VIHICLE_DATA");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(64)
                    .ValueGeneratedNever();

                entity.Property(e => e.EdiTimes)
                    .HasColumnName("EDI_TIMES")
                    .HasColumnType("datetime");

                entity.Property(e => e.EdiUpdate)
                    .HasColumnName("EDI_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.FromEdi)
                    .HasColumnName("FROM_EDI")
                    .HasMaxLength(16);

                entity.Property(e => e.FromUser)
                    .HasColumnName("FROM_USER")
                    .HasMaxLength(64);

                entity.Property(e => e.GpsEdiVihicle)
                    .HasColumnName("GPS_EDI_VIHICLE")
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<VihiclePP>(entity =>
            {
                entity.ToTable("VIHICLE_P_P");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(64)
                    .ValueGeneratedNever();

                entity.Property(e => e.GpsEdiVihicle)
                    .HasColumnName("GPS_EDI_VIHICLE")
                    .HasMaxLength(8);

                entity.Property(e => e.VihicleLat)
                    .HasColumnName("VIHICLE_LAT")
                    .HasColumnType("decimal(16, 0)");

                entity.Property(e => e.VihicleLon)
                    .HasColumnName("VIHICLE_LON")
                    .HasColumnType("decimal(16, 0)");

                entity.Property(e => e.VihiclePPC)
                    .HasColumnName("VIHICLE_P_P_C")
                    .HasMaxLength(16);

                entity.Property(e => e.VihiclePPC1)
                    .HasColumnName("VIHICLE_P_P_C1")
                    .HasMaxLength(32);

                entity.Property(e => e.VihiclePPD).HasColumnName("VIHICLE_P_P_D");

                entity.Property(e => e.VihiclePPP)
                    .HasColumnName("VIHICLE_P_P_P")
                    .HasMaxLength(16);

                entity.Property(e => e.VihiclePPT)
                    .HasColumnName("VIHICLE_P_P_T")
                    .HasColumnType("datetime");
            });
        }
    }
}
