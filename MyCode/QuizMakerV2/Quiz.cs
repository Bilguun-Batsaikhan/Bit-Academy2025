using System;
using System.Collections.Generic;

namespace QuizMaker
{
    public class Quiz
    {
        private List<IQuestion> _questions = new List<IQuestion>();

        public void AddQuestion(IQuestion question)
        {
            _questions.Add(question);
        }

        public void Start()
        {
            int score = 0;

            foreach (var question in _questions)
            {
                question.DisplayQuestion();
                Console.Write("Your answer: ");
                string answer = Console.ReadLine() ?? "";

                if (question.CheckAnswer(answer))
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine("Wrong!\n");
                }
            }

            Console.WriteLine($"Quiz finished! Your score: {score}/{_questions.Count}");
        }
    }
}
