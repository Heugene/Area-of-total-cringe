using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace LB3
{
    class Program
    {
        public static void StudentPrint(OleDbConnection SessionConnect)
        {
            Console.Clear();
            OleDbCommand cmd1 = SessionConnect.CreateCommand();
            cmd1.CommandText = "SELECT * FROM Студенты";
            OleDbDataReader StudReader = cmd1.ExecuteReader();
            Console.WriteLine("{0, -6} {1, -15} {2, 4} {3, -4}", "Шифр", "ФИО", "Курс", "Группа");
            while (StudReader.Read())
            {
                Console.WriteLine("{0, -6} {1, -15} {2, -4} {3, -4}", StudReader["ШифрСтудента"], StudReader["ФИО"], StudReader["Курс"], StudReader["Группа"]);
            }

            Console.WriteLine("");
            Console.WriteLine("Для выхода нажмите любую клавишу");
            Console.ReadKey();
            Menu(SessionConnect);
        }

        public static void SubjectPrint(OleDbConnection SessionConnect)
        {
            Console.Clear();
            OleDbCommand cmd1 = SessionConnect.CreateCommand();
            cmd1.CommandText = "SELECT * FROM Дисциплины";
            OleDbDataReader StudReader = cmd1.ExecuteReader();
            Console.WriteLine("{0, -6} {1, -30} {2, 4}", "Шифр", "Название", "Часов:");
            while (StudReader.Read())
            {
                Console.WriteLine("{0, -6} {1, -30} {2, -4}", StudReader["ШифрДисциплины"], StudReader["Название"], StudReader["КоличествоЧасов"]);
            }

            Console.WriteLine("");
            Console.WriteLine("Для выхода нажмите любую клавишу");
            Console.ReadKey();
            Menu(SessionConnect);
        }

        public static void OffsetPrint(OleDbConnection SessionConnect)
        {
            Console.Clear();
            OleDbCommand cmd1 = SessionConnect.CreateCommand();
            cmd1.CommandText = "SELECT * FROM Зачёты";
            OleDbDataReader StudReader = cmd1.ExecuteReader();
            Console.WriteLine("{0, -6} {1, -7} {2, 4} {3, 24} {4, 4}", "Код", "ШифрСт", "Дата", "ШифрДисц", "Зачёт");
            while (StudReader.Read())
            {
                Console.WriteLine("{0, -6} {1, -7} {2, 4} {3, 6} {4, 10}", StudReader["Код"], StudReader["ШифрСтудента"], StudReader["Дата"].ToString(), StudReader["ШифрДисциплины"], StudReader["Зачёт"]);
            }

            Console.WriteLine("");
            Console.WriteLine("Для выхода нажмите любую клавишу");
            Console.ReadKey();
            Menu(SessionConnect);
        }

        public static void ExamPrint(OleDbConnection SessionConnect)
        {
            Console.Clear();
            OleDbCommand cmd1 = SessionConnect.CreateCommand();
            cmd1.CommandText = "SELECT * FROM Экзамены";
            OleDbDataReader StudReader = cmd1.ExecuteReader();
            Console.WriteLine("{0, -6} {1, -7} {2, 4} {3, 24} {4, 10}", "Код", "ШифрСт", "Дата", "ШифрДисц", "Оценка");
            while (StudReader.Read())
            {
                Console.WriteLine("{0, -6} {1, -7} {2, 4} {3, 6} {4, 10}", StudReader["Код"], StudReader["ШифрСтудента"], StudReader["Дата"].ToString(), StudReader["ШифрДисциплины"], StudReader["Оценка"]);
            }

            Console.WriteLine("");
            Console.WriteLine("Для выхода нажмите любую клавишу");
            Console.ReadKey();
            Menu(SessionConnect);
        }

        public static void StudentSortFam(OleDbConnection SessionConnect)
        {
            Console.Clear();
            OleDbCommand cmd1 = SessionConnect.CreateCommand();
            cmd1.CommandText = "SELECT * FROM Студенты ORDER BY ФИО";
            OleDbDataReader StudReader = cmd1.ExecuteReader();
            Console.WriteLine("{0, -6} {1, -15} {2, 4} {3, -4}", "Шифр", "ФИО", "Курс", "Группа");
            while (StudReader.Read())
            {
                Console.WriteLine("{0, -6} {1, -15} {2, -4} {3, -4}", StudReader["ШифрСтудента"], StudReader["ФИО"], StudReader["Курс"], StudReader["Группа"]);
            }

            Console.WriteLine("");
            Console.WriteLine("Для выхода нажмите любую клавишу");
            Console.ReadKey();
            Menu(SessionConnect);
        }

        public static void StudentSortFamGroup(OleDbConnection SessionConnect)
        {
            Console.Clear();
            OleDbCommand cmd1 = SessionConnect.CreateCommand();
            cmd1.CommandText = "SELECT * FROM Студенты ORDER BY Группа, ФИО";
            OleDbDataReader StudReader = cmd1.ExecuteReader();
            Console.WriteLine("{0, -6} {1, -15} {2, 4} {3, -4}", "Шифр", "ФИО", "Курс", "Группа");
            while (StudReader.Read())
            {
                Console.WriteLine("{0, -6} {1, -15} {2, -4} {3, -4}", StudReader["ШифрСтудента"], StudReader["ФИО"], StudReader["Курс"], StudReader["Группа"]);
            }

            Console.WriteLine("");
            Console.WriteLine("Для выхода нажмите любую клавишу");
            Console.ReadKey();
            Menu(SessionConnect);
        }

        public static void StudExam4and5Print(OleDbConnection SessionConnect)
        {
            Console.Clear();
            OleDbCommand cmd1 = SessionConnect.CreateCommand();
            cmd1.CommandText = "SELECT Студенты.ШифрСтудента, Студенты.ФИО, Студенты.Курс, Студенты.Группа, Экзамены.Оценка " +
                                "FROM Студенты INNER JOIN Экзамены ON Студенты.ШифрСтудента = Экзамены.ШифрСтудента " +
                                "WHERE(([Экзамены]![Оценка] = 4 Or[Экзамены]![Оценка] = 5)); ";
            OleDbDataReader StudReader = cmd1.ExecuteReader();
            Console.WriteLine("{0, -6} {1, -15} {2, 4} {3, -4} {4, -6}", "Шифр", "ФИО", "Курс", "Группа", "Оценка");
            while (StudReader.Read())
            {
                Console.WriteLine("{0, -6} {1, -15} {2, -4} {3, -4} {4, 6}", StudReader["ШифрСтудента"], StudReader["ФИО"], StudReader["Курс"], StudReader["Группа"], StudReader["Оценка"]);
            }

            Console.WriteLine("");
            Console.WriteLine("Для выхода нажмите любую клавишу");
            Console.ReadKey();
            Menu(SessionConnect);
        }

        public static void StudOffsetPassOrNot(OleDbConnection SessionConnect)
        {
            Console.Clear();
            OleDbCommand cmd1 = SessionConnect.CreateCommand();
            Console.WriteLine("Сдавших - 1; Не сдавших - 0");
            cmd1.CommandText = "SELECT * FROM Студенты ORDER BY Группа, ФИО";
            string temp = Console.ReadLine();
            if (temp == "1")
            {
                cmd1.CommandText = "SELECT Студенты.ШифрСтудента, Студенты.ФИО, Студенты.Курс, Студенты.Группа, Зачёты.Зачёт " +
                                   "FROM Студенты INNER JOIN Зачёты ON Студенты.ШифрСтудента = Зачёты.ШифрСтудента " +
                                   "WHERE Зачёты!Зачёт = True;";
            }
            else if (temp == "0")
            {
                cmd1.CommandText = "SELECT Студенты.ШифрСтудента, Студенты.ФИО, Студенты.Курс, Студенты.Группа, Зачёты.Зачёт " +
                                   "FROM Студенты INNER JOIN Зачёты ON Студенты.ШифрСтудента = Зачёты.ШифрСтудента " +
                                   "WHERE Зачёты!Зачёт = False;";
            }
            OleDbDataReader StudReader = cmd1.ExecuteReader();
            Console.WriteLine("{0, -6} {1, -15} {2, 4} {3, -4} {4, 6}", "Шифр", "ФИО", "Курс", "Группа", "Зачёт");
            while (StudReader.Read())
            {
                Console.WriteLine("{0, -6} {1, -15} {2, -4} {3, -4} {4, 8}", StudReader["ШифрСтудента"], StudReader["ФИО"], StudReader["Курс"], StudReader["Группа"], StudReader["Зачёт"]);
            }

            Console.WriteLine("");
            Console.WriteLine("Для выхода нажмите любую клавишу");
            Console.ReadKey();
            Menu(SessionConnect);
        }

        public static void SubjectHoursSortDesc(OleDbConnection SessionConnect)
        {
            Console.Clear();
            OleDbCommand cmd1 = SessionConnect.CreateCommand();
            cmd1.CommandText = "SELECT * FROM Дисциплины ORDER BY КоличествоЧасов DESC";
            OleDbDataReader StudReader = cmd1.ExecuteReader();
            Console.WriteLine("{0, -6} {1, -30} {2, 4}", "Шифр", "Название", "Часов:");
            while (StudReader.Read())
            {
                Console.WriteLine("{0, -6} {1, -30} {2, -4}", StudReader["ШифрДисциплины"], StudReader["Название"], StudReader["КоличествоЧасов"]);
            }

            Console.WriteLine("");
            Console.WriteLine("Для выхода нажмите любую клавишу");
            Console.ReadKey();
            Menu(SessionConnect);
        }

        public static void SubjectInsertRec(OleDbConnection SessionConnect) 
        {
            Console.Clear();
            OleDbCommand cmd1 = SessionConnect.CreateCommand();
            Console.WriteLine("Вставка записи в таблицу Дисциплины");
            Console.WriteLine("Введите ШифрДисциплины формата 000");
            string Key = Console.ReadLine();
            Console.WriteLine("Введите Название");
            string Name = Console.ReadLine();
            Console.WriteLine("Введите Количество часов");
            int HCount = int.Parse(Console.ReadLine()); // поставить защиту
            cmd1.CommandText = "INSERT INTO Дисциплины (ШифрДисциплины, Название, КоличествоЧасов) VALUES ('"+Key+"', '"+Name+"', "+HCount+")";
            cmd1.ExecuteNonQuery();
            Console.WriteLine("Вывести содержимое обновлённой таблицы? (0 - Да. Любая другая клавиша - Нет)");
            if (Console.ReadLine() == "0")
            {
                SubjectPrint(SessionConnect);
            }    
            Console.WriteLine("Для выхода нажмите любую клавишу");
            Console.ReadKey();
            Menu(SessionConnect);
        }

        public static void StudentDeleteRec(OleDbConnection SessionConnect)
        {
            Console.Clear();
            OleDbCommand cmd1 = SessionConnect.CreateCommand();
            Console.WriteLine("Удаление записи из таблицы Студенты");
            Console.WriteLine("Введите ШифрCтудента формата 0А0000");
            //cmd1.CommandText = "DELETE FROM Студенты WHERE ШифрCтудента = '@Key';";
            string Key = Console.ReadLine();
            cmd1.CommandText = "DELETE Студенты.ШифрСтудента " +
                               "FROM Студенты " +
                               "WHERE(([Студенты]![ШифрСтудента] = '"+Key+"')); ";
            //cmd1.Parameters.Add("@Key", OleDbType.VarChar).Value = Console.ReadLine();
            //Console.WriteLine(cmd1.Parameters[0].Value);
            cmd1.ExecuteNonQuery();
            Console.WriteLine("Вывести содержимое обновлённой таблицы? (0 - Да. Любая другая клавиша - Нет)");
            if (Console.ReadLine() == "0")
            {
                StudentPrint(SessionConnect);
            }
            Console.WriteLine("Для выхода нажмите любую клавишу");
            Console.ReadKey();
            Menu(SessionConnect);
        }

        public static void SubjectHoursSum_MaxHrSub(OleDbConnection SessionConnect)
        {
            Console.Clear();
            OleDbCommand cmd1 = SessionConnect.CreateCommand();
            cmd1.CommandText = "SELECT SUM (КоличествоЧасов) AS H_Sum FROM Дисциплины";
            OleDbDataReader StudReader = cmd1.ExecuteReader();
            while (StudReader.Read())
            {
                Console.WriteLine("Суммарно часов: {0}", Convert.ToDouble(StudReader["H_Sum"]));
            }
            OleDbCommand cmd2 = SessionConnect.CreateCommand();
            cmd2.CommandText = "SELECT MAX(КоличествоЧасов) AS MAX_H_SUB FROM Дисциплины";
            StudReader = cmd2.ExecuteReader();
            while (StudReader.Read())
            {
                Console.WriteLine("Дисциплина с наибольшим количеством часов: {0}", Convert.ToDouble(StudReader["MAX_H_SUB"]));
            }
            Console.WriteLine("");
            Console.WriteLine("Для выхода нажмите любую клавишу");
            Console.ReadKey();
            Menu(SessionConnect);
        }

        public static void Menu(OleDbConnection SessionConnect) 
        {
            string MenuVal;
            Console.Clear();
            Console.WriteLine("Введите соотв. число для нужного действия");
            Console.WriteLine("01. Вывести список студентов"+
                            "\n02. Вывести список дисциплин"+
                            "\n03. Вывести список зачётов" +
                            "\n04. Вывести список экзаменов" +
                            "\n05. Отсортировать список студентов по фамилиям" +
                            "\n06. Отсортировать список по группам + фамилиям" +
                            "\n07. Отбор студентов, сдавших экзамены на 4 и 5" +
                            "\n08. Выборка студентов, сдавших или не сдавших зачёт" +
                            "\n09. Отсортировать список дисциплин по убыванию количества часов" +
                            "\n10. Вставить запись в таблицу Дисциплины" +
                            "\n11. Удалить запись из таблицы Студенты" +
                            "\n12. Подсчитать количество часов в таблице Дисциплины и вывести дисциплину с наибольшим количеством часов" +
                            "\nВВЕДИТЕ 000 ДЛЯ ВЫХОДА");
            MenuVal = Console.ReadLine();
            switch (MenuVal)
            {
                case "000":
                    {
                        SessionConnect.Close();
                        Environment.Exit(0);
                    }
                break;
                case "01":
                    { StudentPrint(SessionConnect); }
                break;
                case "02":
                    { SubjectPrint(SessionConnect); }
                break;
                case "03":
                    { OffsetPrint(SessionConnect); }
                break;
                case "04":
                    { ExamPrint(SessionConnect); }
                break;
                case "05":
                    { StudentSortFam(SessionConnect); }
                break;
                case "06":
                    { StudentSortFamGroup(SessionConnect); }
                break;
                case "07":
                    { StudExam4and5Print(SessionConnect); }
                break;
                case "08":
                    { StudOffsetPassOrNot(SessionConnect); }
                break;
                case "09":
                    { SubjectHoursSortDesc(SessionConnect); }
                break;
                case "10":
                    { SubjectInsertRec(SessionConnect); }
                break;
                case "11":
                    { StudentDeleteRec(SessionConnect); }
                break;
                case "12":
                    { SubjectHoursSum_MaxHrSub(SessionConnect); }
                break;
            }
        }
        static void Main(string[] args)
        {
            var SessionConnect = new OleDbConnection();
            SessionConnect.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"D:\Учебные документы Жени\Базы данных\ЛБ3\Сессия.accdb");
            //SessionConnect.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"F:\Учебные документы Жени\Базы данных\ЛБ3\Сессия.accdb");
            SessionConnect.Open();
            Menu(SessionConnect);
        }
    }
}
