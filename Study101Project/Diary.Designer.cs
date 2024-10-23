namespace Study101Project
{
    partial class Diary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Diary));
            this.dateDiary = new System.Windows.Forms.DateTimePicker();
            this.labelNewDiary = new System.Windows.Forms.Label();
            this.labelDeleteDiary = new System.Windows.Forms.Label();
            this.labelSaveDiary = new System.Windows.Forms.Label();
            this.labelClearDiary = new System.Windows.Forms.Label();
            this.labelBackDiary = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Diary_List = new System.Windows.Forms.ListBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelDatetime = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateDiary
            // 
            this.dateDiary.CalendarMonthBackground = System.Drawing.Color.MistyRose;
            this.dateDiary.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateDiary.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDiary.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDiary.Location = new System.Drawing.Point(51, 46);
            this.dateDiary.Name = "dateDiary";
            this.dateDiary.Size = new System.Drawing.Size(283, 28);
            this.dateDiary.TabIndex = 0;
            this.dateDiary.ValueChanged += new System.EventHandler(this.dateDiary_ValueChanged);
            // 
            // labelNewDiary
            // 
            this.labelNewDiary.AutoSize = true;
            this.labelNewDiary.BackColor = System.Drawing.Color.Linen;
            this.labelNewDiary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewDiary.Location = new System.Drawing.Point(820, 625);
            this.labelNewDiary.Name = "labelNewDiary";
            this.labelNewDiary.Size = new System.Drawing.Size(49, 22);
            this.labelNewDiary.TabIndex = 4;
            this.labelNewDiary.Text = "New";
            this.labelNewDiary.Click += new System.EventHandler(this.labelNewDiary_Click);
            // 
            // labelDeleteDiary
            // 
            this.labelDeleteDiary.AutoSize = true;
            this.labelDeleteDiary.BackColor = System.Drawing.Color.Linen;
            this.labelDeleteDiary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeleteDiary.Location = new System.Drawing.Point(975, 625);
            this.labelDeleteDiary.Name = "labelDeleteDiary";
            this.labelDeleteDiary.Size = new System.Drawing.Size(68, 22);
            this.labelDeleteDiary.TabIndex = 5;
            this.labelDeleteDiary.Text = "Delete";
            this.labelDeleteDiary.Click += new System.EventHandler(this.labelDeleteDiary_Click);
            // 
            // labelSaveDiary
            // 
            this.labelSaveDiary.AutoSize = true;
            this.labelSaveDiary.BackColor = System.Drawing.Color.SeaShell;
            this.labelSaveDiary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaveDiary.Location = new System.Drawing.Point(678, 625);
            this.labelSaveDiary.Name = "labelSaveDiary";
            this.labelSaveDiary.Size = new System.Drawing.Size(55, 22);
            this.labelSaveDiary.TabIndex = 6;
            this.labelSaveDiary.Text = "Save";
            this.labelSaveDiary.Click += new System.EventHandler(this.labelSaveDiary_Click);
            // 
            // labelClearDiary
            // 
            this.labelClearDiary.AutoSize = true;
            this.labelClearDiary.BackColor = System.Drawing.Color.Linen;
            this.labelClearDiary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClearDiary.Location = new System.Drawing.Point(605, 625);
            this.labelClearDiary.Name = "labelClearDiary";
            this.labelClearDiary.Size = new System.Drawing.Size(58, 22);
            this.labelClearDiary.TabIndex = 7;
            this.labelClearDiary.Text = "Clear";
            this.labelClearDiary.Click += new System.EventHandler(this.labelClearDiary_Click);
            // 
            // labelBackDiary
            // 
            this.labelBackDiary.AutoSize = true;
            this.labelBackDiary.BackColor = System.Drawing.Color.Linen;
            this.labelBackDiary.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBackDiary.Location = new System.Drawing.Point(27, 635);
            this.labelBackDiary.Name = "labelBackDiary";
            this.labelBackDiary.Size = new System.Drawing.Size(46, 19);
            this.labelBackDiary.TabIndex = 8;
            this.labelBackDiary.Text = "Back";
            this.labelBackDiary.Click += new System.EventHandler(this.labelBackDiary_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FloralWhite;
            this.textBox1.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(45, 95);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(712, 518);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Diary_List
            // 
            this.Diary_List.BackColor = System.Drawing.Color.SeaShell;
            this.Diary_List.FormattingEnabled = true;
            this.Diary_List.ItemHeight = 16;
            this.Diary_List.Location = new System.Drawing.Point(804, 33);
            this.Diary_List.Name = "Diary_List";
            this.Diary_List.Size = new System.Drawing.Size(239, 580);
            this.Diary_List.TabIndex = 10;
            this.Diary_List.SelectedIndexChanged += new System.EventHandler(this.Diary_List_SelectedIndexChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(370, 46);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(308, 28);
            this.textBoxName.TabIndex = 11;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelDatetime
            // 
            this.labelDatetime.AutoSize = true;
            this.labelDatetime.BackColor = System.Drawing.Color.FloralWhite;
            this.labelDatetime.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDatetime.Location = new System.Drawing.Point(47, 24);
            this.labelDatetime.Name = "labelDatetime";
            this.labelDatetime.Size = new System.Drawing.Size(111, 19);
            this.labelDatetime.TabIndex = 12;
            this.labelDatetime.Text = "Date and time";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.FloralWhite;
            this.labelName.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(366, 24);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(98, 19);
            this.labelName.TabIndex = 13;
            this.labelName.Text = "Diary Name";
            // 
            // Diary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1061, 678);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelDatetime);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.Diary_List);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelBackDiary);
            this.Controls.Add(this.labelClearDiary);
            this.Controls.Add(this.labelSaveDiary);
            this.Controls.Add(this.labelDeleteDiary);
            this.Controls.Add(this.labelNewDiary);
            this.Controls.Add(this.dateDiary);
            this.DoubleBuffered = true;
            this.Name = "Diary";
            this.Text = "Diary";
            this.Load += new System.EventHandler(this.Diary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateDiary;
        private System.Windows.Forms.Label labelNewDiary;
        private System.Windows.Forms.Label labelDeleteDiary;
        private System.Windows.Forms.Label labelSaveDiary;
        private System.Windows.Forms.Label labelClearDiary;
        private System.Windows.Forms.Label labelBackDiary;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox Diary_List;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelDatetime;
        private System.Windows.Forms.Label labelName;
    }
}