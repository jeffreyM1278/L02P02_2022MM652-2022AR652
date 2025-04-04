namespace L02P02_2022MM652_2022AR652.Models
{
    public class Libro
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int id_autor { get; set; }
        public string estado  { get; set; }
        public Autor Autor { get; set; }
    }
}
