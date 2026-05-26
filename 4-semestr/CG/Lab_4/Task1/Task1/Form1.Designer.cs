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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarY = new System.Windows.Forms.TrackBar();
            this.trackBarX = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBarAlpha = new System.Windows.Forms.TrackBar();
            this.trackBarSizeY = new System.Windows.Forms.TrackBar();
            this.trackBarSizeX = new System.Windows.Forms.TrackBar();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonChooseFile = new System.Windows.Forms.Button();
            this.trackBarContrast = new System.Windows.Forms.TrackBar();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.trackBarSaturation = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxX1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.trackBarX1 = new System.Windows.Forms.TrackBar();
            this.trackBarY1 = new System.Windows.Forms.TrackBar();
            this.textBoxY1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.trackBarY2 = new System.Windows.Forms.TrackBar();
            this.textBoxY2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.trackBar2X = new System.Windows.Forms.TrackBar();
            this.textBoxX2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.trackBarY3 = new System.Windows.Forms.TrackBar();
            this.textBoxY3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.trackBarX3 = new System.Windows.Forms.TrackBar();
            this.textBoxX3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.trackBarY4 = new System.Windows.Forms.TrackBar();
            this.textBoxY4 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.trackBarX4 = new System.Windows.Forms.TrackBar();
            this.textBoxX4 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(511, 614);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(529, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Перемещение по координатe Y";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(529, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Перемещение по координатe X";
            // 
            // trackBarY
            // 
            this.trackBarY.Location = new System.Drawing.Point(529, 167);
            this.trackBarY.Maximum = 500;
            this.trackBarY.Name = "trackBarY";
            this.trackBarY.Size = new System.Drawing.Size(179, 45);
            this.trackBarY.TabIndex = 11;
            this.trackBarY.Value = 100;
            this.trackBarY.Scroll += new System.EventHandler(this.trackBarY_Scroll);
            // 
            // trackBarX
            // 
            this.trackBarX.Location = new System.Drawing.Point(529, 103);
            this.trackBarX.Maximum = 500;
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(179, 45);
            this.trackBarX.TabIndex = 10;
            this.trackBarX.Value = 100;
            this.trackBarX.Scroll += new System.EventHandler(this.trackBarX_Scroll);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(529, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 19);
            this.label5.TabIndex = 19;
            this.label5.Text = "Вращение на угол α";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(529, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "Масштабирование на значение Sy";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(529, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Масштабирование на значение Sx";
            // 
            // trackBarAlpha
            // 
            this.trackBarAlpha.Location = new System.Drawing.Point(529, 372);
            this.trackBarAlpha.Maximum = 360;
            this.trackBarAlpha.Name = "trackBarAlpha";
            this.trackBarAlpha.Size = new System.Drawing.Size(179, 45);
            this.trackBarAlpha.TabIndex = 16;
            this.trackBarAlpha.Scroll += new System.EventHandler(this.trackBarAlpha_Scroll);
            // 
            // trackBarSizeY
            // 
            this.trackBarSizeY.Location = new System.Drawing.Point(529, 299);
            this.trackBarSizeY.Maximum = 20;
            this.trackBarSizeY.Name = "trackBarSizeY";
            this.trackBarSizeY.Size = new System.Drawing.Size(179, 45);
            this.trackBarSizeY.TabIndex = 14;
            this.trackBarSizeY.Value = 1;
            this.trackBarSizeY.Scroll += new System.EventHandler(this.trackBarSizeY_Scroll);
            // 
            // trackBarSizeX
            // 
            this.trackBarSizeX.Location = new System.Drawing.Point(529, 230);
            this.trackBarSizeX.Maximum = 20;
            this.trackBarSizeX.Name = "trackBarSizeX";
            this.trackBarSizeX.Size = new System.Drawing.Size(179, 45);
            this.trackBarSizeX.TabIndex = 15;
            this.trackBarSizeX.Value = 1;
            this.trackBarSizeX.Scroll += new System.EventHandler(this.trackBarSizeX_Scroll);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(529, 12);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(179, 57);
            this.buttonClear.TabIndex = 20;
            this.buttonClear.Text = "Сбросить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonChooseFile
            // 
            this.buttonChooseFile.Location = new System.Drawing.Point(731, 14);
            this.buttonChooseFile.Name = "buttonChooseFile";
            this.buttonChooseFile.Size = new System.Drawing.Size(179, 55);
            this.buttonChooseFile.TabIndex = 21;
            this.buttonChooseFile.Text = "Выбрать файл";
            this.buttonChooseFile.UseVisualStyleBackColor = true;
            this.buttonChooseFile.Click += new System.EventHandler(this.buttonChooseFile_Click);
            // 
            // trackBarContrast
            // 
            this.trackBarContrast.Location = new System.Drawing.Point(535, 449);
            this.trackBarContrast.Maximum = 30;
            this.trackBarContrast.Name = "trackBarContrast";
            this.trackBarContrast.Size = new System.Drawing.Size(179, 45);
            this.trackBarContrast.TabIndex = 22;
            this.trackBarContrast.Value = 10;
            this.trackBarContrast.Scroll += new System.EventHandler(this.trackBarContrast_Scroll);
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.Location = new System.Drawing.Point(535, 512);
            this.trackBarBrightness.Maximum = 255;
            this.trackBarBrightness.Minimum = -255;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(179, 45);
            this.trackBarBrightness.TabIndex = 23;
            this.trackBarBrightness.Scroll += new System.EventHandler(this.trackBarBrightness_Scroll);
            // 
            // trackBarSaturation
            // 
            this.trackBarSaturation.Location = new System.Drawing.Point(535, 581);
            this.trackBarSaturation.Maximum = 30;
            this.trackBarSaturation.Name = "trackBarSaturation";
            this.trackBarSaturation.Size = new System.Drawing.Size(179, 45);
            this.trackBarSaturation.TabIndex = 24;
            this.trackBarSaturation.Value = 10;
            this.trackBarSaturation.Scroll += new System.EventHandler(this.trackBarSaturation_Scroll);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(532, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 19);
            this.label6.TabIndex = 25;
            this.label6.Text = "Контрастность";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(532, 490);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 19);
            this.label7.TabIndex = 26;
            this.label7.Text = "Яркость";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(533, 560);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 19);
            this.label8.TabIndex = 27;
            this.label8.Text = "Насыщенность";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(725, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "x1 = ";
            // 
            // textBoxX1
            // 
            this.textBoxX1.Location = new System.Drawing.Point(761, 96);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(43, 20);
            this.textBoxX1.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(725, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "UV-координаты";
            // 
            // trackBarX1
            // 
            this.trackBarX1.Location = new System.Drawing.Point(810, 93);
            this.trackBarX1.Maximum = 100;
            this.trackBarX1.Name = "trackBarX1";
            this.trackBarX1.Size = new System.Drawing.Size(127, 45);
            this.trackBarX1.TabIndex = 31;
            this.trackBarX1.Scroll += new System.EventHandler(this.trackBarX1_Scroll);
            // 
            // trackBarY1
            // 
            this.trackBarY1.Location = new System.Drawing.Point(810, 129);
            this.trackBarY1.Maximum = 100;
            this.trackBarY1.Name = "trackBarY1";
            this.trackBarY1.Size = new System.Drawing.Size(127, 45);
            this.trackBarY1.TabIndex = 34;
            this.trackBarY1.Scroll += new System.EventHandler(this.trackBarY1_Scroll);
            // 
            // textBoxY1
            // 
            this.textBoxY1.Location = new System.Drawing.Point(761, 132);
            this.textBoxY1.Name = "textBoxY1";
            this.textBoxY1.Size = new System.Drawing.Size(43, 20);
            this.textBoxY1.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(725, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "y1 = ";
            // 
            // trackBarY2
            // 
            this.trackBarY2.Location = new System.Drawing.Point(810, 203);
            this.trackBarY2.Maximum = 100;
            this.trackBarY2.Name = "trackBarY2";
            this.trackBarY2.Size = new System.Drawing.Size(127, 45);
            this.trackBarY2.TabIndex = 40;
            this.trackBarY2.Scroll += new System.EventHandler(this.trackBarY2_Scroll);
            // 
            // textBoxY2
            // 
            this.textBoxY2.Location = new System.Drawing.Point(761, 206);
            this.textBoxY2.Name = "textBoxY2";
            this.textBoxY2.Size = new System.Drawing.Size(43, 20);
            this.textBoxY2.TabIndex = 39;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(725, 209);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "y2 = ";
            // 
            // trackBar2X
            // 
            this.trackBar2X.Location = new System.Drawing.Point(810, 167);
            this.trackBar2X.Maximum = 100;
            this.trackBar2X.Name = "trackBar2X";
            this.trackBar2X.Size = new System.Drawing.Size(127, 45);
            this.trackBar2X.TabIndex = 37;
            this.trackBar2X.Value = 100;
            this.trackBar2X.Scroll += new System.EventHandler(this.trackBar2X_Scroll);
            // 
            // textBoxX2
            // 
            this.textBoxX2.Location = new System.Drawing.Point(761, 170);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(43, 20);
            this.textBoxX2.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(725, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "x2 = ";
            // 
            // trackBarY3
            // 
            this.trackBarY3.Location = new System.Drawing.Point(810, 281);
            this.trackBarY3.Maximum = 100;
            this.trackBarY3.Name = "trackBarY3";
            this.trackBarY3.Size = new System.Drawing.Size(127, 45);
            this.trackBarY3.TabIndex = 46;
            this.trackBarY3.Value = 100;
            this.trackBarY3.Scroll += new System.EventHandler(this.trackBarY3_Scroll);
            // 
            // textBoxY3
            // 
            this.textBoxY3.Location = new System.Drawing.Point(761, 284);
            this.textBoxY3.Name = "textBoxY3";
            this.textBoxY3.Size = new System.Drawing.Size(43, 20);
            this.textBoxY3.TabIndex = 45;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(725, 287);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 44;
            this.label14.Text = "y3 = ";
            // 
            // trackBarX3
            // 
            this.trackBarX3.Location = new System.Drawing.Point(810, 245);
            this.trackBarX3.Maximum = 100;
            this.trackBarX3.Name = "trackBarX3";
            this.trackBarX3.Size = new System.Drawing.Size(127, 45);
            this.trackBarX3.TabIndex = 43;
            this.trackBarX3.Value = 100;
            this.trackBarX3.Scroll += new System.EventHandler(this.trackBarX3_Scroll);
            // 
            // textBoxX3
            // 
            this.textBoxX3.Location = new System.Drawing.Point(761, 248);
            this.textBoxX3.Name = "textBoxX3";
            this.textBoxX3.Size = new System.Drawing.Size(43, 20);
            this.textBoxX3.TabIndex = 42;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(725, 251);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "x3 = ";
            // 
            // trackBarY4
            // 
            this.trackBarY4.Location = new System.Drawing.Point(810, 352);
            this.trackBarY4.Maximum = 100;
            this.trackBarY4.Name = "trackBarY4";
            this.trackBarY4.Size = new System.Drawing.Size(127, 45);
            this.trackBarY4.TabIndex = 52;
            this.trackBarY4.Value = 100;
            this.trackBarY4.Scroll += new System.EventHandler(this.trackBarY4_Scroll);
            // 
            // textBoxY4
            // 
            this.textBoxY4.Location = new System.Drawing.Point(761, 355);
            this.textBoxY4.Name = "textBoxY4";
            this.textBoxY4.Size = new System.Drawing.Size(43, 20);
            this.textBoxY4.TabIndex = 51;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(725, 358);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 50;
            this.label16.Text = "y4 = ";
            // 
            // trackBarX4
            // 
            this.trackBarX4.Location = new System.Drawing.Point(810, 316);
            this.trackBarX4.Maximum = 100;
            this.trackBarX4.Name = "trackBarX4";
            this.trackBarX4.Size = new System.Drawing.Size(127, 45);
            this.trackBarX4.TabIndex = 49;
            this.trackBarX4.Scroll += new System.EventHandler(this.trackBarX4_Scroll);
            // 
            // textBoxX4
            // 
            this.textBoxX4.Location = new System.Drawing.Point(761, 319);
            this.textBoxX4.Name = "textBoxX4";
            this.textBoxX4.Size = new System.Drawing.Size(43, 20);
            this.textBoxX4.TabIndex = 48;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(725, 322);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 13);
            this.label17.TabIndex = 47;
            this.label17.Text = "x4 = ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(949, 639);
            this.Controls.Add(this.trackBarY4);
            this.Controls.Add(this.textBoxY4);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.trackBarX4);
            this.Controls.Add(this.textBoxX4);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.trackBarY3);
            this.Controls.Add(this.textBoxY3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.trackBarX3);
            this.Controls.Add(this.textBoxX3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.trackBarY2);
            this.Controls.Add(this.textBoxY2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.trackBar2X);
            this.Controls.Add(this.textBoxX2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.trackBarY1);
            this.Controls.Add(this.textBoxY1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.trackBarX1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trackBarSaturation);
            this.Controls.Add(this.trackBarBrightness);
            this.Controls.Add(this.trackBarContrast);
            this.Controls.Add(this.buttonChooseFile);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBarAlpha);
            this.Controls.Add(this.trackBarSizeY);
            this.Controls.Add(this.trackBarSizeX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarY);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarY;
        private System.Windows.Forms.TrackBar trackBarX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBarAlpha;
        private System.Windows.Forms.TrackBar trackBarSizeY;
        private System.Windows.Forms.TrackBar trackBarSizeX;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonChooseFile;
        private System.Windows.Forms.TrackBar trackBarContrast;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.TrackBar trackBarSaturation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxX1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trackBarX1;
        private System.Windows.Forms.TrackBar trackBarY1;
        private System.Windows.Forms.TextBox textBoxY1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar trackBarY2;
        private System.Windows.Forms.TextBox textBoxY2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar trackBar2X;
        private System.Windows.Forms.TextBox textBoxX2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar trackBarY3;
        private System.Windows.Forms.TextBox textBoxY3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar trackBarX3;
        private System.Windows.Forms.TextBox textBoxX3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar trackBarY4;
        private System.Windows.Forms.TextBox textBoxY4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar trackBarX4;
        private System.Windows.Forms.TextBox textBoxX4;
        private System.Windows.Forms.Label label17;
    }
}

