using Bogus.Bson;
using RubricaUtils;
using System.Text.Json;
namespace ProvaRubrica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rubrica r = new Rubrica();
            //bool aggiunto = r.aggiungeContatto(new Contatto("Bilguun", "Batsaikhan", TipoContatto.Amico, "3898929008", "bilguun.ing@gmail.com", new Indirizzo() { Citta = Citta.Torino, Via = "Bonzo", NumeroCivico = 5, Provincia = Provincia.TO}));
            //Console.WriteLine(aggiunto);
            //r.visualizzaContatti();

            RubricaGenerator rubricaGenerator = new RubricaGenerator();
            List<Contatto> contatti = rubricaGenerator.Generate(5);
            var JSONContatti = JsonSerializer.Serialize(contatti, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            foreach (Contatto contatto in contatti)
            {
                r.aggiungeContatto(contatto);
            }
            //Console.WriteLine(JSONContatti);
            //Console.WriteLine(contatti.Count);
            bool exit = false;
            do
            {
                Console.WriteLine("Vorresti aggiungere un nuovo contatto?");
                Console.WriteLine("1. Si");
                Console.WriteLine("2. Visualizza i contatti");
                Console.WriteLine("3. Esce");
                var userInput = Console.ReadLine();
                exit = VerificaInputUtente(userInput, r);
            } while (!exit);
        }
        static bool VerificaInputUtente(string input, Rubrica r) => input switch
        {
            "3" => true,
            "2" => r.visualizzaContatti(),
            "1" => AggiungeContatto(r),
            _ => false,
        };

        static bool AggiungeContatto(Rubrica r)
        {
            Console.WriteLine("Aggiunge Nome");
            var Nome = Console.ReadLine();
            Console.WriteLine("Aggiunge Cognome");
            var Cognome = Console.ReadLine();
            Console.WriteLine("Tipo di Contatto");
            Console.WriteLine("1. Amico,\r\n2. Familiare,\r\n3. Lavoro,\r\n4. Altro");
            var TipoContatto = TtipoContatto(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Aggiunge Telefono");
            var Telefono = Console.ReadLine();
            Console.WriteLine("Aggiunge Email");
            var Email = Console.ReadLine();
            if (!IsValidEmail(Email ?? string.Empty))
            {
                Console.WriteLine("Inserisci un'email valida");
                return false;
            }
            Console.WriteLine("Vorresti aggiungere Indirizzo?");
            Console.WriteLine(" 1. Si, \r\n 2. No, \r\n");
            var Indirizzo = AggiungeIndirizzo(Console.ReadLine() ?? string.Empty);
            
            if (Nome is not null && Cognome != null && Telefono != null && Email != null)
            {                
                    r.aggiungeContatto(new Contatto(Nome, Cognome, TipoContatto, Telefono, Email, Indirizzo));
                    return false;
            }
            return true;
        }
        static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        static TipoContatto TtipoContatto(string input) => input switch
        {
            "1" => TipoContatto.Amico,
            "2" => TipoContatto.Familiare,
            "3" => TipoContatto.Lavoro,
            _ => TipoContatto.Altro
        };
        static Indirizzo AggiungeIndirizzo(string input)
        {
            switch (input)
            {
                case "1":
                    Console.WriteLine("Aggiunge Via");
                    var Via = Console.ReadLine();
                    Console.WriteLine("Aggiunge Numero Civ");
                    int.TryParse(Console.ReadLine(), out int NumCiv);
                    Console.WriteLine("Scegli la Citta");
                    //foreach (var value in Enum.GetValues(typeof(Citta)))
                    //{
                    //    Console.WriteLine(value);
                    //}
                    var namesC = Enum.GetNames(typeof(Citta));
                    for (int i = 0; i < namesC.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}: {namesC[i]}");
                    }
                    int.TryParse(Console.ReadLine(), out int x);
                    Citta c = (Citta) x;
                    Console.WriteLine("Scegli la Provincia");
                    var namesP = Enum.GetNames(typeof(Provincia));
                    for(int i = 0; i < namesP.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}: {namesP[i]}");
                    }
                    int.TryParse(Console.ReadLine(), out int y);
                    Provincia p = (Provincia) y;

                    return new Indirizzo(Via, NumCiv, c, p);

                default: return new Indirizzo();
            }

        }
    }
}
