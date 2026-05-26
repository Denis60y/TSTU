namespace Task1
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.trackBarX = new System.Windows.Forms.TrackBar();
            this.trackBarY = new System.Windows.Forms.TrackBar();
            this.trackBarSizeX = new System.Windows.Forms.TrackBar();
            this.trackBarSizeY = new System.Windows.Forms.TrackBar();
            this.trackBarAlpha = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBarShX = new System.Windows.Forms.TrackBar();
            this.trackBarShY = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarShX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarShY)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(511, 541);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(529, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить фигуру";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Треугольник",
            "Квадрат",
            "Пятиугольник"});
            this.comboBox1.Location = new System.Drawing.Point(529, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // trackBarX
            // 
            this.trackBarX.Location = new System.Drawing.Point(529, 123);
            this.trackBarX.Maximum = 500;
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(179, 45);
            this.trackBarX.TabIndex = 3;
            this.trackBarX.Value = 100;
            this.trackBarX.Scroll += new System.EventHandler(this.trackBarX_Scroll);
            // 
            // trackBarY
            // 
            this.trackBarY.Location = new System.Drawing.Point(529, 187);
            this.trackBarY.Maximum = 500;
            this.trackBarY.Name = "trackBarY";
            this.trackBarY.Size = new System.Drawing.Size(179, 45);
            this.trackBarY.TabIndex = 4;
            this.trackBarY.Value = 100;
            this.trackBarY.Scroll += new System.EventHandler(this.trackBarY_Scroll);
            // 
            // trackBarSizeX
            // 
            this.trackBarSizeX.Location = new System.Drawing.Point(529, 251);
            this.trackBarSizeX.Maximum = 20;
            this.trackBarSizeX.Name = "trackBarSizeX";
            this.trackBarSizeX.Size = new System.Drawing.Size(179, 45);
            this.trackBarSizeX.TabIndex = 6;
            this.trackBarSizeX.Value = 1;
            this.trackBarSizeX.Scroll += new System.EventHandler(this.trackBarSizeX_Scroll);
            // 
            // trackBarSizeY
            // 
            this.trackBarSizeY.Location = new System.Drawing.Point(529, 320);
            this.trackBarSizeY.Maximum = 20;
            this.trackBarSizeY.Name = "trackBarSizeY";
            this.trackBarSizeY.Size = new System.Drawing.Size(179, 45);
            this.trackBarSizeY.TabIndex = 6;
            this.trackBarSizeY.Value = 1;
            this.trackBarSizeY.Scroll += new System.EventHandler(this.trackBarSizeY_Scroll);
            // 
            // trackBarAlpha
            // 
            this.trackBarAlpha.Location = new System.Drawing.Point(529, 393);
            this.trackBarAlpha.Maximum = 360;
            this.trackBarAlpha.Name = "trackBarAlpha";
            this.trackBarAlpha.Size = new System.Drawing.Size(179, 45);
            this.trackBarAlpha.TabIndex = 7;
            this.trackBarAlpha.Scroll += new System.EventHandler(this.trackBarAlpha_Scroll);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(529, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Перемещение по координатe X";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(529, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Перемещение по координатe Y";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(529, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Масштабирование на значение Sx";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(529, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Масштабирование на значение Sy";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(529, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Вращение на угол α";
            // 
            // trackBarShX
            // 
            this.trackBarShX.Location = new System.Drawing.Point(529, 459);
            this.trackBarShX.Name = "trackBarShX";
            this.trackBarShX.Size = new System.Drawing.Size(179, 45);
            this.trackBarShX.TabIndex = 13;
            this.trackBarShX.Scroll += new System.EventHandler(this.trackBarShX_Scroll);
            // 
            // trackBarShY
            // 
            this.trackBarShY.Location = new System.Drawing.Point(529, 523);
            this.trackBarShY.Name = "trackBarShY";
            this.trackBarShY.Size = new System.Drawing.Size(179, 45);
            this.trackBarShY.TabIndex = 14;
            this.trackBarShY.Scroll += new System.EventHandler(this.trackBarShY_Scroll);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(529, 437);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "Сдвиг  по координатe X";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(529, 501);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "Сдвиг  по координатe Y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 580);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trackBarShY);
            this.Controls.Add(this.trackBarShX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarAlpha);
            this.Controls.Add(this.trackBarSizeY);
            this.Controls.Add(this.trackBarSizeX);
            this.Controls.Add(this.trackBarY);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarShX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarShY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TrackBar trackBarX;
        private System.Windows.Forms.TrackBar trackBarY;
        private System.Windows.Forms.TrackBar trackBarSizeX;
        private System.Windows.Forms.TrackBar trackBarSizeY;
        private System.Windows.Forms.TrackBar trackBarAlpha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBarShX;
        private System.Windows.Forms.TrackBar trackBarShY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

