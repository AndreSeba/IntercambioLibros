using Blazored.LocalStorage;
using IntercambioLibros.Model;

namespace IntercambioLibros.Services
{
    public class ServicioUsuarios
    {
        public List<Usuario> Usuarios { get; set; } = new();
        private int contador = 1;

        private readonly ILocalStorageService localStorage;
        private const string ClaveUsuarios = "Usuarios";

        public ServicioUsuarios(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
            _ = CargarDesdeLocalStorage(); // carga inicial
        }

        public async Task RegistrarUsuario(Usuario usuario)
        {
            usuario.Id = contador++;
            Usuarios.Add(usuario);
            await GuardarCambios();
        }

        public Usuario? ValidarLogin(string correo, string contraseña)
        {
            return Usuarios.FirstOrDefault(u => u.Correo == correo && u.Contraseña == contraseña);
        }

        public Usuario? ObtenerUsuarioPorId(int id)
        {
            return Usuarios.FirstOrDefault(u => u.Id == id);
        }

        private void CargarAdminEstatico()
        {
            if (!Usuarios.Any(u => u.Correo == "admin@libros.com"))
            {
                Usuarios.Add(new Usuario
                {
                    Id = contador++,
                    Nombre = "Administrador",
                    Correo = "admin@libros.com",
                    Contraseña = "admin123",
                    Telefono = "123456789",
                    Direccion = "",
                    FotoPerfilBase64 = ""
                });
            }
        }

        // ✅ MÉTODO PÚBLICO para guardar cambios en LocalStorage
        public async Task GuardarCambios()
        {
            await localStorage.SetItemAsync(ClaveUsuarios, Usuarios);
        }

        public async Task CargarDesdeLocalStorage()
        {
            var lista = await localStorage.GetItemAsync<List<Usuario>>(ClaveUsuarios);
            if (lista != null)
            {
                Usuarios = lista;
                contador = Usuarios.Max(u => u.Id) + 1;
            }

            CargarAdminEstatico();
            await GuardarCambios(); // asegurar persistencia con admin
        }

        public void EliminarUsuario(int id)
        {
            var usuario = Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                Usuarios.Remove(usuario);
            }
        }

        public async Task ActualizarUsuario(Usuario usuarioActualizado)
        {
            var index = Usuarios.FindIndex(u => u.Id == usuarioActualizado.Id);
            if (index != -1)
            {
                Usuarios[index] = usuarioActualizado;
                await GuardarCambios(); // ⬅️ Persistimos cambios
            }
        }
    }
}
