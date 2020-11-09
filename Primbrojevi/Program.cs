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
        static bool[] jeLiEliminiran;
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
                if (!jeLiEliminiran[i])
                    ++broj;
            }

            primovi = new int[broj];

            // prebaci primbrojeve u rezultat
            for (int i = 0, j = 0; i < s; ++i)
            {
                if (!jeLiEliminiran[i])
                    primovi[j++] = i;
            }
            return primovi; // vrati niz brojeva
        }

        private static void EliminirajVišekratnike()
        {
            // sito (ide do kvadratnog korijena maksimalnog broja)
            for (int i = 2; i < Math.Sqrt(s) + 1; ++i)
            {
                if (!jeLiEliminiran[i]) // ako je i prekrižen, prekriži i višekratnike
                {
                    EliminirajVišekratnike(i);
                }
            }
        }

        private static void EliminirajVišekratnike(int i)
        {
            for (int j = 2 * i; j < s; j += i)
                jeLiEliminiran[j] = true; // višekratnik nije primbroj
        }

        private static void NapraviNizCijelihBrojeva(int max)
        {
            s = max + 1; // duljina niza
            jeLiEliminiran = new bool[s]; // niz s primbrojevima

            // inicijaliziramo sve na false
            for (int i = 0; i < s; ++i)
                jeLiEliminiran[i] = false;

            // ukloni 0 i 1 koji su primbrojevi po definiciji
            jeLiEliminiran[0] = jeLiEliminiran[1] = true;
        }
    }
}
