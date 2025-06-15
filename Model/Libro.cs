namespace IntercambioLibros.Model
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = "";
        public string Autor { get; set; } = "";
        public string Genero { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string Estado { get; set; } = "Disponible"; // Disponible / No disponible
        public string EstadoFisico { get; set; } = ""; // Nuevo, Seminuevo, Viejo, Dañado
        public string DetallesFisicos { get; set; } = ""; // Le falta tapa, páginas arrugadas, etc.
        public DateTime FechaPublicacion { get; set; } = DateTime.Now;
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string ImagenBase64 { get; set; } = "";
        public string? AudioResenaBase64 { get; set; } = null; // Aquí guardamos el audio como base64
        public int UsuarioId { get; set; }
        public string Editorial { get; set; } = "";
        public int NumeroPaginas { get; set; }
        public string Idioma { get; set; } = "Español";
        public bool Aprobado { get; set; } = false; // false por defecto
        public string EstadoValidacion { get; set; } = "Pendiente"; // Puede ser: Pendiente, Aprobado, Rechazado
    }
}   