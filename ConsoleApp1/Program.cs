using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        struct jatekos
        {
            public int mez;
            public string nev;
            public string Nemzet;
            public string Poszt;
            public int szul;
            public int ev;
        }
        static List<jatekos> juventus;
        static void Main(string[] args)
        {

       

            Beolvas();
            F01();
            F02();
            F03();
            F04();
            F05();
            F06();
            F07();
            F08();
            BF();

            Console.ReadKey();
    }

        private static void BF()
        {
            Console.WriteLine("Adj meg egy mezszámot: ");
            int x = Convert.ToInt32(Console.ReadLine());
            foreach (var j in juventus)
            { 
            if(j.mez==x)
                {
                    Console.WriteLine(j.nev);
                }
            }
        }

        private static void F08()
        {
            var dic = new Dictionary<int, int>();
            foreach (var j in juventus)
            {
                if (!dic.ContainsKey(j.ev))
                    dic.Add(j.ev, 1);
                else dic[j.ev]++;
            }
            Console.WriteLine("3 db játékos: ");
            foreach (var kvp in dic)
            {
                if (kvp.Value ==3) Console.WriteLine(kvp.Key + ", ");
            }
            Console.WriteLine("\n");
        }

        private static void F07()
        {
            var lics = new jatekos() { ev = DateTime.Now.Year };
            foreach (var j in juventus)
            {
                if (j.Poszt == "csatár" && j.ev < lics.ev) lics = j;
            }
            Console.WriteLine($"A legöregebb csatár {lics.nev}");
        }
        private static void F06()
        {
            var dic = new Dictionary<string, int>();
            foreach (var j in juventus)
            {
                if (!dic.ContainsKey(j.Poszt))
                    dic.Add(j.Poszt, 1);
                else dic[j.Poszt]++;
            }
            foreach (var kvp in dic)
            {
                Console.WriteLine("{0, -10} {1}", kvp.Key, kvp.Value);
            }
        }
        private static void F05()
        {
            int sum = 0;
            foreach (var j in juventus)
            {
                sum += (DateTime.Now.Year - j.ev);
            }
            Console.WriteLine("átlagéletkor: {0} ", sum / (float)juventus.Count);
        }
        private static void F04()
        {
            int maxi = 0;
            for (int i = 1; i < juventus.Count; i++)
            {
                if (juventus[i].ev > juventus[maxi].ev) maxi = i;
            }
            Console.WriteLine($"a legfiatalabb játékos: {juventus[maxi].nev}");
        }
        private static void F03()
        {
            int db = 0;
            foreach (var j in juventus)
            {
                if (j.Nemzet == "olasz")
                {
                    db++;
                }
            }
            Console.WriteLine($"{db} db olasz játékos van");
        }
        private static void F02()
        {
            int i = 0;
            while (i < juventus.Count && juventus[i].Nemzet != "magyar")
            {
                i++;
            }
            if (i < juventus.Count) Console.WriteLine("van magyar játékos");
            else Console.WriteLine("Nincs Magyar játékos");

        }
        private static void F01()
        {
            Console.WriteLine($"igazolt játékosok száma: {juventus.Count}");
        }
        private static void Beolvas()
        {
            juventus = new List<jatekos>();
            var sr = new StreamReader(@"..\..\Res\juve.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                string[] darabok = sr.ReadLine().Split(';');
                juventus.Add(
                    new jatekos()
                    {
                        mez = int.Parse(darabok[0]),
                        nev = darabok[1],
                        Nemzet = darabok[2],
                        Poszt = darabok[3],
                        ev = int.Parse(darabok[4]),
                    });
            }
            sr.Close();
        }

    }
}
