/*
1. La nostra app chiede se stampare l'elenco delle auto o inserire.
2. Come primo step la nostra app deve chiedere quante auto vogliamo inserire nella concessionaria.
3. La nostra app deve chiedere il nome, modello, colore e anno di fabbricazione in console per poi inserire la auto in una lista.
4. Una volta inserite le auto stampiamo a video l'elenco delle auto.
*/
class Program
{
    static void Main(string[] args)
    {
        List<Auto> automobili = new()
    {
        new Auto("Fiat", "Panda", "Bianco", 2010),
        new Auto("Ford", "Focus", "Blu", 2015),
        new Auto("Toyota", "Corolla", "Rosso", 2018),
        new Auto("Volkswagen", "Golf", "Nero", 2020)
    };

        while (true)
        {
            System.Console.WriteLine("\n=== GESTIONE CONCESSIONARIA ===");
            System.Console.WriteLine("1: Visualizza elenco auto");
            System.Console.WriteLine("2: Inserisci nuove auto");
            System.Console.WriteLine("3: Esci");
            System.Console.Write("Scegli un'opzione: ");

            string? scelta = System.Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    MostraElencoAuto(automobili);
                    break;
                case "2":
                    InserisciNuoveAuto(automobili);
                    break;
                case "3":
                    System.Console.WriteLine("Arrivederci!");
                    return;
                default:
                    System.Console.WriteLine("Opzione non valida. Riprova.");
                    break;
            }
        }
    }
    static void MostraElencoAuto(List<Auto> automobili)
    {
        if (automobili.Count == 0)
        {
            System.Console.WriteLine("Nessuna auto disponibile.");
            return;
        }

        System.Console.WriteLine("Elenco delle auto:");
        foreach (Auto auto in automobili)
        {
            System.Console.WriteLine(auto);
        }
    }

    static void InserisciNuoveAuto(List<Auto> automobili)
    {
        int numero = GetValidInteger("Quante auto vorresti inserire?");

        for (int i = 0; i < numero; i++)
        {
            System.Console.WriteLine($"\n--- Auto {i + 1} ---");

            string nome = GetValidString($"Inserisci il nome dell'auto {i + 1}:");
            string modello = GetValidString($"Inserisci il modello dell'auto {i + 1}:");
            string colore = GetValidString($"Inserisci il colore dell'auto {i + 1}:");
            int annoFabbricazione = GetValidInteger($"Inserisci l'anno di fabbricazione dell'auto {i + 1}:");

            Auto nuovaAuto = new Auto(nome, modello, colore, annoFabbricazione);
            automobili.Add(nuovaAuto);
        }

        System.Console.WriteLine("\nAuto inserite con successo!");
        MostraElencoAuto(automobili);
    }

    // Add input validation methods
    static int GetValidInteger(string prompt)
    {
        while (true)
        {
            System.Console.WriteLine(prompt);
            if (int.TryParse(System.Console.ReadLine(), out int result) && result > 0)
            {
                return result;
            }
            System.Console.WriteLine("Per favore inserisci un numero valido maggiore di 0.");
        }
    }

    static string GetValidString(string prompt)
    {
        while (true)
        {
            System.Console.WriteLine(prompt);
            string? input = System.Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            System.Console.WriteLine("Per favore inserisci un valore valido.");
        }
    }
}
