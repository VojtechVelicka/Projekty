namespace SpravaPojistenych_Velicka
{
	internal class Program
	{
		static void Main(string[] args)
		{
			SpravaPojistenych spravaPojistenych = new SpravaPojistenych();

			bool behProgramu = true;
			while (behProgramu)
			{
				Console.WriteLine();
				Console.WriteLine("--------------");
				Console.WriteLine("Menu:");
				Console.WriteLine("1 - Vytvořit pojištěného");
				Console.WriteLine("2 - Zobrazit seznam pojištěných");
				Console.WriteLine("3 - Vyhledat pojištěného");
				Console.WriteLine("4 - Ukončit program");
				Console.WriteLine("--------------");
				Console.WriteLine();

				Console.Write("Zvolte akci (1-4): ");
				string volba = Console.ReadLine();

				switch (volba)
				{
					case "1":
						spravaPojistenych.VytvoritPojistenehoZKonsole();
						break;
					case "2":
						spravaPojistenych.ZobrazitSeznamPojistenych();
						break;
					case "3":
						spravaPojistenych.VyhledatPojistenehoZKonsole();
						break;
					case "4":
						Console.WriteLine("Děkujeme za využití našeho programu");
						behProgramu = false;
						break;
					default:
						Console.WriteLine("Neplatná volba. Zvolte prosím číslo od 1 do 4.");
						break;
				}
			}

		}
	}
}