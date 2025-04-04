namespace L02P02_2022MM652_2022AR652.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Libro> Libros { get; set; }
    }
}
