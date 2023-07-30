namespace Projekt_Arena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // vytvoření objektů
            Kostka kostka = new Kostka(10);
            Bojovnik orc = new Bojovnik("Orc", 100, 20, 10, kostka);
            Mag magickyElf = new Mag("Magický Elf", 60, 15, 12, kostka, 30, 45);
            Arena arena = new Arena(orc, magickyElf, kostka);
            // zápas
            arena.Zapas();
            Console.ReadKey();
        }
    }
}