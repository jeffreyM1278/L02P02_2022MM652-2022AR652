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

        
        public IActionResult Index()
        {
            var lista = _context.Autores.ToList(); 
            return View(lista);
        }

       
        public IActionResult Create()
        {
            return View();
        }

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
