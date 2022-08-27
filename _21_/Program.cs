/* See/*Имеется пустой участок земли (двумерный массив) 
и план сада, который необходимо реализовать. 
Эту задачу выполняют два садовника, которые 
не хотят встречаться друг с другом. Первый 
садовник начинает работу с верхнего левого угла 
сада и перемещается слева направо, сделав ряд,
он спускается вниз. Второй садовник начинает 
работу с нижнего правого угла сада и перемещается 
снизу вверх, сделав ряд, он перемещается влево. 
Если садовник видит, что участок сада уже выполнен 
другим садовником, он идет дальше. Садовники должны 
работать параллельно. Создать многопоточное приложение,
моделирующее работу садовников.*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21
{
    class Program
    {
        private static int[,] pole;
        private static int m;
        private static int n;

        static void Main()
        {
            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());
            pole = new int[n, m];
            Thread gardner1 = new Thread(sad1);
            Thread gardner2 = new Thread(sad2);
            gardner1.Start();
            gardner2.Start();
            gardner1.Join();
            gardner2.Join();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(pole[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        private static void sad1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (pole[i, j] == 0)
                        pole[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }
        private static void sad2()
        {
            for (int i = m - 1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    if (pole[j, i] == 0)
                        pole[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}