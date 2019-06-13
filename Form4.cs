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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace Поликлиника
{
    public partial class Form4 : Form
    {
        OleDbConnection conn = new OleDbConnection();
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();
        OleDbCommand cmd = new OleDbCommand();
        string str;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Form1.databaseConnection(conn);
            conn.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT КодЛекарства, КлассЛекарства as Классификатор, НазваниеЛекарства as Название FROM Лекарства", conn);
            ad.Fill(ds);

            System.Data.DataTable dt = new System.Data.DataTable("Лекарства");
            ad.Fill(dt);
            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[2].Width = 175;
            dataGridView1.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Лекарства (КлассЛекарства, НазваниеЛекарства) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена успешно.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];

                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT КодЛекарства, КлассЛекарства as Классификатор, НазваниеЛекарства as Название FROM Лекарства", conn);
                ad.Fill(ds);
                System.Data.DataTable dt = new System.Data.DataTable("Лекарства");
                ad.Fill(dt);
                bs.DataSource = dt;
                bindingNavigator1.BindingSource = bs;
                dataGridView1.DataSource = bs;
                dataGridView1.Columns[2].Width = 175;
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int del = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(del);

            cmd.Connection = conn;
            cmd.CommandText = @"DELETE * FROM Лекарства WHERE КодЛекарства = " + str;
            cmd.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE Лекарства SET КлассЛекарства = '" + textBox1.Text + "', НазваниеЛекарства = '" + textBox2.Text + "' WHERE КодЛекарства = " + str;
            cmd.ExecuteNonQuery();

            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT КодЛекарства, КлассЛекарства as Классификатор, НазваниеЛекарства as Название FROM Лекарства", conn);
            ad.Fill(ds);
            System.Data.DataTable dt = new System.Data.DataTable("Лекарства");
            ad.Fill(dt);
            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[2].Width = 175;
            dataGridView1.Columns[0].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT КодЛекарства, КлассЛекарства as Классификатор, НазваниеЛекарства as Название FROM Лекарства", conn);
            ad.Fill(ds);
            System.Data.DataTable dt = new System.Data.DataTable("Лекарства");
            ad.Fill(dt);
            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[2].Width = 175;
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bs.DataSource;
            dataGridView1.CurrentCell = null;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            //dataGridView1.Rows[i].Selected = true;
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.SpringGreen;
                            break;
                        }
            }
            dataGridView1.Columns[2].Width = 175;
            dataGridView1.Columns[0].Visible = false;

            if (textBox1.Text == "")
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var ExcelApp = new Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 15;

            ExcelApp.Cells[1, 1] = "№";
            ExcelApp.Cells[1, 2] = "Классификатор";
            ExcelApp.Cells[1, 3] = "Название";
            ExcelApp.Visible = true;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount - 1; j++)
                {
                    ExcelApp.Cells[j + 2, i + 1] = (dataGridView1[i, j].Value).ToString();
                }
            }
            ExcelApp.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Word.Document WordDoc;
            var WordApp = new Word.Application();
            WordApp.Visible = true;
            WordDoc = WordApp.Documents.Add(Type.Missing, false, Word.WdNewDocumentType.wdNewBlankDocument, true);
            Word.Range wordrange = WordDoc.Range(0, 0);
            Word.Table wordtable = WordDoc.Tables.Add(wordrange, dataGridView1.RowCount, dataGridView1.ColumnCount, Word.WdDefaultTableBehavior.wdWord9TableBehavior, Word.WdAutoFitBehavior.wdAutoFitWindow);

            Word.Range wordcellrange = WordDoc.Tables[1].Cell(1, 1).Range;
            wordcellrange.Text = "№";
            wordcellrange = wordtable.Cell(1, 2).Range;
            wordcellrange.Text = "Классификатор";
            wordcellrange = wordtable.Cell(1, 3).Range;
            wordcellrange.Text = "Название";

            for (int m = 1; m < wordtable.Rows.Count; m++)
                for (int n = 0; n < wordtable.Columns.Count; n++)
                {
                    wordcellrange = wordtable.Cell(m + 1, n + 1).Range;
                    wordcellrange.Text = dataGridView1[n, m - 1].Value.ToString();
                }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
            var f = new Form1();
            f.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                str = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch (ArgumentOutOfRangeException exc)
            {

            }
            catch (NullReferenceException exc_)
            {

            }
        }
    }
}
