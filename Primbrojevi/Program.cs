using System;
using System.Linq.Expressions;

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
        static int[] primovi;

        // Primjer iz knjige  Robert C. Martin: "Agile Software Development"!!!
        public static int[] GenerirajPrimBrojeve(int max)
        {
            if (max < 2)
                return new int[0]; // vrati prazan niz

            var niz = NapraviNizCijelihBrojeva(max);
            EliminirajVišekratnike(niz);
            return PokupiPrimove(niz);

        }

        private static int[] PokupiPrimove(bool[] jeLiEliminiran)
        {
            // koliko je primbrojeva?
            int broj = 0;
            for (int i = 2; i < jeLiEliminiran.Length; ++i)
            {
                if (NijeEliminiran(i, jeLiEliminiran))
                    broj++;
            }

            primovi = new int[broj];

            // prebaci primbrojeve u rezultat
            for (int i = 2, j = 0; i < jeLiEliminiran.Length; ++i)
            {
                if (NijeEliminiran(i, jeLiEliminiran))
                    primovi[j++] = i;
            }
            return primovi; // vrati niz brojeva
        }

        private static bool NijeEliminiran(int i, bool[] jeLiEliminiran) {
            return jeLiEliminiran[i] == false;
        }

        private static void EliminirajVišekratnike(bool[] jeLiEliminiran)
        {
            // sito (ide do kvadratnog korijena maksimalnog broja)
            for (int i = 2; i < Math.Sqrt(jeLiEliminiran.Length) + 1; ++i)
            {
                if (NijeEliminiran(i, jeLiEliminiran)) // ako je i prekrižen, prekriži i višekratnike
                {
                    EliminirajVišekratnike(i, jeLiEliminiran);
                }
            }
        }

        private static void EliminirajVišekratnike(int i, bool[] jeLiEliminiran)
        {
            for (int j = 2 * i; j < jeLiEliminiran.Length; j += i)
                jeLiEliminiran[j] = true; // višekratnik nije primbroj
        }

        private static bool[] NapraviNizCijelihBrojeva(int max)
        {   
            return new bool[max + 1];
        }
    }
}
