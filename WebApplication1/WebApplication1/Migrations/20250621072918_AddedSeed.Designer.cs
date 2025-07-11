﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.DAL;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ExamDbContext))]
    [Migration("20250621072918_AddedSeed")]
    partial class AddedSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Model.Language", b =>
                {
                    b.Property<int>("IdLanguage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLanguage"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdLanguage");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            IdLanguage = 1,
                            Name = "C#"
                        },
                        new
                        {
                            IdLanguage = 2,
                            Name = "Java"
                        });
                });

            modelBuilder.Entity("WebApplication1.Model.Record", b =>
                {
                    b.Property<int>("IdRecord")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRecord"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExecutionTime")
                        .HasColumnType("int");

                    b.Property<int>("IdLanguage")
                        .HasColumnType("int");

                    b.Property<int>("IdStudent")
                        .HasColumnType("int");

                    b.Property<int>("IdTask")
                        .HasColumnType("int");

                    b.HasKey("IdRecord");

                    b.HasIndex("IdLanguage");

                    b.HasIndex("IdStudent");

                    b.HasIndex("IdTask");

                    b.ToTable("Records");

                    b.HasData(
                        new
                        {
                            IdRecord = 1,
                            CreatedAt = new DateTime(2015, 5, 29, 5, 50, 6, 0, DateTimeKind.Unspecified),
                            ExecutionTime = 1233,
                            IdLanguage = 1,
                            IdStudent = 1,
                            IdTask = 1
                        },
                        new
                        {
                            IdRecord = 2,
                            CreatedAt = new DateTime(2016, 4, 10, 10, 20, 0, 0, DateTimeKind.Unspecified),
                            ExecutionTime = 874,
                            IdLanguage = 2,
                            IdStudent = 2,
                            IdTask = 2
                        });
                });

            modelBuilder.Entity("WebApplication1.Model.Student", b =>
                {
                    b.Property<int>("IdStudent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStudent"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdStudent");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            IdStudent = 1,
                            Email = "tomcio@wp.pl",
                            FirstName = "Tomek",
                            LastName = "Kowalski"
                        },
                        new
                        {
                            IdStudent = 2,
                            Email = "aniaK@wp.pl",
                            FirstName = "Ala",
                            LastName = "Kowalska"
                        });
                });

            modelBuilder.Entity("WebApplication1.Model.Task", b =>
                {
                    b.Property<int>("IdTask")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTask"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdTask");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            IdTask = 1,
                            Description = "Write a program that prints the numbers from 1 to 100.",
                            Name = "Fizz-Buzz"
                        },
                        new
                        {
                            IdTask = 2,
                            Description = "Check if a string is a palindrome.",
                            Name = "Palindrome"
                        });
                });

            modelBuilder.Entity("WebApplication1.Model.Record", b =>
                {
                    b.HasOne("WebApplication1.Model.Language", "Language")
                        .WithMany("Records")
                        .HasForeignKey("IdLanguage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Model.Student", "Student")
                        .WithMany("Records")
                        .HasForeignKey("IdStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Model.Task", "Task")
                        .WithMany("Records")
                        .HasForeignKey("IdTask")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Student");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("WebApplication1.Model.Language", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("WebApplication1.Model.Student", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("WebApplication1.Model.Task", b =>
                {
                    b.Navigation("Records");
                });
#pragma warning restore 612, 618
        }
    }
}
