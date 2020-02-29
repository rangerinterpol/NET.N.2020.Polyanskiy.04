namespace Рекурсивный_поиск_максимального_элемента
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] intArray = new int[] { 1, 52, 41, 6, 26, 12, 105, 98, 100 };
            int max = intArray[0];

            Console.WriteLine("Целочисленный массив заполнен следующими числами:");

            for (int i = 0; i < intArray.Length; i++)
            {
                if (i == intArray.Length)
                {
                    Console.Write(intArray[i]);
                }
                else
                {
                    Console.Write(intArray[i] + " ");
                }
            }

            for (int i = 0; i < intArray.Length; i++)
            {
                if (max == intArray[0] || intArray[i] > max)
                {
                    max = intArray[i];
                }
            }

            Console.WriteLine("\nМаксимальное число: " + max);
            Console.ReadKey();
        }
    }
}
