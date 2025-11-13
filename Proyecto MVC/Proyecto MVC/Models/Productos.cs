namespace Proyecto_MVC.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
