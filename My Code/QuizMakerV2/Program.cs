using QuizMakerV2;
using System;
using System.Collections.Generic;

namespace QuizMaker
{
    class Program
    {
        static void Main()
        {
            //var quiz = new Quiz();

            //quiz.AddQuestion(new MultipleChoiceQuestion(
            //    "What is the capital of France?",
            //    new List<string> { "Berlin", "Madrid", "Paris", "Rome" },
            //    2));

            //quiz.AddQuestion(new TrueFalseQuestion("C# is a programming language?", true));

            //quiz.AddQuestion(new TextQuestion("Who developed the theory of relativity?", "Einstein"));

            //quiz.Start();

            //newQuiz.SaveToFile(["M", "What is the capital of France?", "Berlin", "Madrid", "Paris", "Rome"]);
            //string loadedText = newQuiz.LoadFromFile("C:\\Users\\Bilguun\\Documents\\WriteLines.txt");
            //List<string> lines = new List<string>(loadedText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None));
            //string[] withoutFirst = lines.Skip(1).ToArray();
            ////Console.WriteLine(withoutFirst.Count());
            //IQuestion multipleChoice = newQuiz.CreateMultipleChoice(withoutFirst, 2);
            //if(multipleChoice != null)
            //{
            //    quiz.AddQuestion(multipleChoice);
            //}
            //quiz.Start();

            beginTheProgrammer();
            //quiz.Start();
        }
        public static void beginTheProgrammer()
        {
            var quiz = new Quiz();
            var newQuiz = new NewQuiz();
            Console.WriteLine("Would you like to create a new quiz or load an existing one?");
            Console.WriteLine("1. Create new quiz\r\n2. Load existing quiz\r\n");
            int.TryParse(Console.ReadLine(), out int choice);
            validateUserInput(choice, quiz, newQuiz);
            quiz.Start();
        }

        public static void validateUserInput(int choice, Quiz quiz, NewQuiz newQuiz)
        {
            List<MultipleChoiceQuestion> questionList = new List<MultipleChoiceQuestion>();
            switch (choice)
            {
                case 1:
                    bool done = false;
                    do
                    {
                        MultipleChoiceQuestion? mquiz = newQuiz.CreateQuiz();
                        quiz.AddQuestion(mquiz);
                        questionList.Add(mquiz);
                        Console.WriteLine("Add another question?");
                        Console.WriteLine("1. Yes\r\n2. No\r\n");
                        int.TryParse(Console.ReadLine(), out int  answer);
                        if(answer == 2)
                        {
                            done = true;
                        }
                    } while (!done);
                        saveQuiz(questionList, newQuiz);
                    break;
                case 2:
                    Console.WriteLine("Please write the filename to load the quiz");
                    var fileName = Console.ReadLine();
                    string loadedText = newQuiz.LoadFromFile($"C:\\Users\\Bilguun\\Documents\\{fileName}.txt");
                    List<List<string>> questionBlocks = ParseQuestions(loadedText);

                    foreach (var block in questionBlocks)
                    {
                        //for(int i = 0; i < block.Count; i++)
                        //{
                        //    Console.WriteLine($"{i}: {block[i]}");
                        //}
                        quiz.AddQuestion(ReadQuiz(newQuiz, block));
                    }
                    break;
                default:
                    Console.WriteLine("Wrong answer");
                    break;
            }
        }

        public static void saveQuiz(List<MultipleChoiceQuestion> questionList , NewQuiz n)
        {
            Console.WriteLine("Would you like to save your quiz?");
            Console.WriteLine("1. Yes\r\n2. No\r\n");
            int.TryParse(Console.ReadLine(), out int saveOrNot);
            if (saveOrNot == 1)
            {
                Console.WriteLine("Give your quiz file a name");
                var fileName = Console.ReadLine();
                foreach (MultipleChoiceQuestion question in questionList)
                {
                    string questionText = question.QuestionText;
                    List<string> options = question.Options;
                    int correctIndex = question.CorrectOptionIndex;
                    // Prepare the combined list with "M" first, then questionText, then all options
                    List<string> combined = new List<string> { $"M-{correctIndex}", questionText };
                    combined.AddRange(options);

                    // Convert to array
                    string[] resultArray = combined.ToArray();
                    n.SaveToFile(resultArray, fileName);
                }
            } else
            {
                return;
            }
        }

        public static List<List<string>> ParseQuestions(string loadedText)
        {
            var lines = loadedText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            var questions = new List<List<string>>();
            List<string> currentBlock = null;

            foreach (var line in lines)
            {
                if (line.StartsWith("M-"))
                {
                    if (currentBlock != null)
                    {
                        questions.Add(currentBlock);
                    }
                    currentBlock = new List<string>();
                    currentBlock.Add(line);
                }
                else if (!string.IsNullOrWhiteSpace(line))
                {
                    currentBlock?.Add(line);
                }
            }

            if (currentBlock != null && currentBlock.Count > 0)
                questions.Add(currentBlock);

            return questions;
        }
        public static IQuestion ReadQuiz(NewQuiz newQuiz, List<string> block)
        {
            string firstLine = block[0]; // e.g. "M-0"
            int correctIndex = 0;
            if (firstLine.StartsWith("M-"))
            {
                string indexStr = firstLine.Substring(2);
                int.TryParse(indexStr, out correctIndex);
            }

            string[] questionAndOptions = block.Skip(1).ToArray();
            return newQuiz.CreateMultipleChoice(questionAndOptions, correctIndex);
        }
    }
}
