using QuizMaker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Class
{
    internal class MultipleChoice : IQuizMulti<string>
    {
        public Dictionary<string, List<string>> questionsAndAnswers { get; set; } = new Dictionary<string, List<string>>();
        public Dictionary<string, string> answers { get; set; } = new Dictionary<string, string>();
        // Adding a question along with its answers
        public void AddQuestionAndAnswers(string question, List<string> answers)
        {
            questionsAndAnswers[question] = answers;
        }
        // Adding an answer to an existing question
        public void AddAnswer(string question, string answer)
        {
            if (questionsAndAnswers.ContainsKey(question))
            {
                questionsAndAnswers[question].Add(answer);
            }
        }

        // Adding a question without answers
        public void AddQuestion(string question)
        {
            questionsAndAnswers[question] = new List<string>();
        }

        public Dictionary<string, List<string>> GetMyQuiz()
        {
            return questionsAndAnswers;
        }

        public void MarkCorrectAnswer(string question, int index)
        {
            questionsAndAnswers.TryGetValue(question, out var answersQ);
            bool added = false;
            for(int i = 0; i < answersQ.Count && !added; i++)
            {
                if(i == index - 1)
                {
                    answers[question] = answersQ[i];
                    added = true;
                }
            }
        }

        public void PrintCorrectAnswers()
        {
            foreach (var question in answers)
            {
                Console.WriteLine($"Question: {question.Key}");
                Console.WriteLine($"Correct Answer: {question.Value}");
                Console.WriteLine(); 
            }
        }

        public void RemoveAnswer(string q)
        {
            throw new NotImplementedException();
        }

        public void RemoveQuestion(string question)
        {
            throw new NotImplementedException();
        }
    }
}
