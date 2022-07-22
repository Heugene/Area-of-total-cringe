using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDataXD
{
    class DateEX {
        byte day;
        byte month;
        int year;

        public DateEX(byte D, byte M, int Y) {
            this.day = D;
            this.month = M;
            this.year = Y;
        }

        public void Print() {
            Console.WriteLine(day+"."+month+"."+year);
        }

        private bool VYear() {
            if (this.year % 4 == 0)
            {
                if (this.year % 100 == 0)
                {
                    if (this.year % 400 == 0)
                    { return true; }
                    else { return false; }
                }
                else { return true; }
            }
            else { return false; }
        }

        public byte MCapacity {
            switch (month) {
            case 01 31              // 01/03/05/07/08/10/12 = 31
            case 02 2829            // 02 = 28-29
            case 03 31              // 04/06/09/11 = 30
            case 04 30
            case 05 31
            case 06 30
            case 07 31
            case 08 31
            case 09 30
            case 10 31
            case 11 30
            case 12 31
        }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DateEX Date1 = new DateEX(12, 03, 2004);
            Date1.Print();
        }
    }
}
