using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Arena
{
    internal class Arena
    {
        /// <summary>
        /// První bojovník v aréne
        /// </summary>
        private Bojovnik bojovnik1;
        /// <summary>
        /// Druhý bojovník v aréně
        /// </summary>
        private Bojovnik bojovnik2;
        /// <summary>
        /// Hrací kostka
        /// </summary>
        private Kostka kostka;

        /// <summary>
        /// Vytvoří novou instanci arény
        /// </summary>
        /// <param name="bojovnik1">První bojovník v aréne</param>
        /// <param name="bojovnik2">Druhý bojovník v aréně</param>
        /// <param name="kostka">Hrací kostka</param>
        public Arena(Bojovnik bojovnik1, Bojovnik bojovnik2, Kostka kostka)
        {
            this.bojovnik1 = bojovnik1;
            this.bojovnik2 = bojovnik2;
            this.kostka = kostka;
        }

        /// <summary>
        /// Simuluje zápas bojovníků
        /// </summary>
        public void Zapas()
        {
            // původní pořadí
            Bojovnik b1 = bojovnik1;
            Bojovnik b2 = bojovnik2;
            Console.WriteLine("Vítejte v aréně!");
            Console.WriteLine("Dnes se utkají {0} s {1}! \n", bojovnik1, bojovnik2);
            // prohození bojovníků
            bool zacinaBojovnik2 = (kostka.hod() <= kostka.VratPocetSten() / 2);
            if (zacinaBojovnik2)
            {
                b1 = bojovnik2;
                b2 = bojovnik1;
            }
            Console.WriteLine("Začínat bude bojovník {0}! \nZápas může začít...", b1);
            Console.ReadKey();
            // cyklus s bojem
            while (b1.Nazivu() && b2.Nazivu())
            {
                b1.Utoc(b2);
                Vykresli();
                VypisZpravu(b1.VratPosledniZpravu()); // zpráva o útoku
                VypisZpravu(b2.VratPosledniZpravu()); // zpráva o obraně                  
                if (b2.Nazivu())
                {
                    b2.Utoc(b1);
                    Vykresli();
                    VypisZpravu(b2.VratPosledniZpravu()); 
                    VypisZpravu(b1.VratPosledniZpravu()); 
                }
                Console.WriteLine();
            }
        }

        private void VypisBojovnika(Bojovnik b)
        {
            Console.WriteLine(b);
            Console.Write("Zivot: ");
            Console.ForegroundColor = ConsoleColor.Red;           //Vybarvené pozadí životů
            Console.BackgroundColor = ConsoleColor.DarkRed;       
            Console.WriteLine(b.GrafickyZivot());
            Console.ResetColor();
            if (b is Mag)
            {
                Console.Write("Mana:  ");
                Console.ForegroundColor = ConsoleColor.Blue;          //Mana
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(((Mag)b).GrafickaMana());
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Vykreslí informační obrazovku
        /// </summary>
        private void Vykresli()
        {
            Console.Clear();
            Console.WriteLine(@"
                __    ____  ____  _  _    __   
               /__\  (  _ \( ___)( \( )  /__\  
              /(__)\  )   / )__)  )  (  /(__)\ 
             (__)(__)(_)\_)(____)(_)\_)(__)(__)");
            Console.WriteLine("Bojovníci: \n");
            VypisBojovnika(bojovnik1);
            Console.WriteLine();
            VypisBojovnika(bojovnik2);
            Console.WriteLine();
        }

        /// <summary>
        /// Vypíše zprávu do konzole s malou pauzou
        /// </summary>
        /// <param name="zprava">Zpráva</param>
        private void VypisZpravu(string zprava)
        {
            Console.WriteLine(zprava);
            Thread.Sleep(500);
        }
    }
}
