using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Had
{
    /*  _____ _______         _                      _
     * |_   _|__   __|       | |                    | |
     *   | |    | |_ __   ___| |___      _____  _ __| | __  ___ ____
     *   | |    | | '_ \ / _ \ __\ \ /\ / / _ \| '__| |/ / / __|_  /
     *  _| |_   | | | | |  __/ |_ \ V  V / (_) | |  |   < | (__ / /
     * |_____|  |_|_| |_|\___|\__| \_/\_/ \___/|_|  |_|\_(_)___/___|
     *                                _
     *              ___ ___ ___ _____|_|_ _ _____
     *             | . |  _| -_|     | | | |     |  LICENCE
     *             |  _|_| |___|_|_|_|_|___|_|_|_|
     *             |_|
     *
     * IT ZPRAVODAJSTVÍ  <>  PROGRAMOVÁNÍ  <>  HW A SW  <>  KOMUNITA
     *
     * Tento zdrojový kód je součástí výukových seriálů na
     * IT sociální síti WWW.ITNETWORK.CZ
     *
     * Kód spadá pod licenci prémiového obsahu a vznikl díky podpoře
     * našich členů. Je určen pouze pro osobní užití a nesmí být šířen.
     * Více informací na http://www.itnetwork.cz/licence
     */

    /// <summary>
    /// Reprezentuje hada
    /// </summary>
    class Had
    {
        /// <summary>
        /// Jednotlivé kostky, reprezentující hada
        /// </summary>
        private List<Kostka> clanky = new List<Kostka>();
        /// <summary>
        /// Směr hada (0 doprava, 90 nahoru, 180 doleva, 270 dolů)
        /// </summary>
        public int Smer { get; set; }
        /// <summary>
        /// Zda je had živý
        /// </summary>
        public bool Zivy { get; set; }
        /// <summary>
        /// Kostka reprezentující hadí jídlo
        /// </summary>
        private Kostka jidlo = new Kostka(0, 0, ConsoleColor.Red);
        /// <summary>
        /// Generátor náhodných čísel
        /// </summary>
        Random random = new Random(); // Generátor náhodných čísel
        /// <summary>
        /// Barva hada
        /// </summary>
        private ConsoleColor barva = ConsoleColor.DarkMagenta;

        /// <summary>
        /// Inicializuje instanci
        /// </summary>
        public Had()
        {
            Smer = 0;
            Zivy = true;
            // Vložení prvních 3 článků hada
            clanky.Add(new Kostka(15, 7, barva));
            clanky.Add(new Kostka(14, 7, barva));
            clanky.Add(new Kostka(14, 8, barva));            
            UmistiJidlo(); // Umístění prvního jídla
        }

        /// <summary>
        /// Vykreslí hada a jídlo
        /// </summary>
        public void Vykresli()
        {
            foreach (Kostka clanek in clanky)
            {
                clanek.Vykresli();
            }
            jidlo.Vykresli();
        }

        /// <summary>
        /// Posune hada a zkontroluje kolize
        /// </summary>
        public void Lez()
        {
            if (Zivy)
            {
                Kostka novaHlava = new Kostka(clanky[0].X, clanky[0].Y, barva); // Vytvoření nové hlavy                
                // Posunutí nové hlavy podle směru hada
                if (Smer == 0)
                    novaHlava.X++;
                if (Smer == 90)
                    novaHlava.Y--;
                if (Smer == 180)
                    novaHlava.X--;
                if (Smer == 270)
                    novaHlava.Y++;
                clanky.Insert(0, novaHlava); // Vložení nové hlavy do článků

                if (clanky[0].Kolize(jidlo)) // Hlava narazila na jídlo, nemažeme ocas, protože had se prodloužil
                    UmistiJidlo(); // Přesuneme jídlo na novou pozici
                else
                    clanky.RemoveAt(clanky.Count - 1); // Umazání ocasu

                if (clanky[0].MimoKonzoli) // Usmrcení hada když vydeje hlavou mimo konzoli
                    Zivy = false;
                // Usmrcení hada při kolizi hlavy s ostatními články (hlavu vynecháváme, proto od 1)
                for (int i = 1; i < clanky.Count; i++)
                {
                    if (clanky[0].Kolize(clanky[i]))
                        Zivy = false;
                }
            }
        }

        /// <summary>
        /// Umístí jídlo tak, aby nebylo v hadovi
        /// </summary>
        public void UmistiJidlo()
        {
            Console.Beep(900, 50);
            bool jeKolize = true;
            // Opakuje dokud není jídlo mimo hada
            while (jeKolize)
            {
                jidlo.X = random.Next(Console.WindowWidth / 2);
                jidlo.Y = random.Next(Console.WindowHeight);
                // Předpokládáme, že jídlo není v hadovi
                jeKolize = false;
                foreach (Kostka clanek in clanky)
                {
                    if (jidlo.Kolize(clanek)) // Jídlo koliduje s nějakým článkem hada
                        jeKolize = true;
                }
            }
        }
    }
}
