﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using maibagamofisa.Models;

#nullable disable

namespace maibagamofisa.Migrations
{
    [DbContext(typeof(DeutschlernenproContext))]
    [Migration("20240328094533_addvegetableandanimal")]
    partial class addvegetableandanimal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("maibagamofisa.Models.Animal", b =>
                {
                    b.Property<int>("AnimalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnimalID"));

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GermanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LessonID")
                        .HasColumnType("int");

                    b.HasKey("AnimalID");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("maibagamofisa.Models.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .HasColumnType("int")
                        .HasColumnName("ColorID");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GermanName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("LessonId")
                        .HasColumnType("int")
                        .HasColumnName("LessonID");

                    b.HasKey("ColorId")
                        .HasName("PK__Colors__8DA7676DF8AC25CB");

                    b.HasIndex("LessonId");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("maibagamofisa.Models.Fruit", b =>
                {
                    b.Property<int>("FruitId")
                        .HasColumnType("int")
                        .HasColumnName("FruitID");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GermanName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("LessonId")
                        .HasColumnType("int")
                        .HasColumnName("LessonID");

                    b.HasKey("FruitId")
                        .HasName("PK__Fruits__F33DDB2D3D8B0651");

                    b.HasIndex("LessonId");

                    b.ToTable("Fruit");
                });

            modelBuilder.Entity("maibagamofisa.Models.Vegetable", b =>
                {
                    b.Property<int>("VegetableID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VegetableID"));

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GermanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LessonID")
                        .HasColumnType("int");

                    b.HasKey("VegetableID");

                    b.ToTable("Vegetable");
                });

            modelBuilder.Entity("maibagamofisa.Models.VocabularyLesson", b =>
                {
                    b.Property<int>("LessonId")
                        .HasColumnType("int")
                        .HasColumnName("LessonID");

                    b.Property<string>("CoverImagePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("GermanLessonName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LessonId")
                        .HasName("PK__Vocabula__B084ACB0795A3570");

                    b.ToTable("VocabularyLessons");
                });

            modelBuilder.Entity("maibagamofisa.Models.Color", b =>
                {
                    b.HasOne("maibagamofisa.Models.VocabularyLesson", "Lesson")
                        .WithMany("Colors")
                        .HasForeignKey("LessonId")
                        .HasConstraintName("FK__Colors__LessonID__4BAC3F29");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("maibagamofisa.Models.Fruit", b =>
                {
                    b.HasOne("maibagamofisa.Models.VocabularyLesson", "Lesson")
                        .WithMany("Fruits")
                        .HasForeignKey("LessonId")
                        .HasConstraintName("PK__Fruits__F33DDB2D3D8B0651");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("maibagamofisa.Models.VocabularyLesson", b =>
                {
                    b.Navigation("Colors");

                    b.Navigation("Fruits");
                });
#pragma warning restore 612, 618
        }
    }
}
