using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TovarChecker
{
    class Tovar 
    {
        string name;
        public string Name
        { 
            get {return this.name;}
            set { this.name = value; }
        }
        float price;
        public float Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        int[] AllowedAge; 
        public int[] Diapason
        {
            get { return this.AllowedAge; }
            set { this.AllowedAge = value; }
        }
        /*
        public Tovar()
        {
            Console.WriteLine("Введите название товара");
            this.name = Console.ReadLine();
            Console.WriteLine("Введите цену товара");
            this.price = float.Parse(Console.ReadLine());
            this.AllowedAge = new int[2];
            Console.WriteLine("Введите минимальный возраст пользования");
            this.AllowedAge[0] = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите максимальный возраст пользования");
            this.AllowedAge[1] = int.Parse(Console.ReadLine());
        }
        */
        public Tovar(string name, float price, int MinAge, int MaxAge)
        {
            this.name = name;
            this.price = price;
            this.AllowedAge = new int[2];
            this.AllowedAge[0] = MinAge;
            this.AllowedAge[1] = MaxAge;
        }

        public static bool AgeCheck(Tovar T, int CurrentAge)
        {
            bool result = false;
            if (CurrentAge >= T.AllowedAge[0] && CurrentAge <= T.AllowedAge[1])
            {
                result = true;
            }
            return result;
        }
    }
    class Program
    {
        static void FFill()
        {
            Tovar[] Assortiment = new Tovar[0];
            StreamReader filein = new StreamReader("TovarList.txt");
            while (filein.Peek() != -1)
            {
                Array.Resize(ref Assortiment, Assortiment.Length + 1);
                string[] CurrentTovar = filein.ReadLine().Split('-');
                Assortiment[Assortiment.Length - 1] = new Tovar(CurrentTovar[0],float.Parse(CurrentTovar[1]),int.Parse(CurrentTovar[2]),int.Parse(CurrentTovar[3]));
            }
            filein.Close();
            TSeach(Assortiment);
        }

        static void TSeach(Tovar[] Assortiment) 
        {
            Console.Clear();
            Console.WriteLine("Введите возраст ребёнка");
            int age = int.Parse(Console.ReadLine());
            bool SearchFlag = false;
            for (int i = 0; i < Assortiment.Length; i++)
            {
                if (Tovar.AgeCheck(Assortiment[i], age))
                {
                    Console.WriteLine("Товар: {0}. Цена: {1}. Диапазон возрастов: {2}-{3}.", Assortiment[i].Name, Assortiment[i].Price, Assortiment[i].Diapason[0], Assortiment[i].Diapason[1]);
                    SearchFlag = true;
                }
            }
            if (SearchFlag == false)
            {
                Console.WriteLine("Для заданного возраста товаров не найдено");
            }
            Console.WriteLine("Для выхода из программы нажмите 0. Любая другая клавиша вернёт вас в поиск");
            if(Console.ReadLine() == "0")
            {
                Environment.Exit(0);
            }
            TSeach(Assortiment);
        }

        static void Main(string[] args)
        {
            FFill();
        }
    }
}
