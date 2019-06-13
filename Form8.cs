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
using Word = Microsoft.Office.Interop.Word;
using Microsoft;

namespace Поликлиника
{
    public partial class Form8 : Form
    {
        OleDbConnection conn = new OleDbConnection();
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();
        OleDbCommand cmd = new OleDbCommand();
        string str;

        public Form8()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object value = comboBox1.SelectedValue;
            if (value.ToString() == "System.Data.DataRowView")
            {
            }
            else
            {
                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT DISTINCT Приемы.КодПриема, Больные.ФИО, Приемы.ДатаОбращения, Приемы.ВремяПриема, Диагноз.Диагноз, Лекарства.НазваниеЛекарства, Приемы.Дополнительно, Приемы.Прием, Диагноз.СтоимостьЛечения FROM Приемы, Врачи, Больные, Диагноз, Лекарства WHERE " + comboBox1.SelectedValue + " = Приемы.КодВрача AND Больные.КодПациента = Приемы.КодПациента AND Приемы.Диагноз = Диагноз.КодДиагноза AND Приемы.Лекарство = Лекарства.КодЛекарства", conn);// WHERE Приемы.КодВрача=" + comboBox1.SelectedValue + " AND Больные.КодПациента = Приемы.КодПациента
                ad.Fill(ds);
                DataTable dt = new DataTable();
                ad.Fill(dt);

                bs.DataSource = dt;
                bindingNavigator1.BindingSource = bs;
                dataGridView1.DataSource = bs;
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            Form1.databaseConnection(conn);
            conn.Open();

            OleDbDataAdapter ad2 = new OleDbDataAdapter("SELECT DISTINCT КодВрача, Фамилия, Имя, Отчество FROM Врачи", conn);
            DataTable dt2 = new DataTable();
            ad2.Fill(dt2);
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "Фамилия";
            comboBox1.ValueMember = "КодВрача";

            OleDbDataAdapter ad3 = new OleDbDataAdapter("SELECT КодДиагноза, КлассДиагноза, Диагноз, СтоимостьЛечения FROM Диагноз", conn);
            DataTable dt3 = new DataTable();
            ad3.Fill(dt3);
            comboBox2.DataSource = dt3;
            comboBox2.DisplayMember = "Диагноз";
            comboBox2.ValueMember = "КодДиагноза";
            comboBox2.SelectedIndex = -1;

            OleDbDataAdapter ad4 = new OleDbDataAdapter("SELECT КодЛекарства, КлассЛекарства as Классификатор, НазваниеЛекарства FROM Лекарства", conn);
            DataTable dt4 = new DataTable();
            ad4.Fill(dt4);
            comboBox3.DataSource = dt4;
            comboBox3.DisplayMember = "НазваниеЛекарства";
            comboBox3.ValueMember = "КодЛекарства";
            comboBox3.SelectedIndex = -1;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                str = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                checkBox1.Checked = (bool)dataGridView1.SelectedRows[0].Cells[7].Value;
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
            if (comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || textBox1.Text == "" || checkBox1.Checked == false)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Приемы (Диагноз, Лекарство, Дополнительно, Прием) VALUES ('" + comboBox2.SelectedValue + "','" + comboBox3.SelectedValue + "','" + textBox1.Text + "','" + checkBox1.Checked + "')";
                cmd.ExecuteNonQuery();
                textBox1.Clear();
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];

                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT DISTINCT Приемы.КодПриема, Больные.ФИО, Приемы.ДатаОбращения, Приемы.ВремяПриема, Диагноз.Диагноз, Лекарства.НазваниеЛекарства, Приемы.Дополнительно, Приемы.Прием, Диагноз.СтоимостьЛечения FROM Приемы, Врачи, Больные, Диагноз, Лекарства WHERE " + comboBox1.SelectedValue + " = Приемы.КодВрача AND Больные.КодПациента = Приемы.КодПациента AND Приемы.Диагноз = Диагноз.КодДиагноза AND Приемы.Лекарство = Лекарства.КодЛекарства", conn);// WHERE Приемы.КодВрача=" + comboBox1.SelectedValue + " AND Больные.КодПациента = Приемы.КодПациента
                ad.Fill(ds);
                DataTable dt = new DataTable();
                ad.Fill(dt);

                bs.DataSource = dt;
                bindingNavigator1.BindingSource = bs;
                dataGridView1.DataSource = bs;
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int del = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(del);

            cmd.Connection = conn;
            cmd.CommandText = @"DELETE * FROM Приемы WHERE КодПриема = " + str;
            cmd.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmd.Connection = conn;
            if(checkBox1.Checked == true)
                cmd.CommandText = @"UPDATE Приемы SET Диагноз = '" + comboBox2.SelectedValue + "', Лекарство = '" + comboBox3.SelectedValue + "', Дополнительно = '" + textBox1.Text + "', Прием = '" + 1 + "' WHERE КодПриема = " + str;
            else
                cmd.CommandText = @"UPDATE Приемы SET Диагноз = '" + comboBox2.SelectedValue + "', Лекарство = '" + comboBox3.SelectedValue + "', Дополнительно = '" + textBox1.Text + "', Прием = '" + 0 + "' WHERE КодПриема = " + str;
            cmd.ExecuteNonQuery();

            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT DISTINCT Приемы.КодПриема, Больные.ФИО, Приемы.ДатаОбращения, Приемы.ВремяПриема, Диагноз.Диагноз, Лекарства.НазваниеЛекарства, Приемы.Дополнительно, Приемы.Прием, Диагноз.СтоимостьЛечения FROM Приемы, Врачи, Больные, Диагноз, Лекарства WHERE " + comboBox1.SelectedValue + " = Приемы.КодВрача AND Больные.КодПациента = Приемы.КодПациента AND Приемы.Диагноз = Диагноз.КодДиагноза AND Приемы.Лекарство = Лекарства.КодЛекарства", conn);// WHERE Приемы.КодВрача=" + comboBox1.SelectedValue + " AND Больные.КодПациента = Приемы.КодПациента
            ad.Fill(ds);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT DISTINCT Приемы.КодПриема, Больные.ФИО, Приемы.ДатаОбращения, Приемы.ВремяПриема, Диагноз.Диагноз, Лекарства.НазваниеЛекарства, Приемы.Дополнительно, Приемы.Прием FROM Приемы, Врачи, Больные, Диагноз, Лекарства WHERE " + comboBox1.SelectedValue + " = Приемы.КодВрача AND Больные.КодПациента = Приемы.КодПациента AND Приемы.Диагноз = Диагноз.КодДиагноза AND Приемы.Лекарство = Лекарства.КодЛекарства AND Приемы.ДатаОбращения BETWEEN #" + dateTimePicker1.Text + "# AND #" + dateTimePicker2.Text + "#", conn);
            ad.Fill(ds);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].Visible = false;

            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
        }

        private void Form8_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
            var f = new Form1();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Word.Document WordDoc;
            var WordApp = new Word.Application();
            WordApp.Visible = true;
            WordDoc = WordApp.Documents.Add(Type.Missing, false, Word.WdNewDocumentType.wdNewBlankDocument, true);
            Word.Range wordrange = WordDoc.Range(0, 0);
            Word.Table wordtable = WordDoc.Tables.Add(wordrange, 8, 2, Word.WdDefaultTableBehavior.wdWord9TableBehavior, Word.WdAutoFitBehavior.wdAutoFitWindow);

            Word.Range wordcellrange = WordDoc.Tables[1].Cell(1, 1).Range;
            wordcellrange.Text = "ФИО пациента:";
            wordcellrange = wordtable.Cell(2, 1).Range;
            wordcellrange.Text = "Дата приема:";
            wordcellrange = wordtable.Cell(3, 1).Range;
            wordcellrange.Text = "Диагноз:";
            wordcellrange = wordtable.Cell(4, 1).Range;
            wordcellrange.Text = "Препарат:";
            wordcellrange = wordtable.Cell(5, 1).Range;
            wordcellrange.Text = "Дополнительно:";
            wordcellrange = wordtable.Cell(6, 1).Range;
            wordcellrange.Text = "Стоимость услуги:";
            wordcellrange = wordtable.Cell(7, 1).Range;
            wordcellrange.Text = "Подпись врача:";
            wordcellrange = wordtable.Cell(8, 1).Range;
            wordcellrange.Text = "Подпись пациента:";

            wordcellrange = wordtable.Cell(1, 2).Range;
            wordcellrange.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            wordcellrange = wordtable.Cell(2, 2).Range;
            wordcellrange.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            wordcellrange = wordtable.Cell(3, 2).Range;
            wordcellrange.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            wordcellrange = wordtable.Cell(4, 2).Range;
            wordcellrange.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            wordcellrange = wordtable.Cell(5, 2).Range;
            wordcellrange.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            wordcellrange = wordtable.Cell(6, 2).Range;
            wordcellrange.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString() + " ₽";
        }
    }
}
