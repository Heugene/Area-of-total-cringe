using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CompArray
{
    class TaskArray {
        int[] mas;
        int ml;

        public TaskArray() {
            Console.WriteLine("Введите количество элементов массива");
            ml = int.Parse(Console.ReadLine());
            mas = new int[ml];
        }

            public void RFill()
            {
                Random R = new Random();
                Console.WriteLine("Заполнение случайными числами");
                for (int i = 0; i <= ml - 1; i++)
                {
                    mas[i] = R.Next(-100, 100);
                }
            }
            
            public void Kfill()
            {
                Console.WriteLine("Заполнение с клавиатуры");
                for (int i = 0; i <= ml - 1; i++) {
                    Console.WriteLine("Введите " + (i+1) + " элемент массива");
                    mas[i] = int.Parse(Console.ReadLine());
                }
            }

            public void FFill()
            {
                Console.WriteLine("Заполнение данными из файла");
                StreamReader filein = new StreamReader("TaskFile9.txt");

                string line;
                int N = 0;
                while ((line = filein.ReadLine())!=null){
                    mas[N] = int.Parse(line);
                    N = N + 1;

                }
            }

        public void Print() {
            Console.WriteLine("Вывод элементов массива");
            for (int i = 0; i <= ml - 1; i++) {
                Console.WriteLine((i+1)+" "+mas[i]);
            }
        }

        public int PSumma() {
            int PS = 0;
            foreach (int A in mas) {
                if (A > 0) {
                    PS = PS + A;
                }
            }
            return PS;
        }

        public double PAverage() {
            int S = 0;
            int p = 0;
            foreach (int A in mas)
            {
                if (A > 0)
                {
                    S = S + A;
                    p = p + 1;
                }
            }
            double average = (S / p);
            return average;
        }

        public static void ArrCompS(TaskArray T1, TaskArray T2) {
            if (T1.PSumma() > T2.PSumma()) 
            {
                Console.WriteLine("В первом массиве сумма положительных элементов больше");
            }
            else if (T1.PSumma() < T2.PSumma())
            {
                Console.WriteLine("Во втором массиве сумма положительных элементов больше");
            }
            else { Console.WriteLine("В массивах суммы положительных элементов равны"); }
        }

        public static void ArrCompA(TaskArray T1, TaskArray T2)
        {
            if (T1.PAverage() > T2.PAverage())
            {
                Console.WriteLine("В первом массиве ср. арифм. положительных элементов больше");
            }
            else if (T1.PAverage() < T2.PAverage())
            {
                Console.WriteLine("Во втором массиве ср. арифм положительных элементов больше");
            }
            else { Console.WriteLine("В массивах ср. арифм положительных элементов равны"); }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            TaskArray T1 = new TaskArray();
            TaskArray T2 = new TaskArray();
            TaskArray T3 = new TaskArray();
            TaskArray T4 = new TaskArray();

            T1.Kfill();
                T1.Print();
            T2.FFill();
                T2.Print();
            T3.RFill();
                T3.Print();
            T4.RFill();
                T4.Print();

            TaskArray.ArrCompS(T1, T2);
            TaskArray.ArrCompA(T3, T4);

           // Console.WriteLine(T1.PAverage());
            Console.ReadKey();


        }
    }
}
