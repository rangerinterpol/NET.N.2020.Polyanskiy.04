namespace Фильтрация_по_заданной_цифре
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] numbers = new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int[] resultNumbers;
            int filter = 7, numbersLength = 0;

            foreach (int num in numbers)
            {
                numbersLength++;
            }

            Console.WriteLine($"Входной массив целых чисел: ");

            for (int i = 0; i < numbersLength; i++)
            {
                if (i == numbersLength - 1)
                {
                    Console.WriteLine($"{numbers[i]}" + " }");
                }
                else if (i == 0)
                {
                    Console.Write("{ " + $"{numbers[i]}, ");
                }
                else
                {
                    Console.Write($"{numbers[i]}, ");
                }
            }

            Console.WriteLine($"Массив будет отфильтрован по цифре: {filter}");

            resultNumbers = FilterDigit(numbers, filter);
            int resultLength = 0;

            foreach (int num in resultNumbers)
            {
                resultLength++;
            }

            Console.WriteLine($"Выходной массив: ");

            for (int i = 0; i < resultLength; i++)
            {
                if (resultLength == 1)
                {
                    Console.Write("{ " + $"{resultNumbers[i]}" + " }");
                }
                else if (i == resultLength - 1)
                {
                    Console.Write($"{resultNumbers[i]}" + " }");
                }
                else if (i == 0)
                {
                    Console.Write("{ " + $"{resultNumbers[i]}, ");
                }
                else
                {
                    Console.Write($"{resultNumbers[i]}, ");
                }
            }

            Console.ReadKey();
        }

        /// <summary>Функция возвращает переданный массив, исключая элементы, не содержащие цифровой фильтр.</summary>
        /// <param name = "numbers">Тип - Int32[]. Массив целых чисел.</param>
        /// <param name = "filter">Тип - Int32. Цифра, содержащаяся в искомых элементах.</param>
        /// <returns>Тип - Int32[]. Массив целых чисел, содержащих цифровой фильтр.</returns>
        private static int[] FilterDigit(int[] numbers, int filter)
        {
            List<int> result = new List<int>();

            Regex regexNum = new Regex(@"[" + $"{filter}" + "]");

            int i = 0;
            foreach (int num in numbers)
            {
                if (regexNum.Match(num.ToString()).Success)
                {
                    result.Add(numbers[i]);
                }

                i++;
            }

            return result.ToArray();
        }
    }
}
