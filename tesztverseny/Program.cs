using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tesztverseny
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. feladat: Az adatok beolvasása\n");
            string[] valaszok = File.ReadAllLines("valaszok.txt");
            List<diak> diakok = new List<diak>();
            char[] helyesValaszok = valaszok[0].ToCharArray();

            for(int i = 1; i < valaszok.Length; i++)
            {
                string[] sor = valaszok[i].Split(' ');
                diakok.Add(new diak(sor[0], sor[1]));
            }
            Console.WriteLine("2. feladat: A vetélkedőn " + (valaszok.Length - 1) + " versenyző indult.\n");

            Console.Write("3. feladat: A versenyző azonosítója = ");
            string azonosito = Console.ReadLine();
            string valasz = null;

            for(int i = 0; i < diakok.Count; i++)
            {
                if(azonosito == diakok[i].Azonosito)
                {
                    valasz = diakok[i].Valaszok;
                    Console.WriteLine(valasz + "\n");
                    break;
                }
            }

            string helyes = null;
            for(int i = 0; i < helyesValaszok.Length; i++)
            {
                if (helyesValaszok[i] == valasz.ElementAt(i))
                {
                    helyes += "+";
                }
                else
                {
                    helyes += " ";
                }
            }

            Console.WriteLine("4.feladat: ");
            Console.WriteLine(helyesValaszok.ToArray());
            Console.WriteLine(helyes + "\n");

            Console.Write("5. feladat: A feladat sorszáma = ");
            int sorszam = Convert.ToInt32(Console.ReadLine()) - 1;
            int jomegoldas = 0;
            for (int i = 0; i < diakok.Count; i++)
            {
                if (helyesValaszok[sorszam] == diakok[i].Valaszok.ElementAt(sorszam))
                {
                    jomegoldas++;
                }
            }
            double szazalek = ((double)jomegoldas / diakok.Count) * 100;
            Console.WriteLine("A feladadtra " + jomegoldas + " fő, a versenyzők " + Math.Round(szazalek, 2) + "%-a adott helyes választ.\n");

            Console.WriteLine("6. feladat: A versenyzők pontszámának meghatározása. \n");

            Dictionary<string, int> diakokEsPontszamaik = new Dictionary<string, int>();

            int j = 0;
            int pontszam = 0;
            using (StreamWriter sw = new StreamWriter("pontok.txt"))

            {
                for (int i = 0; i < diakok.Count;)
                {
                    if (helyesValaszok[j] == diakok[i].Valaszok.ElementAt(j))
                    {
                        if ((j + 1) <= 5)
                        {
                            pontszam += 3;
                        }
                        else if ((j + 1) <= 10)
                        {
                            pontszam += 4;
                        }
                        else if ((j + 1) <= 13)
                        {
                            pontszam += 5;
                        }
                        else
                        {
                            pontszam += 6;
                        }
                    }

                    if ((j + 1) % 14 == 0)
                    {
                        sw.WriteLine(diakok[i].Azonosito + " " + pontszam);
                        diakokEsPontszamaik.Add(diakok[i].Azonosito, pontszam);
                        i++;
                        j = 0;
                        pontszam = 0;
                    } else
                    {
                        j++;
                    }
                }
            }

            List<int> elso_harom = new List<int>();
            int helyezes = 0;
            foreach (var item in diakokEsPontszamaik.OrderByDescending(a => a.Value))
            {
                if (!elso_harom.Contains(item.Value))
                {
                    helyezes++;
                    elso_harom.Add(item.Value);
                }

                if (elso_harom.Count == 4)
                {
                    break;
                }

                Console.WriteLine($"{helyezes}. díj ({item.Value} pont): {item.Key}");
            }

        Console.ReadKey();
        }
    }
}
