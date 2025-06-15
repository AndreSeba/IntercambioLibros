using Blazored.LocalStorage;
using IntercambioLibros.Model;

namespace IntercambioLibros.Services
{
    public class ServicioReseñas
    {
        private List<Reseña> reseñas = new();
        private readonly ILocalStorageService _localStorage;
        private const string CLAVE_RESEÑAS = "reseñas";

        public ServicioReseñas(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            _ = CargarDesdeLocalStorage();
        }

        public async Task AgregarReseña(Reseña nueva)
        {
            var existe = reseñas.Any(r =>
                r.SolicitudId == nueva.SolicitudId &&
                r.EvaluadorId == nueva.EvaluadorId);

            if (!existe)
            {
                reseñas.Add(nueva);
                await GuardarCambios();
            }
        }

        public List<Reseña> ObtenerReseñasDeUsuario(int usuarioId)
        {
            return reseñas.Where(r => r.EvaluadoId == usuarioId).ToList();
        }

        public bool YaCalificó(int solicitudId, int evaluadorId)
        {
            return reseñas.Any(r => r.SolicitudId == solicitudId && r.EvaluadorId == evaluadorId);
        }

        public async Task GuardarCambios()
        {
            await _localStorage.SetItemAsync(CLAVE_RESEÑAS, reseñas);
        }

        public async Task CargarDesdeLocalStorage()
        {
            var lista = await _localStorage.GetItemAsync<List<Reseña>>(CLAVE_RESEÑAS);
            if (lista != null)
            {
                reseñas = lista;
            }
        }
    }
}
