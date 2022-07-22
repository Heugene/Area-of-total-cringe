using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassProgram
{
    class N1c3Array {
        int[] Massiv;
        int n;

        public N1c3Array(bool r) {
            Console.WriteLine("Введите размерность массива");
            n = int.Parse(Console.ReadLine());
            Massiv = new int[n];
            if (!r) {
                Console.WriteLine("Последовательно введите элементы массива");
                for (int i = 0; i <= n - 1; i++){
                    Massiv[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Ввод завершён");
            }
            else {
                Console.WriteLine("Заполнение случайными числами:");
                Random R = new Random();
                for (int i = 0; i <= n - 1; i++) {
                    Massiv[i] = R.Next(-10, 10);
                    Console.WriteLine(Massiv[i]);
                }
            }
        }


        public int NegativeC() {
            int nc = 0;
            for (int i = 0; i <=n - 1; i++) {
                if (Massiv[i] < 0) {
                    nc = nc + 1;
                }
            }
            return nc;
        }
    }
    class Program
    {
        static void Main(string[] args) {
            N1c3Array A = new N1c3Array(false);
            N1c3Array B = new N1c3Array(true);
            if (A.NegativeC() < B.NegativeC()) {
                Console.WriteLine("Отрицательных элементов больше в массиве В");
            }
            else if (A.NegativeC() > B.NegativeC()) {
                Console.WriteLine("Отрицательных элементов больше в массиве A");
            }
            else {
                Console.WriteLine("Отрицательных элементов в обоих массивах поровну");
            }

            Console.WriteLine('A'+A.NegativeC());
            Console.WriteLine('B'+B.NegativeC());
            Console.ReadKey();
        }
    }
}
