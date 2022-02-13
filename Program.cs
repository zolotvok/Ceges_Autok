using System;
using System.IO;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = File.ReadAllLines(@"C:\Users\Jack Mehof\Downloads\e_inffor_19maj_fl\Forrasok\4_Ceges_autok/autok.txt");
            int[] nap = new int[s.Length];
            string[] óra = new string[s.Length];
            string[] rendszam = new string[s.Length];
            int[] id = new int[s.Length];
            int[] km = new int[s.Length];
            int[] kibe = new int[s.Length];
            string[] sor;
            for(int i = 0; i < s.Length; i++)
            {
                sor = s[i].Split(" ");
                nap[i] = int.Parse(sor[0]);
                óra[i] = sor[1];
                rendszam[i] = sor[2];
                id[i] = int.Parse(sor[3]);
                km[i] = int.Parse(sor[4]);
                kibe[i] = int.Parse(sor[5]);
            }
            int max = 0;
            for (int i = 0; i < rendszam.Length;i++) {
                if (kibe[i] == 0)
                {
                    if (nap[i] > max) { max = nap[i]; }
                }
            }
            for (int i = 0; i < rendszam.Length; i++)
            {
                if (kibe[i] == 0)
                {
                    if (nap[i] == max) { Console.WriteLine("2.feladat");
                        Console.WriteLine("{0}. nap rendszám: {1}", nap[i], rendszam[i]) ; 
                            
                    }
                }
            }
            Console.WriteLine("3. feladat");
            Console.Write("Nap: ");
            int inp = int.Parse(Console.ReadLine());
            string asd = "";
            Console.WriteLine("Forgalom a(z) {0}. napon:", inp);
            for (int i = 0; i < rendszam.Length; i++) { 
            if (inp == nap[i])
                {
                    if (kibe[i]==0) {  asd = "ki"; }
                    else { asd = "be"; }
                    Console.WriteLine(óra[i] + " " + rendszam[i] + " " + id[i] + " " + asd);
                }
            }

            string rn = "";
            int bent = 0;
            int összkm=0;
            HashSet<string> rnsz = new HashSet<string>(rendszam);

            foreach (var alma in rnsz)
            {
                rn = alma;
               
                for (int x = 0; x < rendszam.Length; x++)
                {
                    if (rn == rendszam[x])
                    {
                        if (kibe[x] == 0) { bent++;  }
                        if (kibe[x] == 1) { bent = bent - 1; ; }
                        
                    }
                }

            }
            int kzd = 0;
            int lm = 0;
            int mkm = 0;
            Console.WriteLine("4. feladat");
            Console.WriteLine("A hónap végén {0} autót nem hoztak vissza",bent);
            Console.WriteLine("5. feladat");
            foreach (var item in rnsz)
            {
                kzd = 0;
                lm = 0;
                mkm = 0;
                for (int i = 0; i < rendszam.Length; i++)
                {
                    if (item == rendszam[i])
                    {
                        if (kzd == 0)
                        {
                            kzd = km[i];
                        }
                        lm = i;
                    }
                }
               
                mkm = km[lm] - kzd;
                Console.WriteLine(item + " " + mkm + " km");
            }

            int ki = 0;
            mkm = 0;
            kzd = 0;
            foreach (var item in rnsz)
            {
                for (int i = 0; i < rendszam.Length; i++)
                {
                    if (item == rendszam[i])
                    {
                        if (kibe[i] == 0)
                        {
                            ki = id[i];
                            kzd = km[i];
                        }
                        else
                        {
                            if (( km[i]-kzd) > mkm)
                            {
                                mkm = km[i]-kzd;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("6. feladat");
            Console.WriteLine("Leghosszabb út: {0} km, személy: {1}",mkm,ki);
            Console.WriteLine("7. feladat");
            Console.Write("Rendszám: ");
            string nip = Console.ReadLine();
            Console.WriteLine("Menetlevél kész.");
            string final = "";

            for (int i = 0; i < rendszam.Length; i++)
            {
                if (rendszam[i] == nip)
                {
                    if (kibe[i] == 0)
                    {
                        final += id[i] + "\t" + nap[i] + "\t" + óra[i] + "\t" + km[i]+" km" + "\t";
                    }
                    else
                    {
                        final += nap[i] + "\t" + óra[i] + "\t" + km[i]+" km"+"\r\n";
                    }    
                }
            }
            string filepath = @"C:\Users\Jack Mehof\Downloads\e_inffor_19maj_fl\Forrasok\4_Ceges_autok/" + nip + "_menetlevel.txt";
            string[] finals = final.Split("\r\n");
            File.WriteAllLines(filepath ,finals);
        }
    }
}
