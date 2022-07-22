using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StudentRun
{
    class Student: IComparable
    {
        string FIO;
        byte StudYear;
        string Group;
        float Result;

        public Student(string FIO, byte StudYear, string Group, float Result) 
        {
            this.FIO = FIO;
            this.StudYear = StudYear;
            this.Group = Group;
            this.Result = Result;
        }

        public string fio 
        {
            get { return this.FIO; }
            set { this.FIO = value; }
        }

        public byte studyear
        { 
            get { return this.StudYear; }
            set { this.StudYear = value; }
        }

        public string group
        { 
            get { return this.Group; }
            set { this.Group = value; }
        }

        public float result
        { 
            get { return this.Result; }
            set { this.Result = value; }
        }

        public Student() 
        {
            Console.WriteLine("Введите ФИО");
            this.FIO = Console.ReadLine();
            Console.WriteLine("Введите курс");
            this.StudYear = byte.Parse(Console.ReadLine());
            Console.WriteLine("Введите группу");
            this.Group = Console.ReadLine();
            Console.WriteLine("Введите результат");
            this.Result = float.Parse(Console.ReadLine());
        }

        public int CompareTo(object s)
        {
            Student S = s as Student;
            return this.Result.CompareTo(S.Result);
        }

        public void Info()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Студент " + FIO);
            Console.WriteLine("курс: " + StudYear);
            Console.WriteLine("группа: " + Group);
            Console.WriteLine("результат: " + Result);

        }
    }
    class Program
    {
        public static void Menu(List<Student> S)
        {
            Console.Clear();
            Console.WriteLine("Выберите режим работы");
            Console.WriteLine("1 - Ввод списка студентов с клавиатуры");
            Console.WriteLine("2 - Загрузка списка студентов из файла");
            byte MenuVal = 0;
            try
            {
                MenuVal = byte.Parse(Console.ReadLine());
                if (!(MenuVal == 1) & !(MenuVal == 2))
                { throw new Exception(); }
            }
            catch 
            {
                Console.WriteLine("Input error! Press any key to return");
                Console.ReadKey();
                Menu(S);
            }

            if (MenuVal == 1) { KFill(S); }
            if (MenuVal == 2) { FFill(S); }
        }
        public static void KFill(List<Student> S) 
        {
            Console.WriteLine("Заполнение с клавиатуры...");
            bool InputFlag = true;

            while (InputFlag == true) 
            {
                S.Add(new Student());
                if (Console.ReadLine() == "0")
                { InputFlag = false; }
            }
            Console.WriteLine("Сохранить данные в файл? 1 - Да, любая другая клавиша - Нет");
            if (Console.ReadLine() == "1") 
            {
                Console.WriteLine("Сохранение данных...");
                StreamWriter fileout = new StreamWriter("TaskFile18_List.txt", false);
                for (int i = 0; i < S.Count; i++)
                {
                    fileout.Write(S[i].fio + "*");
                    fileout.Write(S[i].studyear + "*");
                    fileout.Write(S[i].group + "*");
                    fileout.WriteLine(S[i].result);
                }
                fileout.Close();
                Console.WriteLine("Готово!");
            }
            WinnerSave(S);
            Console.ReadKey();
        }

        public static void FFill(List<Student> S)
        {
            Console.WriteLine("Чтение из файла....");
            StreamReader filein = new StreamReader("TaskFile18_List.txt");
            while (!(filein.Peek() == -1))
            {
                string[] student = filein.ReadLine().Split('*');
                S.Add(new Student(student[0], byte.Parse(student[1]), student[2], float.Parse(student[3])));
            }
            filein.Close();
            Console.WriteLine("Готово!");
            Console.WriteLine("Вывести содержимое файла? 1 - Да, любая другая клавиша - Нет");
            if (Console.ReadLine() == "1") 
            {
                for (int j = 0; j < S.Count; j++)
                { S[j].Info(); }
            }
            WinnerSave(S);
            Console.ReadKey();   
        }

        static void WinnerSave(List<Student> S) 
        {
            Console.WriteLine("Сколько победителей?");
            int WinCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Определение победителей....");
            S.Sort();
            int N = 1; // Счётчик мест
            int i = 0; // Счётчик студентов 
            int temp = 0; // хранит индекс студента, у которого результат отличается от предыдущего
            StreamWriter winners = new StreamWriter("Winners.txt", false);
            winners.WriteLine("Place {0}:", N);
            Console.WriteLine("Place {0}:", N);
            while (N <= WinCount)
            {
                if (S[i].result == S[temp].result)
                {
                    winners.WriteLine(S[i].fio + ", результат: " + S[i].result);
                    Console.WriteLine(S[i].fio + ", результат: " + S[i].result);

                    i = i + 1;
                }
                else
                {
                    temp = i;
                    N = N + 1;
                    if (N <= WinCount)
                    {
                        winners.WriteLine("Place {0}:", N);
                        Console.WriteLine("Place {0}:", N);
                    }
                }
            }
            winners.Close();

        }
        static void Main(string[] args)
        {
            List<Student> TaskList = new List<Student>();
            Program.Menu(TaskList);
        }
    }
}
