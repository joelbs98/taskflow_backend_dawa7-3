using Microsoft.AspNetCore.Mvc;
using TaskFlowApi.Models;
using TaskFlowApi.Services;

namespace TaskFlowApi.Controllers
{
    /*
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private static List<Libro> libros = new List<Libro>
        {
            new Libro { Id = 1, Titulo = "Harry Potter", Autor = "JK Rowling",
            Disponible=true},
            new Libro { Id = 2, Titulo = "Clean Code", Autor = "Robert Martin",
            Disponible= false}
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(libros);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var libro = libros.FirstOrDefault(l => l.Id == id);

            if (libro == null)
            {
                return NotFound();
            }
            return Ok(libro);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Libro nuevoLibro)
        {
            nuevoLibro.Id = libros.Count + 1;
            libros.Add(nuevoLibro);

            return Created("", nuevoLibro);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Libro libroActualizado)
        {
            var libro = libros.FirstOrDefault(l => l.Id == id);

            if (libro == null)
            {
                return NotFound();
            }
            libro.Titulo = libroActualizado.Titulo;
            libro.Autor = libroActualizado.Autor;
            libro.Disponible = libroActualizado.Disponible;

            return Ok(libro);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var libro = libros.FirstOrDefault(l => l.Id == id);

            if (libro == null)
            {
                return NotFound();
            }
            libros.Remove(libro);
            return Ok(new { mensaje = "Libro eliminado correctamente" });

        }


    }
    */
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly LibroService _libroService;
        //guarda una referencia al servicio

        public LibrosController(LibroService libroService)
        {
            _libroService = libroService;
        }
        //Cuando .NET crea el controlador, le entrega automaticamente
        //una instancia de LibroService
        //Esto es inyección de dependencias, ya que el framework le pasa
        //al controlador el servicio que necesita

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_libroService.ObtenerTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var libro = _libroService.ObtenerporId(id);

            if (libro == null)
            {
                return NotFound();
            }
            return Ok(libro);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Libro nuevoLibro)
        {
            var libroCreado = _libroService.Agregar(nuevoLibro);
            return Created("", libroCreado);
        }
    }

}
