using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaUtils
{
    public static class IndirizzoGenerator
    {
        private static readonly Faker faker = new Faker();
        public static Indirizzo Generate()
        {
            return new Indirizzo
            {
                Via = faker.Address.StreetAddress(),
                NumeroCivico = int.Parse(faker.Address.BuildingNumber()),
                Citta = faker.PickRandom<Citta>(),
                Provincia = faker.PickRandom<Provincia>()
            };
        }
    }
}
