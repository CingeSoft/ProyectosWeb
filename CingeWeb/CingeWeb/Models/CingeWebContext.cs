using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CingeWeb.Models
{
    public partial class CingeWebContext : DbContext
    {
        public CingeWebContext()
        {
        }

        public CingeWebContext(DbContextOptions<CingeWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Compañia> Compañia { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compañia>(entity =>
            {
                entity.HasKey(e => e.IdCompañia);

                entity.Property(e => e.IdCompañia)
                    .HasMaxLength(4)
                    .ValueGeneratedNever();

                entity.Property(e => e.ApartadoPostal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CedulaJuridica)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion).IsRequired();

                entity.Property(e => e.DireccionLogo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FacturaElectronica)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NombreCompañia)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PaginaWeb)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.Property(e => e.IdRol)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Usuario);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Contraseñas)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.IdRol)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UltimoLogeo).HasColumnType("datetime");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Roles");
            });
        }
    }
}
