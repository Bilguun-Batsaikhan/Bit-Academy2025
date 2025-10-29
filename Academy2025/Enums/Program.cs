using System.Text.Json;

namespace Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var classRoom = new Classroom() { Name = "Fullstack Dev", StartWeekDay = MyDays.Monday };
            var classroomJson = JsonSerializer.Serialize(classRoom);
            var classRoomConverted = JsonSerializer.Deserialize<Classroom>(classroomJson);

            Console.WriteLine(classroomJson);
        }
    }
}
