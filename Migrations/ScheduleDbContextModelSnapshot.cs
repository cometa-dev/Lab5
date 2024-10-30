﻿// <auto-generated />
using Lab5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab5.Migrations
{
    [DbContext(typeof(ScheduleDbContext))]
    partial class ScheduleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("Lab5.Models.ClassPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ClassPeriods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Time = "8:30 - 10:05"
                        },
                        new
                        {
                            Id = 2,
                            Time = "10:25 - 12:00"
                        },
                        new
                        {
                            Id = 3,
                            Time = "12:20 - 13:55"
                        },
                        new
                        {
                            Id = 4,
                            Time = "14:15 - 15:50"
                        });
                });

            modelBuilder.Entity("Lab5.Models.Classroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Classrooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 30,
                            Number = "101"
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 25,
                            Number = "102"
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 40,
                            Number = "201"
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 35,
                            Number = "202"
                        });
                });

            modelBuilder.Entity("Lab5.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfStudents")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "КН-11",
                            NumberOfStudents = 25,
                            Year = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "КН-12",
                            NumberOfStudents = 27,
                            Year = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "КН-21",
                            NumberOfStudents = 23,
                            Year = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "КН-22",
                            NumberOfStudents = 24,
                            Year = 2
                        });
                });

            modelBuilder.Entity("Lab5.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Instructors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = "Кафедра КН",
                            Email = "ivanov@example.com",
                            Name = "Іванов І.І."
                        },
                        new
                        {
                            Id = 2,
                            Department = "Кафедра КН",
                            Email = "petrov@example.com",
                            Name = "Петров П.П."
                        },
                        new
                        {
                            Id = 3,
                            Department = "Кафедра КН",
                            Email = "sidorov@example.com",
                            Name = "Сидоров С.С."
                        },
                        new
                        {
                            Id = 4,
                            Department = "Кафедра КН",
                            Email = "koval@example.com",
                            Name = "Коваль К.К."
                        });
                });

            modelBuilder.Entity("Lab5.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassPeriodId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassroomId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InstructorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClassPeriodId");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("GroupId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassPeriodId = 1,
                            ClassroomId = 1,
                            GroupId = 1,
                            InstructorId = 1
                        },
                        new
                        {
                            Id = 2,
                            ClassPeriodId = 2,
                            ClassroomId = 2,
                            GroupId = 2,
                            InstructorId = 2
                        });
                });

            modelBuilder.Entity("Lab5.Models.Schedule", b =>
                {
                    b.HasOne("Lab5.Models.ClassPeriod", "ClassPeriod")
                        .WithMany("Schedules")
                        .HasForeignKey("ClassPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab5.Models.Classroom", "Classroom")
                        .WithMany("Schedules")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab5.Models.Group", "Group")
                        .WithMany("Schedules")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab5.Models.Instructor", "Instructor")
                        .WithMany("Schedules")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassPeriod");

                    b.Navigation("Classroom");

                    b.Navigation("Group");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Lab5.Models.ClassPeriod", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Lab5.Models.Classroom", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Lab5.Models.Group", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Lab5.Models.Instructor", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
