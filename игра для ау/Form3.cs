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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int r = random.Next
            (256);
            int g = random.Next
            (256);
            int b = random.Next
            (256);
            this.BackColor = Color.FromArgb(r, g, b);
        }
    }
}
