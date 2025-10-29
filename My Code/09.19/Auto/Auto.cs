/*
1. La nostra app chiede se stampare l'elenco delle auto o inserire.
2. Come primo step la nostra app deve chiedere quante auto vogliamo inserire nella concessionaria.
3. La nostra app deve chiedere il nome, modello, colore e anno di fabbricazione in console per poi inserire la auto in una lista.
4. Una volta inserite le auto stampiamo a video l'elenco delle auto.
*/
class Auto
{
    public string Nome { get; set; }
    public string Modello { get; set; }
    public string Colore { get; set; }
    public int AnnoFabbricazione { get; set; }

    public Auto(string nome, string modello, string colore, int annoFabbricazione)
    {
        Nome = nome;
        Modello = modello;
        Colore = colore;
        AnnoFabbricazione = annoFabbricazione;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Modello: {Modello}, Colore: {Colore}, Anno di Fabbricazione: {AnnoFabbricazione}";
    }
}