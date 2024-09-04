using System;
using System.Collections.Generic;

namespace backEnd.Models
{
  public partial class Categoria
  {
    public Categoria()
    {
      ProductosXcateria = new HashSet<ProductosXcateria>();
    }

    public int CategoriasId { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public bool? Estado { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<ProductosXcateria> ProductosXcateria { get; set; }
  }
}
