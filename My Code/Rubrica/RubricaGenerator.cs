using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaUtils
{
    public class RubricaGenerator : Faker<Contatto>
    {
        public RubricaGenerator() {
            RuleFor(c => c.Nome, setter => setter.Person.FirstName);
            RuleFor(c => c.Cognome, setter => setter.Person.LastName);
            RuleFor(c => c.Email, setter => setter.Person.Email);
            RuleFor(c => c.Telefono, setter => setter.Person.Phone);
            RuleFor(c => c.TipoContatto, setter => setter.PickRandom<TipoContatto>());
            RuleFor(c => c.Indirizzo, _ => IndirizzoGenerator.Generate());
        }
    }
}
