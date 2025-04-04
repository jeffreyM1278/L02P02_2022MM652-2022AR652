using Microsoft.AspNetCore.Mvc;
using L02P02_2022MM652_2022AR652.Data;
using L02P02_2022MM652_2022AR652.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace L02P02_2022MM652_2022AR652.Controllers
{
    public class LibrosController : Controller
    {
        private readonly LibreriaContext _context;

        public LibrosController(LibreriaContext context)
        {
            _context = context;
        }

        // GET: Libros
        public IActionResult Index()
        {
            var libros = _context.Libros.ToList();
            return View(libros);
        }

        // GET: Libros/LibrosPorAutor/5
        public IActionResult LibrosPorAutor(int autorId)
        {
            var libros = _context.Libros.Where(l => l.id_autor == autorId).ToList();
            var autor = _context.Autores.FirstOrDefault(a => a.id == autorId);

            if (autor == null)
            {
                return NotFound();
            }

            ViewData["AutorNombre"] = autor.autor;

            return View(libros);
        }

        // GET: Libros/Details/5
        public IActionResult Details(int id)
        {
            var libro = _context.Libros
                .FirstOrDefault(m => m.id == id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            ViewData["Autores"] = _context.Autores.ToList();
            return View();
        }

        // POST: Libros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Titulo,FechaPublicacion,AutorId")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Autores"] = _context.Autores.ToList();
            return View(libro);
        }

        // GET: Libros/Edit/5
        public IActionResult Edit(int id)
        {
            var libro = _context.Libros.Find(id);
            if (libro == null)
            {
                return NotFound();
            }

            ViewData["Autores"] = _context.Autores.ToList();
            return View(libro);
        }

        // POST: Libros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Titulo,FechaPublicacion,AutorId")] Libro libro)
        {
            if (id != libro.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Libros.Any(e => e.id == libro.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["Autores"] = _context.Autores.ToList();
            return View(libro);
        }

        // GET: Libros/Delete/5
        public IActionResult Delete(int id)
        {
            var libro = _context.Libros
                .FirstOrDefault(m => m.id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var libro = _context.Libros.Find(id);
            _context.Libros.Remove(libro);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
