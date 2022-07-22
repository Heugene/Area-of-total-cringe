using System;
using System.Text.RegularExpressions;
using System.IO;

namespace PhoneNumberFilter
{
    class PString {
        string[] text;
        byte N;

        public void KFill()
        {
            try
            {
                Console.WriteLine("Заполнение с клавиатуры");
                text = new string[N];
                for (int i = 0; i <= N - 1; i++)
                {
                    Console.WriteLine("Введите " + (i + 1) + " номер телефона");
                    text[i] = Console.ReadLine();
                }
                Console.WriteLine("Сохранить список в файл? (0 - нет, 1 - да)");
                byte Sval = byte.Parse(Console.ReadLine());
                if (Sval == 1) { FSave(); }
            }
            catch { Console.WriteLine();}
        }

        public void FFill()
        {
            Console.WriteLine("Заполнение данными из файла");
            StreamReader filein = new StreamReader("TaskFile12.txt");
            text = filein.ReadLine().Split(' ');
            N = byte.Parse(text.Length.ToString());
        }

        public void FSave() {
            Console.WriteLine("Сохранение списка номеров...");
            StreamWriter fileout = new StreamWriter("TaskFile12.txt", false);
            string separator = " ";
            for (int i = 0; i <= N - 1; i++) {
                if (i == N - 1) { separator = ""; }
                fileout.Write(text[i] + separator);
            }
            fileout.Close();
            Console.WriteLine("Готово!");
        }

        public void Print() 
        {
            Console.WriteLine("Вывод списка номеров");
            for (int i = 0; i <= N - 1; i++)
            {
                Console.WriteLine("#" + (i + 1) + " номер телефона: " + text[i]);
            }
        }

        public byte n 
        { set 
            { this.N = value; } 
          get 
            { return this.N; } 
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            byte MenuVal = 0;
            Console.WriteLine("Выберите способ ввода номеров (0 - Вручную с клавиатуры; 1 - Из файла)");
            try
            {
                MenuVal = byte.Parse(Console.ReadLine());
                if (!(MenuVal == 0) & !(MenuVal == 1))
                {
                    throw new Exception();
                }
                if (MenuVal == 0)
                {
                    PString test1 = new PString();
                    Console.WriteLine("Введите количество телефонных номеров");
                    test1.n = byte.Parse(Console.ReadLine());
                    test1.KFill();
                    test1.Print();

                }
                else 
                {
                    PString test2 = new PString();
                    test2.FFill();
                    test2.Print();
                }
            }
            catch {
                Console.WriteLine("Ошибка ввода! ");
            }
            }
        }
    }

