using System;
using System.Linq;
using System.Windows.Forms;

namespace игра_для_ву
{
    public partial class Form2 : Form
    {
        private int zagadannoeChislo;
        private int popytki = 0;
        private Random rnd = new Random();
        private TextBox myTextBox;
        private Label labelPodskazka;
        private Label labelPopytki;

        public Form2()
        {
            InitializeComponent();
            myTextBox = this.Controls.OfType<TextBox>().FirstOrDefault();

            var labels = this.Controls.OfType<Label>().ToList();
            if (labels.Count >= 2)
            {
                labels = labels.OrderBy(l => l.Left).ToList();
                labelPodskazka = labels[0];
                labelPopytki = labels[1];
            }
            var buttons = this.Controls.OfType<Button>().ToList();
            if (buttons.Count >= 2)
            {
                buttons = buttons.OrderBy(b => b.Left).ToList();
                buttons[0].Click += UniversalButtonGuess_Click;
                buttons[1].Click += UniversalButtonReset_Click;
            }

            StartNewGame();
        }

        private void StartNewGame()
        {
            zagadannoeChislo = rnd.Next
(1, 101); 
            popytki = 0;

            if (labelPodskazka != null) labelPodskazka.Text = "Подсказка: введите число";
            if (labelPopytki != null) labelPopytki.Text = "Попытки: 0";
            if (myTextBox != null) myTextBox.Clear();
        }
        private void UniversalButtonGuess_Click(object sender, EventArgs e)
        {
            if (myTextBox == null || labelPodskazka == null || labelPopytki == null)
            {
                MessageBox.Show
("Ошибка: На форме не найдены текстовое поле или надписи!", "Внимание");
                return;
            }

            if (int.TryParse(myTextBox.Text, out int chisloPolzovatelya))
            {
                popytki++;
                labelPopytki.Text = "Попытки: " + popytki;
                if (chisloPolzovatelya < zagadannoeChislo)
                {
                    labelPodskazka.Text = "Подсказка: число больше!";
                }
                else if (chisloPolzovatelya > zagadannoeChislo)
                {
                    labelPodskazka.Text = "Подсказка: число меньше!";
                }
                else
                {
                    labelPodskazka.Text = "Подсказка: ВЫ УГАДАЛИ!";
                    MessageBox.Show
($"Вы угадали число {zagadannoeChislo} за {popytki} попыток!", "Победа!");
                }
            }
            else
            {
                MessageBox.Show
("Пожалуйста, введите корректное число!", "Ошибка");
            }
        }
        private void UniversalButtonReset_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }
    }
}