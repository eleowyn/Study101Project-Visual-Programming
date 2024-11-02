namespace Study101Project
{
    partial class STechnique
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STechnique));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelDetik = new System.Windows.Forms.Label();
            this.labelMenit = new System.Windows.Forms.Label();
            this.labelJam = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.labelMinutes = new System.Windows.Forms.Label();
            this.Hours = new System.Windows.Forms.Label();
            this.numericUpDownSeconds = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
            this.labelPomodoro = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btnFlip = new System.Windows.Forms.Button();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnAddFlashcard = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblTemplateQ = new System.Windows.Forms.Label();
            this.lblTemplateA = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.MistyRose;
            this.groupBox1.Controls.Add(this.labelDetik);
            this.groupBox1.Controls.Add(this.labelMenit);
            this.groupBox1.Controls.Add(this.labelJam);
            this.groupBox1.Controls.Add(this.buttonStop);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.labelSeconds);
            this.groupBox1.Controls.Add(this.labelMinutes);
            this.groupBox1.Controls.Add(this.Hours);
            this.groupBox1.Controls.Add(this.numericUpDownSeconds);
            this.groupBox1.Controls.Add(this.numericUpDownMinutes);
            this.groupBox1.Controls.Add(this.numericUpDownHours);
            this.groupBox1.Controls.Add(this.labelPomodoro);
            this.groupBox1.Location = new System.Drawing.Point(28, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 468);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Timer";
            // 
            // labelDetik
            // 
            this.labelDetik.AutoSize = true;
            this.labelDetik.Font = new System.Drawing.Font("Mongolian Baiti", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetik.Location = new System.Drawing.Point(308, 357);
            this.labelDetik.Name = "labelDetik";
            this.labelDetik.Size = new System.Drawing.Size(61, 43);
            this.labelDetik.TabIndex = 11;
            this.labelDetik.Text = "00";
            // 
            // labelMenit
            // 
            this.labelMenit.AutoSize = true;
            this.labelMenit.Font = new System.Drawing.Font("Mongolian Baiti", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenit.Location = new System.Drawing.Point(201, 357);
            this.labelMenit.Name = "labelMenit";
            this.labelMenit.Size = new System.Drawing.Size(61, 43);
            this.labelMenit.TabIndex = 10;
            this.labelMenit.Text = "00";
            // 
            // labelJam
            // 
            this.labelJam.AutoSize = true;
            this.labelJam.Font = new System.Drawing.Font("Mongolian Baiti", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJam.Location = new System.Drawing.Point(104, 357);
            this.labelJam.Name = "labelJam";
            this.labelJam.Size = new System.Drawing.Size(61, 43);
            this.labelJam.TabIndex = 9;
            this.labelJam.Text = "00";
            this.labelJam.Click += new System.EventHandler(this.labelJam_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.Location = new System.Drawing.Point(257, 285);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(76, 34);
            this.buttonStop.TabIndex = 8;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(164, 285);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(76, 34);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSeconds.Location = new System.Drawing.Point(104, 223);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(77, 21);
            this.labelSeconds.TabIndex = 6;
            this.labelSeconds.Text = "Seconds";
            // 
            // labelMinutes
            // 
            this.labelMinutes.AutoSize = true;
            this.labelMinutes.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinutes.Location = new System.Drawing.Point(104, 168);
            this.labelMinutes.Name = "labelMinutes";
            this.labelMinutes.Size = new System.Drawing.Size(77, 21);
            this.labelMinutes.TabIndex = 5;
            this.labelMinutes.Text = "Minutes";
            this.labelMinutes.Click += new System.EventHandler(this.labelMinutes_Click);
            // 
            // Hours
            // 
            this.Hours.AutoSize = true;
            this.Hours.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hours.Location = new System.Drawing.Point(104, 116);
            this.Hours.Name = "Hours";
            this.Hours.Size = new System.Drawing.Size(59, 21);
            this.Hours.TabIndex = 4;
            this.Hours.Text = "Hours";
            // 
            // numericUpDownSeconds
            // 
            this.numericUpDownSeconds.Location = new System.Drawing.Point(280, 225);
            this.numericUpDownSeconds.Name = "numericUpDownSeconds";
            this.numericUpDownSeconds.Size = new System.Drawing.Size(166, 22);
            this.numericUpDownSeconds.TabIndex = 3;
            // 
            // numericUpDownMinutes
            // 
            this.numericUpDownMinutes.Location = new System.Drawing.Point(280, 167);
            this.numericUpDownMinutes.Name = "numericUpDownMinutes";
            this.numericUpDownMinutes.Size = new System.Drawing.Size(166, 22);
            this.numericUpDownMinutes.TabIndex = 2;
            // 
            // numericUpDownHours
            // 
            this.numericUpDownHours.Location = new System.Drawing.Point(280, 115);
            this.numericUpDownHours.Name = "numericUpDownHours";
            this.numericUpDownHours.Size = new System.Drawing.Size(166, 22);
            this.numericUpDownHours.TabIndex = 1;
            // 
            // labelPomodoro
            // 
            this.labelPomodoro.AutoSize = true;
            this.labelPomodoro.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPomodoro.Location = new System.Drawing.Point(158, 18);
            this.labelPomodoro.Name = "labelPomodoro";
            this.labelPomodoro.Size = new System.Drawing.Size(147, 31);
            this.labelPomodoro.TabIndex = 0;
            this.labelPomodoro.Text = "Pomodoro";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.BackColor = System.Drawing.Color.PapayaWhip;
            this.groupBox2.Controls.Add(this.lblTemplateA);
            this.groupBox2.Controls.Add(this.lblTemplateQ);
            this.groupBox2.Controls.Add(this.btnPrevious);
            this.groupBox2.Controls.Add(this.btnAddFlashcard);
            this.groupBox2.Controls.Add(this.btnNext);
            this.groupBox2.Controls.Add(this.lblAnswer);
            this.groupBox2.Controls.Add(this.btnFlip);
            this.groupBox2.Controls.Add(this.lblQuestion);
            this.groupBox2.Location = new System.Drawing.Point(548, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(502, 468);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Flashcards";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(223, 71);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(97, 23);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Question";
            this.lblQuestion.Click += new System.EventHandler(this.lblQuestion_Click);
            // 
            // timer4
            // 
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(28, 587);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFlip
            // 
            this.btnFlip.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFlip.Location = new System.Drawing.Point(187, 279);
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.Size = new System.Drawing.Size(140, 40);
            this.btnFlip.TabIndex = 1;
            this.btnFlip.Text = "Answer";
            this.btnFlip.UseVisualStyleBackColor = true;
            this.btnFlip.Click += new System.EventHandler(this.btnFlip_Click);
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer.Location = new System.Drawing.Point(223, 163);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(81, 23);
            this.lblAnswer.TabIndex = 2;
            this.lblAnswer.Text = "Answer";
            this.lblAnswer.Click += new System.EventHandler(this.lblAnswer_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(286, 410);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(140, 40);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnAddFlashcard
            // 
            this.btnAddFlashcard.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFlashcard.Location = new System.Drawing.Point(187, 325);
            this.btnAddFlashcard.Name = "btnAddFlashcard";
            this.btnAddFlashcard.Size = new System.Drawing.Size(140, 40);
            this.btnAddFlashcard.TabIndex = 4;
            this.btnAddFlashcard.Text = "Add";
            this.btnAddFlashcard.UseVisualStyleBackColor = true;
            this.btnAddFlashcard.Click += new System.EventHandler(this.btnAddFlashcard_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(105, 410);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(140, 40);
            this.btnPrevious.TabIndex = 5;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblTemplateQ
            // 
            this.lblTemplateQ.AutoSize = true;
            this.lblTemplateQ.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplateQ.Location = new System.Drawing.Point(28, 71);
            this.lblTemplateQ.Name = "lblTemplateQ";
            this.lblTemplateQ.Size = new System.Drawing.Size(95, 23);
            this.lblTemplateQ.TabIndex = 6;
            this.lblTemplateQ.Text = "Question";
            // 
            // lblTemplateA
            // 
            this.lblTemplateA.AutoSize = true;
            this.lblTemplateA.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplateA.Location = new System.Drawing.Point(28, 150);
            this.lblTemplateA.Name = "lblTemplateA";
            this.lblTemplateA.Size = new System.Drawing.Size(82, 23);
            this.lblTemplateA.TabIndex = 7;
            this.lblTemplateA.Text = "Answer";
            // 
            // STechnique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1062, 630);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "STechnique";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STechnique";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelPomodoro;
        private System.Windows.Forms.Label labelSeconds;
        private System.Windows.Forms.Label labelMinutes;
        private System.Windows.Forms.Label Hours;
        private System.Windows.Forms.NumericUpDown numericUpDownSeconds;
        private System.Windows.Forms.NumericUpDown numericUpDownMinutes;
        private System.Windows.Forms.NumericUpDown numericUpDownHours;
        private System.Windows.Forms.Label labelDetik;
        private System.Windows.Forms.Label labelMenit;
        private System.Windows.Forms.Label labelJam;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Button btnFlip;
        private System.Windows.Forms.Button btnAddFlashcard;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblTemplateA;
        private System.Windows.Forms.Label lblTemplateQ;
    }
}