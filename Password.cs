using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Поликлиника
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "login" && textBox2.Text == "1122")
            {
                var f = new Form1();
                f.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Вы ввели неправильный логин или пароль.");
            }

        }
    }
}
