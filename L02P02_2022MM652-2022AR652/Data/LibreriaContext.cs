using L02P02_2022MM652_2022AR652.Models;
using Microsoft.EntityFrameworkCore;

namespace L02P02_2022MM652_2022AR652.Data
{
    public class LibreriaContext: DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options) { }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<ComentarioLibro> ComentariosLibros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>()
                .HasOne(a => a.Autor)
                .WithMany(l => l.Libros)
                .HasForeignKey(l => l.IdAutor);
        }
    }

}
