namespace SekilselHesaplar
{
    public class Square : ICalculate
    {
        public void CalculateField()
        {
            Console.Write("Please write edge lenght of Square : ");
            var edge = double.Parse(Console.ReadLine());

            var field = edge * edge;
            Console.WriteLine("Field of shape : " + field);
        }

        public void CalculatePerimeter()
        {
            Console.Write("Please write edge lenght of Square : ");
            var edge = double.Parse(Console.ReadLine());

            var perimeter = 4 * edge ;
            Console.WriteLine("Perimeter of shape : " + perimeter);
        }

    }
}
