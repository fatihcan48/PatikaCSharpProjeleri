using Algoritma;
using DrawCircle;
using DrawTriangle;
using FibonacciSeries;
using NumberPair;
using ReverseToText;
using SekilselHesaplar;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            // FiboAverage();
            // Triangle.DrawTriangle(15);
            // Circle.DrawCircle(10);
            // AlgoritmaYap.RemoveByIndex();
            // Reverse.ReverseAPattern();
            // CalcSelection();
            // Numbers.NumberPairs();
            // Numbers.NumberAbsAndPow();
            // AlgoritmaYap.ChangeFirstAndLastChars();
            // AlgoritmaYap.YanyanaOlanSessizHarfleriBul();

        }

        
        private static void CalcSelection()
        {
            Console.Write("Please write name of shape for calculation : ");
            string shape = Console.ReadLine();
            Console.Write("Please write calculation type : ");
            string calcType = Console.ReadLine();
            Console.WriteLine("**********************************************");

            var calcApp = GetShapeType(shape);

            ICalculate calculate = calcApp;

            if (calcType == "field")
                calculate.CalculateField();
            else if (calcType == "perimeter")
                calculate.CalculatePerimeter();
            else
                Console.WriteLine("Please enter a valid type!");
        }
        private static ICalculate GetShapeType(string shape)
        {
            switch (shape)
            {
                case "rectangle":
                    return new Rectangle();
                case "square":
                    return new Square();
                case "circle":
                    return new Circle();
                default: 
                    throw new Exception("Please enter a valid shape name");
            }
        }

        private static void FiboAverage()
        {
            int[] fibo = Fibonacci.BuildFibo(4, 10);
            Fibonacci.AverageFibo(fibo);
        }
    }
}