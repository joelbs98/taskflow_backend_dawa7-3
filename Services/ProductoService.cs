using TaskFlowApi.Models;

namespace TaskFlowApi.Services
{
    public class ProductoService
    {
        private readonly List<Producto> productos = new()
        {
            new Producto { Id = 1, Nombre = "Teclado", Disponible=true},
            new Producto{ Id = 2, Nombre = "Mouse", Disponible= false}
        };

        public List<Producto> ObtenerTodos()
        {
            return productos;
        }

        public Producto? ObtenerPorId(int id)
        {
            return productos.FirstOrDefault(p => p.Id == id);
        }

        public Producto Agregar(Producto nuevoProducto)
        {
            nuevoProducto.Id = productos.Count + 1;
            productos.Add(nuevoProducto);
            return nuevoProducto;
        }

        public bool Actualizar(int id, Producto productoActualizado)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto == null)
            {
                return false;
            }

            producto.Nombre = productoActualizado.Nombre;
            producto.Disponible = productoActualizado.Disponible;
            return true;
        }

        public bool Eliminar(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto == null)
            {
                return false;
            }
            productos.Remove(producto);
            return true;
        }
    }
}