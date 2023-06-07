using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaElecciones.Models;

public partial class EleccionesContext : DbContext
{
    public EleccionesContext()
    {
    }

    public EleccionesContext(DbContextOptions<EleccionesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidato> Candidatos { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Partido> Partidos { get; set; }

    public virtual DbSet<Resultado> Resultados { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Voto> Votos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidato>(entity =>
        {
            entity.HasKey(e => e.IdCandidato).HasName("PK__candidat__3CD1A86198E5CC52");

            entity.ToTable("candidatos");

            entity.Property(e => e.IdCandidato)
                .ValueGeneratedNever()
                .HasColumnName("id_candidato");
            entity.Property(e => e.Antecedentes)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("antecedentes");
            entity.Property(e => e.CantidadVotos)
                .IsUnicode(false)
                .HasColumnName("cantidad_votos");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Dpi)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("dpi");
            entity.Property(e => e.EstadoEliminado).HasColumnName("estado_eliminado");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Genero)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.IdCargo).HasColumnName("id_cargo");
            entity.Property(e => e.IdPartido).HasColumnName("id_partido");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Profesion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("profesion");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Candidatos)
                .HasForeignKey(d => d.IdCargo)
                .HasConstraintName("FK__candidato__id_ca__286302EC");

            entity.HasOne(d => d.IdPartidoNavigation).WithMany(p => p.Candidatos)
                .HasForeignKey(d => d.IdPartido)
                .HasConstraintName("FK__candidato__id_pa__276EDEB3");
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__cargo__D3C09EC5DFA4E906");

            entity.ToTable("cargo");

            entity.Property(e => e.IdCargo)
                .ValueGeneratedNever()
                .HasColumnName("id_cargo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.EstadoEliminado).HasColumnName("estado_eliminado");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__departam__64F37A16197220DC");

            entity.ToTable("departamentos");

            entity.Property(e => e.IdDepartamento)
                .ValueGeneratedNever()
                .HasColumnName("id_departamento");
            entity.Property(e => e.EstadoEliminado).HasColumnName("estado_eliminado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.IdMesa).HasName("PK__mesa__68A1E159447A21F7");

            entity.ToTable("mesa");

            entity.Property(e => e.IdMesa)
                .ValueGeneratedNever()
                .HasColumnName("id_mesa");
            entity.Property(e => e.NumMesa).HasColumnName("num_mesa");
            entity.Property(e => e.NumFolio).HasColumnName("num_folio");
            entity.Property(e => e.CantidadVotos).HasColumnName("cantidad_votos");
            entity.Property(e => e.EstadoEliminado).HasColumnName("estado_eliminado");
            entity.Property(e => e.IdUbicacion).HasColumnName("id_ubicacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdUbicacionNavigation).WithMany(p => p.Mesas)
                .HasForeignKey(d => d.IdUbicacion)
                .HasConstraintName("FK__mesa__id_ubicaci__32E0915F");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Mesas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__mesa__id_usuario__31EC6D26");
        });

        modelBuilder.Entity<Partido>(entity =>
        {
            entity.HasKey(e => e.IdPartido).HasName("PK__partido__42D83E44F749704D");

            entity.ToTable("partido");

            entity.Property(e => e.IdPartido)
                .ValueGeneratedNever()
                .HasColumnName("id_partido");
            entity.Property(e => e.EstadoEliminado).HasColumnName("estado_eliminado");
            entity.Property(e => e.FechaFundacion)
                .HasColumnType("date")
                .HasColumnName("fecha_fundacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Sede)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sede");
        });

        modelBuilder.Entity<Resultado>(entity =>
        {
            entity.HasKey(e => e.IdResultado).HasName("PK__resultad__33A42B3054673B59");

            entity.ToTable("resultado");

            entity.Property(e => e.IdResultado)
                .ValueGeneratedNever()
                .HasColumnName("id_resultado");
            entity.Property(e => e.EstadoEliminado).HasColumnName("estado_eliminado");
            entity.Property(e => e.IdCandidato).HasColumnName("id_candidato");
            entity.Property(e => e.Votos).HasColumnName("votos");

            entity.HasOne(d => d.IdCandidatoNavigation).WithMany(p => p.Resultados)
                .HasForeignKey(d => d.IdCandidato)
                .HasConstraintName("FK__resultado__id_ca__2B3F6F97");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__4E3E04AD7DB2FDAC");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("id_usuario");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.EstadoEliminado).HasColumnName("estado_eliminado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Voto>(entity =>
        {
            entity.HasKey(e => e.IdVoto).HasName("PK__voto__5F39601A4A944142");

            entity.ToTable("voto");

            entity.Property(e => e.IdVoto)
                .ValueGeneratedNever()
                .HasColumnName("id_voto");
            entity.Property(e => e.DpiCiudadano)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("dpi_ciudadano");
            entity.Property(e => e.EstadoEliminado).HasColumnName("estado_eliminado");
            entity.Property(e => e.IdCandidato).HasColumnName("id_candidato");
            entity.Property(e => e.IdMesa).HasColumnName("id_mesa");

            entity.HasOne(d => d.IdCandidatoNavigation).WithMany(p => p.Votos)
                .HasForeignKey(d => d.IdCandidato)
                .HasConstraintName("FK__voto__id_candida__35BCFE0A");

            entity.HasOne(d => d.IdMesaNavigation).WithMany(p => p.Votos)
                .HasForeignKey(d => d.IdMesa)
                .HasConstraintName("FK__voto__id_mesa__36B12243");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
