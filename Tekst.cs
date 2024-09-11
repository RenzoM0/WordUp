class Tekst
{
    private List<string> woorden;

    // Struct om bestandsinformatie op te slaan binnen de Tekst klasse
    public struct BestandInformatie
    {
        public string Pad { get; set; }
        public string Bestandsnaam { get; set; }

        // Constructor om pad en bestandsnaam in te stellen
        public BestandInformatie(string pad, string bestandsnaam)
        {
            Pad = pad;
            Bestandsnaam = bestandsnaam;
        }
    }

    public BestandInformatie BestandInfo { get; private set; } // Attribuut van type struct

    // Constructor die de lijst met woorden en bestand informatie instelt
    public Tekst(string pad, string bestandsnaam)
    {
        woorden = new List<string>();
        BestandInfo = new BestandInformatie(pad, bestandsnaam);
        LeesInvoertekst();
    }

    // Methode om woorden te lezen uit het bestand
    private void LeesInvoertekst()
    {
        try
        {
            // Maak het volledige pad naar het bestand
            string volledigePad = Path.Combine(BestandInfo.Pad, BestandInfo.Bestandsnaam);
            // Lees alle lijnen uit het bestand
            string[] lijnen = File.ReadAllLines(volledigePad);

            // Loop door elke lijn en splits deze in woorden
            foreach (string lijn in lijnen)
            {
                string[] woordenInLijn = lijn.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                woorden.AddRange(woordenInLijn);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fout bij het lezen van het bestand: {ex.Message}");
        }
    }

    // Methode om de lijst met woorden terug te geven
    public List<string> GetWoorden()
    {
        return woorden;
    }

    // Methode om de volgorde van woorden om te draaien
    public void DraaiOm()
    {
        woorden.Reverse(); // Draai de lijst met woorden om
    }
    public List<string> Palindromen()
    {
        List<string> palindromen = new List<string>();
        foreach (string woord in woorden)
        {
            // Verwijder speciale tekens en converteer naar kleine letters
            string schoonWoord = new string(woord.Where(char.IsLetter).ToArray()).ToLower();

            // Vergelijk schoonWoord met zijn omgekeerde versie
            if (schoonWoord == new string(schoonWoord.Reverse().ToArray()))
            {
                palindromen.Add(woord);
            }
        }
        return palindromen;
    }
}