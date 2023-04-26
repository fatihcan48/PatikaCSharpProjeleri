namespace Algoritma
{
    public static class AlgoritmaYap
    {
        public static void RemoveByIndex()
        {
            Console.WriteLine("Lütfen bir metin ifadesi ve silinmesini" +
                " istediğiniz index numarasını giriniz (örn; 'algoritma,5' vs. ) : ");

            string pattern = Console.ReadLine();

            var array = pattern.Split(',');

            for (int i = 0; i < array.Length; i=i+2)
            {
                var metin = array[i];

                string removedPattern = metin.Remove(int.Parse(array[i+1]), 1);

                Console.WriteLine("{0}. index de bulunan karakter silinmiştir : {1}",
                    array[i+1], removedPattern);
            }
            
           
        }

    }
}