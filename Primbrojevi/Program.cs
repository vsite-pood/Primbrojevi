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

        public static int[] GenerirajPrimBrojeve(int max)
        {
            if (max < 2)
                return new int[0]; 

            NapraviSitho(max);

            Prosijaj();

            return PokupiPrimove();

        }

        private static int[] PokupiPrimove()
        {
            int broj = 0;
            for (int i = 0; i < s; ++i)
            {
                if (f[i])
                    ++broj;
            }

            primovi = new int[broj];

            for (int i = 0, j = 0; i < s; ++i)
            {
                if (f[i])
                    primovi[j++] = i;
            }
            return primovi;
        }

        private static void Prosijaj()
        {
            for (int i = 2; i < Math.Sqrt(s) + 1; ++i)
            {
                if (f[i]) 
                {
                    for (int j = 2 * i; j < s; j += i)
                        f[j] = false; 
                }
            }
        }

        private static void NapraviSitho(int max)
        {
            s = max + 1; 
            f = new bool[s]; 
            int i;

            for (i = 0; i < s; ++i)
                f[i] = true;

            f[0] = f[1] = false;
        }
    }
}
