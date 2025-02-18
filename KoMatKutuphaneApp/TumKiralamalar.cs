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
    public partial class TumKiralamalar : Form
    {
        VeriModel db = new VeriModel();
        public TumKiralamalar()
        {
            InitializeComponent();
        }

        private void TumKiralamalar_Load(object sender, EventArgs e)
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
            kiralamaTable.Columns.Add("Teslim Tarihi");

            List<Kiralama> kiralamalar = db.TumKiralamalar();

            foreach (Kiralama item in kiralamalar)
            {
                if (item.TeslimTarihi.Year > 0001)
                {
                    kiralamaTable.Rows.Add(item.ID, item.KitapAdi, item.Kiralayan, item.KiralamaTarihi.ToShortDateString(), item.TeslimTarihi.ToShortDateString());
                }
                else
                {
                    kiralamaTable.Rows.Add(item.ID, item.KitapAdi, item.Kiralayan, item.KiralamaTarihi.ToShortDateString(), "Teslim Edilmedi");
                }
            }
            dataGridView1.DataSource = kiralamaTable;
        }
    }
}
