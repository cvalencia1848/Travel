using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Travel.Models
{
    public partial class TravelContext : DbContext
    {
        public TravelContext()
        {
        }

        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; } = null!;
        public virtual DbSet<AutoresHasLibro> AutoresHasLibros { get; set; } = null!;
        public virtual DbSet<Editoriale> Editoriales { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Travel;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autore>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nobre)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AutoresHasLibro>(entity =>
            {
                entity.HasOne(d => d.IdAutoresNavigation)
                    .WithMany(p => p.AutoresHasLibros)
                    .HasForeignKey(d => d.IdAutores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AutoresHasLibros_Autores");

                entity.HasOne(d => d.IdLibrosNavigation)
                    .WithMany(p => p.AutoresHasLibros)
                    .HasForeignKey(d => d.IdLibros)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AutoresHasLibros_Libros");
            });

            modelBuilder.Entity<Editoriale>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sede)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.Property(e => e.NumeroPaginas)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis).HasColumnType("text");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.EditorialesNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.Editoriales)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Libros_Editoriales");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
