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

        
        public IActionResult Index()
        {
            var libros = _context.Libros.ToList();
            return View(libros);
        }

       
        public IActionResult LibrosPorAutor(int autorId)
        {
           
            var autor = _context.Autores.FirstOrDefault(a => a.id == autorId);
            if (autor == null)
            {
                return NotFound(); 
            }

            
            var libros = _context.Libros.Where(l => l.id_autor == autorId).ToList();

            
            ViewData["AutorNombre"] = autor.autor;

           
            return View(libros);
        }

        
    }
}
