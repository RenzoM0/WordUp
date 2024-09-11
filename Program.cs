class Program
{
    static void Main(string[] args)
    {
        // Definieer pad en bestandsnaam
        string pad = "textfiles";
        string bestandsnaam = "invoer.txt";

        // Maak een nieuw Tekst object aan
        Tekst tekst = new Tekst(pad, bestandsnaam);

        // Print de originele woorden
        Console.WriteLine("Originele woorden:");
        foreach (var woord in tekst.GetWoorden())
        {
            Console.WriteLine(woord);
        }

        // Draai de woorden om
        tekst.DraaiOm();

        // Print de omgedraaide woorden
        Console.WriteLine("\nOmgedeelde woorden:");
        foreach (var woord in tekst.GetWoorden())
        {
            Console.WriteLine(woord);
        }
        // Print palindromen
        Console.WriteLine("\nPalindromen:");
        if (tekst.Palindromen().Any())
        {
            foreach (var palindroom in tekst.Palindromen())
            {
                Console.WriteLine(palindroom);
            }
        }
        else { Console.WriteLine("Er zijn geen palindromen"); }
    }

}