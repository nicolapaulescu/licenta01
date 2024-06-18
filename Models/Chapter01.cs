namespace maibagamofisa.Models
{
    public class Chapter01
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public List<Lesson01> Lessons { get; set; } = new List<Lesson01>();
    }

    public class Lesson01
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }

    public class Exercise
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }
        public ExerciseType Type { get; set; }
    }

    public enum ExerciseType
    {
        MultipleChoice,
        FillInTheBlank,
        Listening,
        SentenceConstruction
    }
}
