namespace L02P02_2022MM652_2022AR652.Models
{
    public class ComentarioLibro
    {
        public int id { get; set; }
        public int id_libro { get; set; }
        public string comentarios { get; set; }
        public string usuario { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
