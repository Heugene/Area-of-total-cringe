using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace LB6
{
    class Program
    {
        static void Main(string[] args)
        {
            string SessionConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"D:\Учебные документы Жени\Базы данных\Сессия.accdb";
            DataSet Session = new DataSet();
            OleDbConnection SessionConnect = new OleDbConnection(SessionConnStr);

            OleDbDataAdapter dA_StudAge = new OleDbDataAdapter("SELECT Студенты.ШифрСтудента, Студенты.ФИО, Студенты.Курс, Студенты.Группа, Студенты.ДатаРождения, DateDiff('yyyy',[Студенты]![ДатаРождения],Date()) AS Возраст FROM Студенты;", SessionConnStr);
            //dA_StudAge = new OleDbDataAdapter("SELECT Студенты.ШифрСтудента, Студенты.ФИО, Студенты.Курс, Студенты.Группа, Студенты.ДатаРождения, DateDiff('yyyy',[Студенты]![ДатаРождения],Date()) AS Возраст FROM Студенты WHERE (((DateDiff('yyyy',[Студенты]![ДатаРождения],Date()))=21)) OR (((DateDiff('yyyy',[Студенты]![ДатаРождения],Date()))=20));", SessionConnStr);
            OleDbCommandBuilder SessionOp1Build = new OleDbCommandBuilder(dA_StudAge);
            dA_StudAge.UpdateCommand = SessionOp1Build.GetUpdateCommand();
            dA_StudAge.DeleteCommand = SessionOp1Build.GetDeleteCommand();
            dA_StudAge.InsertCommand = SessionOp1Build.GetInsertCommand();
            dA_StudAge.Fill(Session);
            dA_StudAge = new OleDbDataAdapter("SELECT Студенты.ШифрСтудента, Студенты.ФИО, Студенты.Курс, Студенты.Группа, Студенты.ДатаРождения, DateDiff('yyyy',[Студенты]![ДатаРождения],Date()) AS Возраст FROM Студенты WHERE (((DateDiff('yyyy',[Студенты]![ДатаРождения],Date()))=21)) OR (((DateDiff('yyyy',[Студенты]![ДатаРождения],Date()))=20));", SessionConnStr);
            Console.WriteLine("Запрос 1. Вывод содержимого таблицы Студенты с вычисляемым полем возраста");
            Console.WriteLine("{0, 12} {1,7} {2, 7} {3, 6} {4, 15} {5, 14} ", "ШифрСтудента", "ФИО", "Курс", "Группа", "ДатаРождения", "Возраст");
            for (int i = 0; i < Session.Tables[0].Rows.Count; i++)
            {
                //Console.WriteLine(i);
                Console.WriteLine("{0, 8} {1, 12} {2, 4} {3, 6} {4, 22} {5, 5}", Session.Tables[0].Rows[i][0], Session.Tables[0].Rows[i][1], Session.Tables[0].Rows[i][2], Session.Tables[0].Rows[i][3], Session.Tables[0].Rows[i][4], Session.Tables[0].Rows[i][5]);
            }

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            OleDbDataAdapter dA1_StudAge = new OleDbDataAdapter("SELECT Студенты.ШифрСтудента, Студенты.ФИО, Студенты.Курс, Студенты.Группа, Студенты.ДатаРождения, DateDiff('yyyy',[Студенты]![ДатаРождения],Date()) AS Возраст FROM Студенты WHERE (((DateDiff('yyyy',[Студенты]![ДатаРождения],Date()))=21)) OR (((DateDiff('yyyy',[Студенты]![ДатаРождения],Date()))=20));", SessionConnStr);
            OleDbCommandBuilder SessionOp2Build = new OleDbCommandBuilder(dA1_StudAge);
            dA1_StudAge.UpdateCommand = SessionOp2Build.GetUpdateCommand();
            dA1_StudAge.DeleteCommand = SessionOp2Build.GetDeleteCommand();
            dA1_StudAge.InsertCommand = SessionOp2Build.GetInsertCommand();
            DataSet Session1 = new DataSet();
            dA1_StudAge.Fill(Session1);

            Console.WriteLine("Запрос 2. Вывод содержимого таблицы Студенты с вычисляемым полем возраста (=20 или =21)");
            Console.WriteLine("{0, 12} {1,7} {2, 7} {3, 6} {4, 15} {5, 14} ", "ШифрСтудента", "ФИО", "Курс", "Группа", "ДатаРождения", "Возраст");
            for (int i = 0; i < Session1.Tables[0].Rows.Count; i++)
            {
                //Console.WriteLine(i);
                Console.WriteLine("{0, 8} {1, 12} {2, 4} {3, 6} {4, 22} {5, 5}", Session1.Tables[0].Rows[i][0], Session1.Tables[0].Rows[i][1], Session1.Tables[0].Rows[i][2], Session1.Tables[0].Rows[i][3], Session1.Tables[0].Rows[i][4], Session1.Tables[0].Rows[i][5]);
            }
            Console.ReadKey();
        }
    }
}


// создать новый датасет для 2 запроса