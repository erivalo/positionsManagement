﻿// <auto-generated />
using Management.Service.Infrastructure.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Management.Service.Infrastructure.Data.EntityFramework.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20250323125557_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Management.Service.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Engeneering"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Data"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Operations"
                        });
                });

            modelBuilder.Entity("Management.Service.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Budget")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PositionNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PositionStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecruiterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PositionStatusId");

                    b.HasIndex("RecruiterId");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Budget = 5000m,
                            DepartmentId = 1,
                            PositionNumber = 1,
                            PositionStatusId = 1,
                            RecruiterId = 1,
                            Title = "Senior Software Engineer"
                        },
                        new
                        {
                            Id = 2,
                            Budget = 5500m,
                            DepartmentId = 1,
                            PositionNumber = 2,
                            PositionStatusId = 1,
                            RecruiterId = 1,
                            Title = "Full-Stack Engineer"
                        },
                        new
                        {
                            Id = 3,
                            Budget = 4500m,
                            DepartmentId = 2,
                            PositionNumber = 3,
                            PositionStatusId = 1,
                            RecruiterId = 1,
                            Title = "Solutions Engineer (Shopify)"
                        });
                });

            modelBuilder.Entity("Management.Service.Models.PositionStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PositionsStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Completed"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Closed"
                        });
                });

            modelBuilder.Entity("Management.Service.Models.Recruiter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Recruiters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Maria"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Juana"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cinthia"
                        });
                });

            modelBuilder.Entity("Management.Service.Models.Position", b =>
                {
                    b.HasOne("Management.Service.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Management.Service.Models.PositionStatus", "PositionStatus")
                        .WithMany()
                        .HasForeignKey("PositionStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Management.Service.Models.Recruiter", "Recruiter")
                        .WithMany()
                        .HasForeignKey("RecruiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("PositionStatus");

                    b.Navigation("Recruiter");
                });
#pragma warning restore 612, 618
        }
    }
}
