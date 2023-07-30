using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    class Program
    {
        static void Main(string[] args)
        {
            Had had = new Had(); // Instance hada
            while (had.Zivy) // Herní smyčka
            {
                had.Lez(); // Posun hada
                Console.BackgroundColor = ConsoleColor.Green; // Nastavení zeleného pozadí
                Console.Clear(); // Vymazání konzole
                had.Vykresli(); // Vykreslení hada
                Thread.Sleep(50); // Hrací plochu necháme chvíli vykreslenou
                // Pokud je stisknuta nějaká klávesa
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo klavesa = Console.ReadKey(); // Načtení klávesy
                    // Reakce na jednotlivé klávesy
                    if (klavesa.Key == ConsoleKey.RightArrow)
                        had.Smer = 0;
                    if (klavesa.Key == ConsoleKey.LeftArrow)
                        had.Smer = 180;
                    if (klavesa.Key == ConsoleKey.DownArrow)
                        had.Smer = 270;
                    if (klavesa.Key == ConsoleKey.UpArrow)                    
                        had.Smer = 90;
                }                
            }
            // Konec hry
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Konec hry...");
            Console.ReadKey();
        }
    }
}
