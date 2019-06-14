namespace AccuracyTester
{
    partial class VersusComputer
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
            this.givenWordCPU = new System.Windows.Forms.Label();
            this.givenWordPlayer = new System.Windows.Forms.Label();
            this.yourWord = new System.Windows.Forms.Label();
            this.computerWord = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cpuSolving = new System.Windows.Forms.Label();
            this.winMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // givenWordCPU
            // 
            this.givenWordCPU.AutoSize = true;
            this.givenWordCPU.BackColor = System.Drawing.Color.Transparent;
            this.givenWordCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.givenWordCPU.Location = new System.Drawing.Point(257, 369);
            this.givenWordCPU.Name = "givenWordCPU";
            this.givenWordCPU.Size = new System.Drawing.Size(263, 31);
            this.givenWordCPU.TabIndex = 0;
            this.givenWordCPU.Text = "COMPUTER WORD";
            this.givenWordCPU.Paint += new System.Windows.Forms.PaintEventHandler(this.givenWordCPU_Paint);
            // 
            // givenWordPlayer
            // 
            this.givenWordPlayer.AutoSize = true;
            this.givenWordPlayer.BackColor = System.Drawing.Color.Transparent;
            this.givenWordPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.givenWordPlayer.Location = new System.Drawing.Point(338, 22);
            this.givenWordPlayer.Name = "givenWordPlayer";
            this.givenWordPlayer.Size = new System.Drawing.Size(214, 31);
            this.givenWordPlayer.TabIndex = 1;
            this.givenWordPlayer.Text = "PLAYER WORD";
            this.givenWordPlayer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // yourWord
            // 
            this.yourWord.AutoSize = true;
            this.yourWord.BackColor = System.Drawing.Color.Transparent;
            this.yourWord.Location = new System.Drawing.Point(371, 9);
            this.yourWord.Name = "yourWord";
            this.yourWord.Size = new System.Drawing.Size(58, 13);
            this.yourWord.TabIndex = 2;
            this.yourWord.Text = "Your word:";
            // 
            // computerWord
            // 
            this.computerWord.AutoSize = true;
            this.computerWord.BackColor = System.Drawing.Color.Transparent;
            this.computerWord.Location = new System.Drawing.Point(341, 355);
            this.computerWord.Name = "computerWord";
            this.computerWord.Size = new System.Drawing.Size(88, 13);
            this.computerWord.TabIndex = 3;
            this.computerWord.Text = "Computer\'s word:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.winMessage);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 430);
            this.panel1.TabIndex = 11;
            this.panel1.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(374, 371);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Quit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Location = new System.Drawing.Point(210, 244);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(440, 100);
            this.panel4.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(226, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 63);
            this.label14.TabIndex = 3;
            this.label14.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(2, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 63);
            this.label13.TabIndex = 2;
            this.label13.Text = "0/0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Hits/Clicks";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(234, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Click accuracy";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(430, 137);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 100);
            this.panel3.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 63);
            this.label10.TabIndex = 1;
            this.label10.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Score";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(210, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(214, 100);
            this.panel2.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 63);
            this.label7.TabIndex = 1;
            this.label7.Text = "00:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Time";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(655, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(655, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "00:00";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(708, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "POINTS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(722, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "TIME";
            // 
            // cpuSolving
            // 
            this.cpuSolving.AutoSize = true;
            this.cpuSolving.BackColor = System.Drawing.Color.Transparent;
            this.cpuSolving.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpuSolving.Location = new System.Drawing.Point(350, 404);
            this.cpuSolving.Name = "cpuSolving";
            this.cpuSolving.Size = new System.Drawing.Size(154, 17);
            this.cpuSolving.TabIndex = 16;
            this.cpuSolving.Text = "Computer solving here ";
            this.cpuSolving.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // winMessage
            // 
            this.winMessage.AutoSize = true;
            this.winMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winMessage.Location = new System.Drawing.Point(277, 22);
            this.winMessage.Name = "winMessage";
            this.winMessage.Size = new System.Drawing.Size(243, 31);
            this.winMessage.TabIndex = 5;
            this.winMessage.Text = "CPU/Player wins!";
            this.winMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // VersusComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 430);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.computerWord);
            this.Controls.Add(this.yourWord);
            this.Controls.Add(this.givenWordPlayer);
            this.Controls.Add(this.givenWordCPU);
            this.Controls.Add(this.cpuSolving);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Name = "VersusComputer";
            this.Text = "VersusComputer";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VersusComputer_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VersusComputer_MouseClick_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label givenWordCPU;
        private System.Windows.Forms.Label givenWordPlayer;
        private System.Windows.Forms.Label yourWord;
        private System.Windows.Forms.Label computerWord;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label cpuSolving;
        private System.Windows.Forms.Label winMessage;
    }
}