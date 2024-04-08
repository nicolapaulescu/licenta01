using System.ComponentModel.DataAnnotations;

namespace maibagamofisa.Models
{
    public class Dialogue
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
      

        [Display(Name = "Questions")]
        public string Questions { get; set; }

        public List<string> GetQuestionsList()
        {
            var questionsList = new List<string>();

            if (string.IsNullOrEmpty(Questions))
                return questionsList;

            // Remove square brackets and double quotes
            string cleanQuestions = Questions.TrimStart('[').TrimEnd(']').Replace("\"", "");

            // Split the cleaned string by comma and trim each question
            string[] questionsArray = cleanQuestions.Split(',');
            foreach (var question in questionsArray)
            {
                questionsList.Add(question.Trim());
            }

            return questionsList;
        }

    }

}
