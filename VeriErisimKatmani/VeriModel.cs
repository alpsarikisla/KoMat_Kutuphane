using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class VeriModel
    {
        SqlConnection baglanti;
        SqlCommand komut;

        public VeriModel()
        {
            baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=KoMat_Kutuphane_DB; Integrated Security=True");
            komut = baglanti.CreateCommand();
        }

        #region Dil Metotları

        public List<Dil> DilListele()
        {
            List<Dil> diller = new List<Dil>();

            try
            {
                komut.CommandText = "SELECT ID,Dil FROM Diller";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Dil model = new Dil();
                    model.ID = okuyucu.GetInt32(0);
                    model.Isim = okuyucu.GetString(1);
                    diller.Add(model);
                }
                return diller;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool DilEkle(Dil model)
        {
            try
            {
                komut.CommandText = "INSERT INTO Diller(Dil) VALUES(@isim)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", model.Isim);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }



        #endregion
    }
}
