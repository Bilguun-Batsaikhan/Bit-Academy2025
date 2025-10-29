using System;

namespace QuizMaker
{
    public abstract class QuestionBase : IQuestion
    {
        public string QuestionText { get; set; }

        protected QuestionBase(string questionText)
        {
            QuestionText = questionText;
        }

        public abstract void DisplayQuestion();
        public abstract bool CheckAnswer(string userAnswer);
    }
}
