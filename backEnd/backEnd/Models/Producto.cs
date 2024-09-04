using System;
using System.Collections.Generic;

namespace backEnd.Models
{
  public partial class Producto
  {
    public Producto()
    {
      ProductosXcateria = new HashSet<ProductosXcateria>();
    }

    public int ProductoId { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public string Sku { get; set; } = null!;
    public string? Proveedor { get; set; }
    public DateTime FechaIngreso { get; set; }
    public bool? Estado { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<ProductosXcateria> ProductosXcateria { get; set; }
  }
}
