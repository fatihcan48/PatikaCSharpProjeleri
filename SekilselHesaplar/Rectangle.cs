using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekilselHesaplar
{

    public class Rectangle : ICalculate
    {
        public void CalculateField()
        {
            Console.Write("Please write long edge lenght of rectangle : ");
            var longEdge = double.Parse(Console.ReadLine());

            Console.Write("Please write short edge lenght of rectangle : ");
            var shortEdge = double.Parse(Console.ReadLine());

            var field = longEdge * shortEdge;
            Console.WriteLine("Field of shape : " + field);
        }

        public void CalculatePerimeter()
        {
            Console.Write("Please write long edge lenght of rectangle : ");
            var longEdge = double.Parse(Console.ReadLine());

            Console.Write("Please write short edge lenght of rectangle : ");
            var shortEdge = double.Parse(Console.ReadLine());

            var perimeter = 2 * (longEdge + shortEdge);
            Console.WriteLine("Perimeter of shape : " + perimeter);
        }

    }
}
