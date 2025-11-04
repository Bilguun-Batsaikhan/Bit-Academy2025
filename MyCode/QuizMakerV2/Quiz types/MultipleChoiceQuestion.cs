using System;
using System.Collections.Generic;

namespace QuizMaker
{
    public class MultipleChoiceQuestion : QuestionBase
    {
        public List<string> Options { get; set; }
        public int CorrectOptionIndex { get; set; }

        public MultipleChoiceQuestion(string text, List<string> options, int correctIndex)
            : base(text)
        {
            Options = options;
            CorrectOptionIndex = correctIndex;
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine(QuestionText);
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }
        }

        public override bool CheckAnswer(string userAnswer)
        {
            if (int.TryParse(userAnswer, out int choice))
            {
                return (choice - 1) == CorrectOptionIndex;
            }
            return false;
        }
    }
}
