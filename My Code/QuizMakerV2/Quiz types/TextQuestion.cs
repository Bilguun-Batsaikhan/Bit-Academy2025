using System;

namespace QuizMaker
{
    public class TextQuestion : QuestionBase
    {
        public string CorrectAnswer { get; set; }

        public TextQuestion(string text, string correctAnswer)
            : base(text)
        {
            CorrectAnswer = correctAnswer;
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine(QuestionText);
        }

        public override bool CheckAnswer(string userAnswer)
        {
            return string.Equals(userAnswer, CorrectAnswer, StringComparison.OrdinalIgnoreCase);
        }
    }
}
