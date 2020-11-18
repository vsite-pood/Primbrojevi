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

        public static int[] GenerirajPrimBrojeve(int max)
        {
            if (max < 2)
                return new int[0]; 

            var niz = NapraviNizCijelihBrojeva(max);

            EliminirajVisekratnike(niz);

            return PokupiPrimove(niz);

        }

        private static int[] PokupiPrimove(bool[] jeLiEliminiran)
        {
            int broj = 0;
            for (int i = 2; i < jeLiEliminiran.Length; ++i)
            {
                if (nijeEliminiran(i, jeLiEliminiran))
                    ++broj;
            }

            int[] primovi = new int[broj];

            for (int i = 2, j = 0; i < jeLiEliminiran.Length; ++i)
            {
                if (nijeEliminiran(i, jeLiEliminiran))
                    primovi[j++] = i;
            }
            return primovi;
        }

        private static void EliminirajVisekratnike(bool[] jeLiEliminiran)
        {
            for (int i = 2; i < Math.Sqrt(jeLiEliminiran.Length) + 1; ++i)
            {
                if (nijeEliminiran(i, jeLiEliminiran))
                {
                    EleminirajVesekratnikeOdBrojaN(i, jeLiEliminiran);
                }
            }
        }

        private static bool nijeEliminiran(int i, bool[] jeLiEliminiran)
        {
            return jeLiEliminiran[i] == false;
        }

        private static void EleminirajVesekratnikeOdBrojaN(int n, bool[] jeLiEliminiran)
        {
            for (int j = 2 * n; j < jeLiEliminiran.Length; j += n)
                jeLiEliminiran[j] = true;
        }

        private static bool[] NapraviNizCijelihBrojeva(int max)
        {
            return new bool[max + 1]; 
        }
    }
}
