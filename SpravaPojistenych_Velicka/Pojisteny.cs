using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaPojistenych_Velicka
{
	public class Pojisteny
	{
		public string Jmeno { get; }
		public string Prijmeni { get; }

		public int Vek { get; }
		public string TelefonniCislo { get; }


		public Pojisteny(string jmeno, string prijmeni, int vek, string telefonniCislo)
		{ 
		
		this.Jmeno = jmeno;
		this.Prijmeni = prijmeni;
		this.Vek = vek;
		this.TelefonniCislo = telefonniCislo;
		
		
		}

		public override string ToString()
		{
			return $"{Jmeno} {Prijmeni} (Věk: {Vek}, Telefon: {TelefonniCislo})";
		}


	}
}
