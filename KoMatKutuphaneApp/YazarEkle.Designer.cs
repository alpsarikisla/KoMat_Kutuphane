namespace KoMatKutuphaneApp
{
    partial class YazarEkle
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
            this.lbl_kitapAdi = new System.Windows.Forms.Label();
            this.Yazarcb = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_yazarEkle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_kitapAdi
            // 
            this.lbl_kitapAdi.AutoSize = true;
            this.lbl_kitapAdi.Location = new System.Drawing.Point(13, 13);
            this.lbl_kitapAdi.Name = "lbl_kitapAdi";
            this.lbl_kitapAdi.Size = new System.Drawing.Size(202, 13);
            this.lbl_kitapAdi.TabIndex = 0;
            this.lbl_kitapAdi.Text = "kitapadı Adlı Kitabın Yazarını Düzenliyoruz";
            // 
            // Yazarcb
            // 
            this.Yazarcb.FormattingEnabled = true;
            this.Yazarcb.Location = new System.Drawing.Point(66, 45);
            this.Yazarcb.Name = "Yazarcb";
            this.Yazarcb.Size = new System.Drawing.Size(149, 21);
            this.Yazarcb.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(382, 262);
            this.dataGridView1.TabIndex = 2;
            // 
            // btn_yazarEkle
            // 
            this.btn_yazarEkle.Location = new System.Drawing.Point(222, 45);
            this.btn_yazarEkle.Name = "btn_yazarEkle";
            this.btn_yazarEkle.Size = new System.Drawing.Size(172, 23);
            this.btn_yazarEkle.TabIndex = 3;
            this.btn_yazarEkle.Text = "Yazar Ekle";
            this.btn_yazarEkle.UseVisualStyleBackColor = true;
            this.btn_yazarEkle.Click += new System.EventHandler(this.btn_yazarEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Yazarlar =";
            // 
            // YazarEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 347);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_yazarEkle);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Yazarcb);
            this.Controls.Add(this.lbl_kitapAdi);
            this.Name = "YazarEkle";
            this.Text = "YazarEkle";
            this.Load += new System.EventHandler(this.YazarEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_kitapAdi;
        private System.Windows.Forms.ComboBox Yazarcb;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_yazarEkle;
        private System.Windows.Forms.Label label1;
    }
}