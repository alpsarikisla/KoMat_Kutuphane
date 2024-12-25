using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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

        public Dil DilGetir(int id)
        {
            try
            {
                komut.CommandText = "SELECT ID, Dil FROM Diller WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Dil model = new Dil();
                while (okuyucu.Read())
                {
                    model.ID = okuyucu.GetInt32(0);
                    model.Isim = okuyucu.GetString(1);
                }
                return model;
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

        public bool DilGuncelle(Dil model)
        {
            try
            {
                komut.CommandText = "UPDATE Diller SET Dil=@d WHERE ID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", model.ID);
                komut.Parameters.AddWithValue("@d", model.Isim);
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

        public void DilSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Diller WHERE ID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }

        public int DilKitapSayi(int id)
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Kitaplar WHERE DilID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                int sayi = Convert.ToInt32(komut.ExecuteScalar());
                return sayi;
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion

        #region Yazar Metotları

        public List<Yazar> YazarListele()
        {
            try
            {
                List<Yazar> yazarlar = new List<Yazar>();
                komut.CommandText = "SELECT ID, Isim, Soyisim FROM Yazarlar";
                komut.Parameters.Clear();
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Yazar model = new Yazar();
                    model.ID = okuyucu.GetInt32(0);
                    model.Isim = okuyucu.GetString(1);
                    if (!okuyucu.IsDBNull(2))
                    {
                        model.Soyisim = okuyucu.GetString(2);
                    }
                    yazarlar.Add(model);
                }
                return yazarlar;
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
        public bool YazarEkle(Yazar model)
        {
            try
            {
                komut.CommandText = "INSERT INTO Yazarlar (Isim, Soyisim) VALUES(@isim, @soyisim)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", model.Isim);
                komut.Parameters.AddWithValue("@soyisim", model.Soyisim);
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
        public Yazar YazarGetir(int id)
        {
            try
            {
                Yazar model = new Yazar();
                komut.CommandText = "SELECT ID, Isim,Soyisim FROM Yazarlar WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    model.ID = okuyucu.GetInt32(0);
                    model.Isim = okuyucu.GetString(1);
                    if (!okuyucu.IsDBNull(2))
                    {
                        model.Soyisim = okuyucu.GetString(2);
                    }
                }
                return model;
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
        public bool YazarGuncelle(Yazar model)
        {
            try
            {
                komut.CommandText = "UPDATE Yazarlar SET Isim=@i, Soyisim=@s WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", model.ID);
                komut.Parameters.AddWithValue("@i", model.Isim);
                komut.Parameters.AddWithValue("@s", model.Soyisim);
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
        public void YazarSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Yazarlar WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id",id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public int YazarKitapSayi(int id)
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM KitapYazarlar WHERE YazarID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                int sayi = Convert.ToInt32(komut.ExecuteScalar());
                return sayi;
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion

        #region Tür Metotları


        public List<Tur> TurListele()
        {
            try
            {
                List<Tur> turler = new List<Tur>();
                komut.CommandText = "SELECT ID, Isim FROM Turler";
                komut.Parameters.Clear();
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Tur model = new Tur();
                    model.ID = okuyucu.GetInt32(0);
                    model.Isim = okuyucu.GetString(1);
                   
                    turler.Add(model);
                }
                return turler;
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
        public bool TurEkle(Tur model)
        {
            try
            {
                komut.CommandText = "INSERT INTO Turler (Isim) VALUES(@isim)";
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
        public Tur TurGetir(int id)
        {
            try
            {
                Tur model = new Tur();
                komut.CommandText = "SELECT ID, Isim FROM Turler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    model.ID = okuyucu.GetInt32(0);
                    model.Isim = okuyucu.GetString(1);
                }
                return model;
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
        public bool TurGuncelle(Tur model)
        {
            try
            {
                komut.CommandText = "UPDATE Turler SET Isim=@i WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", model.ID);
                komut.Parameters.AddWithValue("@i", model.Isim);
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
        public void TurSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Turler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public int TurKitapSayi(int id)
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Kitaplar WHERE TurID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                int sayi = Convert.ToInt32(komut.ExecuteScalar());
                return sayi;
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion

        #region Yayınevi Metotları

        public List<YayinEvi> YayinEviListele()
        {
            try
            {
                List<YayinEvi> turler = new List<YayinEvi>();
                komut.CommandText = "SELECT ID, Isim FROM YayinEvleri";
                komut.Parameters.Clear();
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    YayinEvi model = new YayinEvi();
                    model.ID = okuyucu.GetInt32(0);
                    model.Isim = okuyucu.GetString(1);
                    turler.Add(model);
                }
                return turler;
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
        public bool YayineviEkle(YayinEvi model)
        {
            try
            {
                komut.CommandText = "INSERT INTO YayinEvleri (Isim) VALUES(@isim)";
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
        public YayinEvi YayinEviGetir(int id)
        {
            try
            {
                YayinEvi model = new YayinEvi();
                komut.CommandText = "SELECT ID, Isim FROM YayinEvleri WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    model.ID = okuyucu.GetInt32(0);
                    model.Isim = okuyucu.GetString(1);
                }
                return model;
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
        public bool YayinEviGuncelle(YayinEvi model)
        {
            try
            {
                komut.CommandText = "UPDATE YayinEvleri SET Isim=@i WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", model.ID);
                komut.Parameters.AddWithValue("@i", model.Isim);
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
        public void YayinEviSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM YayinEvleri WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public int YayinEviKitapSayi(int id)
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Kitaplar WHERE YayinEviID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                int sayi = Convert.ToInt32(komut.ExecuteScalar());
                return sayi;
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion
    }
}
