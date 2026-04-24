namespace beleptetoRendszer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sorok = new List<string>();
            StreamReader sr = new StreamReader("bedat.txt");
            while (!sr.EndOfStream)
            {
                sorok.Add(sr.ReadLine());
            }
            sr.Close();

            //2. feladat
            Console.WriteLine("2. feladat");
            Console.WriteLine($"Az első tanuló {sorok[0].Split(" ")[1]}-kor lépett be a főkapun.");
            Console.WriteLine($"Az utolsó tanuló {sorok[sorok.Count - 1].Split(" ")[1]}-kor lépett ki a főkapun.");

            // 3. feladat
            List<string> kesok = new List<string>();
            foreach (var sor in sorok)
            {
                if (sor.Split(" ")[2] == "1")
                {
                    string ora = sor.Split(" ")[1].Split(':')[0];
                    int perc = int.Parse(sor.Split(" ")[1].Split(':')[1]);

                    if (ora == "07" && perc > 50)
                    {
                        kesok.Add($"{sor.Split(" ")[1]} {sor.Split(" ")[0]}");
                    }
                    else if (ora == "08" && perc <= 15)
                    {
                        kesok.Add($"{sor.Split(" ")[1]} {sor.Split(" ")[0]}");
                    }
                }
            }
            StreamWriter sw = new StreamWriter("kesok.txt");
            foreach (var k in kesok)
            {
                sw.WriteLine(k);
            }
            sw.Close();


            //4. feladat
            List<string> menzasok = new List<string>();
            foreach (var sor in sorok)
            {
                if (sor.Split(" ")[2] == "3")
                {
                    if (!menzasok.Contains(sor.Split(" ")[0]))
                    {
                        menzasok.Add(sor.Split(" ")[0]);
                    }
                }
            }
            Console.WriteLine("4. feladat");
            Console.WriteLine($"A menzán aznap {menzasok.Count} tanuló ebédelt.");

            //5. feladat
            List<string> konyvtarosok = new List<string>();
            foreach (var sor in sorok)
            {
                if (sor.Split(" ")[2] == "4")
                {
                    if (!konyvtarosok.Contains(sor.Split(" ")[0]))
                    {
                        konyvtarosok.Add(sor.Split(" ")[0]);
                    }
                }
            }

            Console.WriteLine("5. feladat");
            Console.WriteLine($"Aznap {konyvtarosok.Count} tanuló kölcsönzött a könyvtárban.");

            if (konyvtarosok.Count > menzasok.Count)
            {
                Console.WriteLine("Többen voltak, mint a menzán.");
            }
            else
            {
                Console.WriteLine("Nem voltak többen, mint a menzán.");
            }

            //6. feladat
            List<string> kimentek = new List<string>();
            List<string> erintettek = new List<string>();

            foreach (var sor in sorok)
            {
                if (sor.Split(" ")[2] == "2" && int.Parse(sor.Split(" ")[1].Split(':')[0]) == 10 && int.Parse(sor.Split(" ")[1].Split(':')[1]) >= 45)
                {
                    kimentek.Add(sor.Split(" ")[0]);
                }
            }

            foreach (var sor in sorok)
            {
                if (sor.Split(" ")[2] == "1" && int.Parse(sor.Split(" ")[1].Split(':')[0]) == 10 && int.Parse(sor.Split(" ")[1].Split(':')[1]) >= 50)
                {
                    if (kimentek.Contains(sor.Split(" ")[0]) && !erintettek.Contains(sor.Split(" ")[0]))
                    {
                        erintettek.Add(sor.Split(" ")[0]);
                    }
                }
            }

            Console.WriteLine("6. feladat");
            Console.WriteLine("Az érintett tanulók:");
            Console.WriteLine(string.Join(" ", erintettek));

            // 7. feladat
            Console.WriteLine("7. feladat");
            Console.Write("Egy tanuló azonosítója=");
            string bekertId = Console.ReadLine();

            string elso = "";
            string utolso = "";
            foreach (var sor in sorok)
            {
                if (sor.StartsWith(bekertId + " "))
                {
                    string ido = sor.Split(" ")[1];
                    if (elso == "")
                    {
                        elso = ido;
                    }
                    utolso = ido;
                }
            }

            if (elso == "")
            {
                Console.WriteLine("Ilyen azonosítójú tanuló aznap nem volt az iskolában.");
            }
            else
            {
                TimeSpan tav = DateTime.Parse(utolso) - DateTime.Parse(elso);
                Console.WriteLine($"A tanuló érkezése és távozása között {tav.Hours} óra {tav.Minutes} perc telt el.");
            }

        }
    }
}
