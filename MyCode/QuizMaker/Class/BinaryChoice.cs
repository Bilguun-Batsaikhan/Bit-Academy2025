using QuizMaker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Class
{
    internal class BinaryChoice : IQuizMulti<bool>
    {
        public Dictionary<string, List<bool>> questionsAndAnswers { get; set; } = new Dictionary<string, List<bool>>();

        public void AddAnswer(string question, bool answer)
        {
            throw new NotImplementedException();
        }

        public void AddQuestion(string question)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<bool>> GetMyQuiz()
        {
            throw new NotImplementedException();
        }

        public void PrintCorrectAnswers()
        {
            throw new NotImplementedException();
        }

        public void RemoveAnswer(string question)
        {
            throw new NotImplementedException();
        }

        public void RemoveQuestion(string question)
        {
            throw new NotImplementedException();
        }
    }
}
