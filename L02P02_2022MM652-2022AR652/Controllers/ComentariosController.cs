﻿using L02P02_2022MM652_2022AR652.Data;
using L02P02_2022MM652_2022AR652.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace L02P02_2022MM652_2022AR652.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly LibreriaContext _context;

        public ComentariosController(LibreriaContext context)
        {
            _context = context;
        }

        
        public IActionResult Libros(int id)
        {
            var libro = _context.Libros.FirstOrDefault(l => l.id == id);
            if (libro == null)
            {
                return NotFound();
            }

            
            var comentarios = _context.ComentarioLibros
                .Where(c => c.id_libro == id)
                .OrderByDescending(c => c.CreatedAt)  
                .ToList();

            
            ViewData["LibroTitulo"] = libro.nombre;
            return View(comentarios);
        }

        
        public IActionResult Create(int id)
        {
            var libro = _context.Libros.FirstOrDefault(l => l.id == id);
            if (libro == null)
            {
                return NotFound();
            }

            ViewData["LibroTitulo"] = libro.nombre;
            return View(new ComentarioLibro { id_libro = id });
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ComentarioLibro comentario)
        {
            if (ModelState.IsValid)
            {
                comentario.CreatedAt = DateTime.Now;
                _context.ComentarioLibros.Add(comentario);
                _context.SaveChanges();
                return RedirectToAction("Libros", new { id = comentario.id_libro });
            }

            var libro = _context.Libros.FirstOrDefault(l => l.id == comentario.id_libro);
            if (libro == null)
            {
                return NotFound();
            }

            ViewData["LibroTitulo"] = libro.nombre;
            return View(comentario);
        }
    }
}
