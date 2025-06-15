namespace IntercambioLibros.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? FotoPerfilBase64 { get; set; }

        // 📍 Campos para ubicación
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
