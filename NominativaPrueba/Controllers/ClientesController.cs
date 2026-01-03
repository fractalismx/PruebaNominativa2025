namespace NominativaPrueba.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Bussiness;
    using Domain;

    public class ClientesController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: /Clientes
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.ObtenerAsync();
            return View(clientes);
        }

        // GET: /Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            await _clienteService.CrearAsync(cliente.Nombre);
            return RedirectToAction(nameof(Index));
        }
    }

}
