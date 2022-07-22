using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace To4ka
{
    class Point{
        private int x;
        private int y;

        public Point(){
            this.x = 0;
            this.y = 0;
        }

        public Point(int X1, int Y1){
            this.x = X1;
            this.y = Y1;
        }

        public int X
        {
            get {
                return x;
            }

            set {
                x = value;
            }
        }
        public int Y {
            get {
                return y;
            }

            set {
                y = value;
            }
        }
        public int Xf{
            get{
                return x;
            }

            set{
                x = x*value;
            }
        }

        public int Yf{
            get{
                return y;
            }

            set {
                y = y * value;
            }
        }

        public void Print() {
            Console.Write("X = ");
            Console.WriteLine(this.x);
            Console.Write("Y = ");
            Console.WriteLine(this.y);
        }

        public double Destination() {
            return Math.Sqrt((0 - Math.Abs(this.x)) * (0 - Math.Abs(this.x)) + (0 - Math.Abs(this.y)) * (0 - Math.Abs(this.y)));
        }

        public void Move(int X2, int Y2) {
            this.x = this.x + X2;
            this.y = this.y + Y2;
        }

        public static Point operator ++ (Point p1) {
            p1.x = p1.x + 1;
            p1.y = p1.y + 1;
            return p1;
        }

        public static Point operator -- (Point p1)
        {
            p1.x = p1.x - 1;
            p1.y = p1.y - 1;
            return p1;
        }

        public static Point operator * (Point p1, int n)
        {
            p1.x = p1.x*n;
            p1.y = p1.y*n;
            return p1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point();
            Point B = new Point(-5, 8);
            Point C = new Point(10, -3);
            A.Print();
            B.Print();
            Console.Write("Расстояние до точки А от начала координат = ");
            Console.WriteLine(A.Destination());
            Console.Write("Расстояние до точки B от начала координат = ");
            Console.WriteLine(B.Destination());

            A.Move(5, -3);
            A.Print();

            Console.WriteLine(A.X);
            Console.WriteLine(A.Y);

            A.Y = 8;                    //////
            Console.WriteLine(A.Y);     //////

            Console.WriteLine("Щас затестим то бесячее свойство");
            Console.WriteLine("Точка С с изначальными координатами");
            C.Print();
            Console.WriteLine("Щас должна произойти магия...");
            C.Xf = 3;
            C.Yf = 2;
            Console.WriteLine(C.Xf);
            

            Console.WriteLine("Тестим перегрузку операторов");
            Console.WriteLine("++");
            Console.WriteLine("до");
            A.Print();
            ++A;
            Console.WriteLine("после");
            A.Print();

            Console.WriteLine("--");
            Console.WriteLine("до");
            A.Print();
            --A;
            Console.WriteLine("после");
            A.Print();

            Console.WriteLine("*");
            Console.WriteLine("Умножим координаты на 5");
            Console.WriteLine("до");
            A.Print();
            A = A*5;
            Console.WriteLine("после");
            A.Print();

            Console.ReadKey();
        }
    }
}
