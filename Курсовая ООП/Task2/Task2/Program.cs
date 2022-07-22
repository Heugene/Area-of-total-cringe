using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task2
{

    class City
    {
        private string Name;
        private int Population;
        private University[] Universities;

        public City() 
        {
            Console.WriteLine("Введите название города");
            this.Name = Console.ReadLine();
            Console.WriteLine("Введите численность населения города");
            try
            {
                this.Population = int.Parse(Console.ReadLine()); 
            }
            catch 
            {
                Console.WriteLine("Ошибка ввода! Значение по умолчанию: 1." 
                               +"\nЗначение численности населения города можно изменить в дальнейшем");
                this.Population = 1;
            }
            this.Universities = new University[0];
        }

        public City(string Name, int Population)
        {
            this.Name = Name;
            this.Population = Population;
            this.Universities = new University[0];
        }

        public string name
        { 
            get { return this.Name; }
            set { this.Name = value; }
        }

        public int population
        {
            get { return this.Population; }
            set { this.Population = value; }
        }

        public University[] universities
        {
            get { return this.Universities; }
            set { this.Universities = value; }
        }

        public void Add() 
        {
            int N = Universities.Length + 1;
            Array.Resize(ref Universities, N);
            Universities[N - 1] = new University();
        }

        public void Remove()
        {
            Console.Clear();
            Console.WriteLine("Введите название удаляемого ВУЗа");
            string UniDel = Console.ReadLine();
            University[] result = new University[this.Universities.Length - 1];
            int i = 0;
            try
            {
                while (UniDel != this.Universities[i].name)
                {
                    result[i] = this.Universities[i];
                    i = i + 1;
                }
                for (int j = i + 1; j < result.Length; j++)
                {
                    result[j] = this.Universities[j];
                }
                this.Universities = result;
                Console.WriteLine("Готово!");
            }
            catch
            {
                Console.WriteLine("ВУЗ не найден!");
            }
        }
        public int UniCount()
        {
            return Universities.Length;
        }

        public void Info()
        {
            Console.WriteLine(" Город {0}, численность населения: {1}. Количество ВУЗов: {2}", Name, Population, UniCount());
            Console.Write(" Вузы:");
            for (int i = 0; i < UniCount(); i++)
            {
                Console.Write(" " + Universities[i].name);
            }
        }

        public void Rename() 
        {
            Console.WriteLine("Введите новое название города");
            this.Name = Console.ReadLine();
            Console.WriteLine("Готово!");
        }

        public void PopulationUpdate()
        {
            Console.WriteLine("Введите численность населения города");
            try
            {
                this.Population = int.Parse(Console.ReadLine());
                Console.WriteLine("Готово!");
            }
            catch
            {
                Console.WriteLine("Ошибка ввода!");
                Console.WriteLine("Нажмите любую клавишу для повторной попытки");
                Console.ReadKey();
                Console.Clear();
                PopulationUpdate();
            }
        }
    }

    class University
    {
        private string Name;
        private string DateOfCreation;
        private Speciality[] Specialities;

        public University()
        {
            Console.WriteLine("Введите название ВУЗа");
            this.Name = Console.ReadLine();
            Console.WriteLine("Введите дату создания");
            this.DateOfCreation = Console.ReadLine();
            Specialities = new Speciality[0];
        }

        public University(string Name, string DateOfCreation)
        {
            this.Name = Name;
            this.DateOfCreation = DateOfCreation;
            this.Specialities = new Speciality[0];
        }

        public string name 
        {
            get { return this.Name; }
            set { this.Name = value; }
        }

        public string dateOfCreation
        {
            get { return this.DateOfCreation; }
            set { this.DateOfCreation = value; }
        }

        public Speciality[] specialities
        {
            get { return this.Specialities; }
            set { this.Specialities = value; }
        }

        public void Add() 
        {
            int N = Specialities.Length + 1;
            Array.Resize(ref Specialities, N);
            Specialities[N - 1] = new Speciality();
        }

        public void Remove()
        {
            Console.Clear();
            Console.WriteLine("Введите полное название удаляемой специальности (можно просто трёхзначный код)");
            string SpecDel = Console.ReadLine();
            string pattern = @"\d{3}";
            Match match = Regex.Match(SpecDel, pattern);
            if (match.Success)
            {
                Speciality[] result = new Speciality[this.Specialities.Length - 1];
                int i = 0;
                try
                {
                    while (!this.Specialities[i].name.Contains(SpecDel))
                    {
                        result[i] = this.Specialities[i];
                        i = i + 1;
                    }
                    for (int j = i + 1; j < result.Length; j++)
                    {
                        result[j] = this.Specialities[i];
                    }
                    this.Specialities = result;
                    Console.WriteLine("Готово!");
                }
                catch
                {
                    Console.WriteLine("Специальность не найдена!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода!");
                Console.WriteLine("Для повторной попытки нажмите любую клавишу");
                Console.ReadKey();
                Remove();
            }
        }

        public int SpecCount()
        {
            return Specialities.Length;
        }

        public void Info() 
        {
            Console.WriteLine("ВУЗ {0}, дата создания: {1}. Количество специальностей: {2}", Name, DateOfCreation, SpecCount());
            Console.WriteLine("Специальности:");
            for (int i = 0; i < SpecCount(); i++)
            {
                Console.WriteLine("{0}# {1}", i+1, Specialities[i].name);
            }
        }

        public void Rename()
        {
            Console.WriteLine("Введите новое название ВУЗа");
            this.Name = Console.ReadLine();
            Console.WriteLine("Готово!");
        }
    }

    class Speciality
    {
        private string Name;
        private string DateOfCreation;
        private Student[] Students;

        public Speciality() 
        {
            Console.WriteLine("Введите название специальности");
            this.Name = Console.ReadLine();
            Console.WriteLine("Введите дату открытия специальности");
            this.DateOfCreation = Console.ReadLine();
            this.Students = new Student[0];
        }

        public Speciality(string Name, string DateOfCreation) 
        {
            this.Name = Name;
            this.DateOfCreation = DateOfCreation;
            this.Students = new Student[0];
        }

        public string name
        {
            get { return this.Name; }
            set { this.Name = value; }
        }

        public string dateOfCreation
        {
            get { return this.DateOfCreation; }
            set { this.DateOfCreation = value; }
        }

        public Student[] students
        {
            get { return this.Students; }
            set { this.Students = value; }
        }

        public void Add() 
        {
            int N = Students.Length + 1;
            Array.Resize(ref Students, N);
            Students[N - 1] = new Student();
        }

        public void Remove()
        {
            Console.Clear();
            Console.WriteLine("Введите ФИО удаляемого студента");
            string StudentDel = Console.ReadLine();
            Student[] result = new Student[this.students.Length - 1];
            int i = 0;
            try
            {
                while (StudentDel != this.Students[i].fio)
                {
                    result[i] = this.Students[i];
                    i = i + 1;
                }
                for (int j = i + 1; j < result.Length; j++)
                {
                    result[j] = this.Students[i];
                }
                this.Students = result;
                Console.WriteLine("Готово!");
            }
            catch
            {
                Console.WriteLine("Студент не найден!");
            }
        }

        public int StudentCount() 
        {
            return Students.Length;
        }

        public void Info()
        {
            Console.WriteLine("Специальность {0}, дата открытия: {1}. Количество студентов: {2}", Name, DateOfCreation, StudentCount());
            Console.WriteLine("Студенты:");
            for (int i = 0; i < StudentCount(); i++)
            {
                Console.WriteLine("{0}# {1}", i + 1, Students[i].fio);
            }
        }

        public void Rename()
        {
            Console.WriteLine("Введите новое название специальности");
            this.Name = Console.ReadLine();
            Console.WriteLine("Готово!");
        }
    }

    class Student
    {
        private string FIO;
        //private string Speciality;
        private string Address;

        public Student()
        {
            Console.WriteLine("Введите ФИО студента");
            this.FIO = Console.ReadLine();
            Console.WriteLine("Введите адрес студента");
            this.Address = Console.ReadLine();
        }

        public Student(string FIO, string Address)
        {
            this.FIO = FIO;
            this.Address = Address;
        }

        public string fio
        {
            get { return this.FIO; }
            set { this.FIO = value; }
        }

        public string address
        {
            get { return this.Address; }
            set { this.Address = value; }
        }

        public void Info() 
        {
            //info
            Console.WriteLine("Студент {0}, адрес: {1}.", FIO, Address);
        }

        public void Rename()
        {
            Console.WriteLine("Введите новые ФИО студента");
            this.FIO = Console.ReadLine();
            Console.WriteLine("Готово!");
        }

        public void AddressChange()
        {
            Console.WriteLine("Введите новый адрес студента");
            this.Address = Console.ReadLine();
            Console.WriteLine("Готово!");
        }
    }

    class Program
    {
        // main menu
        static void MainMenu() 
        {
            Console.Clear();
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓" +
                            "\n┃            Главное меню             ┃" +
                            "\n┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫" +
                            "\n┃1 - Создание нового списка городов   ┃" +
                            "\n┃2 - Загрузка списка городов из файла ┃" +
                            "\n┃3 - Выход из программы               ┃" +
                            "\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.Write("  Ваш выбор: ");
            try
            {
                int MenuVal = int.Parse(Console.ReadLine());
                switch (MenuVal)
                {
                    case 1:
                        KFill();
                        break;
                    case 2:
                        FFill();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        MainMenu();
                        break;
                }
            }
            catch { MainMenu(); }
        }

        static void KFill() 
        {
            Console.Clear();
            City[] Cities = new City[0];
            Console.WriteLine("Введите данные о городах в список. 0 - окончание ввода в список. Любая другая клавиша - новый город");
            while (Console.ReadLine() != "0") 
            {
                Array.Resize(ref Cities, Cities.Length + 1);
                Cities[Cities.Length - 1] = new City();
            }
            SubMenu1(Cities);
        }

        static void FFill()
        {
            Console.Clear();
            Console.WriteLine("Загрузка данных из файла...");

            if (File.Exists("Cities.txt") && File.Exists("Universities.txt") && File.Exists("Specialities.txt") && File.Exists("Students.txt"))
            {

                City[] Cities = new City[0];

                string[] CurrentCity;
                string[] CurrentUni;
                string[] CurrentSpec;
                string[] CurrentStudent;

                // Пришлось создать ещё и массивы объектов разных типов, так как нельзя передавать по ссылке свойство.
                University[] TempUniL;
                Speciality[] TempSpecL;
                Student[] TempStudentL;

                //Считываем данные о городах
                StreamReader CityIN = new StreamReader("Cities.txt");
                while (CityIN.Peek() > -1) 
                {
                    Array.Resize(ref Cities, Cities.Length + 1);
                    CurrentCity = CityIN.ReadLine().Split('-');
                    Cities[Cities.Length - 1] = new City(CurrentCity[0], int.Parse(CurrentCity[1]));
                }
                CityIN.Close();
                CityIN.Dispose();

                //Считываем данные о ВУЗах
                StreamReader UniIN = new StreamReader("Universities.txt");
                while (UniIN.Peek() > -1)
                {
                    CurrentUni = UniIN.ReadLine().Split('-');
                    for (int i = 0; i < Cities.Length; i++)
                    {
                        if (CurrentUni[0] == Cities[i].name) 
                        {
                            TempUniL = Cities[i].universities;
                            Array.Resize(ref TempUniL, TempUniL.Length + 1);
                            Cities[i].universities = TempUniL;
                            Cities[i].universities[TempUniL.Length - 1] = new University(CurrentUni[1], CurrentUni[2]);
                        }
                    }
                }
                UniIN.Close();

                //Считываем данные о специальностях
                StreamReader SpecIN = new StreamReader("Specialities.txt");
                while (SpecIN.Peek() > -1)
                {
                    CurrentSpec = SpecIN.ReadLine().Split('-');
                    for (int i = 0; i < Cities.Length; i++)
                    {
                        for (int j = 0; j < Cities[i].universities.Length; j++) 
                        {
                            if (CurrentSpec[0] == Cities[i].universities[j].name) 
                            {
                                TempSpecL = Cities[i].universities[j].specialities;
                                Array.Resize(ref TempSpecL, TempSpecL.Length + 1);
                                Cities[i].universities[j].specialities = TempSpecL;
                                Cities[i].universities[j].specialities[TempSpecL.Length - 1] = new Speciality(CurrentSpec[1], CurrentSpec[2]);
                            }
                        }
                    }

                }
                SpecIN.Close();

                //Считываем данные о студентах
                StreamReader StudentIN = new StreamReader("Students.txt");
                while (StudentIN.Peek() > -1)
                {
                    CurrentStudent = StudentIN.ReadLine().Split('-');
                    for (int i = 0; i < Cities.Length; i++)
                    {
                        for (int j = 0; j < Cities[i].universities.Length; j++)
                        {
                            for (int m = 0; m < Cities[i].universities[j].specialities.Length; m++) 
                            {
                                if (CurrentStudent[0] == Cities[i].universities[j].name) 
                                {
                                    if (CurrentStudent[1] == Cities[i].universities[j].specialities[m].name)
                                    {
                                        TempStudentL = Cities[i].universities[j].specialities[m].students;
                                        Array.Resize(ref TempStudentL, TempStudentL.Length + 1);
                                        Cities[i].universities[j].specialities[m].students = TempStudentL;
                                        Cities[i].universities[j].specialities[m].students[TempStudentL.Length - 1] = new Student(CurrentStudent[2], CurrentStudent[3]);
                                    }
                                }
                            }
                        }
                    }
                }
                StudentIN.Close();
                Console.WriteLine("Готово!");
                Program.SubMenu1(Cities);
            }
            else 
            {
                Console.WriteLine("Один или более файлов отсутсвуют!");
                Console.WriteLine("Для возврата нажмите любую клавишу");
                Console.ReadKey();
                MainMenu();
            }
        }

        static void FSave(City[] Cities) 
        {
            Console.Clear();
            Console.WriteLine("Сохранение данных...");

            //сохраняем список городов
            Console.WriteLine("Сохранение списка городов...");
            StreamWriter CityOUT = new StreamWriter("Cities.txt", false);
            for (int i = 0; i < Cities.Length; i++) 
            {
                CityOUT.WriteLine("{0}-{1}", Cities[i].name, Cities[i].population);
                // отладочная строка
                //Console.WriteLine("{0}-{1}", Cities[i].name, Cities[i].population);
            }
            CityOUT.Close();
            Console.WriteLine("Готово!");

            //сохраняем ВУЗы
            Console.WriteLine("Сохранение ВУЗов...");
            StreamWriter UniOUT = new StreamWriter("Universities.txt");
            for (int i = 0; i < Cities.Length; i++)
            {
                for (int j = 0; j < Cities[i].universities.Length; j++)
                {
                    UniOUT.WriteLine("{0}-{1}-{2}", Cities[i].name, Cities[i].universities[j].name, Cities[i].universities[j].dateOfCreation);
                    // отладочная строка
                    //Console.WriteLine("{0}-{1}-{2}", Cities[i].name, Cities[i].universities[j].name, Cities[i].universities[j].dateOfCreation);
                }
            }
            UniOUT.Close();
            Console.WriteLine("Готово!");

            //сохраняем специальности
            Console.WriteLine("Сохранение специальностей...");
            StreamWriter SpecOUT = new StreamWriter("Specialities.txt");
            for (int i = 0; i < Cities.Length; i++)
            {
                for (int j = 0; j < Cities[i].universities.Length; j++)
                {
                    for(int m = 0; m < Cities[i].universities[j].specialities.Length; m++)
                    {
                        SpecOUT.WriteLine("{0}-{1}-{2}", Cities[i].universities[j].name, Cities[i].universities[j].specialities[m].name, Cities[i].universities[j].specialities[m].dateOfCreation);
                        // отладочная строка
                        //Console.WriteLine("{0}-{1}-{2}", Cities[i].universities[j].name, Cities[i].universities[j].specialities[m].name, Cities[i].universities[j].specialities[m].dateOfCreation);
                    }
                }
            }
            SpecOUT.Close();
            Console.WriteLine("Готово!");

            //сохраняем студентов
            Console.WriteLine("Сохранение студентов...");
            StreamWriter StudentOUT = new StreamWriter("Students.txt");
            for (int i = 0; i < Cities.Length; i++)
            {
                for (int j = 0; j < Cities[i].universities.Length; j++)
                {
                    for (int m = 0; m < Cities[i].universities[j].specialities.Length; m++)
                    {
                        for (int n = 0; n < Cities[i].universities[j].specialities[m].students.Length; n++)
                        {
                            StudentOUT.WriteLine("{0}-{1}-{2}-{3}", Cities[i].universities[j].name, Cities[i].universities[j].specialities[m].name, Cities[i].universities[j].specialities[m].students[n].fio, Cities[i].universities[j].specialities[m].students[n].address);
                            // отладочная строка
                            //Console.WriteLine("{0}-{1}-{2}-{3}", Cities[i].universities[j].name, Cities[i].universities[j].specialities[m].name, Cities[i].universities[j].specialities[m].students[n].fio, Cities[i].universities[j].specialities[m].students[n].address);
                        }
                    }
                }
            }
            StudentOUT.Close();
            Console.WriteLine("Готово!");

            Console.WriteLine("ДАННЫЕ СОХРАНЕНЫ");
            Console.WriteLine("Для возврата нажмите любую клавишу");
            Console.ReadKey();
            SubMenu1(Cities);
        }

        static void SSearch(City[] Cities)
        {
            Console.Clear();
            Console.WriteLine("ПОИСК ВУЗОВ С ЗАДАННОЙ СПЕЦИАЛЬНОСТЬЮ");
            Console.WriteLine("Введите полное название специальности (можно просто трёхзначный код)");
            string InputString = Console.ReadLine();
            string pattern = @"\d{3}";
            Match match = Regex.Match(InputString, pattern);
            if (match.Success)
            {
                bool SearchFlag = false;
                Console.WriteLine();
                Console.WriteLine("НАЙДЕННЫЕ ВУЗЫ:");
                Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                for (int i = 0; i < Cities.Length; i++)
                {
                    for (int j = 0; j < Cities[i].universities.Length; j++) 
                    {
                        for (int m = 0; m < Cities[i].universities[j].specialities.Length; m++) 
                        {
                            if (Cities[i].universities[j].specialities[m].name.Contains(match.Value)) 
                            {
                                Console.WriteLine("  ВУЗ: {0}. Город: {1}", Cities[i].universities[j].name, Cities[i].name);
                                Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
                                SearchFlag = true;
                            }
                        }
                    }
                }
                if (SearchFlag == false)
                {
                    Console.WriteLine("  ВУЗы с заданной специальностью не найдены");
                }
                Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Console.WriteLine("Для возврата нажмите любую клавишу");
                Console.ReadKey();
            }
            else 
            {
                Console.WriteLine("Ошибка ввода!");
                Console.WriteLine("Для повторной попытки нажмите любую клавишу");
                Console.ReadKey();
                SSearch(Cities);
            }
        }

        static void SubMenu1(City[] Cities) 
        {
            Console.Clear();
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓" +
                            "\n┃     Просмотр и редактирование списка городов     ┃" +
                            "\n┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫" +
                            "\n┃1 - Вывести список городов на экран               ┃" +
                            "\n┃2 - Просмотр и редактирование информации о городе ┃" +
                            "\n┃3 - Добавить город                                ┃" +
                            "\n┃4 - Удалить город                                 ┃" +
                            "\n┃5 - Сохранить все данные в файлы                  ┃" +
                            "\n┃6 - Поиск ВУЗов с заданной специальностью         ┃" +
                            "\n┃7 - Вернуться в главное меню                      ┃" +
                            "\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛" +
                            "\n" +
                            "\nВАЖНО: НЕ ЗАБУДЬТЕ ВЕРНУТЬСЯ В ЭТО ПОДМЕНЮ ДЛЯ СОХРАНЕНИЯ ИЗМЕНЕНИЙ (пункт 5) ПЕРЕД ВЫХОДОМ ИЗ ПРОГРАММЫ!");
            Console.Write("  Ваш выбор: ");
            try
            {
                int MenuVal = int.Parse(Console.ReadLine());
                switch (MenuVal)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                            for (int i = 0; i < Cities.Length; i++)
                            {
                                Cities[i].Info();
                                Console.WriteLine();
                                Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
                            }
                            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu1(Cities);
                        };
                        break;
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите название города");
                            string FName = Console.ReadLine();
                            bool SearchFlag = false;
                            for (int i = 0; i < Cities.Length; i++)
                            {
                                if (Cities[i].name == FName)
                                {
                                    SubMenu2(Cities[i], Cities);
                                    SearchFlag = true;
                                }
                            }
                            if (SearchFlag == false)
                            {
                                Console.WriteLine("Город не найден!");
                                Console.WriteLine("Для возврата нажмите любую клавишу");
                                Console.ReadKey();
                                SubMenu1(Cities);
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            Array.Resize(ref Cities, Cities.Length + 1);
                            Cities[Cities.Length - 1] = new City();
                            Console.WriteLine("Готово!");
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu1(Cities);
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите название удаляемого города");
                            string CityDel = Console.ReadLine();
                            City[] result = new City[Cities.Length - 1];
                            int i = 0;
                            try
                            {
                                while (CityDel != Cities[i].name)
                                {
                                    result[i] = Cities[i];
                                    i = i + 1;
                                }
                                for (int j = i + 1; j < result.Length; j++)
                                {
                                    result[j] = Cities[i];
                                }
                                Cities = result;
                                Console.WriteLine("Готово!");
                                Console.WriteLine("Для возврата нажмите любую клавишу");
                                Console.ReadKey();
                                SubMenu1(Cities);
                            }
                            catch
                            {
                                Console.WriteLine("Город не найден!");
                                Console.WriteLine("Для возврата нажмите любую клавишу");
                                Console.ReadKey();
                                SubMenu1(Cities);
                            }
                        }
                        break;
                    case 5:
                        {
                            FSave(Cities);
                            SubMenu1(Cities);
                        }
                        break;
                    case 6:
                        {
                            SSearch(Cities);
                            SubMenu1(Cities);
                        }
                        break;
                    case 7:
                        {
                            MainMenu();
                        }
                        break;
                    default:
                        SubMenu1(Cities);
                        break;
                }
            }
            catch { SubMenu1(Cities); }
        }

        static void SubMenu2(City CurrentCity, City[] Cities) 
        {
            Console.Clear();
            Console.WriteLine("ГОРОД: {0}", CurrentCity.name);
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓" +
                            "\n┃    Просмотр и редактирование информации о городе    ┃" +
                            "\n┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫" +
                            "\n┃1 - Вывод информации о городе                        ┃" +
                            "\n┃2 - Переименовать                                    ┃" +
                            "\n┃3 - Обновить данные о численности населения          ┃" +
                            "\n┃4 - Просмотр и редактирование информации о ВУЗе      ┃" +
                            "\n┃5 - Добавить ВУЗ                                     ┃" +
                            "\n┃6 - Удалить ВУЗ                                      ┃" +
                            "\n┃7 - Назад                                            ┃" +
                            "\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.Write("  Ваш выбор: ");
            try
            {
                int MenuVal = int.Parse(Console.ReadLine());
                switch (MenuVal)
                {
                    case 1:
                        {
                            Console.Clear();
                            CurrentCity.Info();
                            Console.WriteLine();
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu2(CurrentCity, Cities);
                        }
                        break;
                    case 2:
                        {
                            Console.Clear();
                            CurrentCity.Rename();
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu2(CurrentCity, Cities);
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            CurrentCity.PopulationUpdate();
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu2(CurrentCity, Cities);
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите название ВУЗа");
                            bool SearchFlag = false;
                            string FName = Console.ReadLine();
                            for (int i = 0; i < CurrentCity.universities.Length; i++)
                            {
                                if (CurrentCity.universities[i].name == FName)
                                {
                                    SubMenu3(CurrentCity.universities[i], CurrentCity, Cities);
                                    SearchFlag = true;
                                }
                            }
                            if (SearchFlag == false)
                            {
                                Console.WriteLine("ВУЗ не найден!");
                                Console.WriteLine("Для возврата нажмите любую клавишу");
                                Console.ReadKey();
                                SubMenu2(CurrentCity, Cities);
                            }
                        }
                        break;
                    case 5:
                        {
                            Console.Clear();
                            CurrentCity.Add();
                            Console.WriteLine("Готово!");
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu2(CurrentCity, Cities);
                        }
                        break;
                    case 6:
                        {
                            CurrentCity.Remove();
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu2(CurrentCity, Cities);
                        }
                        break;
                    case 7:
                        {
                            SubMenu1(Cities);
                        }
                        break;
                    default:
                        SubMenu2(CurrentCity, Cities);
                        break;
                }
            }
            catch { SubMenu2(CurrentCity, Cities); }
        }

        static void SubMenu3(University CurrentUni, City CurrentCity, City[] Cities)
        {
            Console.Clear();
            Console.WriteLine("ВУЗ: {0}", CurrentUni.name);
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓" +
                            "\n┃   Просмотр и редактирование информации о ВУЗе           ┃" +
                            "\n┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫" +
                            "\n┃1 - Вывод информации о ВУЗе                              ┃" +
                            "\n┃2 - Переименовать                                        ┃" +
                            "\n┃3 - Просмотр и редактирование информации о специальности ┃" +
                            "\n┃4 - Добавить специальность                               ┃" +
                            "\n┃5 - Удалить специальность                                ┃" +
                            "\n┃6 - Назад                                                ┃" +
                            "\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.Write("  Ваш выбор: ");
            try
            {
                int MenuVal = int.Parse(Console.ReadLine());
                switch (MenuVal)
                {
                    case 1:
                        {
                            Console.Clear();
                            CurrentUni.Info();
                            Console.WriteLine();
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu3(CurrentUni, CurrentCity, Cities);
                        };
                        break;
                    case 2:
                        {
                            Console.Clear();
                            CurrentUni.Rename();
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu3(CurrentUni, CurrentCity, Cities);
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите полное название удаляемой специальности (можно просто трёхзначный код)");
                            bool SearchFlag = false;
                            string pattern = @"\d{3}";
                            string InputString = Console.ReadLine();
                            Match match = Regex.Match(InputString, pattern);
                            if (match.Success)
                            {
                                for (int i = 0; i < CurrentUni.specialities.Length; i++)
                                {
                                    if (CurrentUni.specialities[i].name.Contains(match.Value))
                                    {
                                        SubMenu4(CurrentUni.specialities[i], CurrentUni, CurrentCity, Cities);
                                        SearchFlag = true;
                                    }
                                }
                                if (SearchFlag == false)
                                {
                                    Console.WriteLine("Специальность не найдена!");
                                    Console.WriteLine("Для возврата нажмите любую клавишу");
                                    Console.ReadKey();
                                    SubMenu3(CurrentUni, CurrentCity, Cities);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка ввода!");
                                Console.WriteLine("Для возврата нажмите любую клавишу");
                                Console.ReadKey();
                                SubMenu3(CurrentUni, CurrentCity, Cities);
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            CurrentUni.Add();
                            Console.WriteLine("Готово!");
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu3(CurrentUni, CurrentCity, Cities);
                        }
                        break;
                    case 5:
                        {
                            CurrentUni.Remove();
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu3(CurrentUni, CurrentCity, Cities);
                        }
                        break;
                    case 6:
                        {
                            SubMenu2(CurrentCity, Cities);
                        }
                        break;
                    default:
                        SubMenu3(CurrentUni, CurrentCity, Cities);
                        break;
                }
            }
            catch { SubMenu3(CurrentUni, CurrentCity, Cities); }
        }

        static void SubMenu4(Speciality CurrentSpec, University CurrentUni, City CurrentCity, City[] Cities)
        {
            Console.Clear();
            Console.WriteLine("СПЕЦИАЛЬНОСТЬ: {0}", CurrentSpec.name);
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓" +
                            "\n┃  Просмотр и редактирование информации о специальности   ┃" +
                            "\n┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫" +
                            "\n┃1 - Вывод информации о специальности                     ┃" +
                            "\n┃2 - Переименовать                                        ┃" +
                            "\n┃3 - Просмотр и редактирование информации о студенте      ┃" +
                            "\n┃4 - Добавить студента                                    ┃" +
                            "\n┃5 - Удалить студента                                     ┃" +
                            "\n┃6 - Назад                                                ┃" +
                            "\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.Write("  Ваш выбор: ");
            try
            {
                int MenuVal = int.Parse(Console.ReadLine());
                switch (MenuVal)
                {
                    case 1:
                        {
                            Console.Clear();
                            CurrentSpec.Info();
                            Console.WriteLine();
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu4(CurrentSpec, CurrentUni, CurrentCity, Cities);
                        };
                        break;
                    case 2:
                        {
                            Console.Clear();
                            CurrentSpec.Rename();
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu4(CurrentSpec, CurrentUni, CurrentCity, Cities);
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите ФИО студента");
                            bool SearchFlag = false;
                            string FName = Console.ReadLine();
                            for (int i = 0; i < CurrentSpec.students.Length; i++)
                            {
                                if (CurrentSpec.students[i].fio == FName)
                                {
                                    SubMenu5(CurrentSpec.students[i], CurrentSpec, CurrentUni, CurrentCity, Cities);
                                    SearchFlag = true;
                                }
                            }
                            if (SearchFlag == false)
                            {
                                Console.WriteLine("Студент не найден!");
                                Console.WriteLine("Для возврата нажмите любую клавишу");
                                Console.ReadKey();
                                SubMenu4(CurrentSpec, CurrentUni, CurrentCity, Cities);
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            CurrentSpec.Add();
                            Console.WriteLine("Готово!");
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu4(CurrentSpec, CurrentUni, CurrentCity, Cities);
                        }
                        break;
                    case 5:
                        {
                            CurrentSpec.Remove();
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu4(CurrentSpec, CurrentUni, CurrentCity, Cities);
                        }
                        break;
                    case 6:
                        {
                            SubMenu3(CurrentUni, CurrentCity, Cities);
                        }
                        break;
                    default:
                        SubMenu4(CurrentSpec, CurrentUni, CurrentCity, Cities);
                        break;
                }
            }
            catch { SubMenu4(CurrentSpec, CurrentUni, CurrentCity, Cities); }
        }

        static void SubMenu5(Student CurrentStudent, Speciality CurrentSpec, University CurrentUni, City CurrentCity, City[] Cities)
        {
            Console.Clear();
            Console.WriteLine("СТУДЕНТ: {0}", CurrentStudent.fio);
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓" +
                            "\n┃     Просмотр и редактирование информации о студенте     ┃" +
                            "\n┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫" +
                            "\n┃1 - Вывод информации о студенте                          ┃" +
                            "\n┃2 - Переименовать                                        ┃" +
                            "\n┃3 - Изменить адрес                                       ┃" +
                            "\n┃4 - Назад                                                ┃" +
                            "\n┃5 - Вернуться к просмотру списка городов                 ┃" +
                            "\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.Write("  Ваш выбор: ");
            try
            {
                int MenuVal = int.Parse(Console.ReadLine());
                switch (MenuVal)
                {
                    case 1:
                        {
                            Console.Clear();
                            CurrentStudent.Info();
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu5(CurrentStudent, CurrentSpec, CurrentUni, CurrentCity, Cities);
                        };
                        break;
                    case 2:
                        {
                            Console.Clear();
                            CurrentStudent.Rename();
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu5(CurrentStudent, CurrentSpec, CurrentUni, CurrentCity, Cities);
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            CurrentStudent.AddressChange();
                            Console.WriteLine("Для возврата нажмите любую клавишу");
                            Console.ReadKey();
                            SubMenu5(CurrentStudent, CurrentSpec, CurrentUni, CurrentCity, Cities);
                        }
                        break;
                    case 4:
                        {
                            SubMenu4(CurrentSpec, CurrentUni, CurrentCity, Cities);
                        }
                        break;
                    case 5:
                        {
                            SubMenu1(Cities);
                        }
                        break;
                    default:
                        SubMenu5(CurrentStudent, CurrentSpec, CurrentUni, CurrentCity, Cities);
                        break;
                }
            }
            catch { SubMenu5(CurrentStudent, CurrentSpec, CurrentUni, CurrentCity, Cities); }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
                MainMenu();
        }
    }
}