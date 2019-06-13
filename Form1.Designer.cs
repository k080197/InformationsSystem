namespace Поликлиника
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.курсоваяDataSet = new Поликлиника.КурсоваяDataSet();
            this.врачиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.врачиTableAdapter = new Поликлиника.КурсоваяDataSetTableAdapters.ВрачиTableAdapter();
            this.tableAdapterManager = new Поликлиника.КурсоваяDataSetTableAdapters.TableAdapterManager();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.врачиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.специальностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лекарстваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.диагнозыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пациентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приемыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кабинетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.формыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приемПациентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расписаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.открытьРасписаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьСправкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.курсоваяDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.врачиBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // курсоваяDataSet
            // 
            this.курсоваяDataSet.DataSetName = "КурсоваяDataSet";
            this.курсоваяDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // врачиBindingSource
            // 
            this.врачиBindingSource.DataMember = "Врачи";
            this.врачиBindingSource.DataSource = this.курсоваяDataSet;
            // 
            // врачиTableAdapter
            // 
            this.врачиTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Поликлиника.КурсоваяDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.БольныеTableAdapter = null;
            this.tableAdapterManager.ВрачиTableAdapter = this.врачиTableAdapter;
            this.tableAdapterManager.ДиагнозTableAdapter = null;
            this.tableAdapterManager.ЛекарстваTableAdapter = null;
            this.tableAdapterManager.ПриемыTableAdapter = null;
            this.tableAdapterManager.СпециальностьTableAdapter = null;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.таблицыToolStripMenuItem,
            this.формыToolStripMenuItem,
            this.расписаниеToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(628, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.файлToolStripMenuItem.Text = "Главная";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // таблицыToolStripMenuItem
            // 
            this.таблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.врачиToolStripMenuItem,
            this.специальностиToolStripMenuItem,
            this.лекарстваToolStripMenuItem,
            this.диагнозыToolStripMenuItem,
            this.пациентыToolStripMenuItem,
            this.приемыToolStripMenuItem,
            this.кабинетыToolStripMenuItem});
            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.таблицыToolStripMenuItem.Text = "Таблицы";
            this.таблицыToolStripMenuItem.Click += new System.EventHandler(this.таблицыToolStripMenuItem_Click);
            // 
            // врачиToolStripMenuItem
            // 
            this.врачиToolStripMenuItem.Name = "врачиToolStripMenuItem";
            this.врачиToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.врачиToolStripMenuItem.Text = "Врачи";
            this.врачиToolStripMenuItem.Click += new System.EventHandler(this.врачиToolStripMenuItem_Click);
            // 
            // специальностиToolStripMenuItem
            // 
            this.специальностиToolStripMenuItem.Name = "специальностиToolStripMenuItem";
            this.специальностиToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.специальностиToolStripMenuItem.Text = "Специальности";
            this.специальностиToolStripMenuItem.Click += new System.EventHandler(this.специальностиToolStripMenuItem_Click);
            // 
            // лекарстваToolStripMenuItem
            // 
            this.лекарстваToolStripMenuItem.Name = "лекарстваToolStripMenuItem";
            this.лекарстваToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.лекарстваToolStripMenuItem.Text = "Лекарства";
            this.лекарстваToolStripMenuItem.Click += new System.EventHandler(this.лекарстваToolStripMenuItem_Click);
            // 
            // диагнозыToolStripMenuItem
            // 
            this.диагнозыToolStripMenuItem.Name = "диагнозыToolStripMenuItem";
            this.диагнозыToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.диагнозыToolStripMenuItem.Text = "Диагнозы";
            this.диагнозыToolStripMenuItem.Click += new System.EventHandler(this.диагнозыToolStripMenuItem_Click);
            // 
            // пациентыToolStripMenuItem
            // 
            this.пациентыToolStripMenuItem.Name = "пациентыToolStripMenuItem";
            this.пациентыToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.пациентыToolStripMenuItem.Text = "Пациенты";
            this.пациентыToolStripMenuItem.Click += new System.EventHandler(this.пациентыToolStripMenuItem_Click);
            // 
            // приемыToolStripMenuItem
            // 
            this.приемыToolStripMenuItem.Name = "приемыToolStripMenuItem";
            this.приемыToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.приемыToolStripMenuItem.Text = "Приемы";
            this.приемыToolStripMenuItem.Click += new System.EventHandler(this.приемыToolStripMenuItem_Click);
            // 
            // кабинетыToolStripMenuItem
            // 
            this.кабинетыToolStripMenuItem.Name = "кабинетыToolStripMenuItem";
            this.кабинетыToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.кабинетыToolStripMenuItem.Text = "Кабинеты";
            this.кабинетыToolStripMenuItem.Click += new System.EventHandler(this.кабинетыToolStripMenuItem_Click);
            // 
            // формыToolStripMenuItem
            // 
            this.формыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.приемПациентаToolStripMenuItem});
            this.формыToolStripMenuItem.Name = "формыToolStripMenuItem";
            this.формыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.формыToolStripMenuItem.Text = "Формы";
            // 
            // приемПациентаToolStripMenuItem
            // 
            this.приемПациентаToolStripMenuItem.Name = "приемПациентаToolStripMenuItem";
            this.приемПациентаToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.приемПациентаToolStripMenuItem.Text = "Прием пациента";
            this.приемПациентаToolStripMenuItem.Click += new System.EventHandler(this.приемПациентаToolStripMenuItem_Click);
            // 
            // расписаниеToolStripMenuItem
            // 
            this.расписаниеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьРасписаниеToolStripMenuItem});
            this.расписаниеToolStripMenuItem.Name = "расписаниеToolStripMenuItem";
            this.расписаниеToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.расписаниеToolStripMenuItem.Text = "Расписание";
            this.расписаниеToolStripMenuItem.Click += new System.EventHandler(this.расписаниеToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(618, 204);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // открытьРасписаниеToolStripMenuItem
            // 
            this.открытьРасписаниеToolStripMenuItem.Name = "открытьРасписаниеToolStripMenuItem";
            this.открытьРасписаниеToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.открытьРасписаниеToolStripMenuItem.Text = "Открыть расписание";
            this.открытьРасписаниеToolStripMenuItem.Click += new System.EventHandler(this.открытьРасписаниеToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьСправкуToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // открытьСправкуToolStripMenuItem
            // 
            this.открытьСправкуToolStripMenuItem.Name = "открытьСправкуToolStripMenuItem";
            this.открытьСправкуToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.открытьСправкуToolStripMenuItem.Text = "Открыть справку";
            this.открытьСправкуToolStripMenuItem.Click += new System.EventHandler(this.открытьСправкуToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(628, 306);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Главная форма";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.курсоваяDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.врачиBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private КурсоваяDataSet курсоваяDataSet;
        private System.Windows.Forms.BindingSource врачиBindingSource;
        private КурсоваяDataSetTableAdapters.ВрачиTableAdapter врачиTableAdapter;
        private КурсоваяDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem врачиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem специальностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лекарстваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem диагнозыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пациентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem приемыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кабинетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem формыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem приемПациентаToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расписаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьРасписаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьСправкуToolStripMenuItem;
    }
}

