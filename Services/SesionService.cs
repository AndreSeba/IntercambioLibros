using IntercambioLibros.Model;

namespace IntercambioLibros.Services
{
    public class SesionService
    {
        public Usuario? UsuarioActual { get; private set; }

        public bool EstaLogueado => UsuarioActual != null;

        public void IniciarSesion(Usuario usuario)
        {
            UsuarioActual = usuario;
        }

        public void CerrarSesion()
        {
            UsuarioActual = null;
        }
    }
}
