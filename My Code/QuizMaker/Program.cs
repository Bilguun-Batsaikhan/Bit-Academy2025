using QuizMaker.Class;
using QuizMaker.Interface;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var multiQuiz = new MultipleChoice();

            // Add full questions with answer choices
            multiQuiz.AddQuestionAndAnswers("What is the capital of France?", new List<string> { "Paris", "London", "Berlin", "Rome" });
            multiQuiz.AddQuestionAndAnswers("Which planet is known as the Red Planet?", new List<string> { "Earth", "Mars", "Jupiter", "Venus" });
            multiQuiz.AddQuestionAndAnswers("Which language is primarily used for Android development?", new List<string> { "Java", "Swift", "Python", "C#" });

            // Add answers to existing questions
            multiQuiz.AddAnswer("What is the capital of France?", "Madrid"); // Adding an extra distractor
            multiQuiz.AddAnswer("Which planet is known as the Red Planet?", "Saturn");

            // Add questions without answers
            multiQuiz.AddQuestion("Who wrote 'To Kill a Mockingbird'?");
            multiQuiz.AddQuestion("What is the boiling point of water in Celsius?");

            // Optionally, set correct answers
            multiQuiz.answers["What is the capital of France?"] = "Paris";
            multiQuiz.answers["Which planet is known as the Red Planet?"] = "Mars";
            multiQuiz.answers["Which language is primarily used for Android development?"] = "Java";
            multiQuiz.answers["Who wrote 'To Kill a Mockingbird'?"] = "Harper Lee";
            multiQuiz.answers["What is the boiling point of water in Celsius?"] = "100";

            var questionsAndAnswers = multiQuiz.GetMyQuiz();
            foreach (var question in questionsAndAnswers)
            {
                Console.WriteLine(question.Key);
                foreach(var answer in question.Value)
                {
                    Console.WriteLine(answer);
                }
            }
            Console.WriteLine("-------------------------------");
            multiQuiz.PrintCorrectAnswers();
            Console.WriteLine("-------------------------------");

            var textQuiz = new TextQuiz();

            // Add questions without answers
            textQuiz.AddQuestion("Who wrote 'To Kill a Mockingbird'?");
            textQuiz.AddQuestion("What is the boiling point of water in Celsius?");
            textQuiz.AddQuestion("Which planet is known as the Red Planet?");
            textQuiz.AddQuestion("What is the capital of France?");
            textQuiz.AddQuestion("Which language is primarily used for Android development?");

            // Add answers to existing questions
            textQuiz.AddAnswer("Who wrote 'To Kill a Mockingbird'?", "Harper Lee");
            textQuiz.AddAnswer("What is the boiling point of water in Celsius?", "100");
            textQuiz.AddAnswer("Which planet is known as the Red Planet?", "Mars");
            textQuiz.AddAnswer("What is the capital of France?", "Paris");
            textQuiz.AddAnswer("Which language is primarily used for Android development?", "Java");

            // Remove an answer (simulate clearing it)
            textQuiz.RemoveAnswer("Which planet is known as the Red Planet?");

            // Remove a question entirely
            textQuiz.RemoveQuestion("What is the boiling point of water in Celsius?");

            // Print all questions and answers
            var questionsAndAnswersS = textQuiz.GetMyQuiz();
            foreach (var qa in questionsAndAnswersS)
            {
                Console.WriteLine($"Q: {qa.Key}");
                Console.WriteLine($"A: {(string.IsNullOrEmpty(qa.Value) ? "[No Answer]" : qa.Value)}");
                Console.WriteLine();
            }

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Correct Answers:");
            foreach (var qa in questionsAndAnswersS)
            {
                if (!string.IsNullOrEmpty(qa.Value))
                {
                    Console.WriteLine($"{qa.Key} => {qa.Value}");
                }
            }
            Console.WriteLine("-------------------------------");

        }
    }
}
