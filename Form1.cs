using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR23
{
    public partial class Form1 : Form
    {
        int formula = 0;
        public Form1()
        {
            InitializeComponent();
            noActive();
        }

        private void active1()
        {
            button1.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            formula = 1;
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel2.Visible = false;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox7.Text = string.Empty;
        }
        private void active2()
        {
            button2.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            formula = 2;
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = true;
        }
        private void noActive()
        {
            button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            formula = 0;
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = false;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox7.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            active1();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            active2();
        }

        // кейпрессы
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) { e.Handled = true; }
            if (e.KeyChar == '0' && ((TextBox)sender).Text.Length == 0)
            {
                e.Handled = true;
            }
            if (((TextBox)sender).Text.Length == 4)
                e.Handled = true;
        }
        private void textBoxDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '-' && ((TextBox)sender).Text.Length > 0)
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',' || e.KeyChar == '.') && ((TextBox)sender).Text.Length == 0)
            {
                ((TextBox)sender).Text = "0,";
                e.Handled = true;
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            }
            else if ((e.KeyChar == ',' || e.KeyChar == '.') && ((TextBox)sender).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
            if (((TextBox)sender).Text.Length == 8)
                e.Handled = true;
        }

        // очистка
        private void button4_Click(object sender, EventArgs e)
        {
            noActive();
        }
        // формулим
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (formula == 1)
                {
                    double x = Convert.ToDouble(textBox1.Text);
                    double h = Convert.ToDouble(textBox7.Text);

                    double z = 0;
                    for (int i = 0; i <= h; i++)
                        z = Math.Pow(-1, i) * i * Math.Pow(x, i) / Factorial(i + 1);

                    textBox4.Text = z.ToString();
                }
                else if (formula == 2)
                {
                    double a = Convert.ToDouble(textBox5.Text);
                    double b = Convert.ToDouble(textBox6.Text);
                    int n = Convert.ToInt32(textBox2.Text);
                    int r = Convert.ToInt32(textBox3.Text);

                    double z = 0;
                    for (int i = 1; i <= n; i++)
                        for (int j = 1; j <= r; j++)
                            z += Math.Pow((i + 1), 2) / ( a * Math.Pow(i, 3) + b * Math.Pow(j, 3) );

                    textBox4.Text = z.ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите действительные числа во все текстовые поля.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Число слишком большое или слишком маленькое.");
            }
        }

        private static long Factorial(int n)
        {
            if (n < 0) MessageBox.Show("Значение должно быть неотрицательным", "Эёу", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if (n == 0)
                return 1;
            return n * Factorial(n - 1);
        }
    }
}
