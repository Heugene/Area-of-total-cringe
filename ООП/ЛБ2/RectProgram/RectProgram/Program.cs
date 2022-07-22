using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RectProgram
{
    class Rectangle{
        private double a;
        private double b;

        public Rectangle (double A, double B){
            this.a = A;
            this.b = B;
        }

        public Rectangle(Rectangle r) {
            this.a = r.a;
            this.b = r.b;
        }

        public Rectangle(){
            a = 0;
            b = 0;
        }

        public double Perimeter() {
            return ((a+b)*2);
        }

        public double Square() {
            return (a * b);
        }

        public bool SCheck(){
            if (a == b){
                return true;
            }
            else {
                return false;
            }
        }

        public void Print(){
            Console.Write("Прямоугольник со сторонами: ");
            Console.Write(a);
            Console.Write(" ");
            Console.Write(b);
            Console.Write("Периметр: ");
            Console.WriteLine(Perimeter());
            Console.Write("Площадь: ");
            Console.WriteLine(Square());
            if (SCheck()) {
                Console.WriteLine("Квадрат: Да");
            }
            else{
                Console.WriteLine("Квадрат: Нет");
            }
        }

        public void Change(){
            Console.WriteLine("Введите значение А");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение В");
            b = double.Parse(Console.ReadLine());
        }

        public void Mash(){
            double A = double.Parse(Console.ReadLine());
            double B = double.Parse(Console.ReadLine());
            a = a + A;
            b = b + B;
        }

        public void PerSqr(out double Sqr, out double Per){
           Sqr = this.a * this.b;
           Per = (this.a + this.b) * 2; 
        }

        public static Rectangle operator --(Rectangle x) {
            Rectangle temp = new Rectangle(x.a, x.b);
            temp.a = temp.a - 1;
            temp.b = temp.b - 1;
            return temp;
        }
        public static Rectangle operator ++ (Rectangle x) {
            Rectangle temp = new Rectangle(x.a, x.b);
            temp.a = temp.a + 1;
            temp.b = temp.b + 1;
            return temp;
        }
    }

    class Program{
      static void Main(string[] args)
        {
            Rectangle A = new Rectangle();
            Rectangle B = new Rectangle(2, 4);
            Rectangle r1 = new Rectangle(3, 9);
            Rectangle r2 = new Rectangle(r1);

            double sqr1;
            double per1;

            A.Change();
            B.Change();
            r1.Change();

            A.Print();
            B.Print();
            r1.Print();

     //       A.Mash();
     //       B.Mash();
     //       r1.Mash();

     //       A.Print();
     //       B.Print();
     //       r1.Print();
            A.PerSqr(out sqr1, out per1);
            Console.WriteLine("Новый метод Хд");
            Console.WriteLine("Периметр А");
            Console.WriteLine(per1);
            Console.WriteLine("Площадь А");
            Console.WriteLine(sqr1);

            Console.WriteLine("Тестим перегрузОчку");
            A = --A;
            A.Print();
            Console.ReadKey();

        }
    }
}
