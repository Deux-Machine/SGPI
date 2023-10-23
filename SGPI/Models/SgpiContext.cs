using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SGPI.Models;

public partial class SgpiContext : DbContext
{
    public SgpiContext()
    {
    }

    public SgpiContext(DbContextOptions<SgpiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Homologacion> Homologacions { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Programa> Programas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoHomologacion> TipoHomologacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
    if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=SEBASTIAN-ALVAR;Database=SGPI;Trusted_Connection=True;TrustServerCertificate=True;");
        }
            }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero);

            entity.ToTable("Genero");

            entity.HasIndex(e => e.IdGenero, "Id_Genero").IsUnique();

            entity.Property(e => e.IdGenero).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Homologacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Homologacion");

            entity.HasIndex(e => e.IdHomologacion, "Id_Homologacion").IsUnique();

            entity.Property(e => e.AsignaturaAnterior)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Asignatura_Anterior");
            entity.Property(e => e.AsigntauraNueva)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Asigntaura_Nueva");
            entity.Property(e => e.CreditoAnterioro).HasColumnName("Credito_Anterioro");
            entity.Property(e => e.CreditoNuevo).HasColumnName("Credito_Nuevo");
            entity.Property(e => e.IdHomologacion).HasColumnName("Id_Homologacion");
            entity.Property(e => e.IdPrograma).HasColumnName("Id_Programa");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.IdPago, "Id_Pagos").IsUnique();

            entity.Property(e => e.FechaPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Fecha_Pago");
            entity.Property(e => e.IdPago).HasColumnName("Id_Pago");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Recibo)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Programa>(entity =>
        {
            entity.HasKey(e => e.IdPrograma);

            entity.ToTable("Programa");

            entity.HasIndex(e => e.IdPrograma, "Id_Programa").IsUnique();

            entity.Property(e => e.IdPrograma).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("Rol");

            entity.HasIndex(e => e.IdRol, "Id_Rol").IsUnique();

            entity.Property(e => e.IdRol).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdDoc);

            entity.ToTable("TipoDocumento");

            entity.HasIndex(e => e.IdDoc, "Id_TipoDocumento").IsUnique();

            entity.Property(e => e.IdDoc).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoHomologacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TipoHomologacion");

            entity.HasIndex(e => e.IdTipoHomologacion, "Id_TipoHomologacion").IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IdHomologacion).HasColumnName("Id_Homologacion");
            entity.Property(e => e.IdTipoHomologacion).HasColumnName("Id_TipoHomologacion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.IdUsuario, "Id_Usuario").IsUnique();

            entity.Property(e => e.IdUsuario).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NumDoc).HasColumnName("Num_Doc");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Primero_Apelliod");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Segundo_Apellido");

            entity.HasOne(d => d.IdDocNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUsuarioTipoDocumento");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUsuarioGenero");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUsuarioRol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
