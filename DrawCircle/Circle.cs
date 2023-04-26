namespace DrawCircle
{
    public static class Circle
    {
        public static void DrawCircle(int radius)
        {

            for (double y = -radius; y <= radius; y++)
            {
                for (double x = -radius; x <= radius; x += 0.5)
                {
                    if ((x * x) + (y * y) >= radius * radius)
                        Console.Write("*");

                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

        }

    }
}