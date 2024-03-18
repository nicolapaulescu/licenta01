using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
}
