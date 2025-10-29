

namespace RubricaUtils
{

    public class Rubrica
    {
        public List<Contatto> Contatti { get; set; }

        public Rubrica()
        {
            Contatti = new List<Contatto>();
        }

        public bool aggiungeContatto(Contatto contatto)
        {
            if (contatto is not null)
            {
                Contatti.Add(contatto);
                return true;
            }
            return false;
        }

        public bool visualizzaContatti()
        {
            Console.WriteLine("Lista di contatti: ");
            Console.WriteLine(ToString());
            return false;
        }

        public override string ToString()
        {
            return string.Join("| ", Contatti);
        }
    }
}
