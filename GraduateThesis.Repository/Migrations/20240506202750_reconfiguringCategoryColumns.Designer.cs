﻿// <auto-generated />
using System;
using GraduateThesis.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraduateThesis.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240506202750_reconfiguringCategoryColumns")]
    partial class reconfiguringCategoryColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GraduateThesis.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Teknoloji",
                            CreatedDate = new DateTime(2024, 5, 6, 23, 27, 50, 221, DateTimeKind.Local).AddTicks(4771)
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Spor",
                            CreatedDate = new DateTime(2024, 5, 6, 23, 27, 50, 221, DateTimeKind.Local).AddTicks(4780)
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Kitap",
                            CreatedDate = new DateTime(2024, 5, 6, 23, 27, 50, 221, DateTimeKind.Local).AddTicks(4782)
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Sanat",
                            CreatedDate = new DateTime(2024, 5, 6, 23, 27, 50, 221, DateTimeKind.Local).AddTicks(4783)
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Dans",
                            CreatedDate = new DateTime(2024, 5, 6, 23, 27, 50, 221, DateTimeKind.Local).AddTicks(4784)
                        },
                        new
                        {
                            Id = 6,
                            CategoryName = "Girişimcilik",
                            CreatedDate = new DateTime(2024, 5, 6, 23, 27, 50, 221, DateTimeKind.Local).AddTicks(4785)
                        });
                });

            modelBuilder.Entity("GraduateThesis.Core.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClubName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClubPhoto")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ClubSummary")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsClubActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Clubs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClubName = "DU Siber",
                            ClubPhoto = "default.jpg",
                            ClubSummary = "DU Siber Kulübü, öğrencilere teknoloji, yazılım ve siber güvenlik alanlarında deneyim kazanma imkanı sunar. Atölyeler, yarışmalar ve seminerlerle öğrenme ortamı sağlar. Katılın, teknolojiye adım atın ve kendinizi geliştirin!",
                            CreatedDate = new DateTime(2024, 5, 6, 23, 27, 50, 221, DateTimeKind.Local).AddTicks(5028),
                            IsClubActive = true
                        },
                        new
                        {
                            Id = 2,
                            ClubName = "Kitap Dostu",
                            ClubPhoto = "default.jpg",
                            ClubSummary = "Kitap Dostu Kulübü, kitap tutkunlarını bir araya getirerek edebiyatın büyülü dünyasında yolculuğa çıkarır. Okuma tutkusunu paylaşan herkesi bekliyoruz!",
                            CreatedDate = new DateTime(2024, 5, 6, 23, 27, 50, 221, DateTimeKind.Local).AddTicks(5030),
                            IsClubActive = true
                        },
                        new
                        {
                            Id = 3,
                            ClubName = "DU Archer Club",
                            ClubPhoto = "default.jpg",
                            ClubSummary = "DU Archer Club, okçuluk tutkunlarının buluşma noktasıdır. Okçuluk sporuna ilgi duyan herkesi bekliyoruz! ",
                            CreatedDate = new DateTime(2024, 5, 6, 23, 27, 50, 221, DateTimeKind.Local).AddTicks(5031),
                            IsClubActive = true
                        },
                        new
                        {
                            Id = 4,
                            ClubName = "DU Scout Club",
                            ClubPhoto = "default.jpg",
                            ClubSummary = "Kulübümüz, doğayla iç içe olmayı, macera dolu anlar yaşamayı seven herkesi bir araya getiriyor. Keşfetmeye hazır mısın?  ",
                            CreatedDate = new DateTime(2024, 5, 6, 23, 27, 50, 221, DateTimeKind.Local).AddTicks(5032),
                            IsClubActive = true
                        },
                        new
                        {
                            Id = 5,
                            ClubName = "Elit Dans Kulübü",
                            ClubPhoto = "default.jpg",
                            ClubSummary = "Elit Dans Kulübü, ritim tutmayı seven herkes için mükemmel bir buluşma noktasıdır. Eğlenceli dans dersleri ve unutulmaz performanslarla dolu bir deneyim için seni de bekliyoruz! ",
                            CreatedDate = new DateTime(2024, 5, 6, 23, 27, 50, 221, DateTimeKind.Local).AddTicks(5033),
                            IsClubActive = true
                        },
                        new
                        {
                            Id = 6,
                            ClubName = "The Young Entrepreneurs Club",
                            ClubPhoto = "default.jpg",
                            ClubSummary = "Genç Girişimciler Kulübü, yenilikçi fikirleriyle öne çıkan gençleri bir araya getirir. İş dünyasına adım atmak isteyenlere mentorluk yapar ve eğitimler düzenler. İş hayatına dair her şeyi keşfetmek için seni de aramıza bekliyoruz! ",
                            CreatedDate = new DateTime(2024, 5, 6, 23, 27, 50, 221, DateTimeKind.Local).AddTicks(5034),
                            IsClubActive = true
                        });
                });

            modelBuilder.Entity("GraduateThesis.Core.Models.ClubCategory", b =>
                {
                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ClubId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ClubCategories");

                    b.HasData(
                        new
                        {
                            ClubId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            ClubId = 2,
                            CategoryId = 3
                        },
                        new
                        {
                            ClubId = 3,
                            CategoryId = 2
                        },
                        new
                        {
                            ClubId = 4,
                            CategoryId = 2
                        },
                        new
                        {
                            ClubId = 5,
                            CategoryId = 5
                        },
                        new
                        {
                            ClubId = 6,
                            CategoryId = 6
                        });
                });

            modelBuilder.Entity("GraduateThesis.Core.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("GraduateThesis.Core.Models.ClubCategory", b =>
                {
                    b.HasOne("GraduateThesis.Core.Models.Category", "Category")
                        .WithMany("ClubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraduateThesis.Core.Models.Club", "Club")
                        .WithMany("ClubCategories")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("GraduateThesis.Core.Models.Category", b =>
                {
                    b.Navigation("ClubCategories");
                });

            modelBuilder.Entity("GraduateThesis.Core.Models.Club", b =>
                {
                    b.Navigation("ClubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
