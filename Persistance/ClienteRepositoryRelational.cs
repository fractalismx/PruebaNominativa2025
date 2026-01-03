using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class ClienteRepositoryRelational : IClienteRepository
    {
        private readonly RelationalDbContext _context;

        public ClienteRepositoryRelational(RelationalDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Cliente>> ObtenerTodosAsync()
            => await _context.Clientes.AsNoTracking().ToListAsync();

        public async Task AgregarAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
