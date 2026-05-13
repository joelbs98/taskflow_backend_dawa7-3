using TaskFlowApi.Models;

namespace TaskFlowApi.Services
{
    public class LibroService
    {
        //private: solo se usa dentro del servicio
        //readonly: la referencia no se cambia
        //new(): una sintaxis abreviada de C# para crear la lista
        private readonly List<Libro> libros = new()
        {
            new Libro { Id = 1, Titulo = "Harry Potter", Autor = "JK Rowling",
            Disponible=true},
            new Libro { Id = 2, Titulo = "Clean Code", Autor = "Robert Martin",
            Disponible= false}
        };

        public List<Libro> ObtenerTodos()
        {
            return libros;
        }

        public Libro? ObtenerporId(int id)
        {
            return libros.FirstOrDefault(l => l.Id == id);
        }

        public Libro Agregar(Libro nuevoLibro)
        {
            nuevoLibro.Id = libros.Count + 1;
            libros.Add(nuevoLibro);
            return nuevoLibro;
        }
    }
}
