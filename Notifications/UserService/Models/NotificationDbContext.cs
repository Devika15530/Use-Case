using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserService.Models
{
    public partial class NotificationDbContext : DbContext
    {
        public NotificationDbContext()
        {
        }

        public NotificationDbContext(DbContextOptions<NotificationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-FA0USB5\\SQLEXPRESS;Database=NotificationDb;User Id=sa; Password=158x1a0530;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.HasKey(e => e.Notificationid)
                    .HasName("PK__Notifica__4BA4C371F34ADAAA");

                entity.Property(e => e.Notificationid)
                    .HasColumnName("notificationid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Createddatetime)
                    .HasColumnName("createddatetime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Notificationname)
                    .IsRequired()
                    .HasColumnName("notificationname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__Notificat__useri__173876EA");
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__UserDeta__CBA1B257ACCCF6B1");

                entity.HasIndex(e => e.Contactnumber)
                    .HasName("UQ__UserDeta__DF8655CC659ED88F")
                    .IsUnique();

                entity.HasIndex(e => e.Emailid)
                    .HasName("UQ__UserDeta__8734520B012D318F")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__UserDeta__F3DBC5726F750D61")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Contactnumber)
                    .IsRequired()
                    .HasColumnName("contactnumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Emailid)
                    .IsRequired()
                    .HasColumnName("emailid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Registereddatetime)
                    .HasColumnName("registereddatetime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
