using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace The_Void
{
    public partial class Main : Form
    {
        int Dialog_Line_Counter = 1;
        int Atoms_Count = 0;
        int Scales_Value = 0;
        byte Number;
        int Bet_Value;
        Random r1 = new Random();
        byte Cube1;
        byte Cube2;
        StreamWriter log;

        bool Repeater = false; //важная штука для диалогов
        bool Rules_Dialog_Active = false;
        bool Result_Dialog_Active = false;
        bool Good_Ending_Dialog_Active = false;
        bool Bad_Ending_Dialog_Active = false;

        int[] Rules_Dialog_Lines = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10, 11, 12, 13, 14, 0, 15, 0}; // эти массивы тоже для диалогов
        int[] Good_Ending_Dialog_Lines = { 21, 22, 0, 0};

       async public static void SplashScreen_Show(Panel BG, Label Title, Label Comment)
        {
            Title.Show();
            BG.BackColor = Color.Black;
           //Текст название из белого становится чёрным и исчезает
            for (byte r = 255, g = 255, b = 255; r > 0 & g > 0 & b > 0; r--, g--, b--, await Task.Delay(30))
            {
                Title.ForeColor =  Color.FromArgb(r, g, b);
                Comment.ForeColor = Color.FromArgb(r, g, b);
            }
            Title.Visible  = Comment.Visible = false;


           //Фон из чёрного становится белым
            BG.BackColor = Color.Black; 
            for (byte a = 255, r = 0, g = 0, b = 0; a>0 & r<255 & g<255 & b<255; a--, r++, g++, b++, await Task.Delay(5))
            {
                BG.BackColor = Color.FromArgb(r, g, b);
            }
        }

       async public static void Ending_SplashScreen_Show(Panel BG, Label Title, Label Comment)
       {
           Title.Text = "КОНЕЦ ИГРЫ";
           Comment.Text = "Спасибо за игру \nАвтор: Геока Евгений \n     ^^";
           BG.BackColor = Color.White;
           //Фон становится чёрным
           for (byte r = 255, g = 255, b = 255; r > 0 & g > 0 & b > 0; r--, g--, b--, await Task.Delay(30))
           {
               BG.BackColor = Color.FromArgb(r, g, b);
           }

           Title.Show();
           Comment.Show();
           //Надписи становятся белыми
           for (byte r = 0, g = 0, b = 0; r < 255 & g < 255 & b < 255; r++, g++, b++, await Task.Delay(10))
           {
               Title.ForeColor = Color.FromArgb(r, g, b);
               Comment.ForeColor = Color.FromArgb(r, g, b);
           }
       }

       public static void Dialog_Show(Label Line, int id, PictureBox Dialog_Field)
       {
           Dialog_Field.Show();
           Line.Show();
           switch (id)
           {
               case 000: Line.Text = "...";
                   break;

               case 001: Line.Text = "Давай сыграем в игру.";
                   break;

               case 002: Line.Text = "А, впрочем... У тебя \nнет другого выбора.";
                   break;

               case 003: Line.Text = "Этот мир исчезнет, \nесли ты его покинешь";
                   break;

               case 004: Line.Text = "Тебе же интересно?";
                   break;

               case 005: Line.Text = "Ладно. Запоминай пра-\nвила: Каждый ход ты \nзагадываешь число от 2 \nдо 12, делаешь ставку \nи бросаешь кости.";
                   break;

               case 006: Line.Text = "Если выпавшая сумма \nменьше 7, а твоё число \nменьше 7, ты выиграл \nставку.";
                   break;

               case 007: Line.Text = "Если выпавшая сумма \nбольше 7, а твоё число \nбольше 7, ты выиграл \nставку.";
                   break;

               case 008: Line.Text = "Если тебе удастся в точ-\nности угадать выпавшее\nчисло, ты выигрываешь \nставку Х4. Придётся мне\nраскошелиться";
                   break;

               case 009: Line.Text = "Во всех остальных \nслучаях ты свою ставку \nпроигрываешь";
                   break;

               case 010: Line.Text = "На столе есть весы со\nшкалой от -5 до 5. Когда\nвыигрываешь ставку, \nони меняют баланс на 1. \n Угадал сумму - на 2";
                   break;

               case 011: Line.Text = "Когда проигрываешь \nставку, баланс меняется\nв противоположную \nсторону на 2.";
                   break;

               case 012: Line.Text = "Играем до 5 очков. Если\nна весах +5, ты победил\nи можешь покинуть этот\nмир. Если -5, то победил\nя. Сыграем ещё партию.";
                   break;

               case 013: Line.Text = "Кстати, если у тебя кон-\nчатся деньги, то ты \nпроиграл, и придётся\nсыграть ещё партию.";
                   break;

               case 014: Line.Text = "А, совсем забыл. \nВозьми 100 Атомов \nдля игры";
                   break;

               case 015: Line.Text = "Ну что, начнём?";
                   break;

               case 016: Line.Text = "Назови число и \nделай ставку.";
                   break;

               case 017: Line.Text = "Повезло.";
                   break;

               case 018: Line.Text = "Не в этот раз";
                   break;

               case 019: Line.Text = "С такой удачей ты бы\nлотерею выиграл... \nНаверное.";
                   break;

               case 020: Line.Text = "Ты проиграл. Я \nвынужден повторить \nцикл";
                   break;

               case 021: Line.Text = "У тебя получилось \nодолеть судьбу. Ты\n свободен.";
                   break;

               case 022: Line.Text = "Я бы пожал тебе руку...\nЕсли б у меня она была.";
                   break;
           }
       }

       public static void Rules_Dialog_Show(ref bool Active)
       {
           Active = true;
       }

       public static void Game_Process(ref bool Active)
       {
           Active = true;
       }

       public static void Game_Start(Label Dialog_Line, PictureBox Dialog_Field, ref bool Rules_Dialog_Active, ref bool Result_Dialog_Active, ref bool Good_Ending_Dialog_Active, ref bool Bad_Ending_Dialog_Active, int[] Rules_Dialog_Lines, Panel Tablo, Label ScalesLB, PictureBox pictureBox1, ref StreamWriter log)
       {
           log = new StreamWriter("log.txt", false);
           Result_Dialog_Active = false;
           Rules_Dialog_Active = false;
           Good_Ending_Dialog_Active = false;
           Bad_Ending_Dialog_Active = false;

           Tablo.Hide(); //это панель с результатами хода (несколько лейблов)
           ScalesLB.Hide();  //Это лейбл для весов отдельный
           Rules_Dialog_Show(ref Rules_Dialog_Active);
           Dialog_Show(Dialog_Line, Rules_Dialog_Lines[0], Dialog_Field);
           Game_Process(ref Result_Dialog_Active);
           pictureBox1.Image = new Bitmap(@".\Scales_0.png"); //это сам компонент для отображения весов
       }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Title_LBL.Hide(); // лейбл названия
            Comment.Text = ""; // А это как раз та нижняя надпись, которую вы сказали убрать
            Dialog_Field.Hide(); // Это картинка рамочки для диалогов
            Atom_Counter.Text = "A: " + Atoms_Count; // лейбл отображения количества валюты и переменная, это значение хранящая
            Bet_Panel.Hide();

            SplashScreen_Show(BG_Panel, Title_LBL, Comment); //показываем заставочку

            Game_Start(Dialog_Line, Dialog_Field, ref this.Rules_Dialog_Active, ref this.Result_Dialog_Active, ref this.Good_Ending_Dialog_Active, ref this.Bad_Ending_Dialog_Active, Rules_Dialog_Lines, panel1, label6, pictureBox1, ref log);
            //начинаем игру. Вот тут очень много параметров накопилось. Часть неиспользуемых даже убирал
        }


        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {  
            //если мы на этапе ознакомления с правилами, то каждое нажатие пробела перебирает фразы из определенного набора
            if (Rules_Dialog_Active)
            {
                if (e.KeyChar == ' ')
                {
                    Dialog_Show(Dialog_Line, Rules_Dialog_Lines[Dialog_Line_Counter], Dialog_Field);
                    Dialog_Line_Counter++;

                    if (Rules_Dialog_Lines[Dialog_Line_Counter - 1] == 14)
                    {
                        Atoms_Count = 100;
                        Atom_Counter.Text = "A: " + Atoms_Count;
                    }

                    // если уже перебрали все фразы
                    if(Dialog_Line_Counter == Rules_Dialog_Lines.Length)
                    {
                        this.Rules_Dialog_Active = false;
                        Dialog_Line_Counter = 0;
                        Dialog_Field.Hide();
                        Dialog_Line.Hide();
                    }
                }
            }

            // если мы уже прочитали правила и начали игровой процесс
            if (Result_Dialog_Active & !Rules_Dialog_Active)
            {
                if (e.KeyChar == ' ')
                {
                    Bet_Panel.Show(); // это компонент панель, на которой два компонента нумерик ап-давн для выбора ставки и числа,  а также кнопка подтверждения
                    numericUpDown2.Maximum = Atoms_Count;
                    Dialog_Show(Dialog_Line, 16, Dialog_Field);
                }
            }

            // если нарвались на плохую концовку то при первом нажатии пробела соперник об этом скажет, а при втором нажатии произойдёт сброс игрового процесса. Игра начинается заново
            if (Bad_Ending_Dialog_Active & Result_Dialog_Active != true & Good_Ending_Dialog_Active != true)
            {
                if (e.KeyChar == ' ')
                {
                    Dialog_Show(Dialog_Line, 20, Dialog_Field);
                    if (Repeater)
                    {
                        Atoms_Count = 0;
                        Atom_Counter.Text = "A: " + Atoms_Count.ToString();
                        Game_Start(Dialog_Line, Dialog_Field, ref this.Rules_Dialog_Active, ref this.Result_Dialog_Active, ref this.Good_Ending_Dialog_Active, ref this.Bad_Ending_Dialog_Active, Rules_Dialog_Lines, panel1, label6, pictureBox1, ref log);
                    }
                    Repeater = !Repeater;
                }
            }
            // Если вышли на хорошую концовку, то перебираются нужные реплики, после чего исчезают почти все индикаторные элементы, кроме количества денег, включая окошко для реплик, потом запускается финальная заставка с затемнением экрана и белыми надписями.
            if (Good_Ending_Dialog_Active & Result_Dialog_Active != true & Bad_Ending_Dialog_Active != true)
            {
                if (e.KeyChar == ' ')
                {
                    Dialog_Show(Dialog_Line, Good_Ending_Dialog_Lines[Dialog_Line_Counter], Dialog_Field);
                    Dialog_Line_Counter++;

                    if (Dialog_Line_Counter == Good_Ending_Dialog_Lines.Length)
                    {
                        Dialog_Line_Counter = 0;
                        Dialog_Field.Hide();
                        Dialog_Line.Hide();
                        panel1.Hide();
                        label6.Hide();

                        Ending_SplashScreen_Show(BG_Panel, Title_LBL, Comment);
                        this.Good_Ending_Dialog_Active = false;
                    }
                }
            }
        }
        // это обработчик события для кнопки подтверждения ставки и числа.
        private void button1_Click(object sender, EventArgs e)
        {
            Bet_Value = Convert.ToInt32(numericUpDown2.Value); // это сумма ставки
            Number = Convert.ToByte(numericUpDown1.Value); //загаданное число
            Bet_Panel.Hide(); // скрываем панель указания ставки
            Cube1 = Convert.ToByte(r1.Next(1, 6)); // тут мы случайным образом генерируем значения кубиков
            Cube2 = Convert.ToByte(r1.Next(1, 6));
            label6.Visible = true; // как раз панель с лейблами для отображения значений кубиков и суммы
            panel1.Visible = true; // лейбл для отображения значения весов

            if (Cube1 + Cube2 == Number) // если угадали сумму, то показываем редкую реплику с айди 19, умножаем ставку на 4 и прибавляем к значению весов +2 очка
            { 
                Dialog_Show(Dialog_Line, 19, Dialog_Field);
                Atoms_Count = Atoms_Count + 4*Bet_Value;
                Atom_Counter.Text = Atoms_Count.ToString();
                Scales_Value = Scales_Value + 2;
            }
            else if (Cube1 + Cube2 < 7 & Number < 7) // один из вариантов выигрыша ставки, которую прибавляем на счёт игрока, весы +1
            {
                Dialog_Show(Dialog_Line, 17, Dialog_Field);
                Atoms_Count = Atoms_Count + Bet_Value;
                Atom_Counter.Text = Atoms_Count.ToString();
                Scales_Value++;
            }
            else if (Cube1 + Cube2 > 7 & Number > 7) // второй вариант выигрыша ставки, которую прибавляем на счёт игрока, весы +1
            {
                Dialog_Show(Dialog_Line, 17, Dialog_Field);
                Atoms_Count = Atoms_Count + Bet_Value;
                Atom_Counter.Text = Atoms_Count.ToString();
                Scales_Value++;
            }
            else // во всех остальных случаях игрок ставку проигрывает, списываем нужную сумму с его счёта, весы -2. Самое несчастливое число - 7.
            {
                Dialog_Show(Dialog_Line, 18, Dialog_Field);
                Atoms_Count = Atoms_Count - Bet_Value;
                Atom_Counter.Text = Atoms_Count.ToString();
                Scales_Value = Scales_Value - 2;
            }
            //выводим на экран результаты хода
            label3.Text = "Кость 1: " + Cube1.ToString();
            label4.Text = "Кость 2: " + Cube2.ToString();
            label5.Text = "Сумма:  " +(Cube1 + Cube2).ToString();
            label6.Text = "Весы: " + Scales_Value;
            // выводим результаты хода в файл.
            log.WriteLine("Ставка: {0}| Число: {1}| Сумма: {2}| Кость1: {3}| Кость2: {4}| Весы: {5} Атомов: {6}", Bet_Value, Number, (Cube1 + Cube2), Cube1, Cube2, Scales_Value, Atoms_Count);

            //Благодаря одному индусу из ютуба, смог сделать переключение картинок весов.
            switch (Scales_Value)
            {
                case -5: pictureBox1.Image = new Bitmap(@".\Scales-5.png");
                    break;

                case -4: pictureBox1.Image = new Bitmap(@".\Scales-4.png");
                    break;

                case -3: pictureBox1.Image = new Bitmap(@".\Scales-3.png");
                    break;

                case -2: pictureBox1.Image = new Bitmap(@".\Scales-2.png");
                    break;

                case -1: pictureBox1.Image = new Bitmap(@".\Scales-1.png");
                    break;

                case 0: pictureBox1.Image = new Bitmap(@".\Scales_0.png");
                    break;

                case 1: pictureBox1.Image = new Bitmap(@".\Scales+1.png");
                    break;

                case 2: pictureBox1.Image = new Bitmap(@".\Scales+2.png");
                    break;

                case 3: pictureBox1.Image = new Bitmap(@".\Scales+3.png");
                    break;

                case 4: pictureBox1.Image = new Bitmap(@".\Scales+4.png");
                    break;

                case 5: pictureBox1.Image = new Bitmap(@".\Scales+5.png");
                    break;
            }

            // условие хорошей концовки при весах +5 и выше
            if (Scales_Value >= 5)
            {
                Good_Ending_Dialog_Active = true;
                Result_Dialog_Active = false;
                Scales_Value = 0;
                log.Close();
            }

            //условие плохой концовки при весах -5 и ниже ИЛИ если денег меньше, чем минимальная ставка (10 единиц)
            if (Atoms_Count <= 10 || Scales_Value <= -5)
            {
                Bad_Ending_Dialog_Active = true;
                Result_Dialog_Active = false;
                Scales_Value = 0;
                log.Close();
            }

            Focus();// а это для того, чтобы не надо было мышкой потом фокус на форму после каждого хода возвращать, чтобы кейпресс работал
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.Close(); //при прямом аварийном закрытии игры файл с логами ходов закрывается и сохраняется
        }

    }
}
