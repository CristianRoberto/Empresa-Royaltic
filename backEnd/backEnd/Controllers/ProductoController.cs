using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backEnd.Models;
using Microsoft.AspNetCore.Cors;

namespace backEnd.Controllers
{
  [EnableCors("ReglasCors")]
  [Route("api/[controller]")]
  [ApiController]
  public class ProductoController : ControllerBase
  {
    private readonly TechStoreDBContext _dbcontext;

    public ProductoController(TechStoreDBContext context)
    {
      _dbcontext = context;
    }

    [HttpGet]
    [Route("ListaProductos")]
    public IActionResult Lista()
    {
      List<Producto> lista = new List<Producto>();

      try
      {
        lista = _dbcontext.Productos.ToList();
        return Ok(lista);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = lista });
      }
    }



    //METODOPOST GUARDAR Producto en la tabla
    [HttpPost]
    [Route("Guardar")]
    public IActionResult Guardar([FromBody] Producto objeto)
    {

      //Utilizo el capturador de errores tryCatch
      try
      {
        //agrego mi objeto a dbcontext.Producto que es la tabla Producto
        //utilizo el metodo agregar y agrega mi objeto
        //estoy agregando mi objeto dentro de modelo producto
        _dbcontext.Productos.Add(objeto);
        //hace un llamado a _dbcontext y utiliza el metodo guardar y guarda.
        _dbcontext.SaveChanges();
        return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
      }
    }



    //Metodo Editar Producto por id
    [HttpPut]
    [Route("Editar")]
    public IActionResult Editar([FromBody] Producto objeto)
    {

      //validamos que el producto queremos editar corresponde a un producto existente en la base de datos
      Producto Producto = _dbcontext.Productos.Find(objeto.ProductoId);
      if (Producto == null)
      {
        return BadRequest("Producto no encontrado");
      }
      try
      {
        Producto.Nombre = objeto.Nombre is null ? Producto.Nombre : objeto.Nombre;
        Producto.Descripcion = objeto.Descripcion is null ? Producto.Descripcion : objeto.Descripcion;
        Producto.Precio = objeto.Precio == 0 ? Producto.Precio : objeto.Precio;
        Producto.Stock = objeto.Stock == 0 ? Producto.Stock : objeto.Stock;
        Producto.Sku = objeto.Sku is null ? Producto.Sku : objeto.Sku;
        Producto.Proveedor = objeto.Proveedor is null ? Producto.Proveedor : objeto.Proveedor;
        Producto.FechaIngreso = objeto.FechaIngreso == default ? Producto.FechaIngreso : objeto.FechaIngreso;
        Producto.Estado = objeto.Estado is null ? Producto.Estado : objeto.Estado;
        Producto.FechaActualizacion = objeto.FechaActualizacion == null ? Producto.FechaActualizacion : objeto.FechaActualizacion;

        _dbcontext.Productos.Update(Producto);
        _dbcontext.SaveChanges();
        return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok Actualizado " });
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
      }
    }



    //metodo para eliminar Producto por id
    [HttpDelete]
    [Route("Eliminar/{ProductoId:int}")]
    public IActionResult Eliminar(int ProductoId)
    {

      Producto Producto = _dbcontext.Productos.Find(ProductoId);

      if (Producto == null)
      {
        return BadRequest("Producto no encontrado");

      }

      try
      {

        _dbcontext.Productos.Remove(Producto);
        _dbcontext.SaveChanges();

        return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok Eliminado" });
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
      }


    }

  }
}


















//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using backEnd.Models;
//using Microsoft.AspNetCore.Cors;

//namespace backEnd.Controllers
//{
//  [EnableCors("ReglasCors")]
//  [Route("api/[controller]")]
//  [ApiController]
//  public class ProductoController : ControllerBase
//  {
//    //Declara un objecto dbcontext vamos a poder utilizar los metodos crud para nuestros modelos (Producto)
//    public readonly ProductoContext _dbcontext;
//    //creo el constructo que recibe el contexto y asigno el valor _context a mi variable _dbcontext
//    public ProductoController(ProductoContext _context)
//    {
//      _dbcontext = _context;
//    }

//    //METODO GET mostrar todos los datos de la tabla productos y categoria ya que estan relacionado atravez de llaves foraneas
//    [HttpGet]
//    [Route("Lista")]
//    public IActionResult Lista()
//    {
//      //CREO UN OBJECTO DE liSTA<PRODUCTO> EL CUAL VA HACER UNA NUEVA LISTA DE PRODUCTOS
//      List<Producto> lista = new List<Producto>();
//      //CREO EL TRYCATCH PARA CAPTURAR ERRORES
//      try
//      {
//        //llamo a mi lista y utilzo _dbContext_NombreModelo[Productos]
//        lista = _dbcontext.Productos.ToList();
//        //DEVUELVE LA LISTA//se crea un json que contiene un mensaje ok y la respuesta sera lista
//        // return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
//        return Ok(lista);

//      }
//      catch (Exception ex)
//      {
//        return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
//      }
//    }





//    }

//  }
//}
