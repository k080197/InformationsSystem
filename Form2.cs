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
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing.Drawing2D;


namespace Поликлиника
{
    public partial class Form2 : Form
    {
        OleDbConnection conn = new OleDbConnection();
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();
        OleDbCommand cmd = new OleDbCommand();
        string str;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1.databaseConnection(conn);
            conn.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT КодВрача, Фамилия, Имя, Отчество, Специальность.Должность as Должность, ДатаРождения as Дата рождения, ДатаПриемаНаРаботу as [Дата приёма на работу], Кабинеты.НомерКабинета as Кабинет FROM Врачи, Специальность, Кабинеты WHERE Врачи.КодДолжности = Специальность.КодДолжности AND Врачи.КодКабинета = Кабинеты.КодКабинета", conn);
            ad.Fill(ds);

            System.Data.DataTable dt = new System.Data.DataTable("Врачи");
            ad.Fill(dt);
            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[2].Width = 175;
            dataGridView1.Columns[0].Visible = false;

            OleDbDataAdapter ad1 = new OleDbDataAdapter("SELECT КодДолжности, Должность FROM Специальность", conn);
            DataTable dt1 = new DataTable();
            ad1.Fill(dt1);
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "Должность";
            comboBox1.ValueMember = "КодДолжности";
            comboBox1.SelectedIndex = -1;

            OleDbDataAdapter ad2 = new OleDbDataAdapter("SELECT КодКабинета, НомерКабинета FROM Кабинеты", conn);
            DataTable dt2 = new DataTable();
            ad2.Fill(dt2);
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "НомерКабинета";
            comboBox2.ValueMember = "КодКабинета";
            comboBox2.SelectedIndex = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.SelectedIndex == -1 || dateTimePicker1.Text == "" || dateTimePicker1.Text == "" || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Врачи (Фамилия, Имя, Отчество, КодДолжности, ДатаРождения, ДатаПриемаНаРаботу, КодКабинета) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.SelectedValue + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + comboBox2.SelectedValue + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена успешно.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];

                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT КодВрача, Фамилия, Имя, Отчество, Специальность.Должность as Должность, ДатаРождения as Дата рождения, ДатаПриемаНаРаботу as [Дата приёма на работу], Кабинеты.НомерКабинета as Кабинет FROM Врачи, Специальность, Кабинеты WHERE Врачи.КодДолжности = Специальность.КодДолжности AND Врачи.КодКабинета = Кабинеты.КодКабинета", conn);
                ad.Fill(ds);
                System.Data.DataTable dt = new System.Data.DataTable("Врачи");
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
            cmd.CommandText = @"DELETE * FROM Врачи WHERE КодВрача = " + str;
            cmd.ExecuteNonQuery();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                str = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            }
            catch (ArgumentOutOfRangeException exc)
            {

            }
            catch (NullReferenceException exc_)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE Врачи SET Фамилия = '" + textBox1.Text + "', Имя = '" + textBox2.Text + "', Отчество = '" + textBox3.Text + "', КодДолжности = '" + comboBox1.SelectedValue + "', ДатаРождения = '" + dateTimePicker1.Text + "', ДатаПриемаНаРаботу = '" + dateTimePicker2.Text + "', КодКабинета = '" + comboBox2.SelectedValue + "' WHERE КодВрача = " + str;
            cmd.ExecuteNonQuery();

            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT КодВрача, Фамилия, Имя, Отчество, Специальность.Должность as Должность, ДатаРождения as Дата рождения, ДатаПриемаНаРаботу as [Дата приёма на работу], Кабинеты.НомерКабинета as Кабинет FROM Врачи, Специальность, Кабинеты WHERE Врачи.КодДолжности = Специальность.КодДолжности AND Врачи.КодКабинета = Кабинеты.КодКабинета", conn);
            ad.Fill(ds);
            System.Data.DataTable dt = new System.Data.DataTable("Врачи");
            ad.Fill(dt);
            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[2].Width = 175;
            dataGridView1.Columns[0].Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var ExcelApp = new Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 15;

            ExcelApp.Cells[1, 1] = "№";
            ExcelApp.Cells[1, 2] = "Фамилия";
            ExcelApp.Cells[1, 3] = "Имя";
            ExcelApp.Cells[1, 4] = "Отчество";
            ExcelApp.Cells[1, 5] = "Специальность";
            ExcelApp.Cells[1, 6] = "Дата рождения";
            ExcelApp.Cells[1, 7] = "Дата приема на работу";
            ExcelApp.Cells[1, 8] = "Номер кабинета";
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
            //object template = Type.Missing;
            //object newTemplate = false;
            //object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
            //object visible = true;
            WordDoc = WordApp.Documents.Add(Type.Missing, false, Word.WdNewDocumentType.wdNewBlankDocument, true);
            //object start = 0;
            //object end = 0;
            Word.Range wordrange = WordDoc.Range(0, 0);
            object defaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;
            Word.Table wordtable = WordDoc.Tables.Add(wordrange, dataGridView1.RowCount, dataGridView1.ColumnCount, ref defaultTableBehavior, ref autoFitBehavior);
            
            Word.Range wordcellrange = WordDoc.Tables[1].Cell(1, 1).Range;
            wordcellrange.Text = "№";
            wordcellrange = wordtable.Cell(1, 2).Range;
            wordcellrange.Text = "Фамилия";
            wordcellrange = wordtable.Cell(1, 3).Range;
            wordcellrange.Text = "Имя";
            wordcellrange = wordtable.Cell(1, 4).Range;
            wordcellrange.Text = "Отчество";
            wordcellrange = wordtable.Cell(1, 5).Range;
            wordcellrange.Text = "Должность";
            wordcellrange = wordtable.Cell(1, 6).Range;
            wordcellrange.Text = "Дата рождения";
            wordcellrange = wordtable.Cell(1, 7).Range;
            wordcellrange.Text = "Дата приема на работу";
            wordcellrange = wordtable.Cell(1, 8).Range;
            wordcellrange.Text = "Номер кабинета";

            for (int m = 1; m < wordtable.Rows.Count; m++)
                for (int n = 0; n < wordtable.Columns.Count; n++)
                {
                    wordcellrange = wordtable.Cell(m + 1, n + 1).Range;
                    wordcellrange.Text = dataGridView1[n, m - 1].Value.ToString();
                }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT КодВрача, Фамилия, Имя, Отчество, Специальность.Должность as Должность, ДатаРождения as Дата рождения, ДатаПриемаНаРаботу as [Дата приёма на работу], Кабинеты.НомерКабинета as Кабинет FROM Врачи, Специальность, Кабинеты WHERE Врачи.КодДолжности = Специальность.КодДолжности AND Врачи.КодКабинета = Кабинеты.КодКабинета", conn);
            ad.Fill(ds);
            System.Data.DataTable dt = new System.Data.DataTable("Врачи");
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
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox4.Text.ToLower()))
                        {
                            //dataGridView1.Rows[i].Selected = true;
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.SpringGreen;
                            break;
                        }
            }
            dataGridView1.Columns[2].Width = 175;
            dataGridView1.Columns[0].Visible = false;

            if (textBox4.Text == "")
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
            var f = new Form1();
            f.Show();
        }
    }
}
