namespace Proyecto_MVC.Models
{
    public class Ventas
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public DateTime FechaVenta { get; set; } = DateTime.Now;
        public decimal Total => (Cantidad * Precio);
    }
}
