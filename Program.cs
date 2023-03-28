using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Channels;

namespace DZ_CS_2
{
    internal class Program
    {
        static void Main()
        {
            //Ex1();
            Ex2();
            
        }
        static void FillAndPrint(int[] arrI, double[,] arrD)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter the " + (i + 1) + " element of array: ");
                arrI[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();

            //вывод одномерного массива 
            foreach (var item in arrI)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // одновременное заполнение и вывод двумерного массива
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Random obj = new();
                    arrD[i, j] = obj.Next(-100, 100) + obj.NextDouble();
                    arrD[i, j] = Math.Round(arrD[i, j], 3);
                    Console.Write(arrD[i, j] + "\t\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static double MaxElem(int[] arrI, double[,] arrD)
        {
            //поиск максимального элемента сначала в одномерном массиве
            double maxElem = 0;
            for (int i = 0; i < 4; i++)
            {
                if (maxElem <= arrI[i] || maxElem <= arrI[i + 1])
                    maxElem = Math.Max(arrI[i], arrI[i + 1]);
            }
            // а затем и в двумерном
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (maxElem <= arrD[i, j] || maxElem <= arrD[i + 1, j + 1])
                        maxElem = Math.Max(arrD[i, j], arrD[i + 1, j + 1]);
                }
            }
            return maxElem;
        }
        static double MinElem(int[] arrI, double[,] arrD)
        {
            //поиск минимального элемента сначала в одномерном массиве
            double minElem = 0;
            for (int i = 0; i < 4; i++)
            {
                if (minElem >= arrI[i] || minElem >= arrI[i + 1])
                    minElem = Math.Min(arrI[i], arrI[i + 1]);
            }
            // а затем и в двумерном
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (minElem >= arrD[i, j] || minElem >= arrD[i + 1, j + 1])
                        minElem = Math.Min(arrD[i, j], arrD[i + 1, j + 1]);
                }
            }
            return minElem;
        }
        static void SumAndMultipl(int[] arrI, double[,] arrD, ref double sum, ref double multipl)
        {
            foreach (var item in arrI) { sum += item; multipl *= item; }

            foreach (var item in arrD) { sum += item; multipl *= item; }
        }
        static void SumOddAndEven(int[] arrI, double[,] arrD, ref int sumEven, ref double sumOddCol)
        {
            // сумма всех чётных элементов массива А
            foreach (var item in arrI)
            {
                if (item % 2 == 0) sumEven += item;
            }
            // сумма элементов нечётных столбцов массива В

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j % 2 != 0) sumOddCol += arrD[i, j];
                }
            }
        }
        static void Ex1()
        {
            int[] arrI = new int[5];
            double[,] arrD = new double[3, 4];

            int sumEven = 0;
            double sum = 0;
            double sumOddCol = 0;
            double multipl = 1;
            //заполнение одномерного массива
            FillAndPrint(arrI, arrD);

            // максимальный элемент 
            Console.WriteLine("Max element of both arrays:\t" + MaxElem(arrI, arrD));

            // минимальный элемент
            Console.WriteLine("Min element of both arrays:\t" + MinElem(arrI, arrD));

            // сумма  и произведение всех элементов в обеих массивах
            SumAndMultipl(arrI, arrD, ref sum, ref multipl);
            Console.WriteLine("Sum of all elements:\t" + Math.Round(sum, 3));
            Console.WriteLine("Multiplication of all elements:\t" + multipl);

            // сумма всех чётных элементов массива А
            // сумма элементов нечётных столбцов массива В
            SumOddAndEven(arrI, arrD, ref sumEven, ref sumOddCol);
            Console.WriteLine("Summ of all even elements in array A:\t" + sumEven);
            Console.WriteLine("Summ of all elements in the all odd columns in array B:\t" + Math.Round(sumOddCol, 3));

        }
        static void Ex2()
        {
            int[,] arr = new int[5, 5];

            int maxElem = 0;
            int minElem = 0;
            int sum     = 0;
                        
            int iMax    = 0;
            int iMin    = 0;
                        
            int jMax    = 0;
            int jMin    = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Random obj = new Random();
                    arr[i, j] = obj.Next(-100, 100);
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (maxElem <= arr[i, j] || maxElem <= arr[i + 1, j + 1])
                    {
                        maxElem = Math.Max(arr[i, j], arr[i + 1, j + 1]);
                        iMax = i;
                        jMax = j;
                    }
                    if (minElem >= arr[i, j] || minElem >= arr[i + 1, j + 1])
                    {
                        minElem = Math.Min(arr[i, j], arr[i + 1, j + 1]);
                        iMin = i;
                        jMin = j;
                    }
                }
            }

            Console.WriteLine($"Max eleemnt:\t{maxElem}");
            Console.WriteLine($"Min element:\t{minElem}");
            Console.WriteLine();

            int iBeg = (iMin <= iMax) ? iMin : iMax;
            int jBeg = (jMin <= jMax) ? jMin : jMax;

            int iEnd = (iBeg == iMin) ? iMax : iMin;
            int jEnd = (jBeg == jMin) ? jMax : jMin;

            for (int i = iBeg; i <= iEnd; i++)
            {
                for (int j = jBeg; j <= jEnd; j++)
                {
                    sum += arr[i, j];
                }
            }
            Console.WriteLine($"Sum betweem max and min elements is:\t{sum}");

        }
    }
}
