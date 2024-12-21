using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoMatKutuphaneApp
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void TSMI_diller_Click(object sender, EventArgs e)
        {
            Form[] acikFormlar = this.MdiChildren;//Ana Form içerisinde açık olan olan tüm formların listesi
            bool acikMi = false;
            for (int i = 0; i < acikFormlar.Length; i++)//Açık olan tüm formları döngü ile geziyoruz
            {
                //Eğer Açıkformların herhengi birinin türü bizim açmak istediğimiz formun türü ile eşleşiyorsa form daha önceden açılmış demektir
                if (acikFormlar[i].GetType() == typeof(DilIslemleri))
                {
                    acikMi = true;
                    acikFormlar[i].Activate();
                    //Açık olan formu öne getir
                }
            }

            if (acikMi == false)//Eğer from açık değil ise
            {
                DilIslemleri frm = new DilIslemleri();
                //Açılacak olan formun nesnesişni yaratıyoruz

                //Dil işlemleri formu Ana Formun MDI Child'ı olacak
                frm.MdiParent = this;
                //Bu form(Ana Form) açılacak olan frm(Dil işlemleri) formunun MDI taşıyıcısı(MdiParent) olsun
                frm.Show();//Formu Aç(Ana Formun içinde)
            }
        }

        private void TSMI_Yazarlar_Click(object sender, EventArgs e)
        {
            Form[] acikFormlar = this.MdiChildren;
            bool acikMi = false;
            for (int i = 0; i < acikFormlar.Length; i++)
            {
                if (acikFormlar[i].GetType() == typeof(YazarIslemleri))
                {
                    acikMi = true;
                    acikFormlar[i].Activate();
                }
            }
            if (acikMi == false)
            {
                YazarIslemleri frm = new YazarIslemleri();
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
