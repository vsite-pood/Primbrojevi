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

        

        // Primjer iz knjige  Robert C. Martin: "Agile Software Development"!!!
        public static int[] GenerirajPrimBrojeve(int max)
        {
            if (max < 2)
                return new int[0]; // vrati prazan niz

            // deklaracije
            var niz = NapraviNizCjelihBrojeva(max);

            // sito (ide do kvadratnog korijena maksimalnog broja)

            EliminirajVisekratnike(niz);

            // koliko je primbrojeva?
            return PokupiPrimove(niz);

        }

        private static int[] PokupiPrimove(bool[] jeliEliminiran)
        {
            int broj = 0;
            for (int i = 2; i < jeliEliminiran.Length; ++i)
            {
                if (!jeliEliminiran[i])
                    ++broj;
            }

            int[] primovi = new int[broj];

            // prebaci primbrojeve u rezultat
            for (int i = 2, j = 0; i < jeliEliminiran.Length; ++i)
            {
                if (!jeliEliminiran[i])
                    primovi[j++] = i;
            }
            return primovi; // vrati niz brojeva
        }

        private static void EliminirajVisekratnike(bool[] jeliEliminiran)
        {
            for (int i = 2; i < Math.Sqrt(jeliEliminiran.Length) + 1; ++i)
            {
                if (!jeliEliminiran[i]) // ako je i prekrižen, prekriži i višekratnike
                {
                    EliminirajVisekratnike(i); // višekratnik nije primbroj
                }
            }

            void EliminirajVisekratnike(int i)
            {
                for (int j = 2 * i; j < jeliEliminiran.Length; j += i)
                    jeliEliminiran[j] = true;
            }
        }

        private static bool[] NapraviNizCjelihBrojeva(int max)
        {
            return new bool[max+1]; // niz s primbrojevima
        }
    }
}
