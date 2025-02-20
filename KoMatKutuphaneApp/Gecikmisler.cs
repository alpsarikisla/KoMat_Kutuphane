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
    public partial class Gecikmisler : Form
    {
        VeriModel db = new VeriModel();
        public Gecikmisler()
        {
            InitializeComponent();
        }

        private void Gecikmisler_Load(object sender, EventArgs e)
        {
            lbl_tarih.Text ="Tarih = " +  DateTime.Now.ToShortDateString();
            GridDoldur();
        }
        public void GridDoldur()
        {
            //Data Table DataGridView'a atılacak olan olan verileri düzenli bir tablo halinde oluşturulabilmesini sağlar
            DataTable dt = new DataTable();
            dt.Columns.Add("Kitap Adı");
            dt.Columns.Add("Kiralayan");
            dt.Columns.Add("Kiralama Tarihi");
            dt.Columns.Add("Kalan Gün");
            dt.Columns.Add("Durum");

            List<Kiralama> kiralar = db.KiradakiKitaplar();
            foreach (Kiralama item in kiralar)
            {
                TimeSpan gun = item.KiralamaTarihi - DateTime.Now;
                string durum = gun.Days + 15 > 0 ? "" : "Gecikmede"; 
                dt.Rows.Add(item.KitapAdi, item.Kiralayan, item.KiralamaTarihi, gun.Days + 15, durum);
            }
            dataGridView1.DataSource = dt;
        }
    }
}
