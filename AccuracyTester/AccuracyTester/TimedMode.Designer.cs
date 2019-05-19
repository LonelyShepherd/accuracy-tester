namespace AccuracyTester
{
    partial class TimedMode
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
            this.getWord = new System.Windows.Forms.Button();
            this.givenWord = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // getWord
            // 
            this.getWord.Location = new System.Drawing.Point(351, 419);
            this.getWord.Name = "getWord";
            this.getWord.Size = new System.Drawing.Size(180, 61);
            this.getWord.TabIndex = 0;
            this.getWord.Text = "GET WORD TEST";
            this.getWord.UseVisualStyleBackColor = true;
            this.getWord.Click += new System.EventHandler(this.getWord_Click);
            // 
            // givenWord
            // 
            this.givenWord.AutoSize = true;
            this.givenWord.Location = new System.Drawing.Point(402, 388);
            this.givenWord.Name = "givenWord";
            this.givenWord.Size = new System.Drawing.Size(78, 13);
            this.givenWord.TabIndex = 1;
            this.givenWord.Text = "GIVEN WORD";
            // 
            // TimedMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 492);
            this.Controls.Add(this.givenWord);
            this.Controls.Add(this.getWord);
            this.Name = "TimedMode";
            this.Text = "TimedMode";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TimedMode_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TimedMode_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getWord;
        private System.Windows.Forms.Label givenWord;
    }
}