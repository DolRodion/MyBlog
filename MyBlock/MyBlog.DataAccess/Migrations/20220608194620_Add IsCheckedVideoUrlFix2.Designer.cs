﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlog.DataAccess;

#nullable disable

namespace MyBlog.DataAccess.Migrations
{
    [DbContext(typeof(DbCheckContext))]
    [Migration("20220608194620_Add IsCheckedVideoUrlFix2")]
    partial class AddIsCheckedVideoUrlFix2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CheckTag", b =>
                {
                    b.Property<int>("ChecksId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("ChecksId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("CheckTag");
                });

            modelBuilder.Entity("MyBlog.DataAccess.Entities.Check", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CheckAuthor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArhival")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCheckedVideoUrl")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Check");
                });

            modelBuilder.Entity("MyBlog.DataAccess.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AvtorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CheckId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CheckId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("MyBlog.DataAccess.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("MyBlog.DataAccess.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("CheckTag", b =>
                {
                    b.HasOne("MyBlog.DataAccess.Entities.Check", null)
                        .WithMany()
                        .HasForeignKey("ChecksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBlog.DataAccess.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBlog.DataAccess.Entities.Check", b =>
                {
                    b.HasOne("MyBlog.DataAccess.Entities.Employee", "Employee")
                        .WithMany("Checks")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MyBlog.DataAccess.Entities.Comment", b =>
                {
                    b.HasOne("MyBlog.DataAccess.Entities.Check", "Check")
                        .WithMany("Comments")
                        .HasForeignKey("CheckId");

                    b.Navigation("Check");
                });

            modelBuilder.Entity("MyBlog.DataAccess.Entities.Check", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("MyBlog.DataAccess.Entities.Employee", b =>
                {
                    b.Navigation("Checks");
                });
#pragma warning restore 612, 618
        }
    }
}
