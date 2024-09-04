using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backEnd.Models
{
    public partial class RequerimientoContext : DbContext
    {
        public RequerimientoContext()
        {
        }

        public RequerimientoContext(DbContextOptions<RequerimientoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Requerimiento> Requerimientos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
       
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Requerimiento>(entity =>
            {
                entity.ToTable("Requerimiento");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.cantidad_bultos).HasColumnName("cantidad_bultos");

                entity.Property(e => e.cantidad_contenedores_unidades).HasColumnName("cantidad_contenedores_unidades");

                entity.Property(e => e.deposito_devolucion_registro_vacio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("deposito_devolucion_registro_vacio");

                entity.Property(e => e.dimensiones)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("dimensiones");

                entity.Property(e => e.direccion_bodega)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion_bodega");

                entity.Property(e => e.tipo_carga)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tipo_carga");

                entity.Property(e => e.tipo_contenedor)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tipo_contenedor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
