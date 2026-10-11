using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class HizmetTuruIslemleri
    {
        public List<HizmetTuru> TumHizmetTurleriniGetir()
        {
            List<HizmetTuru> turler = new List<HizmetTuru>();
            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();

            try
            {
                SqlBaglanti.Instance.OpenConnection();

                SqlCommand komut = new SqlCommand("SELECT * FROM tbl_HizmetTurleri", baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    turler.Add(new HizmetTuru(
                        Convert.ToInt32(dr["TurID"]),
                        dr["TurAdi"].ToString()
                    ));
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmet türleri alınırken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return turler;
        }

        public bool HizmetTuruEkle(string turAdi)
        {
            if (string.IsNullOrWhiteSpace(turAdi))
                throw new Exception("Hizmet türü adı boş olamaz.");

            if (HizmetTuruVarMi(turAdi))
                throw new Exception("Bu ad ile zaten bir hizmet türü kayıtlı.");

            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
            try
            {
                SqlBaglanti.Instance.OpenConnection();
                SqlCommand komut = new SqlCommand("INSERT INTO tbl_HizmetTurleri (TurAdi) VALUES (@adi)", baglanti);
                komut.Parameters.AddWithValue("@adi", turAdi);
                int sonuc = komut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme sırasında hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public bool HizmetTuruGuncelle(int turID, string yeniAdi)
        {
            if (string.IsNullOrWhiteSpace(yeniAdi))
                throw new Exception("Yeni ad boş olamaz.");

            string mevcutAd = "";
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

               
                SqlCommand mevcutKomut = new SqlCommand("SELECT TurAdi FROM tbl_HizmetTurleri WHERE TurID = @id", baglanti);
                mevcutKomut.Parameters.AddWithValue("@id", turID);
                var sonuc = mevcutKomut.ExecuteScalar();
                mevcutAd = sonuc != null ? sonuc.ToString() : "";

                SqlBaglanti.Instance.CloseConnection();
            }
            catch (Exception ex)
            {
                SqlBaglanti.Instance.CloseConnection();
                MessageBox.Show("Mevcut hizmet türü alınırken hata oluştu: " + ex.Message);
                return false;
            }

            if (mevcutAd.Equals(yeniAdi, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Herhangi bir değişiklik yapılmadı.");
                return false;
            }

            if (HizmetTuruVarMi(yeniAdi))
                throw new Exception("Bu ad ile zaten bir hizmet türü kayıtlı.");

            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                SqlCommand komut = new SqlCommand("UPDATE tbl_HizmetTurleri SET TurAdi = @adi WHERE TurID = @id", baglanti);
                komut.Parameters.AddWithValue("@adi", yeniAdi);
                komut.Parameters.AddWithValue("@id", turID);

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

        public bool HizmetTuruSil(int turID)
        {
            if (HizmetTuruKullaniliyorMu(turID))
                throw new Exception("Bu hizmet türü başka veriler tarafından kullanılıyor, silinemez.");

            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
            try
            {
                SqlBaglanti.Instance.OpenConnection();
                SqlCommand komut = new SqlCommand("DELETE FROM tbl_HizmetTurleri WHERE TurID = @id", baglanti);
                komut.Parameters.AddWithValue("@id", turID);
                int sonuc = komut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme sırasında hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        private bool HizmetTuruVarMi(string turAdi)
        {
            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
            try
            {
                SqlBaglanti.Instance.OpenConnection();
                SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM tbl_HizmetTurleri WHERE TurAdi = @adi", baglanti);
                komut.Parameters.AddWithValue("@adi", turAdi);
                int sayi = (int)komut.ExecuteScalar();
                return sayi > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kontrol sırasında hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        private bool HizmetTuruKullaniliyorMu(int turID)
        {
            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
            try
            {
                SqlBaglanti.Instance.OpenConnection();
                SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM tbl_Hizmetler WHERE TurID = @id", baglanti);
                komut.Parameters.AddWithValue("@id", turID);
                int sayi = (int)komut.ExecuteScalar();
                return sayi > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantılı kayıt kontrol edilirken hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }
    }
}
