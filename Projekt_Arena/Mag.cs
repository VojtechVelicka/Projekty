using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Arena
{
    class Mag : Bojovnik
    {

        /// <summary>
        /// Mana
        /// </summary>
        private int mana;
        /// <summary>
        /// Maximální mana, tedy hodnota, kdy je mana plná a lze ji použít
        /// </summary>
        private int maxMana;
        /// <summary>
        /// Magický útok v HP
        /// </summary>
        private int magickyUtok;
        public Mag(string jmeno, int zivot, int utok, int obrana, Kostka kostka, int mana, int magickyUtok) : base(jmeno, zivot, utok, obrana, kostka)
        {
            this.mana = mana;
            this.maxMana = mana;
            this.magickyUtok = magickyUtok;
        }

        /// <summary>
        /// Provede útok na soupeře
        /// </summary>
        /// <param name="souper">Soupeř bojovník</param>
        public override void Utoc(Bojovnik souper)
        {
            // Mana není naplněna
            if (mana < maxMana)
            {
                mana += 10;
                if (mana > maxMana)
                    mana = maxMana;
                base.Utoc(souper);
            }
            else // Magický útok
            {
                int uder = magickyUtok + kostka.hod();
                NastavZpravu(String.Format("{0} použil magii za {1} hp", jmeno, uder));
                souper.BranSe(uder);
                mana = 0;
            }
        }

        /// <summary>
        /// Vrátí grafickou reprezentaci many
        /// </summary>
        /// <returns>Řetězec s grafickou reprezentací many</returns>
        public string GrafickaMana()
        {
            return GrafickyUkazatel(mana, maxMana);
        }
    }
}
