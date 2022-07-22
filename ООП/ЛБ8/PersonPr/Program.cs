using System;

namespace PersonPr
{
    abstract class Person {
        abstract public void Print();
    }

    class Abiturient : Person {
        private string fio;
        private byte age;
        private byte ATM;

        public Abiturient(string fio, byte age, byte ATM) {
            this.fio = fio;
            this.age = age;
            this.ATM = ATM;
        }

        public override void Print() {
            Console.WriteLine("Абитуриент");
            Console.WriteLine(fio);
            Console.WriteLine(age);
            Console.WriteLine(ATM);
        }
    }


    class Student: Abiturient {
        private string fio;
        private byte age;
        private byte ATM;
        private byte kurs;
        private string group;

        public Student(string fio, byte age, byte ATM, byte kurs, string group): base (fio, age, ATM) {
     //       this.fio = fio;
     //       this.age = age;
     //       this.ATM = ATM;
            this.kurs = kurs;
            this.group = group;
        }

        public override void Print() {
            Console.WriteLine("Студент");
            Console.WriteLine(fio);
            Console.WriteLine(age);
            Console.WriteLine(ATM);
            Console.WriteLine(kurs);
            Console.WriteLine(group);
        }

    }

    class Professsor : Person {
        private string FIO;
        private byte age;
        private string kafedra;
        private int oklad;

        public Professsor(string FIO, byte age, string kafedra, int oklad) {
            this.FIO = FIO;
            this.age = age;
            this.kafedra = kafedra;
            this.oklad = oklad;
        }

        public override void Print() {
            Console.WriteLine("Профессор");
            Console.WriteLine(FIO);
            Console.WriteLine(age);
            Console.WriteLine(kafedra);
            Console.WriteLine(oklad);
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            Abiturient A1 = new Abiturient("Геока Евгений Ильич", 17, 11);
            Abiturient A2 = new Abiturient("Катранжи Наталья Сергеевна", 17, 11);
            Abiturient A3 = new Abiturient("Ситниченко Жанна Витальевна", 18, 9);
            Student S1 = new Student("Касаджик Илья Константинович", 19, 10, 2, "");
            Student S2 = new Student("Стратан Александр Сергеевич", 19, 10, 2, "");
            Student S3 = new Student("Мойса Валерий Алексеевич", 19, 10, 2, "");
            Professsor P1 = new Professsor("Дулоглу Анастасия Дмитриевна", 47, "", 20000);
        }
    }
}
