using System;

namespace InterfacePractice
{
    interface IUltraMegaMath
    {
        int Summa();
        int Min();
        int Max();
        void Info();
    }

    class DemoArray: IUltraMegaMath 
    {
        int[] A;
        int size;
        string name;

        public DemoArray(string name, int size) 
        {
            this.name = name;
            this.size = size;
            this.A = new int[size];
            Random R1 = new Random();
            for (int i = 0; i < size; i++) 
            {
                A[i] = R1.Next(-10, 10);
            }
        }

        public void Info() 
        {
            Console.WriteLine("Массив {0}.Элементов: {1}. Вывод элементов: ", name, size);
            for (int i = 0; i < size; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("Минимальный элемент: {0}. Максимальный: {1}. Сумма элементов: {2}", Min(), Max(), Summa());
        }

        public int Summa() 
        {
            int summ = 0;
            for (int i = 0; i < size; i++) 
            {
                summ = summ + A[i];
            }
            return summ;
        }

        public int Min() {
            int min = A[0];
            for (int i = 1; i < size; i++) 
            {
                if (min > A[i]) 
                {
                    min = A[i];
                }
            }
            return min;
        }

        public int Max()
        {
            int max = A[0];
            for (int i = 1; i < size; i++)
            {
                if (max < A[i])
                {
                    max = A[i];
                }
            }
            return max;
        }
    }

    class DemoMatrix : IUltraMegaMath
    {
        int[,] A;
        int CCount; // количество столбцов  
        int RCount; // количество строк
        string name;

        public DemoMatrix(string name, int CCount, int RCount)
        {
            this.name = name;
            this.CCount = CCount;
            this.RCount = RCount; 
            A = new int[RCount, CCount];
            Random R1 = new Random();
            for (int i = 0; i < CCount; i++)
            {
                for (int j = 0; j < RCount; j++)
                {
                    A[j, i] = R1.Next(-10, 10);
                }
            }
        }

        public int this[int CCount, int RCount]
        {
            get { return A[CCount, RCount]; }
            set { A[CCount, RCount] = value; }
        }

        public void Info()
        {
            Console.WriteLine("Матрица {0}.Элементов: {1}. Размеры: {2}x{3} Вывод элементов: ", name, RCount*CCount, RCount, CCount);
            for (int i = 0; i < CCount; i++)
            {
                for (int j = 0; j < RCount; j++)
                {
                    Console.Write(A[j, i] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Минимальный элемент: {0}. Максимальный: {1}. Сумма элементов: {2}", Min(), Max(), Summa());
        }

        public int Summa() 
        {
            int summ = 0;
            for (int i = 0; i < CCount; i++)
            {
                for (int j = 0; j < RCount; j++)
                {
                    summ = summ + A[j, i];
                }
            }
            return summ;
        }

        public int Min() 
        {
            int min = A[0, 0];
            for (int i = 0; i < CCount; i++)
            {
                for (int j = 0; j < RCount; j++)
                {
                    if (min > A[j, i]) 
                    {
                        min = A[j, i];
                    }
                }
            }
            return min;
        }

        public int Max() 
        {
            int max = A[0, 0];
            for (int i = 0; i < CCount; i++)
            {
                for (int j = 0; j < RCount; j++)
                {
                    if (max < A[j, i]) 
                    {
                        max = A[j, i];
                    }
                }
            }
            return max;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для тестирования возможностей интерфейсов");
            DemoArray A1 = new DemoArray("ТестовыйМассив", 10);
            A1.Info();
            DemoMatrix M1 = new DemoMatrix("ТестоваяМатрица", 5, 7);
            M1.Info();
        }
    }
}
