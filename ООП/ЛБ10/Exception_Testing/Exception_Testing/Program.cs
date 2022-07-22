using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exception_Testing
{
    class Program
    {

        public static void STFUXD(double a, double b, double s) {
            double X = a;
            while (X <= b)
            {
                try
                {
                   double Y = Math.Round(Math.Sqrt(X + 5) / Math.Sqrt(X * X - 9), 3);
                     if (double.IsNaN(Y) || double.IsInfinity(Y)) 
                     { throw new Exception(); }
                    // Y = Y / Y;
                    //Y = Y * 2147483647 * 2147483647 * 2147483647;
                    // Y = Y / Y;
                    //int T = Convert.ToInt32(Y);
                    Console.WriteLine("X = {0} | Y = {1}", X, double.Parse(Y.ToString()));
                    X = Math.Round(X + s, 3);
                }
                catch
                {
                    Console.WriteLine("X = {0} | Y = -", X);
                    X = Math.Round(X + s, 3);
                }
            }
        }

        static void Main(string[] args)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
        {
            double a, b, s, Y;
            a = -20;
            b = 20;
            s = 0.1;
            Program.STFUXD(a, b, s);
            Console.ReadKey();

        }
    }
}
