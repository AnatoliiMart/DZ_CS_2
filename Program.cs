using System.Threading.Channels;

namespace DZ_CS_2
{
    internal class Program
    {
        static void Main()
        {
            Ex1();
        }
        static void FillAndPrint (int[] arrI, double[,] arrD)
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
        static double MaxElem    (int[] arrI, double[,]arrD)
        {
            //поиск максимального элемента сначала в одномерном массиве
            double maxElem = 0;
            for (int i = 0; i < 4; i++)
            {
                int tmp = arrI[i];
                if (maxElem <= tmp || maxElem <= arrI[i + 1])
                    maxElem = Math.Max(arrI[i], arrI[i + 1]);

            }
            // а затем и в двумерном
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    double tmp = arrD[i, j];
                    if (maxElem <= tmp || maxElem <= arrD[i + 1, j + 1])
                        maxElem = Math.Max(arrD[i, j], arrD[i + 1, j + 1]);
                }
            }
            return maxElem;
        }
        static double MinElem    (int[] arrI, double[,] arrD)
        {
            //поиск минимального элемента сначала в одномерном массиве
            double minElem = 0;
            for (int i = 0; i < 4; i++)
            {
                int tmp = arrI[i];

                if (minElem >= tmp || minElem >= arrI[i + 1]) 
                    minElem = Math.Min(arrI[i], arrI[i + 1]);
            }
            // а затем и в двумерном
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    double tmp = arrD[i, j];

                    if (minElem >= tmp || minElem >= arrD[i + 1, j + 1])
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
    }
}