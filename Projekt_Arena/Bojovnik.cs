using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Arena
{
    class Bojovnik
    {
       
        protected string jmeno;
        
        protected int zivot;
       
        protected int maxZivot;
       
        protected int utok;
      
        protected int obrana;
        
        protected Kostka kostka;
       
        private string zprava;

        /// <summary>
        /// Vytvoří novou instanci bojovníka
        /// </summary>
        /// <param name="jmeno">Jméno bojovníka</param>
        /// <param name="zivot">Život v HP</param>
        /// <param name="utok">Útok v HP</param>
        /// <param name="obrana">Obrana v HP</param>
        /// <param name="kostka">Instance hrací kostky</param>
        public Bojovnik(string jmeno, int zivot, int utok, int obrana, Kostka kostka)
        {
            this.jmeno = jmeno;
            this.zivot = zivot;
            this.maxZivot = zivot;
            this.utok = utok;
            this.obrana = obrana;
            this.kostka = kostka;
        }

        /// <summary>
        /// Provede útok na soupeře
        /// </summary>
        /// <param name="souper">Soupeř bojovník</param>
        public virtual void Utoc(Bojovnik souper)
        {
            int uder = utok + kostka.hod();
            NastavZpravu(String.Format("{0} útočí s úderem za {1} hp", jmeno, uder));
            souper.BranSe(uder);
        }

        /// <summary>
        /// Brání se proti úderu soupeře
        /// </summary>
        /// <param name="uder">Úder soupeře v HP</param>
        public void BranSe(int uder)
        {
            int zraneni = uder - (obrana + kostka.hod());
            if (zraneni > 0)
            {
                zivot -= zraneni;
                zprava = String.Format("{0} utrpěl poškození {1} hp", jmeno, zraneni);
                if (zivot <= 0)
                {
                    zivot = 0;
                    zprava += " a zemřel";
                }

            }
            else
                zprava = String.Format("{0} odrazil útok", jmeno);
            NastavZpravu(zprava);
        }

        /// <summary>
        /// Zjistí, zda je bojovník naživu
        /// </summary>
        /// <returns>True, pokud je naživu, jinak false</returns>
        public bool Nazivu()
        {
            return (zivot > 0);
        }

        /// <summary>
        /// Nastaví zprávu o útoku nebo obraně
        /// </summary>
        /// <param name="zprava">Zpráva o útoku nebo obraně</param>
        protected void NastavZpravu(string zprava)
        {
            this.zprava = zprava;
        }

        /// <summary>
        /// Vrátí poslední zprávu o útoku nebo obraně
        /// </summary>
        /// <returns>Poslední zpráva o útoku nebo obraně</returns>
        public string VratPosledniZpravu()
        {
            return zprava;
        }


        protected string GrafickyUkazatel(int aktualni, int maximalni)
        {
            string s = "";
            int celkem = 20;
            double pocet = Math.Round(((double)aktualni / maximalni) * celkem);
            if ((pocet == 0) && (Nazivu()))
                pocet = 1;
            for (int i = 0; i < pocet; i++)
                s += "█";
            s = s.PadRight(celkem);
            return s;
        }

        /// <summary>
        /// Vrátí grafickou reprezentaci života
        /// </summary>
        /// <returns>Řetězec s grafickou reprezentací života</returns>
        public string GrafickyZivot()
        {
            return GrafickyUkazatel(zivot, maxZivot);
        }

        /// <summary>
        /// Vrací textovou reprezentaci bojovníka
        /// </summary>
        /// <returns>Textová reprezentace bojovníka</returns>
        public override string ToString()
        {
            return jmeno;
        }
    }
}
