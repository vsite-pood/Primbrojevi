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
        //static bool[] jeliEliminiran;
        //static int[] primovi;

        // Primjer iz knjige  Robert C. Martin: "Agile Software Development"!!!
        public static int[] GenerirajPrimBrojeve(int max)
        {
            if (max < 2)
                return new int[0]; // vrati prazan niz

            var niz = NapraviNizCijelihBrojeva(max);

            EliminirajVišekratnike(niz);

            return PokupiPrimove(niz);
        }

        private static int[] PokupiPrimove(bool[] jeliEliminiran)
        {
            // koliko je primbrojeva?
            int broj = 0;
            for (int i = 2; i < jeliEliminiran.Length; ++i)
            {
                if (NijeEliminiran(i, jeliEliminiran))
                    ++broj;
            }

            int[] primovi = new int[broj];

            // prebaci primbrojeve u rezultat
            for (int i = 2, j = 0; i < jeliEliminiran.Length; ++i)
            {
                if (NijeEliminiran(i, jeliEliminiran))
                    primovi[j++] = i;
            }
            return primovi;
        }

        private static void EliminirajVišekratnike(bool[] jeliEliminiran)
        {
            for (int i = 2; i < Math.Sqrt(jeliEliminiran.Length) + 1; ++i)
            {
                if (NijeEliminiran(i, jeliEliminiran)) // ako je i prekrižen, prekriži i višekratnike
                {
                    EliminirajVišekratnike(i, jeliEliminiran);
                }
            }
        }

        private static bool NijeEliminiran(int i, bool[] jeliEliminiran)
        {
            return jeliEliminiran[i] == false;
        }

        private static void EliminirajVišekratnike(int i, bool[] jeliEliminiran)
        {
            for (int j = 2 * i; j < jeliEliminiran.Length; j += i)
                jeliEliminiran[j] = true; // višekratnik nije primbroj
        }

        private static bool[] NapraviNizCijelihBrojeva(int max)
        {
            return new bool[max + 1]; // niz s primbrojevima
        }
    }
}
