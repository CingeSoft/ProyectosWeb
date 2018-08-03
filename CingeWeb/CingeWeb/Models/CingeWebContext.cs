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

        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Cedulas> Cedulas { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Compañias> Compañias { get; set; }
        public virtual DbSet<InventFactura> InventFactura { get; set; }
        public virtual DbSet<InventFacturaLinea> InventFacturaLinea { get; set; }
        public virtual DbSet<InventFacturaMascota> InventFacturaMascota { get; set; }
        public virtual DbSet<Mascotas> Mascotas { get; set; }
        public virtual DbSet<Medidas> Medidas { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TipoArticulos> TipoArticulos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Zonas> Zonas { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulos>(entity =>
            {
                entity.HasKey(e => e.Código);

                entity.HasIndex(e => e.CódigoUnidad);

                entity.HasIndex(e => e.TipoArticulo);

                entity.Property(e => e.Código)
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.CostoPromedio).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.CódigoUnidad)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FechaCreacíon).HasColumnType("datetime");

                entity.Property(e => e.MargenUtilida).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PrecioVenta).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.TipoArticulo)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.CódigoUnidadNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.CódigoUnidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articulos_Medidas");

                entity.HasOne(d => d.TipoArticuloNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.TipoArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articulos_TipoProductos");
            });

            modelBuilder.Entity<Cedulas>(entity =>
            {
                entity.HasKey(e => e.CódigoCédula);

                entity.Property(e => e.CódigoCédula)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cédula)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.Código);

                entity.HasIndex(e => e.CódigoCédula);

                entity.HasIndex(e => e.CódigoZona);

                entity.Property(e => e.Código)
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cédula)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CódigoCédula)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CódigoZona)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Dirección)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaCreacíon).HasColumnType("datetime");

                entity.Property(e => e.Localidad)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TelefonoCodigoArea)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Teléfono)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.CódigoCédulaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CódigoCédula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_Cedulas");

                entity.HasOne(d => d.CódigoZonaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CódigoZona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_Zonas");
            });

            modelBuilder.Entity<Compañias>(entity =>
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

            modelBuilder.Entity<InventFactura>(entity =>
            {
                entity.HasKey(e => e.Consecutivo);

                entity.Property(e => e.Consecutivo)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cliente)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreadoFecha).HasColumnType("datetime");

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Descuento).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FormaPago)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Impuesto).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Subtotal).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TipoIdentificacion)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Total).HasColumnType("numeric(18, 4)");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.InventFactura)
                    .HasForeignKey(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventFactura_Clientes");

                entity.HasOne(d => d.TipoIdentificacionNavigation)
                    .WithMany(p => p.InventFactura)
                    .HasForeignKey(d => d.TipoIdentificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventFactura_Cedulas");
            });

            modelBuilder.Entity<InventFacturaLinea>(entity =>
            {
                entity.HasKey(e => new { e.Consecutivo, e.Linea });

                entity.Property(e => e.Consecutivo).HasMaxLength(50);

                entity.Property(e => e.Articulo)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Descuento).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.DescuentoPorcentaje).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Impuesto).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.ImpuestoPorcentaje).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Mascota)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PrecioTotal).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.PrecioUnitario).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.TotalLinea).HasColumnType("numeric(18, 4)");

                entity.HasOne(d => d.ArticuloNavigation)
                    .WithMany(p => p.InventFacturaLinea)
                    .HasForeignKey(d => d.Articulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventFacturaLinea_Articulos");

                entity.HasOne(d => d.ConsecutivoNavigation)
                    .WithMany(p => p.InventFacturaLinea)
                    .HasForeignKey(d => d.Consecutivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventFacturaLinea_InventFactura");

                entity.HasOne(d => d.InventFacturaMascota)
                    .WithMany(p => p.InventFacturaLinea)
                    .HasForeignKey(d => new { d.Consecutivo, d.Mascota })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventFacturaLinea_InventFacturaMascota");
            });

            modelBuilder.Entity<InventFacturaMascota>(entity =>
            {
                entity.HasKey(e => new { e.Consecutivo, e.Nombre });

                entity.Property(e => e.Consecutivo).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(200);

                entity.HasOne(d => d.ConsecutivoNavigation)
                    .WithMany(p => p.InventFacturaMascota)
                    .HasForeignKey(d => d.Consecutivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventFacturaMascota_InventFactura");

                entity.HasOne(d => d.NombreNavigation)
                    .WithMany(p => p.InventFacturaMascota)
                    .HasForeignKey(d => d.Nombre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventFacturaMascota_Mascotas");
            });

            modelBuilder.Entity<Mascotas>(entity =>
            {
                entity.HasKey(e => e.Nombre);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .ValueGeneratedNever();

                entity.Property(e => e.Código)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Edad).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Especie)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Peso).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.CódigoNavigation)
                    .WithMany(p => p.Mascotas)
                    .HasForeignKey(d => d.Código)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mascotas_Clientes");
            });

            modelBuilder.Entity<Medidas>(entity =>
            {
                entity.HasKey(e => e.CódigoUnidad);

                entity.Property(e => e.CódigoUnidad)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreUnidad)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.Property(e => e.IdRol)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TipoArticulos>(entity =>
            {
                entity.HasKey(e => e.TipoArticulo);

                entity.Property(e => e.TipoArticulo)
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreTipo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Usuario);

                entity.HasIndex(e => e.IdRol);

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

            modelBuilder.Entity<Zonas>(entity =>
            {
                entity.HasKey(e => e.CódigoZona);

                entity.Property(e => e.CódigoZona)
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreZona)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
