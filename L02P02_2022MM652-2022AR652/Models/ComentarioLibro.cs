namespace L02P02_2022MM652_2022AR652.Models
{
    public class ComentarioLibro
    {
        public int Id { get; set; }
        public int IdLibro { get; set; }
        public string Comentarios { get; set; }
        public string Usuario { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
