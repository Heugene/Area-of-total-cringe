using System;
using System.Collections.Generic;

namespace CollectionProgram
{
    class Student: IComparable
    {
        private string FIO;
        private int BirthDate;
        private float AVGmark;
        public int CompareTo(Object S)
        {
            Student s = S as Student;
            return this.BirthDate.CompareTo(s.BirthDate);
        }

        public Student()
        {
            this.FIO = "no name";
            this.BirthDate = -1;
            this.AVGmark = -1;
        }

        public void KFill()
        {
            Console.WriteLine("Введите ФИО студента");
            this.FIO = Console.ReadLine();
            Console.WriteLine("Введите дату рождения");
            this.BirthDate = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите средний балл");
            this.AVGmark = float.Parse(Console.ReadLine());
        }

        public void Info()
        {
            Console.WriteLine("{0}, {1}. Средний балл: {2}", FIO, BirthDate, AVGmark);
        }

        public float AVG 
        {
            get { return this.AVGmark; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> TestList = new List<Student>();
            Console.WriteLine("Введите информацию о студентах. Нажмите любую клавишу для добавления нового студента после заполнения информации о предыдущем. Введите 0 для окончания формирования списка");
            Console.WriteLine("-----------------------------------------------------------------------------");
            bool FillOver = false;
            byte SCount = 0;
            while (FillOver == false)
            {
                Console.WriteLine("Студент [{0}]", SCount+1);
                TestList.Add(new Student());
                TestList[SCount].KFill();
                Console.WriteLine("-----------------------------------------------------------------------------");
                SCount++;
                if (Console.ReadLine() == "0") 
                {
                    FillOver = true;
                }
            }

            Console.WriteLine("Вывод студентов из списка");
            for (int i = 0; i < TestList.Count; i++)
            {
                Console.Write("#{0}  ", i+1);
                TestList[i].Info();
            }
            Console.WriteLine("-----------------------------------------------------------------------------");

            Console.WriteLine("Выборка студентов, имеющих средний балл не менее N. (Будут отсортированы по дате рождения)");
            Console.Write("Введите значение N (может быть дробным)   : ");
            float N = float.Parse(Console.ReadLine());
            TestList.Sort();
            for (int i = 0; i < TestList.Count; i++) 
            {
                if (TestList[i].AVG >= N) 
                {
                    Console.Write("#{0}  ", i + 1);
                    TestList[i].Info();

                }
            }
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("Для выхода из программы нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}
