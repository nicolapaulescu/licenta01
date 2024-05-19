    using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using maibagamofisa.Models;

namespace maibagamofisa.Models;

public partial class DeutschlernenproContext : DbContext
{
    public DeutschlernenproContext()
    {
    }

    public DeutschlernenproContext(DbContextOptions<DeutschlernenproContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Color> Colors { get; set; }
    public virtual DbSet<VocabularyLesson> VocabularyLessons { get; set; }
    public virtual DbSet<Fruit> Fruits { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__Colors__8DA7676DF8AC25CB");

            entity.Property(e => e.ColorId)
                .ValueGeneratedNever()
                .HasColumnName("ColorID");
            entity.Property(e => e.EnglishName).HasMaxLength(50);
            entity.Property(e => e.GermanName).HasMaxLength(50);
            entity.Property(e => e.ImagePath).HasMaxLength(255);
            entity.Property(e => e.LessonId).HasColumnName("LessonID");

            entity.HasOne(d => d.Lesson).WithMany(p => p.Colors)
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("FK__Colors__LessonID__4BAC3F29");
        });
        modelBuilder.Entity<Fruit>(entity =>
        {
            entity.HasKey(e => e.FruitId).HasName("PK__Fruits__F33DDB2D3D8B0651");

            entity.Property(e => e.FruitId)
                .ValueGeneratedNever()
                .HasColumnName("FruitID");
            entity.Property(e => e.EnglishName).HasMaxLength(50);
            entity.Property(e => e.GermanName).HasMaxLength(50);
            entity.Property(e => e.ImagePath).HasMaxLength(255);
            entity.Property(e => e.LessonId).HasColumnName("LessonID");

            entity.HasOne(d => d.Lesson).WithMany(p => p.Fruits)
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("PK__Fruits__F33DDB2D3D8B0651");
        });


        modelBuilder.Entity<VocabularyLesson>(entity =>
        {
            entity.HasKey(e => e.LessonId).HasName("PK__Vocabula__B084ACB0795A3570");

            entity.Property(e => e.LessonId)
                .ValueGeneratedNever()
                .HasColumnName("LessonID");
            entity.Property(e => e.CoverImagePath).HasMaxLength(255);
            entity.Property(e => e.GermanLessonName).HasMaxLength(100);
            entity.Property(e => e.LessonName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<maibagamofisa.Models.Vegetable> Vegetables { get; set; } = default!;

public DbSet<maibagamofisa.Models.Animal> Animals { get; set; } = default!;

public DbSet<maibagamofisa.Models.Body> Body { get; set; } = default!;

public DbSet<maibagamofisa.Models.House> House { get; set; } = default!;

public DbSet<maibagamofisa.Models.Job> Jobs { get; set; } = default!;

public DbSet<maibagamofisa.Models.Verb> Verbs { get; set; } = default!;

public DbSet<maibagamofisa.Models.Daysoftheweek> Daysoftheweek { get; set; } = default!;

public DbSet<maibagamofisa.Models.Dialogue> Dialogue { get; set; } = default!;

public DbSet<maibagamofisa.Models.Chat> Chat { get; set; } = default!;

    
}
