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
    }
}