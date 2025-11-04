using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Interface
{
    internal interface IQuizSingle<T> : IQuiz<T>
    {
        Dictionary<string, T> questionsAndAnswers { get; set; }
        Dictionary<string, T> GetMyQuiz();
    }
}
