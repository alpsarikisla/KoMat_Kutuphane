namespace KoMatKutuphaneApp
{
    partial class AnaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Kapat = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_KutuphaneIslemleri = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_diller = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_turler = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Yazarlar = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_YayinEvleri = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMI_Kitaplar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.kiralamalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Yardim = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.TSMI_KutuphaneIslemleri,
            this.kiralamalarToolStripMenuItem,
            this.TSMI_Yardim});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(943, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Kapat});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // TSMI_Kapat
            // 
            this.TSMI_Kapat.Name = "TSMI_Kapat";
            this.TSMI_Kapat.Size = new System.Drawing.Size(104, 22);
            this.TSMI_Kapat.Text = "Kapat";
            // 
            // TSMI_KutuphaneIslemleri
            // 
            this.TSMI_KutuphaneIslemleri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_diller,
            this.TSMI_turler,
            this.TSMI_Yazarlar,
            this.TSMI_YayinEvleri,
            this.toolStripSeparator1,
            this.TSMI_Kitaplar,
            this.toolStripSeparator2});
            this.TSMI_KutuphaneIslemleri.Name = "TSMI_KutuphaneIslemleri";
            this.TSMI_KutuphaneIslemleri.Size = new System.Drawing.Size(124, 20);
            this.TSMI_KutuphaneIslemleri.Text = "Kütüphane İşlemleri";
            // 
            // TSMI_diller
            // 
            this.TSMI_diller.Name = "TSMI_diller";
            this.TSMI_diller.Size = new System.Drawing.Size(180, 22);
            this.TSMI_diller.Text = "Diller";
            this.TSMI_diller.Click += new System.EventHandler(this.TSMI_diller_Click);
            // 
            // TSMI_turler
            // 
            this.TSMI_turler.Name = "TSMI_turler";
            this.TSMI_turler.Size = new System.Drawing.Size(180, 22);
            this.TSMI_turler.Text = "Türler";
            this.TSMI_turler.Click += new System.EventHandler(this.TSMI_turler_Click);
            // 
            // TSMI_Yazarlar
            // 
            this.TSMI_Yazarlar.Name = "TSMI_Yazarlar";
            this.TSMI_Yazarlar.Size = new System.Drawing.Size(180, 22);
            this.TSMI_Yazarlar.Text = "Yazarlar";
            this.TSMI_Yazarlar.Click += new System.EventHandler(this.TSMI_Yazarlar_Click);
            // 
            // TSMI_YayinEvleri
            // 
            this.TSMI_YayinEvleri.Name = "TSMI_YayinEvleri";
            this.TSMI_YayinEvleri.Size = new System.Drawing.Size(180, 22);
            this.TSMI_YayinEvleri.Text = "Yayın Evleri";
            this.TSMI_YayinEvleri.Click += new System.EventHandler(this.TSMI_YayinEvleri_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // TSMI_Kitaplar
            // 
            this.TSMI_Kitaplar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.TSMI_Kitaplar.ForeColor = System.Drawing.Color.ForestGreen;
            this.TSMI_Kitaplar.Name = "TSMI_Kitaplar";
            this.TSMI_Kitaplar.Size = new System.Drawing.Size(180, 22);
            this.TSMI_Kitaplar.Text = "Kitaplar";
            this.TSMI_Kitaplar.Click += new System.EventHandler(this.TSMI_Kitaplar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // kiralamalarToolStripMenuItem
            // 
            this.kiralamalarToolStripMenuItem.Name = "kiralamalarToolStripMenuItem";
            this.kiralamalarToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.kiralamalarToolStripMenuItem.Text = "Kiralamalar";
            // 
            // TSMI_Yardim
            // 
            this.TSMI_Yardim.Name = "TSMI_Yardim";
            this.TSMI_Yardim.Size = new System.Drawing.Size(56, 20);
            this.TSMI_Yardim.Text = "Yardım";
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(943, 488);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnaForm";
            this.Text = "Kokpit & Matrix Kütüphanesi";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Kapat;
        private System.Windows.Forms.ToolStripMenuItem TSMI_KutuphaneIslemleri;
        private System.Windows.Forms.ToolStripMenuItem TSMI_diller;
        private System.Windows.Forms.ToolStripMenuItem TSMI_turler;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Yazarlar;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Kitaplar;
        private System.Windows.Forms.ToolStripMenuItem TSMI_YayinEvleri;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem kiralamalarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Yardim;
    }
}