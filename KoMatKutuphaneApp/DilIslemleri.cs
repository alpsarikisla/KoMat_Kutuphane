using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeriErisimKatmani;

namespace KoMatKutuphaneApp
{
    public partial class DilIslemleri : Form
    {
        VeriModel db = new VeriModel();
        public DilIslemleri()
        {
            InitializeComponent();
        }
        private void DilIslemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.DilListele();
        }
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                Dil model = new Dil();
                model.Isim = tb_isim.Text;
                if (db.DilEkle(model))
                {
                    MessageBox.Show("Dil eklendi", "Ekleme Başarılı");
                }
                else
                {
                    MessageBox.Show("Bir Hata Oluştu", "Ekleme Başarısız");
                }
                tb_isim.Text = "";
                dataGridView1.DataSource = db.DilListele();
            }
            else
            {
                MessageBox.Show("Dil Adı boş bırakılamaz", "Boş veri");
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dataGridView1, e.X,e.Y);
            }
        }
    }
}
