using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class HizmetIslemleri
    {
        public List<Hizmet> TumHizmetleriGetir()
        {
            List<Hizmet> hizmetler = new List<Hizmet>();
            string sorgu = @"SELECT h.HizmetID, h.HizmetAdi, h.TurID, t.TurAdi, h.Fiyat, h.Sure, h.ToplamSeans
                             FROM tbl_Hizmetler h
                             INNER JOIN tbl_HizmetTurleri t ON h.TurID = t.TurID ";

            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                SqlDataReader dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    hizmetler.Add(new Hizmet(
                        Convert.ToInt32(dr["HizmetID"]),
                        dr["HizmetAdi"].ToString(),
                        Convert.ToInt32(dr["TurID"]),
                        dr["TurAdi"].ToString(),
                        Convert.ToDecimal(dr["Fiyat"]),
                        Convert.ToInt32(dr["Sure"]),
                        Convert.ToInt32(dr["ToplamSeans"])
                    ));
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmetler alınırken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return hizmetler;
        }

        public bool HizmetEkle(Hizmet h)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(h.HizmetAdi))
                    throw new Exception("Hizmet adı boş olamaz.");

                if (HizmetVarMi(h.HizmetAdi))
                    throw new Exception("Bu adla bir hizmet zaten mevcut.");

                if (h.Fiyat <= 0 || h.Sure <= 0 || h.ToplamSeans <= 0)
                    throw new Exception("Fiyat, süre ve seans sayısı sıfırdan büyük olmalıdır.");

                string sorgu = @"INSERT INTO tbl_Hizmetler (HizmetAdi, TurID, Fiyat, Sure, ToplamSeans)
                                 VALUES (@adi, @turID, @fiyat, @sure, @seans)";

                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@adi", h.HizmetAdi);
                komut.Parameters.AddWithValue("@turID", h.TurID);
                komut.Parameters.AddWithValue("@fiyat", h.Fiyat);
                komut.Parameters.AddWithValue("@sure", h.Sure);
                komut.Parameters.AddWithValue("@seans", h.ToplamSeans);

                int sonuc = komut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmet eklenirken hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public bool HizmetGuncelle(Hizmet h)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(h.HizmetAdi))
                    throw new Exception("Hizmet adı boş olamaz.");

                if (HizmetVarMi(h.HizmetAdi, h.HizmetID))
                    throw new Exception("Bu adla başka bir hizmet zaten mevcut.");

                if (h.Fiyat <= 0 || h.Sure <= 0 || h.ToplamSeans <= 0)
                    throw new Exception("Fiyat, süre ve seans sayısı sıfırdan büyük olmalıdır.");

                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                
                string kontrolSorgu = @"SELECT HizmetAdi, TurID, Fiyat, Sure, ToplamSeans 
                                FROM tbl_Hizmetler WHERE HizmetID = @id";

                SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, baglanti);
                kontrolKomut.Parameters.AddWithValue("@id", h.HizmetID);

                SqlDataReader dr = kontrolKomut.ExecuteReader();
                if (dr.Read())
                {
                    string mevcutAd = dr["HizmetAdi"].ToString();
                    int mevcutTurID = Convert.ToInt32(dr["TurID"]);
                    decimal mevcutFiyat = Convert.ToDecimal(dr["Fiyat"]);
                    int mevcutSure = Convert.ToInt32(dr["Sure"]);
                    int mevcutSeans = Convert.ToInt32(dr["ToplamSeans"]);

                    if (mevcutAd == h.HizmetAdi &&
                        mevcutTurID == h.TurID &&
                        mevcutFiyat == h.Fiyat &&
                        mevcutSure == h.Sure &&
                        mevcutSeans == h.ToplamSeans)
                    {
                        dr.Close();
                        MessageBox.Show("Herhangi bir değişiklik yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                dr.Close();

                
                string sorgu = @"UPDATE tbl_Hizmetler
                         SET HizmetAdi = @adi, TurID = @turID, Fiyat = @fiyat, Sure = @sure, ToplamSeans = @seans
                         WHERE HizmetID = @id";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@adi", h.HizmetAdi);
                komut.Parameters.AddWithValue("@turID", h.TurID);
                komut.Parameters.AddWithValue("@fiyat", h.Fiyat);
                komut.Parameters.AddWithValue("@sure", h.Sure);
                komut.Parameters.AddWithValue("@seans", h.ToplamSeans);
                komut.Parameters.AddWithValue("@id", h.HizmetID);

                int sonuc = komut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public bool HizmetSil(int hizmetID)
        {
            try
            {
                if (HizmetKullaniliyorMu(hizmetID))
                    throw new Exception("Bu hizmet randevularda kullanılıyor, silinemez.");

                if (HizmetUrunleriKullaniliyorMu(hizmetID))
                    throw new Exception("Bu hizmete ait ürünler var, lütfen önce ürünleri siliniz.");

                string sorgu = "DELETE FROM tbl_Hizmetler WHERE HizmetID = @id";
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@id", hizmetID);

                int sonuc = komut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        private bool HizmetVarMi(string ad, int? hariçID = null)
        {
            try
            {
                string sorgu = "SELECT COUNT(*) FROM tbl_Hizmetler WHERE HizmetAdi = @adi";
                if (hariçID != null)
                    sorgu += " AND HizmetID != @id";

                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@adi", ad);
                if (hariçID != null)
                    komut.Parameters.AddWithValue("@id", hariçID);

                int sayi = (int)komut.ExecuteScalar();
                return sayi > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmet kontrol edilirken hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        private bool HizmetKullaniliyorMu(int hizmetID)
        {
            try
            {
                string sorgu = "SELECT COUNT(*) FROM tbl_Randevular WHERE HizmetID = @id";
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@id", hizmetID);

                int sayi = (int)komut.ExecuteScalar();
                return sayi > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmet kullanım durumu kontrol edilirken hata oluştu:\n" + ex.Message);
                return true; 
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        private bool HizmetUrunleriKullaniliyorMu(int hizmetID)
        {
            try
            {
                string sorgu = "SELECT COUNT(*) FROM tbl_HizmetUrunleri WHERE HizmetID = @id";
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@id", hizmetID);

                int sayi = (int)komut.ExecuteScalar();
                return sayi > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmet ürün bağlantısı kontrol edilirken hata oluştu:\n" + ex.Message);
                return true; 
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }
        public DataTable HizmetleriTureGoreGetir(int turID)
        {
            DataTable dt = new DataTable();
            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_Hizmetler WHERE TurID = @turID", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@turID", turID);
            da.Fill(dt);
            return dt;
        }

        public int GetirHizmetSuresi(int hizmetID)
        {
            int sure = 0;

            try
            {
                SqlBaglanti.Instance.OpenConnection();
                string sorgu = "SELECT Sure FROM tbl_Hizmetler WHERE HizmetID = @hizmetID";

                using (SqlCommand cmd = new SqlCommand(sorgu, SqlBaglanti.Instance.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@hizmetID", hizmetID);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        sure = Convert.ToInt32(result);
                }
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return sure;
        }

        public int GetirToplamSeans(int hizmetID)
        {
            int seans = 1;

            try
            {
                SqlBaglanti.Instance.OpenConnection();
                string sorgu = "SELECT ToplamSeans FROM tbl_Hizmetler WHERE HizmetID = @hizmetID";

                using (SqlCommand cmd = new SqlCommand(sorgu, SqlBaglanti.Instance.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@hizmetID", hizmetID);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        seans = Convert.ToInt32(result);
                }
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return seans;
        }

        public int GetirHizmetTurID(int hizmetID)
        {
            int turID = -1;

            try
            {
                SqlConnection conn = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = "SELECT TurID FROM tbl_Hizmetler WHERE HizmetID = @hizmetID";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@hizmetID", hizmetID);

                object result = cmd.ExecuteScalar();
                if (result != null)
                    turID = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmet Türü alınırken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return turID;
        }

        public decimal GetirHizmetFiyati(int hizmetID)
        {
            decimal fiyat = 0;
            SqlConnection conn = SqlBaglanti.Instance.GetConnection();
            SqlBaglanti.Instance.OpenConnection();

            try
            {
                string sorgu = "SELECT Fiyat FROM tbl_Hizmetler WHERE HizmetID = @id";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@id", hizmetID);
                object sonuc = cmd.ExecuteScalar();

                if (sonuc != null)
                    fiyat = Convert.ToDecimal(sonuc);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return fiyat;
        }

        public int GetHizmetIDByName(string hizmetAdi)
        {
            int hizmetID = -1;

            try
            {
                SqlConnection conn = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = "SELECT HizmetID FROM tbl_Hizmetler WHERE HizmetAdi = @hizmetAdi";

                using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@hizmetAdi", hizmetAdi);

                    object sonuc = cmd.ExecuteScalar();
                    if (sonuc != null)
                        hizmetID = Convert.ToInt32(sonuc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmet ID alınırken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return hizmetID;
        }
        public DataTable TureGoreHizmetleriGetir(int turID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = SqlBaglanti.Instance.GetConnection();

            try
            {
                SqlBaglanti.Instance.OpenConnection();
                 string sorgu = @"
                SELECT 
                h.HizmetID, 
                h.HizmetAdi, 
                h.TurID,          
                ht.TurAdi, 
                h.Fiyat, 
                h.Sure, 
                h.ToplamSeans
            FROM tbl_Hizmetler h
            INNER JOIN tbl_HizmetTurleri ht ON h.TurID = ht.TurID
            WHERE h.TurID = @turID";

                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@turID", turID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmetler listelenirken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return dt;
        }
    }
}
