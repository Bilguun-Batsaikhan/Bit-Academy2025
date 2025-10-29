namespace Enums
{
    public class Classroom
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public MyDays StartWeekDay { get; set; }
        public MyDays[] Days { get; set; } = [MyDays.Monday, MyDays.Friday];
        public DayOfWeek MyProperty { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Description}-{StartWeekDay}-{string.Join(',', Days)}";
        }
    }
}
