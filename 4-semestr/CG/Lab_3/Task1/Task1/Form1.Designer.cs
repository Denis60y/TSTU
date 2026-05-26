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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBarX = new System.Windows.Forms.TrackBar();
            this.trackBarY = new System.Windows.Forms.TrackBar();
            this.trackBarSizeX = new System.Windows.Forms.TrackBar();
            this.trackBarSizeY = new System.Windows.Forms.TrackBar();
            this.trackBarAlphaX = new System.Windows.Forms.TrackBar();
            this.trackBarZ = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBarSizeZ = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.trackBarAlphaY = new System.Windows.Forms.TrackBar();
            this.trackBarAlphaZ = new System.Windows.Forms.TrackBar();
            this.comboBoxProjection = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.trackBarD = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlphaX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlphaY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlphaZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarD)).BeginInit();
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Куб",
            "Пирамида",
            "Параллелепипед"});
            this.comboBox1.Location = new System.Drawing.Point(529, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(529, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 57);
            this.button1.TabIndex = 4;
            this.button1.Text = "Добавить фигуру";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(529, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Перемещение по координатe X";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(529, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Перемещение по координатe Y";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(728, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Масштабирование на значение Sx";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(728, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Масштабирование на значение Sy";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(529, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Вращение по оси X";
            // 
            // trackBarX
            // 
            this.trackBarX.Location = new System.Drawing.Point(529, 123);
            this.trackBarX.Maximum = 500;
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(179, 45);
            this.trackBarX.TabIndex = 18;
            this.trackBarX.Value = 100;
            this.trackBarX.Scroll += new System.EventHandler(this.trackBarX_Scroll);
            // 
            // trackBarY
            // 
            this.trackBarY.Location = new System.Drawing.Point(529, 187);
            this.trackBarY.Maximum = 500;
            this.trackBarY.Name = "trackBarY";
            this.trackBarY.Size = new System.Drawing.Size(179, 45);
            this.trackBarY.TabIndex = 19;
            this.trackBarY.Value = 100;
            this.trackBarY.Scroll += new System.EventHandler(this.trackBarY_Scroll);
            // 
            // trackBarSizeX
            // 
            this.trackBarSizeX.Location = new System.Drawing.Point(728, 123);
            this.trackBarSizeX.Maximum = 20;
            this.trackBarSizeX.Name = "trackBarSizeX";
            this.trackBarSizeX.Size = new System.Drawing.Size(179, 45);
            this.trackBarSizeX.TabIndex = 20;
            this.trackBarSizeX.Value = 1;
            this.trackBarSizeX.Scroll += new System.EventHandler(this.trackBarSizeX_Scroll);
            // 
            // trackBarSizeY
            // 
            this.trackBarSizeY.Location = new System.Drawing.Point(728, 187);
            this.trackBarSizeY.Maximum = 20;
            this.trackBarSizeY.Name = "trackBarSizeY";
            this.trackBarSizeY.Size = new System.Drawing.Size(179, 45);
            this.trackBarSizeY.TabIndex = 21;
            this.trackBarSizeY.Value = 1;
            this.trackBarSizeY.Scroll += new System.EventHandler(this.trackBarSizeY_Scroll);
            // 
            // trackBarAlphaX
            // 
            this.trackBarAlphaX.Location = new System.Drawing.Point(529, 327);
            this.trackBarAlphaX.Maximum = 360;
            this.trackBarAlphaX.Name = "trackBarAlphaX";
            this.trackBarAlphaX.Size = new System.Drawing.Size(179, 45);
            this.trackBarAlphaX.TabIndex = 22;
            this.trackBarAlphaX.Scroll += new System.EventHandler(this.trackBarAlphaX_Scroll);
            // 
            // trackBarZ
            // 
            this.trackBarZ.Location = new System.Drawing.Point(529, 252);
            this.trackBarZ.Maximum = 500;
            this.trackBarZ.Name = "trackBarZ";
            this.trackBarZ.Size = new System.Drawing.Size(179, 45);
            this.trackBarZ.TabIndex = 26;
            this.trackBarZ.Value = 100;
            this.trackBarZ.Scroll += new System.EventHandler(this.trackBarZ_Scroll);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(529, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 19);
            this.label8.TabIndex = 25;
            this.label8.Text = "Перемещение по координатe Z";
            // 
            // trackBarSizeZ
            // 
            this.trackBarSizeZ.Location = new System.Drawing.Point(728, 252);
            this.trackBarSizeZ.Maximum = 20;
            this.trackBarSizeZ.Name = "trackBarSizeZ";
            this.trackBarSizeZ.Size = new System.Drawing.Size(179, 45);
            this.trackBarSizeZ.TabIndex = 28;
            this.trackBarSizeZ.Value = 1;
            this.trackBarSizeZ.Scroll += new System.EventHandler(this.trackBarSizeZ_Scroll);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(728, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(185, 19);
            this.label9.TabIndex = 27;
            this.label9.Text = "Масштабирование на значение Sz";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(529, 371);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "Вращение по оси Y";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(529, 437);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 19);
            this.label7.TabIndex = 17;
            this.label7.Text = "Вращение по оси Z";
            // 
            // trackBarAlphaY
            // 
            this.trackBarAlphaY.Location = new System.Drawing.Point(529, 393);
            this.trackBarAlphaY.Maximum = 360;
            this.trackBarAlphaY.Name = "trackBarAlphaY";
            this.trackBarAlphaY.Size = new System.Drawing.Size(179, 45);
            this.trackBarAlphaY.TabIndex = 23;
            this.trackBarAlphaY.Scroll += new System.EventHandler(this.trackBarAlphaY_Scroll);
            // 
            // trackBarAlphaZ
            // 
            this.trackBarAlphaZ.Location = new System.Drawing.Point(529, 461);
            this.trackBarAlphaZ.Maximum = 360;
            this.trackBarAlphaZ.Name = "trackBarAlphaZ";
            this.trackBarAlphaZ.Size = new System.Drawing.Size(179, 45);
            this.trackBarAlphaZ.TabIndex = 24;
            this.trackBarAlphaZ.Scroll += new System.EventHandler(this.trackBarAlphaZ_Scroll);
            // 
            // comboBoxProjection
            // 
            this.comboBoxProjection.FormattingEnabled = true;
            this.comboBoxProjection.Items.AddRange(new object[] {
            "Кабине",
            "Кавалье",
            "Центральная"});
            this.comboBoxProjection.Location = new System.Drawing.Point(728, 12);
            this.comboBoxProjection.Name = "comboBoxProjection";
            this.comboBoxProjection.Size = new System.Drawing.Size(179, 21);
            this.comboBoxProjection.TabIndex = 29;
            this.comboBoxProjection.SelectedIndexChanged += new System.EventHandler(this.comboBoxProjection_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(728, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 57);
            this.button2.TabIndex = 30;
            this.button2.Text = "Сброс";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // trackBarD
            // 
            this.trackBarD.Location = new System.Drawing.Point(728, 327);
            this.trackBarD.Maximum = 1000;
            this.trackBarD.Minimum = 300;
            this.trackBarD.Name = "trackBarD";
            this.trackBarD.Size = new System.Drawing.Size(179, 45);
            this.trackBarD.TabIndex = 32;
            this.trackBarD.Value = 400;
            this.trackBarD.Scroll += new System.EventHandler(this.trackBarD_Scroll);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(728, 302);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(185, 19);
            this.label10.TabIndex = 31;
            this.label10.Text = "d = ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 575);
            this.Controls.Add(this.trackBarD);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBoxProjection);
            this.Controls.Add(this.trackBarSizeZ);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.trackBarZ);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.trackBarAlphaZ);
            this.Controls.Add(this.trackBarAlphaY);
            this.Controls.Add(this.trackBarAlphaX);
            this.Controls.Add(this.trackBarSizeY);
            this.Controls.Add(this.trackBarSizeX);
            this.Controls.Add(this.trackBarY);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlphaX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSizeZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlphaY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlphaZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBarX;
        private System.Windows.Forms.TrackBar trackBarY;
        private System.Windows.Forms.TrackBar trackBarSizeX;
        private System.Windows.Forms.TrackBar trackBarSizeY;
        private System.Windows.Forms.TrackBar trackBarAlphaX;
        private System.Windows.Forms.TrackBar trackBarZ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackBarSizeZ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trackBarAlphaY;
        private System.Windows.Forms.TrackBar trackBarAlphaZ;
        private System.Windows.Forms.ComboBox comboBoxProjection;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar trackBarD;
        private System.Windows.Forms.Label label10;
    }
}

