using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Interface
{
    internal interface IQuiz<T>
    {
        void AddQuestion(string question);
        void AddAnswer(string question, T answer);
        void RemoveQuestion(string question);
        void RemoveAnswer(string question);
    }
}
