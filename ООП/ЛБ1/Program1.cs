using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Эта программа вычисляет расстояние между двумя точками");
            Console.Write("Введите значение х1: ");
                double x1 = double.Parse(Console.ReadLine());
            Console.Write("Введите значение y1: ");
                double y1 = double.Parse(Console.ReadLine());
            Console.Write("Введите значение х2: ");
                double x2 = double.Parse(Console.ReadLine());
            Console.Write("Введите значение y2: ");
                double y2 = double.Parse(Console.ReadLine());
                double Distance = Math.Sqrt((x2-x1)*(x2-x1)+(y2-y1)*(y2-y1));
                Console.Write("Расстояние между точками с заданными координатами = ");
                String distance = string.Format("{0:f3}", Distance);
                Console.WriteLine(distance);
                Console.ReadKey();

        }
    }
}
