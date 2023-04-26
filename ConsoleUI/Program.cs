﻿using Algoritma;
using DrawCircle;
using DrawTriangle;
using FibonacciSeries;
using ReverseToText;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // FiboAverage();

            // Triangle.DrawTriangle(15);

            // Circle.DrawCircle(10);

            // AlgoritmaYap.RemoveByIndex();

            Reverse.ReverseAPattern();

        }

        private static void FiboAverage()
        {
            int[] fibo = Fibonacci.BuildFibo(4, 10);
            Fibonacci.AverageFibo(fibo);
        }
    }
}