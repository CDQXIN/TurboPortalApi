﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TurboPortalApi.Core;

namespace TurboPortalApi.Core.Migrations
{
    [DbContext(typeof(TurboPortalContext))]
    [Migration("20210701153312_i1")]
    partial class i1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TurboPortalApi.Entity.Resources", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("编号")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime")
                        .HasComment("创建时间");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LastModifierId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LessonUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisitNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Resources");

                    b
                        .HasComment("课程资源");
                });

            modelBuilder.Entity("TurboPortalApi.Entity.UserResourceMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserResourceMapping");
                });

            modelBuilder.Entity("TurboPortalApi.Entity.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("编号")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime")
                        .HasComment("创建时间");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastLoginTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifierId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LoginNum")
                        .HasColumnType("int");

                    b.Property<string>("Mobile")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QQ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b
                        .HasComment("网站用户");
                });
#pragma warning restore 612, 618
        }
    }
}
