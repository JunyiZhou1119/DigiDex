using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DigimonApi.Models
{
    public partial class DigimonContext : DbContext
    {
   

        public DigimonContext(DbContextOptions<DigimonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DigiDex> DigiDex { get; set; }
        public virtual DbSet<DigiInfo> DigiInfo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DigiDex>(entity =>
            {
                entity.HasKey(e => e.DigiId)
                    .HasName("PK__DigiDex__7609777131987739");

                entity.Property(e => e.DigiId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DigiInfo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ability)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Attribute)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Hp).HasColumnName("HP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sp).HasColumnName("SP");

                entity.Property(e => e.Stage)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Digi)
                    .WithMany(p => p.DigiInfo)
                    .HasForeignKey(d => d.DigiId)
                    .HasConstraintName("FK__DigiInfo__DigiId__2D27B809");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
