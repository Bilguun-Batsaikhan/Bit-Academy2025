using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Interface
{
    internal interface IQuizMulti<T> : IQuiz<T>
    {
        // Inside interface I can have a property declared, but not initialized
        Dictionary<string, List<T>> questionsAndAnswers { get; set; }
        Dictionary<string, List<T>> GetMyQuiz();
        
        void PrintCorrectAnswers();
    }
}
