using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSeries
{
    public static class Fibonacci
    {
        public static int[] BuildFibo(int sayi1, int derinlik)
        {

            int[] f = new int[derinlik];
      
            f[0] = sayi1;
            f[1] = f[0];

            for (int i = 2; i < derinlik; i++)
            {
                f[i] = f[i - 1] + f[i - 2];
            }

            return f;

        }

        public static void AverageFibo(int[] fibo)
        {
            int sum = 0;    

            for (int i = 0; i < fibo.Length; i++)
            {
                sum = sum + fibo[i];
            }

            double average = sum/fibo.Length;

            Console.WriteLine("Vermiş oladuğunuz fibonacci serisinin ortalaması: {0}", average);
        }
    }
}
