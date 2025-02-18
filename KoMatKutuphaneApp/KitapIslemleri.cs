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
    public partial class KitapIslemleri : Form
    {
        VeriModel db = new VeriModel();
        int secilenID = -1;
        public KitapIslemleri()
        {
            InitializeComponent();
        }

        private void KitapIslemleri_Load(object sender, EventArgs e)
        {
            cbdoldur();

            //Daha düzenli ve kolonları isteğe göre biçimlendirilebilir bir datagridview oluşturmak için datatable kullanacağız.
            //dataGridView1.DataSource = db.KitapListele();
            GridDoldur();
        }

        private void cbdoldur()
        {
            cb_dil.DataSource = db.DilListele();
            cb_dil.DisplayMember = "Isim";
            cb_dil.ValueMember = "ID";

            cb_tur.DataSource = db.TurListele();
            cb_tur.DisplayMember = "Isim";
            cb_tur.ValueMember = "ID";

            cb_yayinEvi.DataSource = db.YayinEviListele();
            cb_yayinEvi.DisplayMember = "Isim";
            cb_yayinEvi.ValueMember = "ID";
        }

        public void GridDoldur()
        {
            //Data Table DataGridView'a atılacak olan olan verileri düzenli bir tablo halinde oluşturulabilmesini sağlar
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Sıra No");
            dt.Columns.Add("Kitap Adı");
            dt.Columns.Add("Yazar");
            dt.Columns.Add("Tür");
            dt.Columns.Add("Yayınevi");
            dt.Columns.Add("Dil");
            dt.Columns.Add("Barkod");

            List<Kitap> kitaplar = db.KitapListele();
            foreach (Kitap item in kitaplar)
            {
                string yazar = db.KitapYazarlari(item.ID) ;
                dt.Rows.Add(item.ID, item.SiraNo, item.Isim, yazar, item.Tur, item.YayinEvi, item.Dil, item.Barkod);
            }
            dataGridView1.DataSource = dt;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                Kitap k = new Kitap();
                k.Isim = tb_isim.Text;
                k.SiraNo = Convert.ToInt16(tb_siraNo.Text);
                k.Barkod = tb_barkod.Text;
                k.Tur_ID = Convert.ToInt32(cb_tur.SelectedValue);
                k.Dil_ID = Convert.ToInt32(cb_dil.SelectedValue);
                k.YayinEvi_ID = Convert.ToInt32(cb_yayinEvi.SelectedValue);
                if (db.KitapEkle(k))
                {
                    MessageBox.Show("Kitap başarı ile eklenmiştir", "Başarılı");
                }
                else
                {
                    MessageBox.Show("Kitap Eklenirken bir hata oluştu", "Hata");
                }
                GridDoldur();
                tb_barkod.Text = tb_isim.Text = tb_siraNo.Text="";
                cb_dil.SelectedIndex = cb_tur.SelectedIndex = cb_yayinEvi.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Kitap Adı boş bırakılamaz", "Veri Boş");
            }
        }

        private void TSMI_duzenle_Click(object sender, EventArgs e)
        {
            Kitap k = db.KitapGetir(secilenID);
            tb_id.Text = k.ID.ToString();
            tb_isim.Text = k.Isim;
            tb_barkod.Text = k.Barkod;
            tb_siraNo.Text = k.SiraNo.ToString();
            cb_dil.SelectedValue = k.Dil_ID;
            cb_tur.SelectedValue = k.Tur_ID;
            cb_yayinEvi.SelectedValue = k.YayinEvi_ID;
            btn_duzenle.Visible = true;
        }

        private void TSMI_sil_Click(object sender, EventArgs e)
        {
            Kitap k = db.KitapGetir(secilenID);
            if (MessageBox.Show(k.Isim+" isimli kitabı silmek istiyor musunuz?","Onay",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.kitapSil(secilenID);
                GridDoldur();
            }
        }

        private void TSMI_YazarEkle_Click(object sender, EventArgs e)
        {
            YazarEkle frm = new YazarEkle(secilenID);
            frm.ShowDialog();
            GridDoldur();
        }

        private void TSMI_Kirala_Click(object sender, EventArgs e)
        {
            KirayaVer frm = new KirayaVer(secilenID);
            frm.ShowDialog();
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

        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            Kitap k = db.KitapGetir(secilenID);
            k.Isim = tb_isim.Text;
            k.Barkod = tb_barkod.Text;
            k.SiraNo = Convert.ToInt16(tb_siraNo.Text);
            k.Dil_ID = Convert.ToInt32(cb_dil.SelectedValue);
            k.Tur_ID = Convert.ToInt32(cb_tur.SelectedValue);
            k.YayinEvi_ID = Convert.ToInt32(cb_yayinEvi.SelectedValue);
            if (db.kitapGuncelle(k))
            {
                MessageBox.Show(k.Isim + " adlı kitabınız başarıyla güncellenmiştir.", "Başarılı");
                tb_id.Text = tb_isim.Text = tb_barkod.Text = tb_siraNo.Text = "";
                GridDoldur();
                btn_duzenle.Visible = false;
            }
            else
            {
                MessageBox.Show(k.Isim + " adlı kitabınız güncellenirken bir hata ile karşılaşıldı.", "Hata");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            tb_barkod.Text = tb_isim.Text = tb_id.Text = tb_siraNo.Text = "";
            cbdoldur();
        }
    }
}
