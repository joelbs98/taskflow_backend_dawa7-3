using Microsoft.AspNetCore.Mvc;//funcionalidades de controladores y respuestas
using Microsoft.AspNetCore.SignalR;
using TaskFlowApi.Models;//permite usar la clase Tarea

namespace TaskFlowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private static List<Tarea> tareas = new List<Tarea>
        {
            new Tarea{Id = 1, Titulo = "Estudiar Angular",
             Descripcion= "Repasar componentes", Completada = true},
            new Tarea{Id = 2, Titulo = "Preparar backend",
             Descripcion= "Crear primera API", Completada = false}
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);

            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarea nuevaTarea)
        {
            nuevaTarea.Id = tareas.Count + 1;
            tareas.Add(nuevaTarea);
            return Created("", nuevaTarea);
            //Devovler el código HTTP 201 Created con la tarea creada
        }

        //Agregar un endpoint GET por id
        // GET /api/tareas/1
    }
}

/*
1 El usuario interactua con el frontend
2 El frontend envia una solicitud al backend
3 El backend procesa la solicitud
4. El backend consulta o modifica la base de datos
5. El backend recibe el resultado
6. El frontend va a mostrar la respuesta al usuario
*/