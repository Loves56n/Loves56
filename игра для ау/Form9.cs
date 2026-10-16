using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace игра_для_ау
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double num1) && double.TryParse(textBox3.Text, out double num2))
            {
                string operation = textBox2.Text.Trim(); 
                double result = 0;
                bool validOperation = true;
                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":

                        if (num2 == 0)
                        {
                            MessageBox.Show("Ошибка: Деление на ноль невозможно!", "Математическая ошибка");
                            validOperation = false;
                        }
                        else
                        {
                            result = num1 / num2;
                        }
                        break;
                    default:
                        MessageBox.Show("Ошибка: Введите один из знаков действий: +, -, *, /", "Неверная операция");
                        validOperation = false;
                        break;
                }
                if (validOperation)
                {
                    textBox4.Text = result.ToString();
                }
            }
            else
            {
                MessageBox.Show("Ошибка: Пожалуйста, введите корректные числа в поля Число 1 и Число 2!", "Ошибка ввода");
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
