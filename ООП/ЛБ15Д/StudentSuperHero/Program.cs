using System;

namespace StudentSuperHero
{
    public class Man
    {
        string name;
        public Man()
        {
            name = "NoName";
        }
        public Man(string n)
        {
            name = n;
        }
        public void print()
        {
            Console.Write(name);
        }
    }
    interface IBall
    {
        void play();
    }
    interface IGitara
    {
        void play();
    }
    interface IKVN
    {
        void play();
    }
    public class Student : Man, IBall, IGitara, IKVN
    {
        public Student() : base()
        { }
        public Student(string n) : base(n)
        { }
        void IBall.play()
        {
            Console.WriteLine(" - играет в мяч");
        }
        void IGitara.play()
        {
            Console.WriteLine(" - играет на гитаре");
        }
        void IKVN.play()
        {
            Console.WriteLine(" - играет в КВН. Не просто клоун, а самый настоящий цирк!");
        }
        public void study()
        {
            Console.WriteLine(" - учится в институте,  а также");
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Student x = new Student("Иван");
            x.print();
            x.study();
            ((IBall)x).play();
            ((IGitara)x).play();
            ((IKVN)x).play();
            Console.WriteLine();
            Student y = new Student("Пётр");
            y.print();
            y.study();
            IBall i1 = y;
            i1.play();
            IGitara i2 = y;
            i2.play();
            IKVN i3 = y;
            i3.play();
            Console.Write("Press any key to continue  . . . ");
            Console.ReadKey(true);
        }
    }
}
