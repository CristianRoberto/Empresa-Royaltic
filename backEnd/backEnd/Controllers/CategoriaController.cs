using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using backEnd.Models;
using Microsoft.AspNetCore.Cors;

namespace backEnd.Controllers
{
  [EnableCors("ReglasCors")]
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriaController : ControllerBase
  {
    private readonly TechStoreDBContext _dbcontext;

    public CategoriaController(TechStoreDBContext context)
    {
      _dbcontext = context;
    }

    [HttpGet]
    [Route("ListaCategorias")]
    public IActionResult Lista()
    {
      List<Categoria> lista = new List<Categoria>();

      try
      {
        lista = _dbcontext.Categorias.ToList();
        return Ok(lista);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = lista });
      }
    }



    //METODOPOST GUARDAR Categoria en la tabla
    [HttpPost]
    [Route("Guardar")]
    public IActionResult Guardar([FromBody] Categoria objeto)
    {

      //Utilizo el capturador de errores tryCatch
      try
      {
        //agrego mi objeto a dbcontext.Categoria que es la tabla Categoria
        //utilizo el metodo agregar y agrega mi objeto
        //estoy agregando mi objeto dentro de modelo Categoria
        _dbcontext.Categorias.Add(objeto);
        //hace un llamado a _dbcontext y utiliza el metodo guardar y guarda.
        _dbcontext.SaveChanges();
        return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
      }
    }



    //Metodo Editar Categoria por id
    [HttpPut]
    [Route("Editar")]
    public IActionResult Editar([FromBody] Categoria objeto)
    {

      //validamos que el Categoria queremos editar corresponde a un Categoria existente en la base de datos
      Categoria Categoria = _dbcontext.Categorias.Find(objeto.CategoriasId);
      if (Categoria == null)
      {
        return BadRequest("Categoria no encontrado");
      }
      try
      {
        Categoria.Nombre = objeto.Nombre is null ? Categoria.Nombre : objeto.Nombre;
        Categoria.Descripcion = objeto.Descripcion is null ? Categoria.Descripcion : objeto.Descripcion;
        Categoria.Estado = objeto.Estado is null ? Categoria.Estado : objeto.Estado;
        Categoria.FechaActualizacion = objeto.FechaActualizacion == null ? Categoria.FechaActualizacion : objeto.FechaActualizacion;

        _dbcontext.Categorias.Update(Categoria);
        _dbcontext.SaveChanges();
        return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok Actualizado " });
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
      }
    }



    //metodo para eliminar Categoria por id
    [HttpDelete]
    [Route("Eliminar/{CategoriaId:int}")]
    public IActionResult Eliminar(int CategoriaId)
    {

      Categoria Categoria = _dbcontext.Categorias.Find(CategoriaId);

      if (Categoria == null)
      {
        return BadRequest("Categoria no encontrado");

      }

      try
      {

        _dbcontext.Categorias.Remove(Categoria);
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
