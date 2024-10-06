using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingOptimalPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[,] horisontalCosts = new int[6,5]{ { 1, 4, 6, 9, 1 }, { 4, 4, 6, 7, 8 }, { 3, 5, 7, 9, 8 }, { 2, 3, 2, 5, 9 }, { 1, 5, 7, 8, 9 }, { 0, 8, 6, 9, 9 } };
            //int rowsSizeHor = horisontalCosts.GetLength(0);
            //int columnsSizeHor = horisontalCosts.GetLength(1);
            //for (int i = 0; i < rowsSizeHor; i++)
            //{
            //    for (int j = 0; j < columnsSizeHor; j++)
            //    {
            //        Console.Write(horisontalCosts[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.ReadKey();

            int[,] verticalCosts = new int[6,5]{ { 2, 2, 2, 3, 1 }, { 4,3,2,5,8}, {3,4,4,6,9}, { 2,5,5,7,8}, {1,2,4,6,7}, {9,1,3,6,8} };
            //int rowsSizeVer = verticalCosts.GetLength(0);
            //int columnsSizeVer = verticalCosts.GetLength(1);
            //for (int i = 0; i < rowsSizeVer; i++)
            //{
            //    for (int j = 0; j < columnsSizeVer; j++)
            //    {
            //        Console.Write(verticalCosts[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.ReadKey();

            //interimResults - это массив для результатов сложения кусков пути
            int[,]interimResults = new int[6,6];

            //colouredResults- это массив для выделения цветом
            int[,]colouredResults=new int[6,6];
            
            //установка условий
            interimResults[5, 5] = 0;

            //начальная точка участвует в пути поэтому ставим 1(1=раскраска)
            colouredResults[0, 0] = 1;
            //конечная точка участвует в пути поэтому ставим 1(раскраска)
            colouredResults[5, 5] = 1;
            Console.WriteLine("Найден оптимальный путь: \n");

            //рассчет 5-й строки (горизонтали) и 5-го столбца (вертикали) массива interimResults
            //(вынужденное решение)
            for (int i = 4;i >=0;i--)
            {
                interimResults[5,i]= interimResults[5, i + 1] + horisontalCosts[5, i];
                interimResults[i, 5] = interimResults[i + 1, 5] + verticalCosts[5, i];
            }

     
            //дальнейшее заполнение массива interimResults(оптимальное решение)
            //внешний цикл по строкам
            for (int i = 4; i >= 0; i--)
            {
                //внутренний цикл по столбцам
                for (int j = 4; j >= 0; j--)
                {
                    int sum1 = interimResults[i + 1, j] + verticalCosts[j, i]; 
                    int sum2 = interimResults[i, j + 1] + horisontalCosts[i,j];
                    if(sum1 < sum2)
                    {
                        interimResults[i, j] = sum1;
                       
                    }
                    else
                    {
                        interimResults[i, j] = sum2;
                      
                    }
                }
            }
            //i1 и j1 нужны для запоминания пути 
            //задаем начальные значения i1=0 и j1=0
            int i1 = 0, j1 = 0;
            //отметить единицами те значения в массиве interimResults, к-е будем раскрашивать
            
            
            while ((j1 != 5) && (i1 != 5))
            {
                
                int sum1 = interimResults[i1 + 1, j1] + verticalCosts[j1, i1];
                int sum2 = interimResults[i1, j1 + 1] + horisontalCosts[i1, j1];
                if (interimResults[i1, j1] == sum1) i1++;
                else j1++;
                colouredResults[i1, j1] = 1;
            }
            //выделение цветом необходимого пути
            for (int i = 5; i >= 0; i--)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (colouredResults[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write("{0,5}", interimResults[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

            //вывод массива без окрашивания
            for (int i = 5; i>=0; i--)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write("{0,5}",interimResults[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }

    }
}
