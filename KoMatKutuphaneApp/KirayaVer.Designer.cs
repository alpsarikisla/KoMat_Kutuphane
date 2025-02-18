namespace KoMatKutuphaneApp
{
    partial class KirayaVer
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
            this.btn_kirayaVer = new System.Windows.Forms.Button();
            this.lbl_kitapAdi = new System.Windows.Forms.Label();
            this.tb_isim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_kirayaVer
            // 
            this.btn_kirayaVer.Location = new System.Drawing.Point(262, 88);
            this.btn_kirayaVer.Name = "btn_kirayaVer";
            this.btn_kirayaVer.Size = new System.Drawing.Size(172, 23);
            this.btn_kirayaVer.TabIndex = 7;
            this.btn_kirayaVer.Text = "Kiraya Ver";
            this.btn_kirayaVer.UseVisualStyleBackColor = true;
            this.btn_kirayaVer.Click += new System.EventHandler(this.btn_kirayaVer_Click);
            // 
            // lbl_kitapAdi
            // 
            this.lbl_kitapAdi.AutoSize = true;
            this.lbl_kitapAdi.Location = new System.Drawing.Point(26, 22);
            this.lbl_kitapAdi.Name = "lbl_kitapAdi";
            this.lbl_kitapAdi.Size = new System.Drawing.Size(188, 13);
            this.lbl_kitapAdi.TabIndex = 5;
            this.lbl_kitapAdi.Text = "kitapadı Adlı Kitabı Kiraya Veriyorsunuz";
            // 
            // tb_isim
            // 
            this.tb_isim.Location = new System.Drawing.Point(100, 62);
            this.tb_isim.Name = "tb_isim";
            this.tb_isim.Size = new System.Drawing.Size(281, 20);
            this.tb_isim.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Öğrenci Adı=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(387, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "*Zorunlu";
            // 
            // KirayaVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 149);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_isim);
            this.Controls.Add(this.btn_kirayaVer);
            this.Controls.Add(this.lbl_kitapAdi);
            this.Name = "KirayaVer";
            this.Text = "Kiraya Ver";
            this.Load += new System.EventHandler(this.KirayaVer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_kirayaVer;
        private System.Windows.Forms.Label lbl_kitapAdi;
        private System.Windows.Forms.TextBox tb_isim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}