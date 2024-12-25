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
    public partial class TurIslemleri : Form
    {
        VeriModel db = new VeriModel();
        int secilenID = -1;
        public TurIslemleri()
        {
            InitializeComponent();
        }

        private void TurIslemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TurListele();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                Tur model = new Tur();
                model.Isim = tb_isim.Text;
                if (db.TurEkle(model))
                {
                    MessageBox.Show("Tür eklendi", "Ekleme Başarılı");
                }
                else
                {
                    MessageBox.Show("Bir Hata Oluştu", "Ekleme Başarısız");
                }
                tb_isim.Text = "";
                dataGridView1.DataSource = db.TurListele();
            }
            else
            {
                MessageBox.Show("Tür Adı boş bırakılamaz", "Boş veri");
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int satir = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                dataGridView1.ClearSelection();
                if (satir != -1)
                {
                    contextMenuStrip1.Show(dataGridView1, e.X, e.Y);
                    dataGridView1.Rows[satir].Selected = true;
                    secilenID = Convert.ToInt32(dataGridView1.Rows[satir].Cells[0].Value);
                }
            }
        }

        private void TSMI_duzenle_Click(object sender, EventArgs e)
        {
            Tur d = db.TurGetir(secilenID);
            tb_id.Text = d.ID.ToString();
            tb_isim.Text = d.Isim;
            btn_duzenle.Visible = true;
        }

        private void TSMI_sil_Click(object sender, EventArgs e)
        {
            int kitapsayi = db.TurKitapSayi(secilenID);
            if (kitapsayi == 0)
            {
                Tur model = db.TurGetir(secilenID);
                DialogResult sonuc = MessageBox.Show($"{model.Isim} türü silinecektir.\nOnaylıyor musunuz?", "Silme işlemini onaylayın", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    db.TurSil(secilenID);
                    dataGridView1.DataSource = db.TurListele();
                }
                else
                {
                    MessageBox.Show("Silme işlemi iptal edildi", "İptal");
                }
            }
            else
            {
                MessageBox.Show($"Bu türe ait sistemde kayıtlı {kitapsayi} adet kitabı olduğu için bu tür silinemez...", "Tür Silinemez");
            }
        }

        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            Tur d = db.TurGetir(secilenID);
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                d.Isim = tb_isim.Text;
                if (db.TurGuncelle(d))
                {
                    MessageBox.Show("Güncelleme Başarılı", "Başarılı");
                    tb_id.Text = tb_isim.Text = "";
                    btn_duzenle.Visible = false;
                    dataGridView1.DataSource = db.TurListele();
                }
                else
                {
                    MessageBox.Show("Tür güncellenirken bir hata oluştu", "Başarısız");
                }
            }
            else
            {
                MessageBox.Show("Tür adı boş bırakılamaz", "Hata");
            }
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            tb_id.Text = tb_isim.Text = "";
            btn_duzenle.Visible = false;
        }
    }
}
