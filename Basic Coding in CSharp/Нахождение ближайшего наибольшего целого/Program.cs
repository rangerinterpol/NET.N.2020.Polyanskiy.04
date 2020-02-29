namespace Нахождение_ближайшего_наибольшего_целого
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            uint number = 1234126;
            int result;

            Console.WriteLine($"Число на входе: {number}");

            result = FindNextBiggerNumber(number);

            Console.WriteLine($"Ближайшее наибольшее число: {result}");

            Console.ReadKey();
        }

        /// <summary>Функция получает и возвращает ближайшее наибольшее число из цифр числа, переданного на вход.</summary>
        /// <remarks>
        /// 1) Входной параметр number парсится в строку. Цифры заносятся в массив intArrayNumbers.
        /// 2) Вычисляются максимальное - intMaximum и минимальное - intMinimum возможные числа.
        /// 3) Генерируется последовательность чисел squares в диапазоне (intMaximum, intMinimum).
        /// 4) На основании intMaximum заполняется массив уникальных цифр listUnicPatternNumbers входной переменной number.
        /// 5) Выполняется перебор коллекции squares. Проверяется, содержатся ли в элементе все цифры из listUnicPatternNumbers.
        /// 6) Если условие выполнено, последнее число передается в выходной параметр intNextBiggerNumber.</remarks>
        /// <param name = "number">Тип - UInt32. Положительное целое число.</param>
        /// <returns>Тип - Int32. Целое число, либо -1 по умолчанию.</returns>
        private static int FindNextBiggerNumber(uint number)
        {
            bool isNumberTrue, numberIsFound = false;

            string strNumber = number.ToString(), strMaximum, strMinimum;

            List<string> pattern = new List<string>();

            List<char> listUnicPatternNumbers = new List<char>();

            List<int> listMaximum = new List<int>();

            int[] intArrayNumbers = new int[strNumber.Length];
            int symbolIndex = 0, tempMinimum, tempMaximum;

            int intMaximum, intMinimum, intNextBiggerNumber = -1;

            foreach (char symb in strNumber)
            {
                intArrayNumbers[symbolIndex] = symb - 48; // С 48-го по ASCII.
                symbolIndex++;
            }

            tempMaximum = intArrayNumbers[0];
            tempMinimum = intArrayNumbers[0];

            // Нахождение максимального числа из strNumber.
            for (int i = 0, indexSubtract = 0; i < intArrayNumbers.Length; i++)
            {
                if (i == 0)
                {
                    listMaximum.Insert(0, tempMaximum);
                }

                if (intArrayNumbers[i] > tempMaximum)
                {
                    tempMaximum = intArrayNumbers[i];
                    listMaximum.Insert(0, tempMaximum);
                }
                else if (intArrayNumbers[i] < tempMinimum)
                {
                    tempMinimum = intArrayNumbers[i];
                    listMaximum.Add(tempMinimum);
                }
                else if (i != 0)
                {
                    indexSubtract++;

                    listMaximum.Insert(i - indexSubtract, intArrayNumbers[i]);
                }
            }

            strMaximum = string.Join(string.Empty, listMaximum.ToArray());
            strMinimum = string.Join(string.Empty, strMaximum.Reverse().ToArray());

            intMaximum = Convert.ToInt32(strMaximum);
            intMinimum = Convert.ToInt32(strMinimum);

            // Генерируем последовательность int значений с минимального по максимальное возможное число.
            IEnumerable<int> squares = Enumerable.Range(intMinimum, intMaximum - intMinimum + 1);

            // Уникальная последовательность int значений для проверки на соответствие по цифрам.
            foreach (char ch in strMaximum)
            {
                if (!listUnicPatternNumbers.Contains(ch))
                {
                    listUnicPatternNumbers.Add(ch);
                }
            }

            // Перебор и проверка чисел в диапазоне от минимального к максимальному.
            foreach (int square in squares)
            {
                if (numberIsFound == true)
                {
                    break;
                }
                else if (square <= number)
                {
                    continue;
                }

                char[] tempsquare = square.ToString().ToArray();

                for (int i = 0; i < tempsquare.Length; i++)
                {
                    if (listUnicPatternNumbers.Contains(tempsquare[i]))
                    {
                        isNumberTrue = true;

                        // Искомое число найдено, когда каждый символ tempsquare содержится в listUnicPatternNumbers
                        if (i == tempsquare.Length - 1 && isNumberTrue == true)
                        {
                            intNextBiggerNumber = Convert.ToInt32(square);
                            numberIsFound = true;
                            break;
                        }
                    }
                    else
                    {
                        isNumberTrue = false;
                        break;
                    }
                }
            }

            return intNextBiggerNumber;
        }
    }
}