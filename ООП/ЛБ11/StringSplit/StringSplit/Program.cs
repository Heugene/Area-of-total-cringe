using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringSplit
{
    class Program
    {
        public static string EmpDel(string strIn) {
            string Result = "";
            string[] B = strIn.Split(' ');
            for (int i = 0; i < B.Length; i++) {
                if (!String.Equals(B[i], "")) {
                    Result = Result + B[i] + " ";
                }
            }
                return Result;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите в строку ФИО через пробел");
                string FIO = Console.ReadLine();
                FIO = Program.EmpDel(FIO);
                string []fio = FIO.Split(' ');
                for (int i = 0; i < fio.Length-1; i++)
                {
                    Console.WriteLine(fio[i]);
                }
                Console.WriteLine(fio[0]);
            }

            catch(Exception error) { Console.WriteLine("error" + error); }
            Console.ReadKey();
        }
    }
}
