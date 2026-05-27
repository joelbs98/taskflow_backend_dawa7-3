using Microsoft.AspNetCore.Mvc;
using TaskFlowApi.Models;
using TaskFlowApi.Services;

namespace TaskFlowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoService _productoService;

        public ProductosController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productoService.ObtenerTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var producto = _productoService.ObtenerPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Producto nuevoProducto)
        {
            //Verifica que el texto no sea nulo, vacío, solo espacios
            if (string.IsNullOrWhiteSpace(nuevoProducto.Nombre))
            {
                return BadRequest("El nombre del producto es obligatorio");
            }
            var ProductoCreado = _productoService.Agregar(nuevoProducto);
            return Created("", ProductoCreado);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Producto productoActualizado)
        {
            if (string.IsNullOrWhiteSpace(productoActualizado.Nombre))
            {
                return BadRequest("El nombre del producto es obligatorio");
            }

            var actualizado = _productoService.Actualizar(id, productoActualizado);

            if (!actualizado)
            {
                return NotFound();
            }

            return Ok(new { mensaje = "Producto actualizado correctamente" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eliminado = _productoService.Eliminar(id);

            if (!eliminado)
            {
                return NotFound();
            }
            return Ok(new { mensaje = "Producto eliminado correctamente" });
        }



    }
}