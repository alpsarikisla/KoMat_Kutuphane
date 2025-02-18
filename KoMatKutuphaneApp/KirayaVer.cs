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
    public partial class KirayaVer : Form
    {
        VeriModel db = new VeriModel();
        public int ID;
       
        public KirayaVer(int kitapID)
        {
            InitializeComponent();
            ID = kitapID;

        }

        private void btn_kirayaVer_Click(object sender, EventArgs e)
        {
            Kiralama k = new Kiralama();
            k.Kiralayan = tb_isim.Text;
            k.KitapID = ID;
            k.KiralamaTarihi = DateTime.Now;
            if (db.KirayaVer (k))
            {
                MessageBox.Show("Kitap Başarıyla Kiralandı", "Başarılı");
                
            }
            else
            {
                MessageBox.Show("Kiralama Sırasında Bir sorun Oluştu", "Başarısız");
            }
            this.Close();
        }

        private void KirayaVer_Load(object sender, EventArgs e)
        {
            lbl_kitapAdi.Text = db.KitapGetir(ID).Isim + " adlı kitabı Kiraya Veriyorsunuz";
        }
    }
}
