using QuizMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMakerV2
{
    internal class NewQuiz
    {
        public void SaveToFile(string[] lines, string fileName)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // 'true' enables append mode
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, fileName + ".txt"), true))
            {
                
                    foreach (string line in lines)
                    {
                        outputFile.WriteLine(line);
                    }
                    // Add a separator or empty line
                    outputFile.WriteLine();
                
            }
        }

        public string LoadFromFile(string FilePath)
        {
            try
            {
                // Open the text file using a stream reader.
                using StreamReader reader = new(FilePath);

                // Read the stream as a string.
                string text = reader.ReadToEnd();

                return text;
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return string.Empty;
        }
        public MultipleChoiceQuestion? CreateMultipleChoice(string[] choices, int correctIndex)
        {
            if (choices.Count() > 0)
            {
                return new MultipleChoiceQuestion(choices[0], choices.Skip(1).ToList(), correctIndex);
            }
            return null;
        }
        public MultipleChoiceQuestion? CreateQuiz()
        {
            Console.WriteLine("Please insert a question.");
            var q = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please indicate number of possible answers");
            int.TryParse(Console.ReadLine(), out int num);
            string[] multipleQuiz = new string[num + 1];
            int x = 1;
            while (num > 0)
            {
                Console.WriteLine("Please insert an answer");
                var a = Console.ReadLine();
                
                    multipleQuiz[x++] = a ?? string.Empty;
                
                num--;
            }
            multipleQuiz[0] = q;
            Console.WriteLine("Please insert the correct answer index");
            for(int i = 1;i < multipleQuiz.Length; i++)
            {
                Console.WriteLine($"{i}: {multipleQuiz[i]}");
            }
            int.TryParse(Console.ReadLine(), out int index);
            return CreateMultipleChoice(multipleQuiz, index - 1);
        }
        //public int GetQuizAnswer(IQuestion quiz)
        //{
        //    if(quiz.GetType().Equals(typeof(MultipleChoiceQuestion)))
        //    {
        //        quiz.ge
        //    }
        //    //TODO: Implement the others later
        //}
    }
}
