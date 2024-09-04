using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backEnd.Models
{
    public partial class TechStoreDBContext : DbContext
    {
        public TechStoreDBContext()
        {
        }

        public TechStoreDBContext(DbContextOptions<TechStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<ProductosXcateria> ProductosXcateria { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Categoria>(entity =>
      {
        entity.HasKey(e => e.CategoriasId)
            .HasName("PK_Categoria");

        entity.Property(e => e.CategoriasId).HasColumnName("CategoriasID");

        entity.Property(e => e.Descripcion)
            .HasMaxLength(255);

        entity.Property(e => e.Estado)
            .IsRequired()
            .HasDefaultValue(true);

        entity.Property(e => e.FechaActualizacion)
            .HasColumnType("datetime");

        entity.Property(e => e.FechaCreacion)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()");

        entity.Property(e => e.Nombre)
            .HasMaxLength(100);
      });

      modelBuilder.Entity<Producto>(entity =>
      {
        entity.HasIndex(e => e.Sku, "UQ_Producto_Sku")
            .IsUnique();

        entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

        entity.Property(e => e.Descripcion)
            .HasMaxLength(255);

        entity.Property(e => e.Estado)
            .IsRequired()
            .HasDefaultValue(true);

        entity.Property(e => e.FechaActualizacion)
            .HasColumnType("datetime");

        entity.Property(e => e.FechaCreacion)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()");

        entity.Property(e => e.FechaIngreso)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()");

        entity.Property(e => e.Nombre)
            .HasMaxLength(100);

        entity.Property(e => e.Precio)
            .HasColumnType("decimal(10, 2)");

        entity.Property(e => e.Proveedor)
            .HasMaxLength(100);

        entity.Property(e => e.Sku)
            .HasMaxLength(50)
            .HasColumnName("SKU");
      });

      modelBuilder.Entity<ProductosXcateria>(entity =>
      {
        entity.HasKey(e => new { e.ProductoId, e.CategoriasId })
            .HasName("PK_ProductosXCategorias");

        entity.ToTable("ProductosXCategorias");

        entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

        entity.Property(e => e.CategoriasId).HasColumnName("CategoriasID");

        entity.Property(e => e.FechaAsignacion)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()");

        entity.HasOne(d => d.oCategoria)
            .WithMany(p => p.ProductosXcateria)
            .HasForeignKey(d => d.CategoriasId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductosXCategorias_Categoria");

        entity.HasOne(d => d.oProducto)
            .WithMany(p => p.ProductosXcateria)
            .HasForeignKey(d => d.ProductoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductosXCategorias_Producto");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
