﻿// <auto-generated />
using System;
using EdgeCloud.LES.ClassLibrary.Repository.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EdgeCloud.LES.ClassLibrary.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EdgeCloud.LES.ClassLibrary.Core.Models.ApiRequestLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClientMessage")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("ContentType")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ErrorMessage")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("MacAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RequestData")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<DateTimeOffset>("RequestDate")
                        .HasColumnType("datetimeoffset(7)");

                    b.Property<string>("ResponseData")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<DateTimeOffset>("ResponseDate")
                        .HasColumnType("datetimeoffset(7)");

                    b.Property<DateTimeOffset>("ServerImportDate")
                        .HasColumnType("datetimeoffset(7)");

                    b.HasKey("Id");

                    b.ToTable("ApiRequestLogs");
                });

            modelBuilder.Entity("EdgeCloud.LES.ClassLibrary.Core.Models.EventLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<string>("MacAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("ServerImportDate")
                        .HasColumnType("datetimeoffset(7)");

                    b.Property<int>("ServiceType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EventLogs");
                });

            modelBuilder.Entity("EdgeCloud.LES.ClassLibrary.Core.Models.InteractionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClientMessage")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<DateTimeOffset>("InteractionActivityDate")
                        .HasColumnType("datetimeoffset(7)");

                    b.Property<string>("MacAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("ServerImportDate")
                        .HasColumnType("datetimeoffset(7)");

                    b.HasKey("Id");

                    b.ToTable("InteractionLogs");
                });

            modelBuilder.Entity("EdgeCloud.LES.ClassLibrary.Core.Models.NavigationLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClientMessage")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("MacAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("NavigationActivityDate")
                        .HasColumnType("datetimeoffset(7)");

                    b.Property<DateTimeOffset>("ServerImportDate")
                        .HasColumnType("datetimeoffset(7)");

                    b.HasKey("Id");

                    b.ToTable("NavigationLogs");
                });

            modelBuilder.Entity("EdgeCloud.LES.ClassLibrary.Core.Models.NetworkLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ActivityType")
                        .HasColumnType("int");

                    b.Property<string>("MacAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("NetworkActivityDate")
                        .HasColumnType("datetimeoffset(7)");

                    b.Property<DateTimeOffset>("ServerImportDate")
                        .HasColumnType("datetimeoffset(7)");

                    b.HasKey("Id");

                    b.ToTable("NetworkLogs");
                });

            modelBuilder.Entity("EdgeCloud.LES.ClassLibrary.Core.Models.UserAuthenticationLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ActivityType")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("AuthActivityDate")
                        .HasColumnType("datetimeoffset(7)");

                    b.Property<string>("ClientMessage")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("ErrorMessage")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("MacAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("ServerImportDate")
                        .HasColumnType("datetimeoffset(7)");

                    b.HasKey("Id");

                    b.ToTable("AuthenticationLogs");
                });
#pragma warning restore 612, 618
        }
    }
}