namespace Proyecto_MVC.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string tipoDocumento { get; set; } = string.Empty;
        public int NumeroDocumento { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Telefono { get; set; }
        public string Direccion { get; set; } = string.Empty;

    }
}
