using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public bool yazarKontrol(string isimSoyad)
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Yazarlar WHERE Isim + ' ' + Soyisim LIKE @isimSoyad";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isimSoyad", isimSoyad);
                baglanti.Open();
                int sayi = Convert.ToInt32(komut.ExecuteScalar());
                if (sayi == 0)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

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
        public List<Yazar> YazarListeleWithSoyad()
        {
            try
            {
                List<Yazar> yazarlar = new List<Yazar>();
                komut.CommandText = "SELECT ID, Isim + ' ' + Soyisim FROM Yazarlar";
                komut.Parameters.Clear();
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Yazar model = new Yazar();
                    model.ID = okuyucu.GetInt32(0);
                    model.Isim = okuyucu.GetString(1);
                    
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
        public bool yayineviKontrol(string yayineviAdi)
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM YayinEvleri WHERE Isim LIKE @yayineviAdi";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@yayineviAdi", yayineviAdi);
                baglanti.Open();
                int sayi = Convert.ToInt32(komut.ExecuteScalar());
                if (sayi == 0)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }
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

        #region Kitap Metotları

        public List<Kitap> KitapListele()
        {
            List<Kitap> kitaplar = new List<Kitap>();
            try
            {
                komut.CommandText = "SELECT K.ID, K.TurID, T.Isim, K.YayinEviID, Y.Isim, K.DilID, D.Dil, K.SiraNo,K.Isim,K.Barkod FROM Kitaplar AS K JOIN Turler AS T ON K.TurID=T.ID JOIN YayinEvleri AS Y ON K.YayinEviID = Y.ID JOIN Diller AS D ON K.DilID=D.ID";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Kitap k = new Kitap();
                    k.ID = okuyucu.GetInt32(0);
                    k.Tur_ID = okuyucu.GetInt32(1);
                    k.Tur = okuyucu.GetString(2);
                    k.YayinEvi_ID = okuyucu.GetInt32(3);
                    k.YayinEvi = okuyucu.GetString(4);
                    k.Dil_ID = okuyucu.GetInt32(5);
                    k.Dil = okuyucu.GetString(6);
                    k.SiraNo = okuyucu.GetInt16(7);
                    k.Isim = okuyucu.GetString(8);
                    if (!okuyucu.IsDBNull(9))
                    {
                        k.Barkod = okuyucu.GetString(9);
                    }
                    kitaplar.Add(k);
                }
                return kitaplar;
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

        public bool KitapEkle(Kitap k)
        {
            try
            {
                komut.CommandText = "INSERT INTO Kitaplar(TurID,YayineviID,DilID,SiraNo,Isim,Barkod) VALUES(@turID,@yayineviID,@dilID,@siraNo,@isim,@barkod)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@turID", k.Tur_ID);
                komut.Parameters.AddWithValue("@yayineviID", k.YayinEvi_ID);
                komut.Parameters.AddWithValue("@dilID", k.Dil_ID);
                komut.Parameters.AddWithValue("@siraNo", k.SiraNo);
                komut.Parameters.AddWithValue("@isim", k.Isim);
                komut.Parameters.AddWithValue("@barkod", k.Barkod);
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

        public string KitapYazarlari(int kitapID)
        {
            try
            {
                komut.CommandText = "SELECT Y.Isim + ' ' + Y.Soyisim FROM KitapYazarlar AS KY JOIN Yazarlar AS Y ON KY.YazarID=Y.ID WHERE KY.KitapID=@kid";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kid", kitapID);
                baglanti.Open();
                string yazarlar = "";
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    yazarlar += okuyucu.GetString(0) + ", ";
                }
                return yazarlar;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public Kitap KitapGetir(int id)
        {
            Kitap k = new Kitap();
            try
            {
                komut.CommandText = "SELECT K.ID, K.TurID, T.Isim, K.YayinEviID, Y.Isim, K.DilID, D.Dil, K.SiraNo,K.Isim,K.Barkod FROM Kitaplar AS K JOIN Turler AS T ON K.TurID=T.ID JOIN YayinEvleri AS Y ON K.YayinEviID = Y.ID JOIN Diller AS D ON K.DilID=D.ID WHERE K.ID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    k.ID = okuyucu.GetInt32(0);
                    k.Tur_ID = okuyucu.GetInt32(1);
                    k.Tur = okuyucu.GetString(2);
                    k.YayinEvi_ID = okuyucu.GetInt32(3);
                    k.YayinEvi = okuyucu.GetString(4);
                    k.Dil_ID = okuyucu.GetInt32(5);
                    k.Dil = okuyucu.GetString(6);
                    k.SiraNo = okuyucu.GetInt16(7);
                    k.Isim = okuyucu.GetString(8);
                    if (!okuyucu.IsDBNull(9))
                    {
                        k.Barkod = okuyucu.GetString(9);
                    }
                   
                }
                return k;
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

        public void kitapSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM KitapYazarlar WHERE KitapID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.CommandText = "DELETE FROM Kitaplar WHERE ID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool kitapGuncelle(Kitap k)
        {
            try
            {
                komut.CommandText = "UPDATE Kitaplar SET SiraNo = @sNo, TurID = @tID, YayineviID = @yeID, DilID = @dID, Isim = @i, Barkod = @b WHERE ID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", k.ID);
                komut.Parameters.AddWithValue("@sNo", k.SiraNo);
                komut.Parameters.AddWithValue("@tID", k.Tur_ID);
                komut.Parameters.AddWithValue("@yeID", k.YayinEvi_ID);
                komut.Parameters.AddWithValue("@dID", k.Dil_ID);
                komut.Parameters.AddWithValue("@i", k.Isim);
                komut.Parameters.AddWithValue("@b", k.Barkod);
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

        #region Kitap Yazarlar Metotları

        public List<Yazar> kitapIDdenYazarListele(int kitapID)
        {
            try
            {
                komut.CommandText = "SELECT Y.ID, Y.Isim, Y.Soyisim FROM KitapYazarlar AS KY JOIN Yazarlar AS Y ON KY.YazarID=Y.ID WHERE KY.KitapID=@kid";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kid", kitapID);
                baglanti.Open();
                List<Yazar> yazarlar = new List<Yazar>();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    yazarlar.Add(new Yazar() { ID = okuyucu.GetInt32(0), Isim = okuyucu.GetString(1), Soyisim = okuyucu.GetString(2) });
                }
                return yazarlar;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool kitabaYazarEkle(int kitapID, int yazarID)
        {
            try
            {
                komut.CommandText = "INSERT INTO KitapYazarlar (KitapID,YazarID) VALUES(@kid,@yid)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kid", kitapID);
                komut.Parameters.AddWithValue("@yid", yazarID);
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

        #region Kiralamalar

        public List<Kiralama> KiradakiKitaplar()
        {
            List<Kiralama> kiralamalar = new List<Kiralama>();
            try
            {
                komut.CommandText = "SELECT K.ID, KK.Isim, K.KiralamaTarihi, K.Aciklama FROM Kiralamalar AS K JOIN Kitaplar AS KK ON K.KitapID = KK.ID WHERE K.TeslimTarihi IS NULL";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Kiralama k = new Kiralama();
                    k.ID = reader.GetInt32(0);
                    k.KitapAdi = reader.GetString(1);
                    k.KiralamaTarihi = reader.GetDateTime(2);
                    k.Kiralayan = reader.GetString(3);
                    kiralamalar.Add(k);
                }
                return kiralamalar;
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
        public List<Kiralama> TumKiralamalar()
        {
            List<Kiralama> kiralamalar = new List<Kiralama>();
            try
            {
                komut.CommandText = "SELECT K.ID, KK.Isim, K.KiralamaTarihi, K.TeslimTarihi, K.Aciklama FROM Kiralamalar AS K JOIN Kitaplar AS KK ON K.KitapID = KK.ID";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Kiralama k = new Kiralama();
                    k.ID = reader.GetInt32(0);
                    k.KitapAdi = reader.GetString(1);
                    k.KiralamaTarihi = reader.GetDateTime(2);
                    if (!reader.IsDBNull(3))
                    {
                        k.TeslimTarihi = reader.GetDateTime(3);
                    }

                    k.Kiralayan = reader.GetString(4);
                    kiralamalar.Add(k);
                }
                return kiralamalar;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool KirayaVer(Kiralama k)
        {
            try
            {
                komut.CommandText = "INSERT INTO Kiralamalar (KitapID,KiralamaTarihi,Aciklama) VALUES(@kitapID,@kiralamaTarihi,@aciklama)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kitapID", k.KitapID);
                komut.Parameters.AddWithValue("@kiralamaTarihi", k.KiralamaTarihi);
                komut.Parameters.AddWithValue("@aciklama", k.Kiralayan);
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

        public bool TeslimEt(int kiralamaID)
        {
            try
            {
                komut.CommandText = "UPDATE Kiralamalar SET TeslimTarihi=@TeslimTarihi WHERE ID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", kiralamaID);
                komut.Parameters.AddWithValue("@TeslimTarihi", DateTime.Now);
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
