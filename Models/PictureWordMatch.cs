namespace maibagamofisa.Models
{
    public class PictureWordMatch
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string CorrectWord { get; set; }
        public List<string> Words { get; set; }
    }
}
