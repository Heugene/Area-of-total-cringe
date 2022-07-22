using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LB_DataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public DataGridView DT
        {
            get
            {
                return dataGridView1;
            }
            set 
            {
                this.dataGridView1 = value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.TopLeftHeaderCell.Value = "№ п/п";
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i+1);
            }
            graph();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            string inputValue;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                inputValue = Convert.ToString(dataGridView1.Rows[i].Cells[5].Value);
                double mark;
                if (inputValue == "")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else if (double.TryParse(inputValue, out mark))
                {
                    if (mark >= 3)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    if (mark >= 4)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                    }
                    if (mark == 5)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                    if (mark <3)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double mark = 0;
            if(e.ColumnIndex != 5 || e.RowIndex == -1)
            {
                return;
            }
            try
            {
                mark = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                if (mark >= 2 && mark <= 5)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[6].Value = Convert.ToString(mark * 120);
                }
            }

            catch (Exception Ex)
            {
                dataGridView1.Rows[e.RowIndex].Cells[5].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[6].Value = "";
            }
           
        }

        private void dataGridView1_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            if (e.Column.Index == 6)
            {
                e.Column.ReadOnly = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            graph();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Удалить данные о студенте: " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString(), "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
            graph();
        }

        public void graph()
        {
            chart1.Titles[0].Text = "Диаграмма сумм стипендии студентов";
            chart1.Series[0].Points.Clear();

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[5].Value != "")
                {
                    chart1.Series[0].Points.AddXY(i, Convert.ToDouble(dataGridView1[5, i].Value));
                }
                else
                {
                    chart1.Series[0].Points.AddXY(i, 0);
                }
                chart1.Series[0].Points[i].AxisLabel = Convert.ToString(dataGridView1[0, i].Value);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            graph();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }
    }
}
