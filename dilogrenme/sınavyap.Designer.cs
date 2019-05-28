namespace dilogrenme
{
    partial class sınavyap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sınavyap));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.rba = new System.Windows.Forms.RadioButton();
            this.rbb = new System.Windows.Forms.RadioButton();
            this.rbc = new System.Windows.Forms.RadioButton();
            this.rbd = new System.Windows.Forms.RadioButton();
            this.rbe = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(760, 370);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(301, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Türkçe - İngilizce";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(161, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kelime :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(243, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 3;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(344, 192);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(119, 38);
            this.metroButton1.TabIndex = 9;
            this.metroButton1.Text = "Cevapla";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // rba
            // 
            this.rba.AutoSize = true;
            this.rba.Location = new System.Drawing.Point(182, 155);
            this.rba.Name = "rba";
            this.rba.Size = new System.Drawing.Size(32, 17);
            this.rba.TabIndex = 10;
            this.rba.TabStop = true;
            this.rba.Text = "A";
            this.rba.UseVisualStyleBackColor = true;
            // 
            // rbb
            // 
            this.rbb.AutoSize = true;
            this.rbb.Location = new System.Drawing.Point(267, 155);
            this.rbb.Name = "rbb";
            this.rbb.Size = new System.Drawing.Size(32, 17);
            this.rbb.TabIndex = 11;
            this.rbb.TabStop = true;
            this.rbb.Text = "B";
            this.rbb.UseVisualStyleBackColor = true;
            // 
            // rbc
            // 
            this.rbc.AutoSize = true;
            this.rbc.Location = new System.Drawing.Point(357, 155);
            this.rbc.Name = "rbc";
            this.rbc.Size = new System.Drawing.Size(32, 17);
            this.rbc.TabIndex = 12;
            this.rbc.TabStop = true;
            this.rbc.Text = "C";
            this.rbc.UseVisualStyleBackColor = true;
            // 
            // rbd
            // 
            this.rbd.AutoSize = true;
            this.rbd.Location = new System.Drawing.Point(441, 155);
            this.rbd.Name = "rbd";
            this.rbd.Size = new System.Drawing.Size(33, 17);
            this.rbd.TabIndex = 13;
            this.rbd.TabStop = true;
            this.rbd.Text = "D";
            this.rbd.UseVisualStyleBackColor = true;
            // 
            // rbe
            // 
            this.rbe.AutoSize = true;
            this.rbe.Location = new System.Drawing.Point(531, 155);
            this.rbe.Name = "rbe";
            this.rbe.Size = new System.Drawing.Size(32, 17);
            this.rbe.TabIndex = 14;
            this.rbe.TabStop = true;
            this.rbe.Text = "E";
            this.rbe.UseVisualStyleBackColor = true;
            // 
            // sınavyap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rbe);
            this.Controls.Add(this.rbd);
            this.Controls.Add(this.rbc);
            this.Controls.Add(this.rbb);
            this.Controls.Add(this.rba);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "sınavyap";
            this.Text = "Öğrenilmek İstenen Kelimeleri Cevapla";
            this.Load += new System.EventHandler(this.sınavyap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.RadioButton rba;
        private System.Windows.Forms.RadioButton rbb;
        private System.Windows.Forms.RadioButton rbc;
        private System.Windows.Forms.RadioButton rbd;
        private System.Windows.Forms.RadioButton rbe;
    }
}