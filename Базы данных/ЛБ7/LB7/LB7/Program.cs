using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

namespace LB7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Подключение
            OleDbConnection Connect = new OleDbConnection();
            Connect.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"D:\Учебные документы Жени\Базы данных\Сессия.accdb";

            //Создаём датасет и адаптеры для связываемых таблиц
            DataSet Session = new DataSet();
            OleDbDataAdapter SubDA = new OleDbDataAdapter("SELECT * FROM Дисциплины", Connect.ConnectionString);
            OleDbDataAdapter EkzDA = new OleDbDataAdapter("SELECT * FROM Экзамены", Connect.ConnectionString);
            OleDbDataAdapter StudDA = new OleDbDataAdapter("SELECT * FROM Студенты", Connect.ConnectionString);

            SubDA.Fill(Session, "Дисциплины");
            EkzDA.Fill(Session, "Экзамены");
            StudDA.Fill(Session, "Студенты");

            //Связываем таблицы
            DataRelation SubEkz = Session.Relations.Add("Дисц+Экз", Session.Tables["Дисциплины"].Columns["ШифрДисциплины"], Session.Tables["Экзамены"].Columns["ШифрДисциплины"]);
            DataRelation StudEkz = Session.Relations.Add("Студ+Экз", Session.Tables["Студенты"].Columns["ШифрСтудента"], Session.Tables["Экзамены"].Columns["ШифрСтудента"]);
            //Пробуем вывести эту дичь
            
            foreach (DataRow SubRow in Session.Tables["Дисциплины"].Rows)
            {
                int i = 0;
                Console.WriteLine(SubRow["Название"]);
                foreach (DataRow EkzRow in SubRow.GetChildRows(SubEkz))
                {

                    Console.WriteLine("\t"+["ФИО"] + " " + EkzRow["Оценка"]);
                    i++;
                }
            }
            

            Console.ReadKey();
        }
    }
}
