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
    public partial class Kiralamalar : Form
    {
        VeriModel db = new VeriModel();
        int secilenID = -1;
        public Kiralamalar()
        {
            InitializeComponent();
        }

        private void Kiralamalar_Load(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void GridDoldur()
        {
            DataTable kiralamaTable = new DataTable();
            kiralamaTable.Columns.Add("ID");
            kiralamaTable.Columns.Add("Kitap Adı");
            kiralamaTable.Columns.Add("Kiralayan");
            kiralamaTable.Columns.Add("Kiralama Tarihi");
           
            List<Kiralama> kiralamalar = db.KiradakiKitaplar();

            foreach (Kiralama item in kiralamalar)
            {
                kiralamaTable.Rows.Add(item.ID, item.KitapAdi, item.Kiralayan, item.KiralamaTarihi.ToShortDateString() );
            }
            dataGridView1.DataSource = kiralamaTable;
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

        private void TSMI_TeslimEt_Click(object sender, EventArgs e)
        {
            if (db.TeslimEt(secilenID))
            {
                MessageBox.Show("Teslim Edildi", "Teşekkür ederiz");
            }
            else
            {
                MessageBox.Show("Bir Hata Oluştu", "Başarısız");
            }
            GridDoldur();
        }
    }
}
