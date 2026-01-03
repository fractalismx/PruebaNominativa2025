using Domain;
using System.Text.RegularExpressions;

namespace Bussiness
{
    public class ClienteService
    {
        private readonly IClienteRepository _repo;

        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public Task<IReadOnlyList<Cliente>> ObtenerAsync()
            => _repo.ObtenerTodosAsync();

        public Task CrearAsync(string nombre)
        {
            string caracteresAEliminar = @"[""'\|°!“#$%&/()=‘¿?¡¨*´+{}\[\],\-_~^@¬;:\–]";
            nombre = Regex.Replace(nombre, caracteresAEliminar, "");

            nombre = nombre.Replace("\\\"", "").Replace("–", "");
            nombre = Regex.Replace(nombre, @"\s+", " ").Trim();

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));

            return _repo.AgregarAsync(new Cliente { Nombre = nombre });
        }
    }
}