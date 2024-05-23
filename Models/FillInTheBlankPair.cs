using System.Collections.Generic;

namespace maibagamofisa.Models
{
    public class FillInTheBlankPair
    {
        public int Id { get; set; }
        public string Sentence { get; set; }
        public List<string> Options { get; set; }
        public string CorrectWord { get; set; }
    }
}
