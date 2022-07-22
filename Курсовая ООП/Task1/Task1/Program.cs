using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Matrix
    {
        // объявление полей класса
        int[,] TMatrix; // двумерный массив
        int x, y; // x - количество столбцов, y - количество строк
        string name; // имя матрицы

        // конструктор
        public Matrix()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Введите имя матрицы");
                this.name = Console.ReadLine();
            Console.Write("Введите число столбцов: ");
                try { this.x = int.Parse(Console.ReadLine()); }
                catch { Console.WriteLine("Некорректный ввод! значение по умолчанию 5"); this.x = 5; }
            Console.Write("Введите число строк: ");
                try { this.y = int.Parse(Console.ReadLine()); }
                catch { Console.WriteLine("Некорректный ввод! значение по умолчанию 5"); this.y = 5; }
            TMatrix = new int[this.x, this.y];
            Console.WriteLine("Выберите режим заполнения матрицы (0 - Вручную с клавиатуры; Любая другая клавиша - заполнение случайными числами)");
                if (Console.ReadLine() == "0") { KFill(); }
                else { RFill(); }
        }

        // двумерный индексатор
        public int this[int x, int y]
        {
            get { return TMatrix[x, y]; }
            set { TMatrix[x, y] = value; }
        }

        // метод заполнения матрицы с клавиатуры
        public void KFill()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Заполнение матрицы {0} с клавиатуры", name);            
            for (int iy = 0; iy <= (y - 1); iy++)
            {
                for (int ix = 0; ix <= (x - 1); ix++)
                {
                    Console.Write("Введите элемент [{0},{1}]: ", (ix + 1), (iy + 1));
                    try { TMatrix[ix, iy] = int.Parse(Console.ReadLine()); }
                    catch { 
                        Console.WriteLine("Некорректный ввод! Вводите только числа. [{0},{1}] = 1", (ix + 1), (iy + 1));
                        TMatrix[ix, iy] = 1;
                    }
                }
            }
        }
        // метод заполнения матрицы случайными числами
        public void RFill() 
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Заполнение матрицы {0} случайными числами", name);
            Console.WriteLine("-------------------------------------");
            Random R1 = new Random();
            for (int iy = 0; iy <= (y - 1); iy++)
            {
                for (int ix = 0; ix <= (x - 1); ix++)
                { 
                    TMatrix[ix, iy] = R1.Next(-100, 100);
                }
            }

        }

        // метод вывода матрицы в окно консоли
        public void Print()
        {
            Console.WriteLine("Вывод элементов матрицы {0}:", name);
            for (int iy = 0; iy <= y - 1; iy++)
            {
                for (int ix = 0; ix <= x - 1; ix++)
                {
                    Console.Write(TMatrix[ix, iy] + " ");
                }
            Console.WriteLine();
            }
        }

        // перегрузка оператора + (прибавляет к элементам матрицы целое число)
        public static Matrix operator + (Matrix MM, int A) 
        {
            for (int iy = 0; iy <= MM.y - 1; iy++)
            {
                for (int ix = 0; ix <= MM.x - 1; ix++)
                {
                    MM[ix, iy] = MM[ix, iy] + A;
                }
            }
        return MM;
        }

        // перегрузка оператора - (вычитает из элементов матрицы целое число)
        public static Matrix operator - (Matrix MM, int A)
        {
            for (int iy = 0; iy <= MM.y - 1; iy++)
            {
                for (int ix = 0; ix <= MM.x - 1; ix++)
                {
                    MM[ix, iy] = MM[ix, iy] - A;
                }
            }
            return MM;
        }

        // метод вычисления количества положительных элементов в нечётных строках
        public int SpecialTask() 
        {
            int result = 0;
            bool odd = true;
            for (int iy = 0; iy <= y - 1; iy++)
            {
                for (int ix = 0; ix <= x - 1; ix++)
                {
                    if (odd)
                    { 
                        if (TMatrix[ix, iy] > 0)
                        {
                            result = result + 1;
                        }
                    }
                }
                odd = !odd;
            }
            return result;
        }

        class Program
        {
            static void Main(string[] args)
            {
                // создание экземпляров класса и заполнение матриц
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Создание матриц");
                Matrix M1 = new Matrix();
                Matrix M2 = new Matrix();
                // вывод на экран матриц
                M1.Print();
                M2.Print();
                // демонстрация работы перегруженных операторов
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Тестирование перегруженных операторов + и -");
                Console.WriteLine("Введите число N ({0}+N, {1}-N)", M1.name, M2.name);
                int N; // число, которое будет прибавляться или вычитаться
                    try { N = int.Parse(Console.ReadLine()); }
                    catch { 
                        N = 20;
                        Console.WriteLine("Некорректный ввод! Значение по умолчанию: 20");
                    }
                M1 = M1 + N;
                M1.Print();
                M2 = M2 - N;
                M2.Print();
                // демонстрация работы особого метода, уникального для каждого варианта
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("SpecialTask testing (Вариант 6)");
                Console.WriteLine("Вывести количество положительных элементов в нечётных строках");
                Console.WriteLine("Matrix 1 {0}: " + M1.SpecialTask(), M1.name);
                Console.WriteLine("Matrix 2 {0}: " + M2.SpecialTask(), M2.name);
                Console.WriteLine("Для выхода из программы нажмите любую клавишу");
                Console.ReadKey();
                Console.ReadKey();
            }
        }
    }
}
