namespace Clicker
{
    partial class Main
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFile = new System.Windows.Forms.Button();
            this.RunIT = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.durationInput = new System.Windows.Forms.TextBox();
            this.timeInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "(*.txt)|*.txt";
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(15, 203);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(75, 23);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "OpenFile";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // RunIT
            // 
            this.RunIT.Location = new System.Drawing.Point(93, 241);
            this.RunIT.Name = "RunIT";
            this.RunIT.Size = new System.Drawing.Size(75, 23);
            this.RunIT.TabIndex = 1;
            this.RunIT.Text = "Run";
            this.RunIT.UseVisualStyleBackColor = true;
            this.RunIT.Click += new System.EventHandler(this.Show_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 42);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(221, 155);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(161, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // durationInput
            // 
            this.durationInput.Location = new System.Drawing.Point(60, 16);
            this.durationInput.Name = "durationInput";
            this.durationInput.Size = new System.Drawing.Size(68, 20);
            this.durationInput.TabIndex = 4;
            this.durationInput.Text = "60";
            this.durationInput.TextChanged += new System.EventHandler(this.durationInput_TextChanged);
            // 
            // timeInput
            // 
            this.timeInput.Location = new System.Drawing.Point(168, 16);
            this.timeInput.Name = "timeInput";
            this.timeInput.Size = new System.Drawing.Size(68, 20);
            this.timeInput.TabIndex = 5;
            this.timeInput.Text = "10000";
            this.timeInput.TextChanged += new System.EventHandler(this.timeInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Duration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Timer";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 276);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeInput);
            this.Controls.Add(this.durationInput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.RunIT);
            this.Controls.Add(this.openFile);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openFile;
        private Executor executor;
        private System.Windows.Forms.Button RunIT;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox durationInput;
        private System.Windows.Forms.TextBox timeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

