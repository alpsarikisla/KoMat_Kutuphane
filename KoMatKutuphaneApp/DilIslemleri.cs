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
        int secilenID = -1;
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
                int satir = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                //Tıklama işleminin kordinatlarının hangi satırın üzerine denk geldiğini bulmamızı sağlar
                dataGridView1.ClearSelection();
                if (satir != -1)
                {
                    contextMenuStrip1.Show(dataGridView1, e.X, e.Y);
                    dataGridView1.Rows[satir].Selected = true;
                    //hangi satırın üzerinde sağ tıkladıysak o satırın seçili olmasını sağladık.
                    secilenID = Convert.ToInt32(dataGridView1.Rows[satir].Cells[0].Value);
                }
            }
        }

        private void TSMI_duzenle_Click(object sender, EventArgs e)
        {
            Dil d = db.DilGetir(secilenID);
            tb_id.Text = d.ID.ToString();
            tb_isim.Text = d.Isim;
            btn_duzenle.Visible = true;
        }

        private void TSMI_sil_Click(object sender, EventArgs e)
        {
            db.DilSil(secilenID);
            dataGridView1.DataSource = db.DilListele();
        }

        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            Dil d = db.DilGetir(secilenID);
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                d.Isim = tb_isim.Text;
                if (db.DilGuncelle(d))
                {
                    MessageBox.Show("Güncelleme Başarılı", "Başarılı");
                    tb_id.Text = tb_isim.Text = "";
                    btn_duzenle.Visible = false;
                    dataGridView1.DataSource = db.DilListele();
                }
                else
                {
                    MessageBox.Show("Dil güncellenirken bir hata oluştu", "Başarısız");
                }
            }
            else
            {
                MessageBox.Show("Dil adı boş bırakılamaz", "Hata");
            }    
        }
    }
}
