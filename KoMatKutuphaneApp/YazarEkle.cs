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
    public partial class YazarEkle : Form
    {
        VeriModel db = new VeriModel();
        public int ID;

        public YazarEkle(int id)
        {
            InitializeComponent();
            ID = id;
        }

        private void YazarEkle_Load(object sender, EventArgs e)
        {
            Yazarcb.DataSource = db.YazarListeleWithSoyad();
            Yazarcb.DisplayMember = "Isim";
            Yazarcb.ValueMember = "ID";

            lbl_kitapAdi.Text = db.KitapGetir(ID).Isim + " adlı kitabı düzenliyorsunuz.";
            GridDoldur();
        }



        private void btn_yazarEkle_Click(object sender, EventArgs e)
        {
            if (Yazarcb.SelectedItem != null)
            {
                try
                {
                    Yazar secilen = (Yazar)Yazarcb.SelectedItem;
                    if (db.kitabaYazarEkle(ID, secilen.ID))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Bir Hata Oluştu", "Hata");
                    }
                }
                catch
                {
                    MessageBox.Show("Bir Hata Oluştu", "Hata");
                }
            }
            GridDoldur();
        }
        private void GridDoldur()
        {
            dataGridView1.DataSource = db.kitapIDdenYazarListele(ID);
        }
    }
}
