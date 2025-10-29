using QuizMaker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Class
{
    internal class TextQuiz : IQuizSingle<string>
    {
        public Dictionary<string, string> questionsAndAnswers { get; set; } = new Dictionary<string, string>();

        public void AddAnswer(string question, string answer)
        {
            if (questionsAndAnswers.ContainsKey(question))
            {
                questionsAndAnswers[question] = answer;
            }
        }

        public void AddQuestion(string question)
        {
            questionsAndAnswers[question] = string.Empty;
        }

        public Dictionary<string, string> GetMyQuiz()
        {
            return questionsAndAnswers;
        }

        public void RemoveAnswer(string question)
        {
            if (questionsAndAnswers.ContainsKey(question))
            {
                questionsAndAnswers[question] = string.Empty;
            }
        }

        public void RemoveQuestion(string question)
        {
            questionsAndAnswers.Remove(question);
        }
    }
}
