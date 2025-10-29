using Bogus;

namespace NuGetTest
{
    public class DataGenerator : Faker<Car>
    {
        public DataGenerator()
        {
            RuleFor(c => c.Id, setter => setter.Random.Guid());
            RuleFor(c => c.Manufacturer, setter => setter.Vehicle.Manufacturer());
            RuleFor(c => c.Description, setter => setter.Lorem.Paragraph());
        }
    }
}
