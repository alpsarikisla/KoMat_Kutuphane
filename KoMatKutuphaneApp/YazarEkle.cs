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
            Yazarcb.DataSource = db.YazarListele();
            Yazarcb.DisplayMember = "Isim";
            Yazarcb.ValueMember = "ID";
            dataGridView1.DataSource = db.kitapIDdenYazarListele(ID);
        }

        private void btn_yazarEkle_Click(object sender, EventArgs e)
        {

        }
    }
}
