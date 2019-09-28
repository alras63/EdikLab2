using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdikLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[,] Matrix;
            int N = 0;
            {
                Console.WriteLine("Введите размерность");
                N = int.Parse(Console.ReadLine());
            }

            //заполняем матрицу случайными числами
            Matrix = new int[N, N];
            bool[] Negative = new bool[N];

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < N; j++)
                {
                    Matrix[i, j] = rnd.Next(-50, 50);
                    if (Matrix[i, j] < 0)
                    {
                        Negative[i] = true;
                    }

                    Console.Write("{0}\t", Matrix[i, j]);
                }
            }
           
            int[] sum = new int[N];
            for (int i = 0; i < N; i++)
            {
                if (Negative[i] == false)
                {
                    for (int j = 0; j < N; j++)
                    {
                        sum[i] += Matrix[i, j];
                    }
                }
            }
            foreach (int element in sum)
            {
                Console.WriteLine(element);
            }

            //Считаем диагонали НАД
            int step = 1;
            int[] summa = new int[N * 2 -2];
            while (step < N )
            {
                for (int i = 0; i < N; i++)
                {

                    for (int j = i + step; j < N; j++)
                    {
                        if (j == i + step)
                        {
                            summa[step-1] += Matrix[i, j];
                        }
                    }

                }
             

                step++;
            }

            //Считаем диагонали ПОД 

            int step2 =  1;
         
            while (step2 < N)
            {
                for (int i = step2; i <N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                     
                        if (j == i - step2)
                        {
                            summa[N*2 - 2 - step2] += Matrix[i, j];

                        }
                    }

                }
              

                step2++;
            }

            //Выведем суммы
            Console.WriteLine("Получившиеся суммы для каждой диагонали (ОНИ НЕ ОТСОРТИРОВАНЫ, ВПЕРЕМЕШКУ!)");
            foreach(int element in summa)
            {
                Console.WriteLine("Сумма одной из диагоналей: {0}", element);
            }

            //Отсортируем массив

            Array.Sort(summa);
            //Выведем отсортированные
            Console.WriteLine("Получившиеся суммы для каждой диагонали (ОНИ ОТСОРТИРОВАНЫ!)");
            foreach (int element in summa)
            {
                Console.WriteLine("Сумма одной из диагоналей: {0}", element);
            }

            //Выведем минимальный элемент
            Console.WriteLine("МИНИМУМ СРЕДИ СУММЫ ЭЛЕМЕНТОВ ДИАГОНАЛИ, ПАРАЛЛЕЛЬНЫХ ГЛАВНОЙ ДИАГОНАЛИ: {0}", summa[0]);

            Console.ReadLine();
        }

    }
}
