namespace maibagamofisa.Models
{
    public class SentenceConstruction
    {
        public int Id { get; set; }
        public List<string> CorrectOrder { get; set; }
        public List<string> ShuffledWords { get; set; }
    }
}
