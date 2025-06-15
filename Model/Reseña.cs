namespace IntercambioLibros.Model
{
    public class Reseña
    {
        public int SolicitudId { get; set; }
        public int EvaluadorId { get; set; }  // el que da la reseña
        public int EvaluadoId { get; set; }   // el que recibe la reseña
        public int Puntuacion { get; set; }   // de 1 a 5
        public string Comentario { get; set; } = "";
    }
}
