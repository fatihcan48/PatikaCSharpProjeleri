using FibonacciSeries;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int [] fibo = Fibonacci.BuildFibo(4, 10);
            Fibonacci.AverageFibo(fibo);

            Console.ReadKey();  
        }
    }
}