using System;
using System.Collections.Generic;

namespace backEnd.Models
{
  public partial class ProductosXcateria
  {
    public int ProductoId { get; set; }
    public int CategoriasId { get; set; }
    public DateTime FechaAsignacion { get; set; }

    public virtual Categoria? oCategoria { get; set; }
    public virtual Producto? oProducto { get; set; }
  }
}
