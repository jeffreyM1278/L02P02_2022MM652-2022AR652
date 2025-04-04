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
            // Buscar al autor por el id
            var autor = _context.Autores.FirstOrDefault(a => a.id == autorId);
            if (autor == null)
            {
                return NotFound(); // Si no se encuentra el autor, mostrar un 404
            }

            // Filtrar los libros que pertenecen al autor seleccionado
            var libros = _context.Libros.Where(l => l.id_autor == autorId).ToList();

            // Pasar el nombre del autor a la vista
            ViewData["AutorNombre"] = autor.autor;

            // Retornar la vista con los libros del autor
            return View(libros);
        }

        // El resto de acciones del controlador (Details, Create, Edit, Delete) sigue igual
        // ...
    }
}
