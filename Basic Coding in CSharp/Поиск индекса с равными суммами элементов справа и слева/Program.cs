namespace Поиск_индекса_с_равными_суммами_элементов_справа_и_слева
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            float[] floatArray = new float[] { 1, 1, 1, 1, 26, 1, 2, 0, 1 };
            float leftsum = 0.0f, rightsum = 0.0f;

            int middleIndex = 0;

            Console.WriteLine("Целочисленный массив заполнен следующими числами:");

            for (int i = 0; i < floatArray.Length; i++)
            {
                if (i == floatArray.Length)
                {
                    Console.Write(floatArray[i]);
                }
                else
                {
                    Console.Write(floatArray[i] + " ");
                }
            }

            for (int i = 0; i < floatArray.Length; i++)
            {
                for (int j = 0; j < floatArray.Length; j++)
                {
                    if (j < i)
                    {
                        leftsum += floatArray[j];
                    }
                    else if (j > i)
                    {
                        rightsum += floatArray[j];
                    }
                }

                if (leftsum == rightsum)
                {
                    middleIndex = i;
                    break;
                }

                leftsum = 0;
                rightsum = 0;
            }

            if (middleIndex == 0)
            {
                middleIndex = -1;
            }
            else
            {
                Console.WriteLine($"\nИндекс с равными суммами слева и справа: {middleIndex}");
            }

            Console.ReadKey();
        }
    }
}
