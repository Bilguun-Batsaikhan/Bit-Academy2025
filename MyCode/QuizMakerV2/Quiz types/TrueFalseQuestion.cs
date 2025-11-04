using QuizMakerV2;
using System;

namespace QuizMaker
{
    public class TrueFalseQuestion : QuestionBase
    {
        public bool CorrectAnswer { get; set; }

        public TrueFalseQuestion(string text, bool correctAnswer)
            : base(text)
        {
            CorrectAnswer = correctAnswer;
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{QuestionText} (true/false)");
        }

        public override bool CheckAnswer(string userAnswer)
        {
            //return bool.TryParse(userAnswer, out bool answer) && answer == CorrectAnswer;
            return userAnswer.StringToBool() == CorrectAnswer;
        }
    }
}
