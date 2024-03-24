﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using newshub.Data;

#nullable disable

namespace newshub.Migrations
{
    [DbContext(typeof(UserdbContext))]
    [Migration("20240325192119_Favoriteuser")]
    partial class Favoriteuser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("newshub.Models.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArticleTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Favoriteuser");
                });

            modelBuilder.Entity("newshub.Models.Nadmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uemail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("upass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("newshub.Models.Register", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userID"));

                    b.Property<string>("conpass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uemail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("umob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("upass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("newshub.Models.cardData1", b =>
                {
                    b.Property<int>("cardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cardID"));

                    b.Property<string>("Channel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VedioLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cardID");

                    b.ToTable("cardData");
                });
#pragma warning restore 612, 618
        }
    }
}
