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
    public partial class Form7 : Form
    {
        OleDbConnection conn = new OleDbConnection();
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();
        OleDbCommand cmd = new OleDbCommand();
        string str;

        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox5.SelectedIndex == -1 || dateTimePicker1.Text == "" || comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Приемы (КодПациента, КодВрача, ДатаОбращения, Диагноз, Лекарство, ВремяПриема) VALUES ('" + comboBox1.SelectedValue + "','" + comboBox5.SelectedValue + "','" + dateTimePicker1.Text + "','" + 1 + "','" + 1 + "','" + comboBox3.Text + "')";
                cmd.ExecuteNonQuery();
                textBox1.Clear();
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];

                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Приемы.КодПриема, Больные.ФИО as Пациент, Врачи.Фамилия as Врач, Приемы.ДатаОбращения as Дата обращения, Приемы.ВремяПриема as Время записи, Кабинеты.НомерКабинета as [Номер Кабинета], Приемы.Прием, Врачи.Имя, Врачи.Отчество FROM Приемы, Диагноз, Лекарства, Врачи, Больные, Кабинеты WHERE Приемы.КодПациента = Больные.КодПациента AND Приемы.КодВрача = Врачи.КодВрача AND Приемы.Диагноз = Диагноз.КодДиагноза AND Приемы.Лекарство = Лекарства.КодЛекарства AND Врачи.КодКабинета = Кабинеты.КодКабинета", conn);
                ad.Fill(ds);
                System.Data.DataTable dt = new System.Data.DataTable("Приемы");
                ad.Fill(dt);
                bs.DataSource = dt;
                bindingNavigator1.BindingSource = bs;
                dataGridView1.DataSource = bs;
                dataGridView1.Columns[1].Width = 175;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[7].Visible = false;
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            Form1.databaseConnection(conn);
            conn.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Приемы.КодПриема, Больные.ФИО as Пациент, Врачи.Фамилия as Врач, Приемы.ДатаОбращения as Дата обращения, Приемы.ВремяПриема as Время записи, Кабинеты.НомерКабинета as [Номер Кабинета], Приемы.Прием, Врачи.Имя, Врачи.Отчество FROM Приемы, Диагноз, Лекарства, Врачи, Больные, Кабинеты WHERE Приемы.КодПациента = Больные.КодПациента AND Приемы.КодВрача = Врачи.КодВрача AND Приемы.Диагноз = Диагноз.КодДиагноза AND Приемы.Лекарство = Лекарства.КодЛекарства AND Врачи.КодКабинета = Кабинеты.КодКабинета", conn);
            ad.Fill(ds);
            System.Data.DataTable dt = new System.Data.DataTable("Приемы");
            ad.Fill(dt);
            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[2].Width = 175;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            OleDbDataAdapter ad1 = new OleDbDataAdapter("SELECT КодПациента, ФИО, ДатаРождения as Дата рождения FROM Больные", conn);
            DataTable dt1 = new DataTable();
            ad1.Fill(dt1);
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "ФИО";
            comboBox1.ValueMember = "КодПациента";
            comboBox1.SelectedIndex = -1;

            OleDbDataAdapter ad2 = new OleDbDataAdapter("SELECT Специальность.КодДолжности, КодВрача, Фамилия, Имя, Отчество, Специальность.Должность as Должность, ДатаРождения as Дата рождения, ДатаПриемаНаРаботу as Дата приёма на работу FROM Врачи, Специальность WHERE Врачи.КодДолжности = Специальность.КодДолжности", conn);
            DataTable dt2 = new DataTable();
            ad2.Fill(dt2);
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "Должность";
            comboBox2.ValueMember = "КодДолжности";

            //OleDbDataAdapter ad3 = new OleDbDataAdapter("SELECT КодДиагноза, КлассДиагноза, Диагноз, СтоимостьЛечения FROM Диагноз", conn);
            //DataTable dt3 = new DataTable();
            //ad3.Fill(dt3);
            //comboBox3.DataSource = dt3;
            //comboBox3.DisplayMember = "Диагноз";
            //comboBox3.ValueMember = "КодДиагноза";
            //comboBox3.SelectedIndex = -1;

            //OleDbDataAdapter ad4 = new OleDbDataAdapter("SELECT КодЛекарства, КлассЛекарства as Классификатор, НазваниеЛекарства FROM Лекарства", conn);
            //DataTable dt4 = new DataTable();
            //ad4.Fill(dt4);
            //comboBox4.DataSource = dt4;
            //comboBox4.DisplayMember = "НазваниеЛекарства";
            //comboBox4.ValueMember = "КодЛекарства";
            //comboBox4.SelectedIndex = -1;

            ToolTip t = new ToolTip();
            t.SetToolTip(button6, "Распечатать талон");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int del = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(del);

            cmd.Connection = conn;
            cmd.CommandText = @"DELETE * FROM Приемы WHERE КодПриема = " + str;
            cmd.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE Приемы SET КодПациента = '" + comboBox1.SelectedValue + "', КодВрача = '" + comboBox5.SelectedValue + "', ДатаОбращения = '" + dateTimePicker1.Text + "', ВремяПриема = '" + comboBox3.Text + "' WHERE КодПриема = " + str;
            cmd.ExecuteNonQuery();

            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Приемы.КодПриема, Больные.ФИО as Пациент, Врачи.Фамилия as Врач, Приемы.ДатаОбращения as Дата обращения, Приемы.ВремяПриема as Время записи, Кабинеты.НомерКабинета as [Номер Кабинета], Приемы.Прием, Врачи.Имя, Врачи.Отчество FROM Приемы, Диагноз, Лекарства, Врачи, Больные, Кабинеты WHERE Приемы.КодПациента = Больные.КодПациента AND Приемы.КодВрача = Врачи.КодВрача AND Приемы.Диагноз = Диагноз.КодДиагноза AND Приемы.Лекарство = Лекарства.КодЛекарства AND Врачи.КодКабинета = Кабинеты.КодКабинета", conn);
            ad.Fill(ds);
            System.Data.DataTable dt = new System.Data.DataTable("Приемы");
            ad.Fill(dt);
            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[2].Width = 175;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Приемы.КодПриема, Больные.ФИО as Пациент, Врачи.Фамилия as Врач, Приемы.ДатаОбращения as Дата обращения, Приемы.ВремяПриема as Время записи, Кабинеты.НомерКабинета as [Номер Кабинета], Приемы.Прием, Врачи.Имя, Врачи.Отчество FROM Приемы, Диагноз, Лекарства, Врачи, Больные, Кабинеты WHERE Приемы.КодПациента = Больные.КодПациента AND Приемы.КодВрача = Врачи.КодВрача AND Приемы.Диагноз = Диагноз.КодДиагноза AND Приемы.Лекарство = Лекарства.КодЛекарства AND Врачи.КодКабинета = Кабинеты.КодКабинета", conn);
            ad.Fill(ds);
            System.Data.DataTable dt = new System.Data.DataTable("Приемы");
            ad.Fill(dt);
            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[2].Width = 175;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bs.DataSource;
            dataGridView1.CurrentCell = null;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount - 2; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.SpringGreen;
                            break;
                        }
            }
            dataGridView1.Columns[2].Width = 175;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[7].Visible = false;

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
            ExcelApp.Cells[1, 2] = "ФИО";
            ExcelApp.Cells[1, 3] = "Врач";
            ExcelApp.Cells[1, 4] = "Дата приема";
            ExcelApp.Visible = true;
            for (int i = 0; i < dataGridView1.ColumnCount - 2; i++)
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
            wordcellrange.Text = "ФИО";
            wordcellrange = wordtable.Cell(1, 3).Range;
            wordcellrange.Text = "Врач";
            wordcellrange = wordtable.Cell(1, 4).Range;
            wordcellrange.Text = "Дата приема";
            wordcellrange = wordtable.Cell(1, 5).Range;
            wordcellrange.Text = "Диагноз";
            wordcellrange = wordtable.Cell(1, 6).Range;
            wordcellrange.Text = "Лекарство";

            for (int m = 1; m < wordtable.Rows.Count; m++)
                for (int n = 0; n < wordtable.Columns.Count - 2; n++)
                {
                    wordcellrange = wordtable.Cell(m + 1, n + 1).Range;
                    wordcellrange.Text = dataGridView1[n, m - 1].Value.ToString();
                }
        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
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
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox5.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch (ArgumentOutOfRangeException exc)
            {

            }
            catch (NullReferenceException exc_)
            {

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            object value = comboBox2.SelectedValue;
            if (value.ToString() == "System.Data.DataRowView")
            {
            }
            else
            {
                OleDbDataAdapter ad2 = new OleDbDataAdapter("SELECT DISTINCT КодВрача, Фамилия, Имя FROM Врачи, Специальность WHERE Врачи.КодДолжности=" + comboBox2.SelectedValue + "", conn);//[" + comboBox2.SelectedValue + "]
                DataTable dt2 = new DataTable();
                ad2.Fill(dt2);
                comboBox5.DataSource = dt2;
                comboBox5.DisplayMember = "Фамилия";
                comboBox5.ValueMember = "КодВрача";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var ExcelApp = new Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 20;
            ExcelApp.Columns[2].ColumnWidth = 30;
            ExcelApp.Visible = true;

            dataGridView1.Rows[dataGridView1.RowCount - 2].Selected = true;

            ExcelApp.Cells[1, 1] = "Номер кабинета:";
            ExcelApp.Cells[2, 1] = "Дата/время приема:";
            ExcelApp.Cells[3, 1] = "ФИО врача:";

            ExcelApp.Cells[1, 2] = dataGridView1.SelectedRows[0].Cells[4].Value;
            ExcelApp.Cells[2, 2] = dataGridView1.SelectedRows[0].Cells[3].Value;
            ExcelApp.Cells[3, 2] = dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + " " + dataGridView1.SelectedRows[0].Cells[6].Value.ToString() + " " + dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }
    }
}
