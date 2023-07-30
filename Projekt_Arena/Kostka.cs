using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Arena
{
    internal class Kostka
    {
        /// <summary>
        /// Generátor náhodných čísel
        /// </summary>
        private Random random;
        /// <summary>
        /// Počet stěn kostky
        /// </summary>
        private int pocetSten;

        /// <summary>
        /// Vytvoří novou instanci hrací kostky
        /// </summary>
        public Kostka()
        {
            this.pocetSten = 6;
            random = new Random();
        }

        /// <summary>
        /// Vytvoří novou instanci hrací kostky
        /// </summary>
        /// <param name="pocetSten">Počet stěn hrací kostky</param>
        public Kostka(int pocetSten)
        {
            this.pocetSten = pocetSten;
            random = new Random();
        }

        /// <summary>
        /// Vrátí počet stěn hrací kostky
        /// </summary>
        /// <returns>počet stěn hrací kostky</returns>
        public int VratPocetSten()
        {
            return pocetSten;
        }

        /// <summary>
        /// Vykoná hod kostkou
        /// </summary>
        /// <returns>Číslo od 1 do počtu stěn</returns>
        public int hod()
        {
            return random.Next(1, pocetSten + 1);
        }

        /// <summary>
        /// Vrací textovou reprezentaci kostky
        /// </summary>
        /// <returns>Textová reprezentace kostky</returns>
        public override string ToString()
        {
            return String.Format("Kostka s {0} stěnami", pocetSten);
        }
    }
}
