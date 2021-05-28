using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Bank.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Bank.Data
{
    public partial class bankDBContext : DbContext
    {
        public bankDBContext()
        {
        }

        public bankDBContext(DbContextOptions<bankDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Depositor> Depositors { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public object Currencies { get; internal set; }
        public object Deposit { get; internal set; }
        public object PersonnelDepartamet { get; internal set; }
        public object Position { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlite("Data Source=C:\\Users\\GANSOR\\source\\repos\\Bank\\bankDB.db");
                optionsBuilder.UseSqlServer("Data Source=JUSTKUST\\SQLEXPRESS;Initial Catalog=bankDB.db;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.CurId);

                entity.Property(e => e.CurId)
                    .HasColumnName("CurID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExchangeRate).HasColumnType("INT");

                entity.Property(e => e.Name).HasColumnType("INT");
            });

            modelBuilder.Entity<Depositor>(entity =>
            {
                entity.HasKey(e => e.PassData);

                entity.Property(e => e.PassData).HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.DepId)
                    .HasColumnName("DepID")
                    .HasColumnType("INT");

                entity.Property(e => e.DepRafMark).HasColumnType("INT");

                entity.Property(e => e.DeposDate)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.EmId)
                    .HasColumnName("EmID")
                    .HasColumnType("INT");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.PhoneNum)
                    .IsRequired()
                    .HasColumnType("VARCHAR(11)");

                entity.Property(e => e.RefundDate)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.SummAm).HasColumnType("INT");

                entity.Property(e => e.SummRef).HasColumnType("INT");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Depositors)
                    .HasForeignKey(d => d.DepId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Em)
                    .WithMany(p => p.Depositors)
                    .HasForeignKey(d => d.EmId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Deposit>(entity =>
            {
                entity.HasKey(e => e.DepId);

                entity.Property(e => e.DepId)
                    .HasColumnName("DepID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddCond)
                    .IsRequired()
                    .HasColumnType("VARCHAR(200)");

                entity.Property(e => e.CurId)
                    .HasColumnName("CurID")
                    .HasColumnType("INT");

                entity.Property(e => e.DepName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(60)");

                entity.Property(e => e.InRate).HasColumnType("INT");

                entity.Property(e => e.MinDepAmount).HasColumnType("INT");

                entity.Property(e => e.MinDepTern).HasColumnType("INT");

                entity.HasOne(d => d.Cur)
                    .WithMany(p => p.Deposits)
                    .HasForeignKey(d => d.CurId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmId);

                entity.Property(e => e.EmId)
                    .HasColumnName("EmID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Age).HasColumnType("INT");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("Full_Name")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.PosId)
                    .HasColumnName("PosID")
                    .HasColumnType("INT");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasColumnType("VARCHAR(11)");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PosId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PosId);

                entity.ToTable("positions");

                entity.Property(e => e.PosId)
                    .HasColumnName("PosID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.PosName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(60)");

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasColumnType("VARCHAR(200)");

                entity.Property(e => e.Responsibilities)
                    .IsRequired()
                    .HasColumnType("VARCHAR(200)");

                entity.Property(e => e.Salary).HasColumnType("INT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
