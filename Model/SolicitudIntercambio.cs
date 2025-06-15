namespace IntercambioLibros.Model
{
    public class SolicitudIntercambio
    {
        public int Id { get; set; }
        public int LibroSolicitadoId { get; set; }
        public int LibroOfrecidoId { get; set; }
        public int UsuarioSolicitanteId { get; set; }
        public int UsuarioDueñoLibroId { get; set; }
        public string Estado { get; set; } = "Pendiente"; // "Pendiente", "Aceptada", "Rechazada", "Cancelada"
        public DateTime FechaSolicitud { get; set; } = DateTime.Now;
    }
}
