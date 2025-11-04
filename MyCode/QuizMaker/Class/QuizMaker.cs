using Microsoft.Win32.SafeHandles;
using QuizMaker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Class
{
    internal class QuizMaker
    {
        public void StartProgram()
        {
            Console.WriteLine("What type of quiz would you like to make today?");
            Console.WriteLine("1. Multiple choice\r\n 2. Short Answer\r\n 3. True or False");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Please try again");
                    break;
            }
        }
        public void MultipleChoice(MultipleChoice mc)
        {
            bool doneQuestions = false;
            do
            {

                Console.WriteLine("1. Insert a question \r\n 2. Finish with the questions");
                int.TryParse(Console.ReadLine(), out int r);
                switch (r)
                {
                    case 1:
                        var question = Console.ReadLine();
                        mc.AddQuestion(question);
                        AddAnswer(mc, question);
                        break;
                    case 2:
                        doneQuestions = true;
                        break;
                    default:
                        Console.WriteLine("Try again");
                        break;
                }
            } while (!doneQuestions);
        }
        //---------------------
        public void AddAnswer(MultipleChoice mc, string question)
        {
            bool doneAnswers = false;
            while (!doneAnswers)
            {
                Console.WriteLine("1. Insert an answer for the question \r\n 2. Finish adding answers");
                    case 1:
                    var answer = Console.ReadLine();
                    mc.AddAnswer(question, answer);
                    break;
                case 2:
                    doneAnswers = true;
                    break;
                default:
                    Console.WriteLine("Try again");
                    break;
                }
            }
        }
    }
}
