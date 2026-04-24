namespace autokMozgatasa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. feladat
            List<string> sorok = new List<string>();
            StreamReader sr = new StreamReader("jeladas.txt");
            while (!sr.EndOfStream)
            {
                sorok.Add(sr.ReadLine());
            }
            sr.Close();

            //2. feladat
            Console.WriteLine("2. feladat");
            string utolsoSor = sorok[sorok.Count - 1];
            Console.WriteLine($"Az utolsó jeladás időpontja {utolsoSor.Split("\t")[1]}:{utolsoSor.Split("\t")[2]}, a jármű rendszáma {utolsoSor.Split("\t")[0]}");

            //3. feladat
            Console.WriteLine("3. feladat");
            string elsoRendszam = sorok[0].Split('\t')[0];
            Console.WriteLine($"Az első jármű: {elsoRendszam}");
            Console.Write("Jeladásainak időpontjai: ");
            foreach (var s in sorok)
            {
                string[] tomb = s.Split('\t');
                if (tomb[0] == elsoRendszam)
                {
                    Console.Write($"{tomb[1]}:{tomb[2]} ");
                }
            }
            Console.WriteLine();

            //4. feladat
            Console.WriteLine("4. feladat");
            Console.Write("Kérem, adja meg az órát: ");
            string beOra = Console.ReadLine();
            Console.Write("Kérem, adja meg a percet: ");
            string bePerc = Console.ReadLine();
            int db = 0;
            foreach (var sor in sorok)
            {
                string[] tomb = sor.Split('\t');
                if (tomb[1] == beOra && tomb[2] == bePerc)
                {
                    db++;
                }
            }
            Console.WriteLine($"A jeladások száma: {db}");


            //5. feladat
            Console.WriteLine("5. feladat");
            int max = 0;
            foreach (var sor in sorok)
            {
                string[] tomb = sor.Split('\t');
                int sebesseg = int.Parse(tomb[3]);
                if (sebesseg > max)
                {
                    max = sebesseg;
                }
            }

            Console.WriteLine($"A legnagyobb sebesség km/h: {max}");
            Console.Write("A járművek: ");

            foreach (var sor in sorok)
            {
                string[] tomb = sor.Split('\t');
                if (int.Parse(tomb[3]) == max)
                {
                    Console.Write(tomb[0] + " ");
                }
            }
            Console.WriteLine();

            //6. feladat
            Dictionary<string, string> elsoJelzes = new Dictionary<string, string>();
            Dictionary<string, string> utolsoJelzes = new Dictionary<string, string>();

            foreach (var sor in sorok)
            {
                string[] tomb = sor.Split('\t');
                string rendszam = tomb[0];
                string ido = $"{tomb[1]} {tomb[2]}";

                if (!elsoJelzes.ContainsKey(rendszam))
                {
                    elsoJelzes[rendszam] = ido;
                }
                utolsoJelzes[rendszam] = ido;
            }

            StreamWriter sw = new StreamWriter("ido.txt");
            foreach (var rendszam in elsoJelzes.Keys)
            {
                sw.WriteLine($"{rendszam} {elsoJelzes[rendszam]} {utolsoJelzes[rendszam]}");
            }
            sw.Close();
        }
    }
}
