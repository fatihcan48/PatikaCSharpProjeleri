namespace NumberPair
{
    public static class Numbers
    {
        public static void NumberPairs()
        {
            Console.Write("Please enter number pairs : ");
            string numbers = Console.ReadLine();

            string[] arrayNumbers = numbers.Split(' ');

            List<string> result = new List<string>();

            for (int i = 0; i < arrayNumbers.Length; i = i + 2)
            {
                if (string.Equals(arrayNumbers[i], arrayNumbers[i + 1]))
                {
                    string member = (Math.Pow((int.Parse(arrayNumbers[i]) +
                        int.Parse(arrayNumbers[i + 1])), 2)).ToString();
                    result.Add(member);
                }
                else
                {
                    string member = (int.Parse(arrayNumbers[i]) +
                        int.Parse(arrayNumbers[i + 1])).ToString();
                    result.Add(member);
                }
            }

            Console.Write("Output : ");
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }

        public static void NumberAbsAndPow()
        {
            Console.Write("Please enter numbers between 0 and 100 : ");
            string input = Console.ReadLine();

            string[] numberArray = input.Split(" ");
            double smallerSum = 0;
            double biggerSum = 0;

            foreach (var item in numberArray)
            {
                if (int.Parse(item) <= 67)
                {
                    int number = 67 - int.Parse(item);
                    smallerSum = smallerSum + number;
                }
                else
                {
                    int absNumber = Math.Abs(67 - int.Parse(item));
                    double number = Math.Pow(absNumber, 2);
                    biggerSum += number;
                }
            }

            Console.Write("Output : {0} {1}", smallerSum, biggerSum);
        }
    }
}