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
