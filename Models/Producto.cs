namespace TaskFlowApi.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Disponible { get; set; }
    }
}