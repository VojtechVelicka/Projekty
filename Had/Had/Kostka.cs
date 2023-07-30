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
    /// Reprezentuje kostku v herním poli
    /// </summary>
    class Kostka
    {
        /// <summary>
        /// Vodorovná souřadnice
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Svislá souřadnice
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Barva kostky
        /// </summary>
        public ConsoleColor Barva { get; set; }

        /// <summary>
        /// Vrátí zda je kostka mimo konzoli
        /// </summary>
        public bool MimoKonzoli
        {
            get
            {
                return (X >= Console.WindowWidth / 2 || Y >= Console.WindowHeight || X < 0 || Y < 0);
            }
        }

        /// <summary>
        /// Inicializuje instanci
        /// </summary>
        /// <param name="x">Vodorovná souřadnice</param>
        /// <param name="y">Svislá souřadnice</param>
        /// <param name="barva">Barva</param>
        public Kostka(int x, int y, ConsoleColor barva)
        {
            X = x;
            Y = y;
            Barva = barva;
        }

        /// <summary>
        /// Vykreslí kostku do konzole
        /// </summary>
        public void Vykresli()
        {
            if (!MimoKonzoli)
            {
                Console.CursorLeft = X * 2; // Kostku kreslíme jako 2 znaky za sebou, vejde se jich do konzole tedy vodorovně 2x méně
                Console.CursorTop = Y;
                Console.ForegroundColor = Barva;
                Console.Write("██");
            }
        }

        /// <summary>
        /// Zjistí zda kostka koliduje s jinou kostkou v herním poli
        /// </summary>
        /// <param name="kostka">Jiná kostka</param>
        /// <returns>Zda kostka koliduje s jinou kostkou</returns>
        public bool Kolize(Kostka kostka)
        { 
            return (X == kostka.X && Y == kostka.Y);
        }
    }

}
