using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Поликлиника
{
    public partial class Form1 : Form
    {
        public static OleDbConnection databaseConnection(OleDbConnection conn)
        {
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder();
            builder.DataSource = @".\\Курсовая.accdb";
            builder.Provider = @"Microsoft.ACE.OLEDB.12.0";
            builder.PersistSecurityInfo = false;

            try
            {
                conn.ConnectionString = builder.ConnectionString;
                return conn;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при подключении к базе данных!");
                return null;
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void врачиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.врачиBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.курсоваяDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "курсоваяDataSet.Врачи". При необходимости она может быть перемещена или удалена.
            this.врачиTableAdapter.Fill(this.курсоваяDataSet.Врачи);

        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void врачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form2();
            f.Show();
            Hide();
        }

        private void таблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void специальностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form3();
            f.Show();
            Hide();
        }

        private void лекарстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form4();
            f.Show();
            Hide();
        }

        private void диагнозыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form6();
            f.Show();
            Hide();
        }

        private void пациентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form5();
            f.Show();
            Hide();
        }

        private void приемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form7();
            f.Show();
            Hide();
        }

        private void кабинетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form9();
            f.Show();
            Hide();
        }

        private void приемПациентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form8();
            f.Show();
            Hide();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void расписаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьРасписаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form10();
            f.Show();
            Hide();
        }

        private void открытьСправкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form11();
            f.Show();
            Hide();
        }
    }
}
