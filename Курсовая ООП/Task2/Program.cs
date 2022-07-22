using System;
using System.IO;

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
            this.Population = int.Parse(Console.ReadLine()); // поставить защиту
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
                Console.Write(" " + Specialities[i].name);
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
                Console.Write(" " + Students[i].fio);
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
            Console.WriteLine();
            this.FIO = Console.ReadLine();
            Console.WriteLine();
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
                            "\n┃1 - Ввод списка городов с клавиатуры ┃" +
                            "\n┃2 - Загрузка списка городов из файла ┃" +
                            "\n┃3 - Сохранить список городов в файл  ┃" +
                            "\n┃4 - Выход из программы               ┃" +
                            "\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.Write("  Ваш выбор: ");
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
                   // FSave();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
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
            StreamReader filein = new StreamReader("тест.txt");
            City[] Cities = new City[0];
            string inputCity;
            string[] tempCity;
            string[] tempUniList;
            string[] tempUni;
            string[] tempSpecList;
            string[] tempSpec;
            string[] tempStudentList;
            string[] tempStudent;
            // пришлось создать ещё три массива объектов, чтобы убрать ошибку CS0206 (нельзя передавать свойства и индексаторы по ссылке)
            University[] CurrentUniList = new University[0];
            Speciality[] CurrentSpecList = new Speciality[0];
            Student[] CurrentStudentList = new Student[0];
            while (filein.Peek() > -1) 
            {
                inputCity = filein.ReadLine();
                tempCity = inputCity.Split('*');
                Array.Resize(ref Cities, Cities.Length + 1);
                Cities[Cities.Length - 1] = new City(tempCity[0], int.Parse(tempCity[1]));
                tempUniList = tempCity[2].Split('?');
                Array.Resize(ref CurrentUniList, tempUniList.Length);
                Cities[Cities.Length - 1].universities = CurrentUniList;
                    for (int i = 0; i < tempUniList.Length; i++) 
                    {
                        tempUni = tempUniList[i].Split('+');
                        Cities[Cities.Length - 1].universities[i] = new University(tempUni[0], tempUni[1]);
                        tempSpecList = tempUni[2].Split('-');
                        Array.Resize(ref CurrentSpecList, tempSpecList.Length);
                        Cities[Cities.Length - 1].universities[i].specialities = CurrentSpecList;
                            for (int j = 0; j < tempSpecList.Length; j++) 
                            {
                                tempSpec = tempSpecList[j].Split('#');
                                Cities[Cities.Length - 1].universities[i].specialities[j] = new Speciality(tempSpec[0], tempSpec[1]);
                                tempStudentList = tempSpec[2].Split('%');
                                Array.Resize(ref CurrentStudentList, tempStudentList.Length);
                                Cities[Cities.Length - 1].universities[i].specialities[j].students = CurrentStudentList;
                                    for (int m = 0; m < tempStudentList.Length; m++) 
                                        {
                                            tempStudent = tempStudentList[m].Split(':');
                                            Cities[Cities.Length - 1].universities[i].specialities[j].students[m] = new Student(tempStudent[0], tempStudent[1]);
                                        }
                            }
                    }
            }
            filein.Close();
            Console.WriteLine("Готово!");
            Program.SubMenu1(Cities);
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
                            "\n┃4 - Удалить город (НЕДОСТУПНО)                    ┃" +
                            "\n┃5 - Вернуться в главное меню                      ┃" +
                            "\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.Write("  Ваш выбор: ");
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
                        SubMenu1(Cities);
                    }
                    break;
                case 5:
                    {
                        MainMenu();
                    }
                    break;
            }
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
                            "\n┃3 - Просмотр и редактирование информации о ВУЗе      ┃" +
                            "\n┃4 - Добавить ВУЗ                                     ┃" +
                            "\n┃5 - Удалить ВУЗ (НЕДОСТУПНО)                         ┃" +
                            "\n┃6 - Назад                                            ┃" +
                            "\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.Write("  Ваш выбор: ");
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
                case 4:
                    {
                        Console.Clear();
                        CurrentCity.Add();
                        Console.WriteLine("Готово!");
                        Console.WriteLine("Для возврата нажмите любую клавишу");
                        Console.ReadKey();
                        SubMenu2(CurrentCity, Cities);
                    }
                    break;
                case 5:
                    {
                        SubMenu2(CurrentCity, Cities);
                    }
                    break;
                case 6:
                    {
                        SubMenu1(Cities);
                    }
                    break;
            }
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
                            "\n┃5 - Удалить специальность (НЕДОСТУПНО)                   ┃" +
                            "\n┃6 - Назад                                                ┃" +
                            "\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.Write("  Ваш выбор: ");
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
                        Console.WriteLine("Введите название Специальности");
                        bool SearchFlag = false;
                        string FName = Console.ReadLine();
                        for (int i = 0; i < CurrentUni.specialities.Length; i++)
                        {
                            if (CurrentUni.specialities[i].name == FName)
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
                        SubMenu3(CurrentUni, CurrentCity, Cities);
                    }
                    break;
                case 6:
                    {
                        SubMenu2(CurrentCity, Cities);
                    }
                    break;
            }
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
                            "\n┃5 - Удалить студента (НЕДОСТУПНО)                        ┃" +
                            "\n┃6 - Назад                                                ┃" +
                            "\n┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.Write("  Ваш выбор: ");
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
                        SubMenu4(CurrentSpec, CurrentUni, CurrentCity, Cities);
                    }
                    break;
                case 6:
                    {
                        SubMenu3(CurrentUni, CurrentCity, Cities);
                    }
                    break;
            }
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
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MainMenu();
            // сделать чтение из файла через многоуровневый сплит +
            // сделать запись в файл для сплита
            // придумать что-то с полем специальности для студента +
            // сделать красивое оформление вывода +
            // сделать защиту от долбаёба
            // сделать свойства для доступа к массивам +
            // сделать главное меню и несколько подменю +
            // перенести сохранение списка городов в подменю
            // исправить косяки вывода методов ИНФО
            // добавить в свитчи меню вызов меню при нажатии непредусмотренной цифры
        }
    }
}