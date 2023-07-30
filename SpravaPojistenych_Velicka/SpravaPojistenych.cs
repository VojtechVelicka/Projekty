using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace SpravaPojistenych_Velicka
{
	public class SpravaPojistenych
	{
		private List<Pojisteny> seznamPojistenych;

		public SpravaPojistenych()
		{
			seznamPojistenych = new List<Pojisteny>();
		}

		public void VytvoritPojisteneho(string jmeno, string prijmeni, int vek, string telefonniCislo)
		{
			Pojisteny pojisteny = new Pojisteny(jmeno, prijmeni, vek, telefonniCislo);
			seznamPojistenych.Add(pojisteny);
			Console.WriteLine("Pojištěný byl úspěšně vytvořen.");
		}

		public void ZobrazitSeznamPojistenych()
		{
			if (seznamPojistenych.Count > 0)
			{
				Console.WriteLine("Seznam pojištěných:");
				foreach (Pojisteny pojisteny in seznamPojistenych)
				{
					Console.WriteLine(pojisteny.ToString());
				}
			}
			else
			{
				Console.WriteLine("Seznam pojištěných je prázdný.");
			}
		}

		public void VyhledatPojisteneho(string jmeno, string prijmeni)
		{
			bool nalezeno = false;
			foreach (Pojisteny pojisteny in seznamPojistenych)
			{
				if (pojisteny.Jmeno.Equals(jmeno, StringComparison.OrdinalIgnoreCase) &&
					pojisteny.Prijmeni.Equals(prijmeni, StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine("Pojištěný nalezen:");
					Console.WriteLine(pojisteny.ToString());
					nalezeno = true;
					break;
				}
			}

			if (!nalezeno)
			{
				Console.WriteLine("Pojištěný s daným jménem a příjmením nebyl nalezen.");
			}
		}

		public void VytvoritPojistenehoZKonsole()
		{
			Console.WriteLine("Zadejte údaje nového pojištěného:");
			bool kontrolaJmena = false;
			string jmeno = "";

			while (!kontrolaJmena)
			{
				Console.Write("Jméno: ");
				jmeno = Console.ReadLine();
				jmeno.Trim();
				jmeno = char.ToUpper(jmeno[0]) + jmeno.Substring(1).ToLower();
				if (!int.TryParse(jmeno, out _))
				{
					kontrolaJmena = true;
				}
				else
				{
					Console.WriteLine("Neplatné jméno. Zadejte pouze písmena.");
				}
			}
			bool kontrolaPrijmeni = false;
			string prijmeni = "";

			while (!kontrolaPrijmeni)
			{
				Console.Write("Přijmení: ");
				prijmeni = Console.ReadLine();
				prijmeni.Trim();
				prijmeni = char.ToUpper(prijmeni[0]) + prijmeni.Substring(1).ToLower();
				if (!int.TryParse(prijmeni, out _))
				{
					kontrolaPrijmeni = true;
				}
				else
				{
					Console.WriteLine("Neplatné přijmení. Zadejte pouze písmena.");
				}
			}

			int vek = 0;
			bool kontrolaVeku = false;
			while (!kontrolaVeku)
			{
				Console.Write("Věk: ");
				if (int.TryParse(Console.ReadLine(), out vek) && vek >= 0)
				{
					kontrolaVeku = true;
				}
				else
				{
					Console.WriteLine("Neplatný věk. Zadejte prosím nezáporné celé číslo.");
				}
			}

			string telefonniCislo = "";
			bool spravnyFormat = false;
			while (!spravnyFormat)
			{
				Console.Write("Telefonní číslo (+420 000 000 000): ");
				telefonniCislo = Console.ReadLine();
				if (telefonniCislo.StartsWith("+") && telefonniCislo.Length == 16)
				{
					spravnyFormat = true;
				}
				else
				{
					Console.WriteLine("Neplatný formát telefonního čísla. Zadejte číslo ve formátu +420 000 000 000.");
				}
			}



			VytvoritPojisteneho(jmeno, prijmeni, vek, telefonniCislo);
		}

		public void VyhledatPojistenehoZKonsole()
		{
			Console.Write("Zadejte jméno pojištěného: ");
			string jmeno = Console.ReadLine();

			Console.Write("Zadejte příjmení pojištěného: ");
			string prijmeni = Console.ReadLine();

			VyhledatPojisteneho(jmeno, prijmeni);
		}




		


	}
}
