namespace L02P02_2022MM652_2022AR652.Models
{
    public class Autor
    {
        public int id{ get; set; }
        public string autor { get; set; }
        public ICollection<Libro> Libros { get; set; }
    }
}
