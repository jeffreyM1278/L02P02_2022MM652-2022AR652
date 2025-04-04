using L02P02_2022MM652_2022AR652.Data;
using L02P02_2022MM652_2022AR652.Models;
using Microsoft.AspNetCore.Mvc;

namespace L02P02_2022MM652_2022AR652.Controllers
{
    public class AutoresController : Controller
    {
        private readonly LibreriaContext _context;

        public AutoresController(LibreriaContext context)
        {
            _context = context;
        }

        // GET: Autores
        public IActionResult Index()
        {
            var lista = _context.Autores.ToList(); // Muestra todos los autores
            return View(lista);
        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Autores.Add(autor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }
    }
}
