using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SenaiChamados.Models;

#nullable disable

namespace SenaiChamados.Models
{
    public partial class SenaiChamadosContext : DbContext
    {
        public SenaiChamadosContext()
        {
        }

        public SenaiChamadosContext(DbContextOptions<SenaiChamadosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chamado> Chamados { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Prioridade> Prioridades { get; set; }
        public virtual DbSet<RegistroMaterial> Registromateriais { get; set; }
        public virtual DbSet<Setor> Setors { get; set; }
        public virtual DbSet<StatusChamado> Statuschamados { get; set; }
        public virtual DbSet<TipoUsuario> Tipousuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=SenaiChamados;uid=root;pwd=Senai@132", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Chamado>(entity =>
            {
                entity.ToTable("chamado");

                entity.HasIndex(e => e.IdAutor, "IdAutor");

                entity.HasIndex(e => e.IdPrioridade, "IdPrioridade");

                entity.HasIndex(e => e.IdResponsavel, "IdResponsavel");

                entity.HasIndex(e => e.IdStatus, "IdStatus");

                entity.HasIndex(e => e.Lugar, "Lugar")
                    .IsUnique();

                entity.Property(e => e.DataAbertura).HasColumnType("date");

                entity.Property(e => e.DataDeFinalicao).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lugar)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.ChamadoIdAutorNavigations)
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("chamado_ibfk_3");

                entity.HasOne(d => d.IdPrioridadeNavigation)
                    .WithMany(p => p.Chamados)
                    .HasForeignKey(d => d.IdPrioridade)
                    .HasConstraintName("chamado_ibfk_1");

                entity.HasOne(d => d.IdResponsavelNavigation)
                    .WithMany(p => p.ChamadoIdResponsavelNavigations)
                    .HasForeignKey(d => d.IdResponsavel)
                    .HasConstraintName("chamado_ibfk_4");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Chamados)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("chamado_ibfk_2");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("material");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Quantidade)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Prioridade>(entity =>
            {
                entity.ToTable("prioridade");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<RegistroMaterial>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("registromateriais");

                entity.HasIndex(e => e.IdChamado, "IdChamado");

                entity.HasIndex(e => e.IdMaterial, "IdMaterial");

                entity.HasOne(d => d.IdChamadoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdChamado)
                    .HasConstraintName("registromateriais_ibfk_2");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdMaterial)
                    .HasConstraintName("registromateriais_ibfk_1");
            });

            modelBuilder.Entity<Setor>(entity =>
            {
                entity.ToTable("setor");

                entity.HasIndex(e => e.Descricao, "Descricao")
                    .IsUnique();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StatusChamado>(entity =>
            {
                entity.ToTable("statuschamado");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("tipousuario");

                entity.HasIndex(e => e.Descricao, "Descricao")
                    .IsUnique();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.HasIndex(e => e.IdSetor, "IdSetor");

                entity.HasIndex(e => e.IdTipoUsuario, "IdTipoUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdSetorNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdSetor)
                    .HasConstraintName("usuario_ibfk_2");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("usuario_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
