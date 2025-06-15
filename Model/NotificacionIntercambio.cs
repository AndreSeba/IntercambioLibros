namespace IntercambioLibros.Model
{
    public class NotificacionIntercambio
    {
        public int Id { get; set; }
        public int UsuarioDestinoId { get; set; } // A quién va dirigida
        public int SolicitudIntercambioId { get; set; } // Qué solicitud
        public bool Leido { get; set; } = false;
        public DateTime Fecha { get; set; } = DateTime.Now;
        // ✅ Nuevo campo para texto personalizado
        public string Mensaje { get; set; } = "";

    }
}
