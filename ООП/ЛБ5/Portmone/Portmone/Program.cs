using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portmone
{
    class Port {
        int Nom;
        int q;

        public Port(int N, int Q) {
            this.Nom = N;
            this.q = Q;
        }

        public int Nominal {
            set {
                this.Nom = value;
            }

            get {
                return this.Nom;
            }
        }

        public int Quantity {
            set {
                this.q = value;
            }

            get {
                return this.q;
            }
        }

        public int Summa {
            get {
                return (this.q * this.Nom);
            }
        }

        public void Print() {
            Console.WriteLine("Номинал: " + this.Nom);
            Console.WriteLine("Количество купюр " + this.q);
            Console.WriteLine("Сумма: "+ Summa);
        }

        public void MCheck(int price) {
            if (price == 0) {
                Console.WriteLine("Введите цену товара");
                price = int.Parse(Console.ReadLine());
            } 
            if (price < Summa)
            {
                Console.WriteLine("Денег хватит на приобретение этого товара");
            }
            else {
                Console.WriteLine("Денег не хватит на приобретение этого товара");
            }
        }

        public void QCheck() {
            Console.WriteLine("Введите стоимость товара");
            int price = int.Parse(Console.ReadLine());
            int Q = Summa / price;
            Console.WriteLine("За имеющуюся сумму можно приобрести " + Q + " товаров");
        }
                                          
    }

    class Program
    {
        static void Main(string[] args)
        {
            Port A = new Port(50, 100);
            Port B = new Port(500, 70);
            Port C = new Port(200, 125);

            A.Print();
            B.Print();
            C.Print();

            A.MCheck(0);
            B.QCheck();
            C.MCheck(25001);

            C.Quantity = 500;
            C.MCheck(25001);
            C.Print();

            Console.ReadKey();
        }
    }
}
