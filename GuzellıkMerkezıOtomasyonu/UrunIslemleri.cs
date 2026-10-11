using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class UrunIslemleri
    {
        public List<Urun> TumUrunleriGetir()
        {
            List<Urun> urunler = new List<Urun>();
            string sorgu = "SELECT UrunID, UrunAdi, BirimFiyat FROM tbl_Urunler";

            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                SqlDataReader dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    urunler.Add(new Urun(
                        Convert.ToInt32(dr["UrunID"]),
                        dr["UrunAdi"].ToString(),
                        Convert.ToDecimal(dr["BirimFiyat"])
                    ));
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler alınırken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return urunler;
        }

        public bool UrunEkle(Urun urun)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(urun.UrunAdi))
                    throw new Exception("Ürün adı boş olamaz.");

                if (urun.BirimFiyat <= 0)
                    throw new Exception("Fiyat 0'dan büyük olmalıdır.");

                if (UrunVarMi(urun.UrunAdi))
                    throw new Exception("Bu ürün zaten kayıtlı.");

                string sorgu = "INSERT INTO tbl_Urunler (UrunAdi, BirimFiyat) VALUES (@adi, @fiyat)";
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@adi", urun.UrunAdi);
                komut.Parameters.AddWithValue("@fiyat", urun.BirimFiyat);

                int sonuc = komut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün eklenirken hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public bool UrunGuncelle(Urun urun)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(urun.UrunAdi))
                    throw new Exception("Ürün adı boş olamaz.");

                if (urun.BirimFiyat <= 0)
                    throw new Exception("Fiyat 0'dan büyük olmalıdır.");

                if (UrunVarMi(urun.UrunAdi, urun.UrunID))
                    throw new Exception("Bu adla başka bir ürün zaten var.");

                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

               
                string kontrolSorgu = "SELECT UrunAdi, BirimFiyat FROM tbl_Urunler WHERE UrunID = @id";
                SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, baglanti);
                kontrolKomut.Parameters.AddWithValue("@id", urun.UrunID);
                SqlDataReader dr = kontrolKomut.ExecuteReader();

                if (dr.Read())
                {
                    string mevcutAd = dr["UrunAdi"].ToString();
                    decimal mevcutFiyat = Convert.ToDecimal(dr["BirimFiyat"]);
                    dr.Close();

                    
                    if (mevcutAd == urun.UrunAdi && mevcutFiyat == urun.BirimFiyat)
                    {
                        MessageBox.Show("Herhangi bir değişiklik yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    dr.Close();
                    throw new Exception("Ürün bulunamadı.");
                }

              
                string sorgu = "UPDATE tbl_Urunler SET UrunAdi = @adi, BirimFiyat = @fiyat WHERE UrunID = @id";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@adi", urun.UrunAdi);
                komut.Parameters.AddWithValue("@fiyat", urun.BirimFiyat);
                komut.Parameters.AddWithValue("@id", urun.UrunID);

                int sonuc = komut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün güncellenirken hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public bool UrunSil(int urunID)
        {
            if (UrunKullaniliyorMu(urunID))
            {
                MessageBox.Show("Bu ürün başka kayıtlarla ilişkili olduğu için silinemez!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = "DELETE FROM tbl_Urunler WHERE UrunID = @id";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@id", urunID);

                int sonuc = komut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürününüzün stokları olduğundan silinemez.");
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        private bool UrunVarMi(string urunAdi, int? hariçID = null)
        {
            try
            {
                string sorgu = "SELECT COUNT(*) FROM tbl_Urunler WHERE UrunAdi = @adi";
                if (hariçID.HasValue)
                    sorgu += " AND UrunID != @id";

                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@adi", urunAdi);
                if (hariçID.HasValue)
                    komut.Parameters.AddWithValue("@id", hariçID.Value);

                int sayi = (int)komut.ExecuteScalar();
                return sayi > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün kontrol edilirken hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        private bool UrunKullaniliyorMu(int urunID)
        {
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = "SELECT COUNT(*) FROM tbl_HizmetUrunleri WHERE UrunID = @id";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@id", urunID);

                int sayi = (int)komut.ExecuteScalar();
                return sayi > 0;
            }
            catch
            {
                return true; 
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public int GetMevcutStokFromTopluListe(int urunID)
        {
            StokHareketIslemleri stokHareketIslemleri = new StokHareketIslemleri();
            DataTable dt = stokHareketIslemleri.TumUrunlerinStokDurumu();

            var satir = dt.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["UrunID"]) == urunID);
            if (satir != null)
            {
                return Convert.ToInt32(satir["MevcutStok"]);
            }

            return 0;
        }

        public int GetUrunIDByName(string urunAdi)
        {
            int urunID = -1;
            string sorgu = "SELECT UrunID FROM tbl_Urunler WHERE UrunAdi = @urunAdi";

            SqlConnection conn = SqlBaglanti.Instance.GetConnection();
            try
            {
                SqlBaglanti.Instance.OpenConnection();
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@urunAdi", urunAdi);

                object sonuc = cmd.ExecuteScalar();
                if (sonuc != null)
                {
                    urunID = Convert.ToInt32(sonuc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün ID alınırken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return urunID;
        }

     
    }
}
