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
        static bool[] jeLiElImInirAn;
        static int[] primovi;


        public static int[] GenerirajPrimBrojeve(int max)
        {
            if (max < 2)
                return new int[0]; 

            NapraviNizCijelihBrojeva(max);

            EliminirajVisekratnike();

            return PokupiPrimove();

        }

        private static int[] PokupiPrimove()
        {
            int broj = 0;
            for (int i = 0; i < s; ++i)
            {
                if (!jeLiElImInirAn[i])
                    ++broj;
            }

            primovi = new int[broj];

            for (int i = 0, j = 0; i < s; ++i)
            {
                if (!jeLiElImInirAn[i])
                    primovi[j++] = i;
            }
            return primovi;
        }

        private static void EliminirajVisekratnike()
        {
            for (int i = 2; i < Math.Sqrt(s) + 1; ++i)
            {
                if (!jeLiElImInirAn[i])
                {
                    EleminirajVesekratnikeOdBrojaN(i);
                }
            }
        }

        private static void EleminirajVesekratnikeOdBrojaN(int n)
        {
            for (int j = 2 * n; j < s; j += n)
                jeLiElImInirAn[j] = true;
        }

        private static void NapraviNizCijelihBrojeva(int max)
        {
            s = max + 1; 
            jeLiElImInirAn = new bool[s]; 

            for (int i = 0; i < s; ++i)
                jeLiElImInirAn[i] = false;

            jeLiElImInirAn[0] = jeLiElImInirAn[1] = true;
        }
    }
}
