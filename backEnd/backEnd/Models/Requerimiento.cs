using System;
using System.Collections.Generic;

namespace backEnd.Models
{
    public partial class Requerimiento
    {
        public int Id { get; set; }
        public int? cantidad_bultos { get; set; }
        public int? cantidad_contenedores_unidades { get; set; }
        public string? tipo_carga { get; set; }
        public string? tipo_contenedor { get; set; }
        public string? deposito_devolucion_registro_vacio { get; set; }
        public string? dimensiones { get; set; }
        public string? direccion_bodega { get; set; }
    }
}
