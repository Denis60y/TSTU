namespace Task2
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBarY3 = new System.Windows.Forms.TrackBar();
            this.trackBarX3 = new System.Windows.Forms.TrackBar();
            this.trackBarY2 = new System.Windows.Forms.TrackBar();
            this.trackBarX2 = new System.Windows.Forms.TrackBar();
            this.trackBarY1 = new System.Windows.Forms.TrackBar();
            this.trackBarX1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(623, 605);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(641, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Z-индекс первого квадрата(красного)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(641, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(95, 20);
            this.textBox1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(641, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "Z-индекс пвторого квадрата(синего)";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(641, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(95, 20);
            this.textBox2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(638, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Z-индекс третьего квадрата(зелёного)";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(641, 151);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(95, 20);
            this.textBox3.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(640, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 40);
            this.button1.TabIndex = 12;
            this.button1.Text = "Нарисовать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(645, 549);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 31);
            this.label9.TabIndex = 31;
            this.label9.Text = "подвинуть третий квадрат вниз на:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(645, 485);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 31);
            this.label8.TabIndex = 30;
            this.label8.Text = "подвинуть третий квадрат вправо на:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(645, 419);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 31);
            this.label7.TabIndex = 29;
            this.label7.Text = "подвинуть второй квадрат вниз на:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(645, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 31);
            this.label6.TabIndex = 28;
            this.label6.Text = "подвинуть второй квадрат вправо на:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(645, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 31);
            this.label5.TabIndex = 27;
            this.label5.Text = "подвинуть первый квадрат вниз на:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(645, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 29);
            this.label4.TabIndex = 26;
            this.label4.Text = "подвинуть первый квадрат вправо на:";
            // 
            // trackBarY3
            // 
            this.trackBarY3.Location = new System.Drawing.Point(644, 583);
            this.trackBarY3.Maximum = 400;
            this.trackBarY3.Name = "trackBarY3";
            this.trackBarY3.Size = new System.Drawing.Size(143, 45);
            this.trackBarY3.TabIndex = 25;
            this.trackBarY3.Scroll += new System.EventHandler(this.trackBarY3_Scroll);
            // 
            // trackBarX3
            // 
            this.trackBarX3.Location = new System.Drawing.Point(644, 519);
            this.trackBarX3.Maximum = 400;
            this.trackBarX3.Name = "trackBarX3";
            this.trackBarX3.Size = new System.Drawing.Size(143, 45);
            this.trackBarX3.TabIndex = 24;
            this.trackBarX3.Scroll += new System.EventHandler(this.trackBarX3_Scroll);
            // 
            // trackBarY2
            // 
            this.trackBarY2.Location = new System.Drawing.Point(644, 453);
            this.trackBarY2.Maximum = 400;
            this.trackBarY2.Name = "trackBarY2";
            this.trackBarY2.Size = new System.Drawing.Size(143, 45);
            this.trackBarY2.TabIndex = 23;
            this.trackBarY2.Scroll += new System.EventHandler(this.trackBarY2_Scroll);
            // 
            // trackBarX2
            // 
            this.trackBarX2.Location = new System.Drawing.Point(644, 387);
            this.trackBarX2.Maximum = 400;
            this.trackBarX2.Name = "trackBarX2";
            this.trackBarX2.Size = new System.Drawing.Size(143, 45);
            this.trackBarX2.TabIndex = 22;
            this.trackBarX2.Scroll += new System.EventHandler(this.trackBarX2_Scroll);
            // 
            // trackBarY1
            // 
            this.trackBarY1.Location = new System.Drawing.Point(644, 319);
            this.trackBarY1.Maximum = 400;
            this.trackBarY1.Name = "trackBarY1";
            this.trackBarY1.Size = new System.Drawing.Size(143, 45);
            this.trackBarY1.TabIndex = 21;
            this.trackBarY1.Scroll += new System.EventHandler(this.trackBarY1_Scroll);
            // 
            // trackBarX1
            // 
            this.trackBarX1.Location = new System.Drawing.Point(642, 252);
            this.trackBarX1.Maximum = 400;
            this.trackBarX1.Name = "trackBarX1";
            this.trackBarX1.Size = new System.Drawing.Size(143, 45);
            this.trackBarX1.TabIndex = 20;
            this.trackBarX1.Scroll += new System.EventHandler(this.trackBarX1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 629);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBarY3);
            this.Controls.Add(this.trackBarX3);
            this.Controls.Add(this.trackBarY2);
            this.Controls.Add(this.trackBarX2);
            this.Controls.Add(this.trackBarY1);
            this.Controls.Add(this.trackBarX1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBarY3;
        private System.Windows.Forms.TrackBar trackBarX3;
        private System.Windows.Forms.TrackBar trackBarY2;
        private System.Windows.Forms.TrackBar trackBarX2;
        private System.Windows.Forms.TrackBar trackBarY1;
        private System.Windows.Forms.TrackBar trackBarX1;
    }
}

