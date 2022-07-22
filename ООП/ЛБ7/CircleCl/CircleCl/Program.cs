using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleCl
{
    class Circle {
        double rad;
        int X;
        int Y;

        public Circle() {
            this.rad = 1;
            this.X = 0;
            this.Y = 0;
        }

        public Circle(int X, int Y, double rad) {
            this.X = X;
            this.Y = Y;
            this.rad = rad;
        }

        public Circle(Circle CC){
            this.X = CC.X;
            this.Y = CC.Y;
            this.rad = CC.rad;
        }

        public void Print() {
            Console.WriteLine("Окружность с центром в точке ("+X+","+Y+") и радиусом "+rad);
        }

        /*       public static void VVod() {
                   Console.WriteLine("Сколько окружностей создать?");
                   int K = int.Parse(Console.ReadLine());
                   int X1;
                   int Y1;
                   double rad1;
                   for (int i = 1; i >= K; i++ ) {
                       Console.WriteLine("Введите Х центра");
                       X1 = int.Parse(Console.ReadLine());
                       Console.WriteLine("Введите Y центра");
                       Y1 = int.Parse(Console.ReadLine());
                       Console.WriteLine("Введите радиус");
                       rad1 = double.Parse(Console.ReadLine());
                       Circle = new Circle(X1, Y1, rad1);   
                   }
               }
          */

        public double Clength() {
            return (3.14*rad);
        }

        public void CChange(int N1, int N2) {
            X = X + N1;
            Y = Y + N2;
        }
        
        public static void CCompare (Circle c1, Circle c2) {
            if (c1.rad > c2.rad){
                Console.WriteLine("Первая окружность имеет больший радиус");
            }
            else if (c1.rad < c2.rad)
            {
                Console.WriteLine("Вторая окружность имеет больший радиус");
            }
            else { Console.WriteLine("Обе окружности равны по радиусу"); }
        }

        public static Circle operator +(Circle c1, int n) {
            c1.X = c1.X + n;
            c1.Y = c1.Y + n;
            return c1;
        }
    }

    class Orb: Circle {

        public Orb(int x1, int y1, double rad1) : base(x1, x1, rad1) {
        }

        public double Volume() {
            return 1;
        }
    } 


    class Program
    {
        static void Main(string[] args)
        {
            Circle C1 = new Circle();
            Circle C2 = new Circle(5, 8, 10);
            Circle C3 = new Circle(C2);

            C1.Print();
            C2.Print();
            C3.Print();

            C1.CChange(2, 6);
            C1.Print();

            Console.WriteLine("C2 length = " + C2.Clength());
            Circle.CCompare(C1, C2);

            C3 = C3 + 5;
            C3.Print();


            Console.ReadKey();
        }
    }
}
