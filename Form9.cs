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
    public partial class Form9 : Form
    {
        OleDbConnection conn = new OleDbConnection();
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();
        OleDbCommand cmd = new OleDbCommand();
        string str;

        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Кабинеты (НомерКабинета) VALUES ('" + textBox1.Text + "')";
                cmd.ExecuteNonQuery();
                textBox1.Clear();
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];

                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM Кабинеты", conn);
                ad.Fill(ds);
                System.Data.DataTable dt = new System.Data.DataTable("Кабинеты");
                ad.Fill(dt);
                bs.DataSource = dt;
                bindingNavigator1.BindingSource = bs;
                dataGridView1.DataSource = bs;
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int del = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(del);

            cmd.Connection = conn;
            cmd.CommandText = @"DELETE * FROM Кабинеты WHERE КодКабинета = " + str;
            cmd.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE Кабинеты SET НомерКабинета = '" + textBox1.Text + "' WHERE КодКабинета = " + str;
            cmd.ExecuteNonQuery();

            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM Кабинеты", conn);
            ad.Fill(ds);
            System.Data.DataTable dt = new System.Data.DataTable("Кабинеты");
            ad.Fill(dt);
            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].Visible = false;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            Form1.databaseConnection(conn);
            conn.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM Кабинеты", conn);
            ad.Fill(ds);
            System.Data.DataTable dt = new System.Data.DataTable("Кабинеты");
            ad.Fill(dt);
            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                str = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
            catch (ArgumentOutOfRangeException exc)
            {

            }
            catch (NullReferenceException exc_)
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM Кабинеты", conn);
            ad.Fill(ds);
            System.Data.DataTable dt = new System.Data.DataTable("Кабинеты");
            ad.Fill(dt);
            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bs.DataSource;
            dataGridView1.CurrentCell = null;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox2.Text.ToLower()))
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.SpringGreen;
                            break;
                        }
            }
            dataGridView1.Columns[0].Visible = false;

            if (textBox2.Text == "")
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
        }

        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
            var f = new Form1();
            f.Show();
        }
    }
}
