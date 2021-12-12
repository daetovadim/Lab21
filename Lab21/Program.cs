using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21
{
    class Program
    {
        private static int gardenLength;
        private static int gardenWidth;
        static int[,] garden;

        public static void Gardener1()
        {
            for (int i = 0; i < gardenLength; i++)
            {
                for (int j = 0; j < gardenWidth; j++)
                {
                    if (garden[i, j] == 0)
                        garden[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }
        public static void Gardener2()
        {
            int k, l;
            for (int i = 0; i < gardenWidth; i++)
            {
                for (int j = 0; j < gardenLength; j++)
                {
                    k = gardenLength - j - 1;
                    l = gardenWidth - i - 1;
                    if (garden[k, l] == 0)
                        garden[k, l] = 2;
                    Thread.Sleep(1);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("\tРабота с потоками");
            try
            {
                Console.Write("\n Введите длину сада: ");
                gardenLength = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n Введите ширину сада: ");
                gardenWidth = Convert.ToInt32(Console.ReadLine());

                garden = new int[gardenLength, gardenWidth];

                ThreadStart threadStart1 = new ThreadStart(Gardener1);
                Thread myThread = new Thread(threadStart1);
                myThread.Start();

                Gardener2();

                Console.WriteLine();
                for (int i = 0; i < gardenLength; i++)
                {
                    for (int j = 0; j < gardenWidth; j++)
                    {
                        Console.Write(garden[i, j]);
                        Thread.Sleep(50);
                    }
                    Console.WriteLine();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\tВведите числовое значение!");
            }
            Console.ReadKey();
        }
    }
}
