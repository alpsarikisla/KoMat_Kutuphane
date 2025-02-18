using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class Kiralama
    {
        public int ID { get; set; }
        public int KitapID { get; set; }
        public string KitapAdi { get; set; }
        public DateTime KiralamaTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public string Kiralayan { get; set; }

    }
}
