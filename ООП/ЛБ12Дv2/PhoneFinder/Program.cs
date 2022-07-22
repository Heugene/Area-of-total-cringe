using System;
using System.IO;
using System.Text.RegularExpressions;

namespace PhoneFinder
{
    class Message {
        string text;

        public void KFill() {
            Console.WriteLine("Введите сообщение");
            text = Console.ReadLine();
            Console.WriteLine("Создать файл сообщения? (0 - Да; Любая другая клавиша - нет)");
            if (Console.ReadLine() == "0") { FSave(); }
        }

        public void FFill() {
            Console.WriteLine("Загрузка сообщения из файла");
            StreamReader filein = new StreamReader("TaskFile12.txt");
            text = filein.ReadLine();
        }

        public void FSave() {
            Console.WriteLine("Сохранение сообщения...");
            StreamWriter fileout = new StreamWriter("TaskFile12.txt", false);
            fileout.Write(text);
            fileout.Close();
            Console.WriteLine("Готово!");
        }

        public void Print() {
            Console.WriteLine("Вывод сообщения");
            Console.WriteLine(text);
        }

        public void PFind() {
            string pattern1 = @"\d{2}-\d{2}-\d{2}";
            string pattern2 = @"\d{3}-\d{3}";
            string pattern3 = @"\d{3}-\d{2}-\d{2}";
            Console.WriteLine("Найденные номера:");
            Match match = Regex.Match(text, pattern1);
            while (match.Success) {
                Console.WriteLine(match.Value);
                match = match.NextMatch();
            }
            match = Regex.Match(text, pattern2);
            while (match.Success)
            {
                Console.WriteLine(match.Value);
                match = match.NextMatch();
            }
            match = Regex.Match(text, pattern3);
            while (match.Success)
            {
                Console.WriteLine(match.Value);
                match = match.NextMatch();
            }
        }

    }
    class Program
    {
        public static void Menu() {
            Console.WriteLine("Выберите режим работы (0 - Ввод сообщения с клавиатуры; 1 - Ввод сообщения из файла)");
            string MenuVal = Console.ReadLine();
            Message TestMessage = new Message();
            if (MenuVal == "0") { TestMessage.KFill(); }
            else if (MenuVal == "1") { TestMessage.FFill(); }
            else { Menu(); }
            TestMessage.Print();
            TestMessage.PFind();
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
