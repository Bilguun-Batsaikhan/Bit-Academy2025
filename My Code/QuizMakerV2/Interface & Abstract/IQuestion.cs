namespace QuizMaker
{
    public interface IQuestion
    {
        string QuestionText { get; set; }
        void DisplayQuestion();
        bool CheckAnswer(string userAnswer);
    }
}
