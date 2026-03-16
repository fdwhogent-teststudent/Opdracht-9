namespace Opdacht_9 {
    class Program {
        static void Main(string[] args) {
            string[] namen = new string[100];
            string[] emails = new string[100];
            string[] telefoons = new string[100];
            int aantalContacten = 0;

            string[] menuOpties = { "Toevoegen", "Verwijderen", "Afsluiten" };
            int geselecteerd = 0;
            bool draait = true;

            while (draait) {
                Console.Clear();

                // Overzicht tonen
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                    CONTACTENBEHEER                       ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════╣");
                Console.ResetColor();

                if (aantalContacten == 0) {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("║  Geen contacten gevonden.                                ║");
                    Console.ResetColor();
                } else {
                    Console.WriteLine("║  {0,-20} {1,-18} {2,-16} ║", "Naam", "E-mail", "Telefoon");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("║  {0,-20} {1,-18} {2,-16} ║", "────────────────────", "──────────────────", "────────────────");
                    Console.ResetColor();

                    for (int i = 0; i < aantalContacten; i++) {
                        string naam = namen[i];
                        string email = emails[i];
                        string telefoon = telefoons[i];

                        if (naam.Length > 20)
                            naam = naam.Substring(0, 17) + "...";
                        if (email.Length > 18)
                            email = email.Substring(0, 15) + "...";
                        if (telefoon.Length > 16)
                            telefoon = telefoon.Substring(0, 13) + "...";

                        Console.WriteLine("║  {0,-20} {1,-18} {2,-16} ║", naam, email, telefoon);
                    }
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
                Console.ResetColor();
                Console.WriteLine();

                // Horizontaal menu tekenen
                for (int i = 0; i < menuOpties.Length; i++) {
                    if (i == geselecteerd) {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"  {menuOpties[i]}  ");
                        Console.ResetColor();
                    } else {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write($"  {menuOpties[i]}  ");
                        Console.ResetColor();
                    }
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nGebruik <- en -> pijltjestoetsen om te navigeren, Enter om te kiezen.");
                Console.ResetColor();

                // Toetsinvoer verwerken
                ConsoleKeyInfo toets = Console.ReadKey(true);

                if (toets.Key == ConsoleKey.LeftArrow) {
                    geselecteerd = geselecteerd - 1;
                    if (geselecteerd < 0)
                        geselecteerd = menuOpties.Length - 1;
                } else if (toets.Key == ConsoleKey.RightArrow) {
                    geselecteerd = geselecteerd + 1;
                    if (geselecteerd >= menuOpties.Length)
                        geselecteerd = 0;
                } else if (toets.Key == ConsoleKey.Enter) {
                    if (menuOpties[geselecteerd] == "Toevoegen") {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=== Nieuw contact toevoegen ===\n");
                        Console.ResetColor();

                        Console.Write("Naam: ");
                        string invoerNaam = Console.ReadLine();
                        Console.Write("E-mail: ");
                        string invoerEmail = Console.ReadLine();
                        Console.Write("Telefoon: ");
                        string invoerTelefoon = Console.ReadLine();

                        if (invoerNaam != "" && invoerNaam != null) {
                            if (aantalContacten < 100) {
                                namen[aantalContacten] = invoerNaam;
                                emails[aantalContacten] = invoerEmail != null ? invoerEmail : "";
                                telefoons[aantalContacten] = invoerTelefoon != null ? invoerTelefoon : "";
                                aantalContacten = aantalContacten + 1;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nContact toegevoegd!");
                                Console.ResetColor();
                            } else {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nMaximum aantal contacten bereikt!");
                                Console.ResetColor();
                            }
                        } else {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNaam mag niet leeg zijn!");
                            Console.ResetColor();
                        }

                        Console.WriteLine("\nDruk op een toets om verder te gaan...");
                        Console.ReadKey(true);
                    } else if (menuOpties[geselecteerd] == "Verwijderen") {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Deze functionaliteit is nog niet beschikbaar.");
                        Console.ResetColor();
                        Console.WriteLine("\nDruk op een toets om verder te gaan...");
                        Console.ReadKey(true);
                    } else if (menuOpties[geselecteerd] == "Afsluiten") {
                        draait = false;
                        Console.Clear();
                        Console.WriteLine("Einde!");
                    }
                }
            }
        }
    }
}