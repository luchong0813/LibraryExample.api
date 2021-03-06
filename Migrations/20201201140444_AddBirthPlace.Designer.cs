﻿// <auto-generated />
using System;
using LibraryExample.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryExample.api.Migrations
{
    [DbContext(typeof(LibrayDbContext))]
    [Migration("20201201140444_AddBirthPlace")]
    partial class AddBirthPlace
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryExample.api.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("BirthData")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthData = new DateTimeOffset(new DateTime(1960, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            BirthPlace = "北京",
                            Email = "yangwanqing@outlook.com",
                            Name = "杨万青"
                        },
                        new
                        {
                            Id = 2,
                            BirthData = new DateTimeOffset(new DateTime(2005, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            BirthPlace = "南京",
                            Email = "ltm@outlook.com",
                            Name = "梁垌明"
                        },
                        new
                        {
                            Id = 3,
                            BirthData = new DateTimeOffset(new DateTime(1993, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            BirthPlace = "上海",
                            Email = "dshjdsh@163.com",
                            Name = "刘铁萌"
                        },
                        new
                        {
                            Id = 4,
                            BirthData = new DateTimeOffset(new DateTime(1995, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            BirthPlace = "深圳",
                            Email = "zzh@outlook.com",
                            Name = "赵梓恒"
                        },
                        new
                        {
                            Id = 5,
                            BirthData = new DateTimeOffset(new DateTime(1994, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            BirthPlace = "成都",
                            Email = "34782742@outlook.com",
                            Name = "鲁小冲"
                        });
                });

            modelBuilder.Entity("LibraryExample.api.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("Page")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Description = "Description of Book 1",
                            Page = 786,
                            Title = "Book1"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 3,
                            Description = "Description of Book 2",
                            Page = 786,
                            Title = "Book2"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 4,
                            Description = "Description of Book 3",
                            Page = 786,
                            Title = "Book3"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            Description = "Description of Book 4",
                            Page = 786,
                            Title = "Book4"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 5,
                            Description = "Description of Book 5",
                            Page = 786,
                            Title = "Book5"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 2,
                            Description = "Description of Book 6",
                            Page = 786,
                            Title = "Book6"
                        });
                });

            modelBuilder.Entity("LibraryExample.api.Entities.Book", b =>
                {
                    b.HasOne("LibraryExample.api.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
