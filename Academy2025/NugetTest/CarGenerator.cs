using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
namespace NugetTest
{
    internal class CarGenerator : Faker<Car>
    {
        public CarGenerator() {
            RuleFor(c => c.Id, setter => setter.Random.Uuid());
            RuleFor(c => c.Manufacturer, setter => setter.Vehicle.Manufacturer());
            RuleFor(c => c.Description, setter => setter.Lorem.Paragraph());
        }
    }
}
