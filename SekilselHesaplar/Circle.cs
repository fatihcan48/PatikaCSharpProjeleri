using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekilselHesaplar
{
    public class Circle : ICalculate
    {
        private double pi = 3.14159;
        public void CalculateField()
        {
            Console.Write("Please write radius of Circle : ");
            var radius = double.Parse(Console.ReadLine());

            var field = pi*radius*radius;
            Console.WriteLine("Field of shape : {0:.00}" ,field);
        }

        public void CalculatePerimeter()
        {
            Console.Write("Please write radius of Circle : ");
            var radius = double.Parse(Console.ReadLine());

            var perimeter = 2*pi*radius;
            Console.WriteLine("Perimeter of shape : {0:.00}" ,perimeter);
        }

    }
}
