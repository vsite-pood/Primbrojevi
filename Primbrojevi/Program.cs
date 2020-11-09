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

        static bool[] jeliEliminiran;
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
            for (int i = 2; i < jeliEliminiran.Length; ++i)
            {
                if (nijeEliminiran(i))
                    ++broj;
            }

            primovi = new int[broj];

            for (int i = 2, j = 0; i < jeliEliminiran.Length; ++i)
            {
                if (nijeEliminiran(i))
                    primovi[j++] = i;
            }
            return primovi;
        }

        private static void EliminirajVisekratnike()
        {
            for (int i = 2; i < Math.Sqrt(jeliEliminiran.Length) + 1; ++i)
            {
                if (nijeEliminiran(i))
                {
                    EleminirajVesekratnikeOdBrojaN(i);
                }
            }
        }

        private static bool nijeEliminiran(int i)
        {
            return jeliEliminiran[i] == false;
        }

        private static void EleminirajVesekratnikeOdBrojaN(int n)
        {
            for (int j = 2 * n; j < jeliEliminiran.Length; j += n)
                jeliEliminiran[j] = true;
        }

        private static void NapraviNizCijelihBrojeva(int max)
        {
            jeliEliminiran = new bool[max + 1]; 
        }
    }
}
