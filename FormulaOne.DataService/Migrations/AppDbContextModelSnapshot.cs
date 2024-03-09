﻿// <auto-generated />
using System;
using FormulaOne.DataService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormulaOne.DataService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("FormulaOne.Entities.DbSet.Achievement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FastestLap")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PolePosition")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RaceWins")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("WorldChampionship")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("FormulaOne.Entities.DbSet.Circuit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Circuits");
                });

            modelBuilder.Entity("FormulaOne.Entities.DbSet.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<int>("DriverNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("FormulaOne.Entities.DbSet.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Base")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Chassis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("FastestLaps")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstTeamEntry")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullTeamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HighestRaceFinished")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PolePositions")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PowerUnit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamChief")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TechnicalChief")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TimesHighestRaceFinished")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("WorldChampionships")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("FormulaOne.Entities.DbSet.Achievement", b =>
                {
                    b.HasOne("FormulaOne.Entities.DbSet.Driver", "Driver")
                        .WithMany("Achievements")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Achivements_Driver");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("FormulaOne.Entities.DbSet.Driver", b =>
                {
                    b.HasOne("FormulaOne.Entities.DbSet.Team", "Team")
                        .WithMany("Drivers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_Team_Driver");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("FormulaOne.Entities.DbSet.Driver", b =>
                {
                    b.Navigation("Achievements");
                });

            modelBuilder.Entity("FormulaOne.Entities.DbSet.Team", b =>
                {
                    b.Navigation("Drivers");
                });
#pragma warning restore 612, 618
        }
    }
}
