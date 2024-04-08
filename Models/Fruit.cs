namespace maibagamofisa.Models
{
    public class Fruit
    {

        public int FruitId { get; set; }

        public string EnglishName { get; set; } = null!;

        public string GermanName { get; set; } = null!;

        public string ImagePath { get; set; } = null!;

        public int? LessonId { get; set; }

        public virtual VocabularyLesson? Lesson { get; set; }
    }
}
