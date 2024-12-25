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
        public KitapIslemleri()
        {
            InitializeComponent();
        }

        private void KitapIslemleri_Load(object sender, EventArgs e)
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
    }
}
