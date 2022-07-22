using System;
using System.IO;
using System.Text.RegularExpressions;

namespace WordGame
{

    class Message
    {
        string text;

        public void KFill()
        {
            Console.WriteLine("Введите сообщение");
            text = Message.EmpDel(Console.ReadLine());
            Console.WriteLine("Создать файл сообщения? (0 - Да; Любая другая клавиша - нет)");
            if (Console.ReadLine() == "0") { FSave(); }
        }

        public void FFill()
        {
            Console.WriteLine("Загрузка сообщения из файла");
            StreamReader filein = new StreamReader("TaskFile13.txt");
            text = Message.EmpDel(filein.ReadLine());
        }

        public void FSave()
        {
            Console.WriteLine("Сохранение сообщения...");
            StreamWriter fileout = new StreamWriter("TaskFile13.txt", false);
            fileout.Write(text);
            fileout.Close();
            Console.WriteLine("Готово!");
        }

        public void Print()
        {
            Console.WriteLine("Вывод сообщения");
            Console.WriteLine(text);
        }

        public static string EmpDel(string strIn)
        {
            string Result = "";
            string[] B = strIn.Split(' ');
            string splitter = " ";
            for (int i = 0; i < B.Length; i++)
            {
                if (!String.Equals(B[i], ""))
                {
                    if (i == B.Length - 1) { splitter = ""; }
                    Result = Result + B[i] + splitter;
                }
            }
            return Result;
        }

        public void CGame()
        {
            string CityPattern1 = @" ?[А, Б, В, Г, Д, Е, Ё, Ж, З, И, Й, К, Л, М, Н, О, П, Р, С, Т, У, Ф, Х, Ц, Ч, Ш, Щ, Ы, Э, Ю, Я]+[а, б, в, г, д, е, ё, ж, з, и, й, к, л, м, н, о, п, р, с, т, у, ф, х, ц, ч, ш, щ, ъ, ы, ь, э, ю, я]*";
            //string CityPattern1 = @" ?[A-Z]{1,}[a-z]{0,} ?";
            Console.WriteLine("Найденные города:");
            string temp = "";
            Match match1 = Regex.Match(text, CityPattern1);
            while (match1.Success)
            {
                if (match1.Success)
                {
                    Console.WriteLine(EmpDel(match1.Value));
                    temp = temp + EmpDel(match1.Value);
                    match1 = match1.NextMatch();
                }
            }
            string[] CArray = temp.Split(' ');
            bool IsChainPossible = true;
            bool IsWordFound;
            Console.WriteLine("CityString:");
            Console.WriteLine(temp);
            int i = 0;
            char LastNCurrent;
            char FirstNNext;
            Console.WriteLine("Game testing");
            while (IsChainPossible)
            { 
                LastNCurrent = CArray[i][CArray[i].Length - 1];
                Console.WriteLine(CArray[i]);
                Console.WriteLine(LastNCurrent);
                for (int m = 1; m < (CArray.Length-1); m++)
                {
                    if (CArray[m] == "") { m = m + 1; }
                    else
                    {
                        FirstNNext = CArray[m][0];
                        IsWordFound = false;
                        Console.WriteLine(FirstNNext);
                        if (FirstNNext == Char.ToUpper(LastNCurrent))
                        {
                            //CArray[i] = ""; Тут я пытался исключить использованные элементы
                            i = m;
                            IsChainPossible = true;
                            Console.WriteLine(CArray[i]);
                            IsWordFound = true;
                            break;
                        }
                        else if ((m == CArray.Length - 2) & (IsWordFound == false)) { IsChainPossible = false; }
                    }
                }
            }
            Console.WriteLine("Больше продолжать цепочку нельзя");
        }

    }
    class Program
    {
        public static void Menu()
        {
            Console.WriteLine("Выберите режим работы (0 - Ввод сообщения с клавиатуры; 1 - Ввод сообщения из файла)");
            string MenuVal = Console.ReadLine();
            Message TestMessage = new Message();
            if (MenuVal == "0") { TestMessage.KFill(); }
            else if (MenuVal == "1") { TestMessage.FFill(); }
            else { Menu(); }
            TestMessage.Print();
            TestMessage.CGame();
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}