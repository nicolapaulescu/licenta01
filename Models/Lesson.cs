using System.Collections.Generic;

namespace maibagamofisa.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Exercise> Exercises { get; set; }
        public bool IsCompleted { get; set; }
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
        Matching
    }
}
