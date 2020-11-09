using System;

namespace Vsite.Pood
{
    public class Program
    {
        static void Main(string[] args)
        {
            IspišiPrimbrojeve(0);
            Console.ReadKey();
            IspišiPrimbrojeve(1);
            Console.ReadKey();
            IspišiPrimbrojeve(2);
            Console.ReadKey();
            IspišiPrimbrojeve(100);
            Console.ReadKey();
        }

        static void IspišiPrimbrojeve(int max)
        {
            Console.WriteLine("Primbrojevi do {0}:", max);
            var brojevi = GenerirajPrimBrojeve(max);
            if (brojevi.Length == 0)
                Console.WriteLine("Nema");
            else
            {
                foreach (var broj in brojevi)
                    Console.WriteLine(broj);
            }
        }
        static int s;
        static bool[] f;
        static int[] primovi;

        // Primjer iz knjige  Robert C. Martin: "Agile Software Development"!!!
        public static int[] GenerirajPrimBrojeve(int max)
        {
            if (max < 2)
                return new int[0]; // vrati prazan niz

            NapraviNizCijelihBrojeva(max);

            EliminirajVišekratnike();

            return PokupiPrimove();
        }

        private static int[] PokupiPrimove()
        {
            // koliko je primbrojeva?
            int broj = 0;
            for (int i = 0; i < s; ++i)
            {
                if (f[i])
                    ++broj;
            }

            primovi = new int[broj];

            // prebaci primbrojeve u rezultat
            for (int i = 0, j = 0; i < s; ++i)
            {
                if (f[i])
                    primovi[j++] = i;
            }
            return primovi;
        }

        private static void EliminirajVišekratnike()
        {
            for (int i = 2; i < Math.Sqrt(s) + 1; ++i)
            {
                if (f[i]) // ako je i prekrižen, prekriži i višekratnike
                {
                    EliminirajVišekratnike(i);
                }
            }
        }

        private static void EliminirajVišekratnike(int i)
        {
            for (int j = 2 * i; j < s; j += i)
                f[j] = false; // višekratnik nije primbroj
        }

        private static void NapraviNizCijelihBrojeva(int max)
        {
            // deklaracije
            s = max + 1; // duljina niza
            f = new bool[s]; // niz s primbrojevima

            // inicijaliziramo sve na true
            for (int i = 0; i < s; ++i)
                f[i] = true;

            // ukloni 0 i 1 koji su primbrojevi po definiciji
            f[0] = f[1] = false;

            // sito (ide do kvadratnog korijena maksimalnog broja)
        }
    }
}
