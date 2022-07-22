using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

namespace LB5_Dataset
{
    class Program
    {
        static void Main(string[] args)
        {
            string ConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"F:\Учебные документы Жени\Базы данных\Сессия.accdb";
            DataSet Session = new DataSet();
            OleDbDataAdapter StudOffsetPass = new OleDbDataAdapter("SELECT Студенты.ШифрСтудента, Студенты.ФИО, Студенты.Курс, Студенты.Группа, Зачёты.Зачёт " +
                                   "FROM Студенты INNER JOIN Зачёты ON Студенты.ШифрСтудента = Зачёты.ШифрСтудента " +
                                   "WHERE Зачёты!Зачёт = True;", ConnStr);
            StudOffsetPass.Fill(Session, "StudOffsetPassTable");
            OleDbCommandBuilder SessionOpBuild = new OleDbCommandBuilder(StudOffsetPass);
            Console.WriteLine("{0, 12}{1, 12}{2, 5}{3, 8}{4, 10}", Session.Tables[0].Columns[0].Caption, Session.Tables[0].Columns[1].Caption, Session.Tables[0].Columns[2].Caption, Session.Tables[0].Columns[3].Caption, Session.Tables[0].Columns[4].Caption);
            Console.WriteLine();
                for (int j = 0; j < Session.Tables["StudOffsetPassTable"].Rows.Count; j++)
                {
                    Console.WriteLine("{0, 12}{1, 12}{2, 5}{3, 8}{4, 10}", Session.Tables[0].Rows[j][0], Session.Tables[0].Rows[j][1], Session.Tables[0].Rows[j][2], Session.Tables[0].Rows[j][3], Session.Tables[0].Rows[j][4]);
                    Console.WriteLine();
                }
            Console.ReadKey();
        }
    }
}
