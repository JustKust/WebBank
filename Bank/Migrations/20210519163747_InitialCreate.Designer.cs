// <auto-generated />
using System;
using Bank.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bank.Migrations
{
    [DbContext(typeof(bankDBContext))]
    [Migration("20210519163747_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bank.Models.Currency", b =>
                {
                    b.Property<int>("CurId")
                        .HasColumnName("CurID")
                        .HasColumnType("INT");

                    b.Property<int>("ExchangeRate")
                        .HasColumnType("INT");

                    b.Property<int>("Name")
                        .HasColumnType("INT");

                    b.HasKey("CurId");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("Bank.Models.Depositors", b =>
                {
                    b.Property<string>("PassData")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("DepId")
                        .HasColumnName("DepID")
                        .HasColumnType("INT");

                    b.Property<int>("DepRafMark")
                        .HasColumnType("INT");

                    b.Property<DateTime>("DeposDate")
                        .HasColumnType("DATE");

                    b.Property<int>("EmId")
                        .HasColumnName("EmID")
                        .HasColumnType("INT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<DateTime>("RefundDate")
                        .HasColumnType("DATE");

                    b.Property<int>("SummAm")
                        .HasColumnType("INT");

                    b.Property<int>("SummRef")
                        .HasColumnType("INT");

                    b.HasKey("PassData");

                    b.HasIndex("DepId");

                    b.HasIndex("EmId");

                    b.ToTable("Depositors");
                });

            modelBuilder.Entity("Bank.Models.Deposits", b =>
                {
                    b.Property<int>("DepId")
                        .HasColumnName("DepID")
                        .HasColumnType("INT");

                    b.Property<string>("AddCond")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<int>("CurId")
                        .HasColumnName("CurID")
                        .HasColumnType("INT");

                    b.Property<string>("DepName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.Property<int>("InRate")
                        .HasColumnType("INT");

                    b.Property<int>("MinDepAmount")
                        .HasColumnType("INT");

                    b.Property<int>("MinDepTern")
                        .HasColumnType("INT");

                    b.HasKey("DepId");

                    b.HasIndex("CurId");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("Bank.Models.Employee", b =>
                {
                    b.Property<int>("EmId")
                        .HasColumnName("EmID")
                        .HasColumnType("INT");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Age")
                        .HasColumnType("INT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnName("Full_Name")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("CHAR(1)");

                    b.Property<int>("PosId")
                        .HasColumnName("PosID")
                        .HasColumnType("INT");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.HasKey("EmId");

                    b.HasIndex("PosId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Bank.Models.Positions", b =>
                {
                    b.Property<int>("PosId")
                        .HasColumnName("PosID")
                        .HasColumnType("INT");

                    b.Property<string>("PosName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Responsibilities")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<int>("Salary")
                        .HasColumnType("INT");

                    b.HasKey("PosId");

                    b.ToTable("positions");
                });

            modelBuilder.Entity("Bank.Models.Depositors", b =>
                {
                    b.HasOne("Bank.Models.Deposits", "Dep")
                        .WithMany("Depositors")
                        .HasForeignKey("DepId")
                        .IsRequired();

                    b.HasOne("Bank.Models.Employee", "Em")
                        .WithMany("Depositors")
                        .HasForeignKey("EmId")
                        .IsRequired();
                });

            modelBuilder.Entity("Bank.Models.Deposits", b =>
                {
                    b.HasOne("Bank.Models.Currency", "Cur")
                        .WithMany("Deposits")
                        .HasForeignKey("CurId")
                        .IsRequired();
                });

            modelBuilder.Entity("Bank.Models.Employee", b =>
                {
                    b.HasOne("Bank.Models.Positions", "Pos")
                        .WithMany("Employee")
                        .HasForeignKey("PosId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
