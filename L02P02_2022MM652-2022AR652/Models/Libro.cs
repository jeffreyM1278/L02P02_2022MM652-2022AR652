namespace L02P02_2022MM652_2022AR652.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdAutor { get; set; }
        public Autor Autor { get; set; }
    }
}
