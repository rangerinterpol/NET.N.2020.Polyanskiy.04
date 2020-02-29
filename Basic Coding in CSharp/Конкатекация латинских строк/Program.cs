namespace Конкатекация_латинских_строк
{
    using System;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private static void Main(string[] args)
        {
            const int N = 2; // Количество строк

            bool strIsWrong = false;

            string[] strArray = new string[N];
            string strConcat;

            Console.WriteLine("Введите последовательно две строки в латинском алфавите.\nСимволы могут повторяться.");

            Regex regexLatin = new Regex(@"[A-z]");

            for (int i = 0; i < N; i++)
            {
                // Возврат индекса для повторного ввода строки, если количество строк больше одной.
                if (strIsWrong == true)
                {
                    i--;
                    strIsWrong = false;
                }

                strArray[i] = Console.ReadLine();

                // Проверка на принадлежность латинскому алфавиту.
                Match matchLatin = regexLatin.Match(strArray[i]);

                if (matchLatin.Success == false)
                {
                    Console.WriteLine("Строка должна содержать только латинские символы.\nВведите новую строку.");
                    strIsWrong = true;
                }
            }

            strConcat = string.Concat(strArray);

            // Проверка на повторяющиеся символы. Повторяющимися будут считаться рядом стоящие, чтобы не скосить пол предложения.
            foreach (char ch in strConcat)
            {
                Regex regexRepeat = new Regex(@"" + $"{ch}" + "{2,}");
                Match matchRepeat = regexRepeat.Match(strConcat);

                if (matchRepeat.Success)
                {
                    strConcat = strConcat.Remove(matchRepeat.Index, matchRepeat.Value.Length);
                }
            }

            Console.WriteLine(strConcat);
            Console.ReadKey();
        }
    }
}
