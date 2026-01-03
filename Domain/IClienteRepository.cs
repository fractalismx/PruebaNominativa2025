namespace Domain
{
    public interface IClienteRepository
    {
        Task<IReadOnlyList<Cliente>> ObtenerTodosAsync();
        Task AgregarAsync(Cliente cliente);
    }
}
