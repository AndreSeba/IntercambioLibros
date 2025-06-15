using Blazored.LocalStorage;
using IntercambioLibros.Model;

namespace IntercambioLibros.Services
{
    public class ServicioSolicitudes
    {
        public List<SolicitudIntercambio> Solicitudes { get; set; } = new();
        private int contador = 1;

        private readonly ILocalStorageService _localStorage;
        private const string CLAVE_SOLICITUDES = "solicitudes";

        public ServicioSolicitudes(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            _ = CargarDesdeLocalStorage(); // Carga inicial
        }

        public async Task EnviarSolicitud(SolicitudIntercambio solicitud)
        {
            solicitud.Id = contador++;
            Solicitudes.Add(solicitud);
            await GuardarCambios();
        }

        public List<SolicitudIntercambio> ObtenerSolicitudesPorUsuario(int usuarioId)
        {
            return Solicitudes
                .Where(s => s.UsuarioSolicitanteId == usuarioId || s.UsuarioDueñoLibroId == usuarioId)
                .ToList();
        }

        public SolicitudIntercambio? ObtenerSolicitudPorId(int id)
        {
            return Solicitudes.FirstOrDefault(s => s.Id == id);
        }

        public async Task GuardarCambios()
        {
            await _localStorage.SetItemAsync(CLAVE_SOLICITUDES, Solicitudes);
        }

        public async Task CargarDesdeLocalStorage()
        {
            var lista = await _localStorage.GetItemAsync<List<SolicitudIntercambio>>(CLAVE_SOLICITUDES);
            if (lista != null)
            {
                Solicitudes = lista;
                contador = Solicitudes.Max(s => s.Id) + 1;
            }
        }
    }
}
