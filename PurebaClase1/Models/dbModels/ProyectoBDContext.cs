using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PurebaClase1.Models.dbModels
{
    public partial class ProyectoBDContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {

        public ProyectoBDContext()
        {
        }

        public ProyectoBDContext(DbContextOptions<ProyectoBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrito> Carritos { get; set; } = null!;
        public virtual DbSet<CategoriaRopa> CategoriaRopas { get; set; } = null!;
        public virtual DbSet<CategoriaTicket> CategoriaTickets { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<DetallesDeVenta> DetallesDeVentas { get; set; } = null!;
        public virtual DbSet<Direccion> Direccions { get; set; } = null!; 
        public virtual DbSet<MetodoDePago> MetodoDePagos { get; set; } = null!;
        public virtual DbSet<Ropa> Ropas { get; set; } = null!;
        public virtual DbSet<RopaTalla> RopaTallas { get; set; } = null!;
        public virtual DbSet<Talla> Tallas { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<Venta> Ventas { get; set; } = null!;
        public object Direcciones { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdRopa });

                entity.Property(e => e.Cantidad).IsFixedLength();

                entity.HasOne(d => d.IdRopaNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdRopa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrito_Ropa");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrito_Usuarios");
            });

            modelBuilder.Entity<CategoriaRopa>(entity =>
            {
                entity.Property(e => e.IdCategoria).ValueGeneratedNever();
            });

            modelBuilder.Entity<CategoriaTicket>(entity =>
            {
                entity.Property(e => e.IdCategoria).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.IdColor).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<DetallesDeVenta>(entity =>
            {
                entity.HasKey(e => new { e.IdVentas, e.IdRopa });

                entity.HasOne(d => d.IdRopaNavigation)
                    .WithMany(p => p.DetallesDeVenta)
                    .HasForeignKey(d => d.IdRopa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetallesDeVentas_Ropa");

                entity.HasOne(d => d.IdVentasNavigation)
                    .WithMany(p => p.DetallesDeVenta)
                    .HasForeignKey(d => d.IdVentas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetallesDeVentas_Ventas");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.Property(e => e.IdDireccion).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Direccions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Direccion_Usuarios");
            });

            modelBuilder.Entity<MetodoDePago>(entity =>
            {
                entity.Property(e => e.IdMetododepago).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.MetodoDePagos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MetodoDePago_Usuarios");
            });


            modelBuilder.Entity<Ropa>(entity =>
            {
                entity.Property(e => e.IdRopa).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Ropas)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ropa_CategoriaRopa");

                entity.HasOne(d => d.IdColorNavigation)
                    .WithMany(p => p.Ropas)
                    .HasForeignKey(d => d.IdColor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ropa_Color");
            });

            modelBuilder.Entity<RopaTalla>(entity =>
            {
                entity.HasKey(e => new { e.IdRopa, e.IdTalla });

                entity.Property(e => e.Cantidad).IsFixedLength();

                entity.HasOne(d => d.IdRopaNavigation)
                    .WithMany(p => p.RopaTallas)
                    .HasForeignKey(d => d.IdRopa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RopaTalla_Ropa");

                entity.HasOne(d => d.IdTallaNavigation)
                    .WithMany(p => p.RopaTallas)
                    .HasForeignKey(d => d.IdTalla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RopaTalla_Talla");
            });

            modelBuilder.Entity<Talla>(entity =>
            {
                entity.Property(e => e.IdTalla).ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion).IsFixedLength();
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.IdTicket).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Ticket_CategoriaTicket");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Ticket_Usuarios");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.Property(e => e.IdVentas).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdUsuariosNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdUsuarios)
                    .HasConstraintName("FK_Ventas_Usuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
