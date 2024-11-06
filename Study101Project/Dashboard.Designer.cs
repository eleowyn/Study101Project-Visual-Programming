namespace Study101Project
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.labelProfile = new System.Windows.Forms.Label();
            this.labelTracker = new System.Windows.Forms.Label();
            this.labelBrainhack = new System.Windows.Forms.Label();
            this.labelDiary = new System.Windows.Forms.Label();
            this.labelGames = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProfile
            // 
            this.labelProfile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelProfile.AutoSize = true;
            this.labelProfile.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProfile.Location = new System.Drawing.Point(50, 243);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(121, 21);
            this.labelProfile.TabIndex = 0;
            this.labelProfile.Text = ">>    Profile";
            this.labelProfile.Click += new System.EventHandler(this.labelProfile_Click);
            // 
            // labelTracker
            // 
            this.labelTracker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTracker.AutoSize = true;
            this.labelTracker.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTracker.Location = new System.Drawing.Point(50, 297);
            this.labelTracker.Name = "labelTracker";
            this.labelTracker.Size = new System.Drawing.Size(128, 21);
            this.labelTracker.TabIndex = 1;
            this.labelTracker.Text = ">>    Tracker";
            this.labelTracker.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // labelBrainhack
            // 
            this.labelBrainhack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBrainhack.AutoSize = true;
            this.labelBrainhack.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBrainhack.Location = new System.Drawing.Point(50, 505);
            this.labelBrainhack.Name = "labelBrainhack";
            this.labelBrainhack.Size = new System.Drawing.Size(150, 21);
            this.labelBrainhack.TabIndex = 2;
            this.labelBrainhack.Text = ">>    Brainhack";
            this.labelBrainhack.Click += new System.EventHandler(this.label3_Click);
            // 
            // labelDiary
            // 
            this.labelDiary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDiary.AutoSize = true;
            this.labelDiary.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiary.Location = new System.Drawing.Point(50, 567);
            this.labelDiary.Name = "labelDiary";
            this.labelDiary.Size = new System.Drawing.Size(109, 21);
            this.labelDiary.TabIndex = 3;
            this.labelDiary.Text = ">>    Diary";
            this.labelDiary.Click += new System.EventHandler(this.labelDiary_Click);
            // 
            // labelGames
            // 
            this.labelGames.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelGames.AutoSize = true;
            this.labelGames.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGames.Location = new System.Drawing.Point(50, 624);
            this.labelGames.Name = "labelGames";
            this.labelGames.Size = new System.Drawing.Size(119, 21);
            this.labelGames.TabIndex = 4;
            this.labelGames.Text = ">>    Games";
            this.labelGames.Click += new System.EventHandler(this.labelGames_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.monthCalendar1.BackColor = System.Drawing.SystemColors.Info;
            this.monthCalendar1.Location = new System.Drawing.Point(395, 74);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 9;
            this.monthCalendar1.TitleBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.monthCalendar1.TrailingForeColor = System.Drawing.Color.IndianRed;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(389, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "TASKS";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = ">  Calendar Tracker";
            this.label2.Click += new System.EventHandler(this.label2_Click_2);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = ">  To-do Lists";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 419);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = ">  Study Tracker";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 35);
            this.label5.TabIndex = 15;
            this.label5.Text = "Dashboard";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(395, 408);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(439, 267);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1223, 745);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.labelGames);
            this.Controls.Add(this.labelDiary);
            this.Controls.Add(this.labelBrainhack);
            this.Controls.Add(this.labelTracker);
            this.Controls.Add(this.labelProfile);
            this.DoubleBuffered = true;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProfile;
        private System.Windows.Forms.Label labelTracker;
        private System.Windows.Forms.Label labelBrainhack;
        private System.Windows.Forms.Label labelDiary;
        private System.Windows.Forms.Label labelGames;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}