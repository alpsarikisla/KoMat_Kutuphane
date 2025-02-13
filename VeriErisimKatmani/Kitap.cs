using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class Kitap
    {
        public int ID { get; set; }
        public int Tur_ID { get; set; }
        public string Tur { get; set; }
        public int YayinEvi_ID { get; set; }
        public string YayinEvi { get; set; }
        public int Dil_ID { get; set; }
        public string Dil { get; set; }
        public string Isim { get; set; }
        public string Barkod { get; set; }
        public short SiraNo { get; set; }
    }
}
