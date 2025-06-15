using Blazored.LocalStorage;
using IntercambioLibros.Model;

namespace IntercambioLibros.Services
{
    public class ServicioNotificaciones
    {
        public List<NotificacionIntercambio> Notificaciones { get; set; } = new();
        private int contador = 1;
        private readonly ILocalStorageService _localStorage;
        private const string CLAVE = "notificaciones";

        public ServicioNotificaciones(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            _ = CargarDesdeLocalStorage();
        }

        public async Task AgregarNotificacion(NotificacionIntercambio noti)
        {
            noti.Id = contador++;
            Notificaciones.Add(noti);
            await GuardarCambios();
        }

        public List<NotificacionIntercambio> ObtenerPorUsuario(int usuarioId)
        {
            return Notificaciones.Where(n => n.UsuarioDestinoId == usuarioId).ToList();
        }

        public async Task MarcarLeido(int notificacionId)
        {
            var noti = Notificaciones.FirstOrDefault(n => n.Id == notificacionId);
            if (noti != null)
            {
                noti.Leido = true;
                await GuardarCambios();
            }
        }

        public bool TieneNotificacionesNuevas(int usuarioId)
        {
            return Notificaciones.Any(n => n.UsuarioDestinoId == usuarioId && !n.Leido);
        }

        public async Task GuardarCambios()
        {
            await _localStorage.SetItemAsync(CLAVE, Notificaciones);
        }

        private async Task CargarDesdeLocalStorage()
        {
            var datos = await _localStorage.GetItemAsync<List<NotificacionIntercambio>>(CLAVE);
            if (datos != null)
            {
                Notificaciones = datos;
                contador = Notificaciones.Max(n => n.Id) + 1;
            }
        }
    }
}
