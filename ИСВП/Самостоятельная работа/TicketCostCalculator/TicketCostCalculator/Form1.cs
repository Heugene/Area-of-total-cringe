using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketCostCalculator
{
    public partial class Form1 : Form
    {

        double TicketCost;   //стоимость путёвки
        byte ResidentsCount; //количество проживающих
        byte DaysCount;      //количество дней пребывания
        double PayRatio;      //коэффициент оплаты
        double DiscountRatio; //коэффициент скидки

        public void Reset() // метод сброса данных на форме
        {
            // Первичная настройка первой группы (Ввод дат заезда и отъезда)
            this.groupBox1.Visible = true;
            this.groupBox1.Enabled = true;

            // Первичная настройка второй группы (Выбор способа оплаты)
            this.groupBox2.Visible = false;
            this.groupBox2.Enabled = true;

            // Первичная настройка третьей группы (Ввод числа проживающих)
            this.groupBox4.Visible = false;
            this.groupBox4.Enabled = true;

            // Первичная настройка четвёртой группы (Вывод информации о предварительной стоимости путёвки)
            this.groupBox5.Visible = false;
            this.groupBox5.Enabled = true;
        }

        public byte DaysCountCalculate(DateTime StartDate, DateTime EndDate) //функция для подсчёта разницы дат в днях
        {
            if (Convert.ToInt32((EndDate - StartDate).TotalDays) < 0 || Convert.ToInt32((EndDate - StartDate).Days) > 255)
            {
                return 0;
            }
            else if (Convert.ToInt32((EndDate - StartDate).Days) == 0)
            {
                return 1;
            }
            else
            {
                return Convert.ToByte((EndDate - StartDate).Days);
            }
        }

        public double TicketCostCalculate()
        {
            return this.ResidentsCount * this.DaysCount * this.PayRatio * this.DiscountRatio;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DaysCountCalculate(dateTimePicker1.Value, dateTimePicker2.Value) != 0) // если разница дат не более 255 дней
            {
                this.DaysCount = DaysCountCalculate(dateTimePicker1.Value, dateTimePicker2.Value);
                this.groupBox1.Enabled = false;
                this.groupBox2.Visible = true;
            }
            else
            {
                MessageBox.Show("Дата приезда не может быть позже даты отъезда, а количество дней между ними может быть в пределах 255");
                Reset();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //считаем коэфф.оплаты в зависимости от вида оплаты
            if (radioButton1.Checked)
            {
                this.PayRatio = 1; // если оплата наличными
            }
            else if (radioButton2.Checked)
            {
                this.PayRatio = 0.85; // если оплата картой Visa
            }
            this.groupBox2.Enabled = false;
            this.groupBox4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ResidentsCount = Convert.ToByte(numericUpDown1.Value); //забираем значение количества проживающих в переменную
            //считаем скидку за количество проживающих
            if (ResidentsCount < 5)
            {
                this.DiscountRatio = 1;
            }
            else
            {
                this.DiscountRatio = 0.9;
            }

            //считаем предварительную стоимость путёвки
            this.TicketCost = TicketCostCalculate();
            textBox1.Text = this.TicketCost.ToString();
            this.groupBox4.Enabled = false;
            this.groupBox5.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
