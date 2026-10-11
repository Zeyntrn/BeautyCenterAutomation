using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class HizmetUrunIslemleri
    {
        public bool HizmeteUrunEkle(int hizmetID, int urunID, int miktar, int? randevuOrani)
        {
            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
            try
            {
                SqlBaglanti.Instance.OpenConnection();

               
                string kontrolSorgu = @"SELECT COUNT(*) FROM tbl_HizmetUrunleri
                                        WHERE HizmetID = @hizmetID AND UrunID = @urunID";
                SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, baglanti);
                kontrolKomut.Parameters.AddWithValue("@hizmetID", hizmetID);
                kontrolKomut.Parameters.AddWithValue("@urunID", urunID);

                int varMi = (int)kontrolKomut.ExecuteScalar();
                if (varMi > 0)
                {
                  
                    throw new Exception("Bu ürün zaten bu hizmete eklenmiş.");
                }

                
                string ekleSorgu = @"INSERT INTO tbl_HizmetUrunleri 
                             (HizmetID, UrunID, KullanilanMiktar, RandevuBasinaOran)
                             VALUES (@hizmetID, @urunID, @miktar, @oran)";
                SqlCommand ekleKomut = new SqlCommand(ekleSorgu, baglanti);
                ekleKomut.Parameters.AddWithValue("@hizmetID", hizmetID);
                ekleKomut.Parameters.AddWithValue("@urunID", urunID);
                ekleKomut.Parameters.AddWithValue("@miktar", miktar);

                // Eğer oran null ise veritabanına NULL yazılır
                if (randevuOrani.HasValue)
                    ekleKomut.Parameters.AddWithValue("@oran", randevuOrani.Value);
                else
                    ekleKomut.Parameters.AddWithValue("@oran", DBNull.Value);

                int sonuc = ekleKomut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmet ürün ekleme hatası:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }
        public bool HizmeteUrunSil(int hizmetID, int urunID)
        {
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = "DELETE FROM tbl_HizmetUrunleri WHERE HizmetID = @hizmetID AND UrunID = @urunID";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@hizmetID", hizmetID);
                komut.Parameters.AddWithValue("@urunID", urunID);

                int sonuc = komut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün silinirken hata oluştu: " + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }
        public bool HizmeteUrunGuncelle(int hizmetID, int urunID, int yeniMiktar, int? yeniRandevuOrani)
        {
            if (hizmetID <= 0 || urunID <= 0 || yeniMiktar <= 0)
            {
                MessageBox.Show("Lütfen geçerli hizmet, ürün ve miktar bilgileri giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string kontrolSorgu = @"SELECT KullanilanMiktar, RandevuBasinaOran 
                                FROM tbl_HizmetUrunleri 
                                WHERE HizmetID = @hizmetID AND UrunID = @urunID";
                SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, baglanti);
                kontrolKomut.Parameters.AddWithValue("@hizmetID", hizmetID);
                kontrolKomut.Parameters.AddWithValue("@urunID", urunID);

                using (SqlDataReader dr = kontrolKomut.ExecuteReader())
                {
                    if (!dr.Read())
                    {
                        MessageBox.Show("Bu hizmete ait ürün bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    int mevcutMiktar = Convert.ToInt32(dr["KullanilanMiktar"]);
                    int? mevcutOran = dr["RandevuBasinaOran"] != DBNull.Value ? Convert.ToInt32(dr["RandevuBasinaOran"]) : (int?)null;

                    if (mevcutMiktar == yeniMiktar && mevcutOran == yeniRandevuOrani)
                    {
                        MessageBox.Show("Herhangi bir değişiklik yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

                    string guncelleSorgu = @"
            UPDATE tbl_HizmetUrunleri 
            SET KullanilanMiktar = @miktar, RandevuBasinaOran = @randevuOrani 
            WHERE HizmetID = @hizmetID AND UrunID = @urunID";

                    using (SqlCommand guncelleKomut = new SqlCommand(guncelleSorgu, baglanti))
                    {
                        guncelleKomut.Parameters.AddWithValue("@miktar", yeniMiktar);
                        guncelleKomut.Parameters.AddWithValue("@hizmetID", hizmetID);
                        guncelleKomut.Parameters.AddWithValue("@urunID", urunID);

                        if (yeniRandevuOrani.HasValue)
                            guncelleKomut.Parameters.AddWithValue("@randevuOrani", yeniRandevuOrani.Value);
                        else
                            guncelleKomut.Parameters.AddWithValue("@randevuOrani", DBNull.Value);

                        int sonuc = guncelleKomut.ExecuteNonQuery();
                        return sonuc > 0;
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public DataTable TumHizmetUrunleriniGetir()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"
            SELECT 
                hu.HizmetID, 
                hu.UrunID, 
                h.HizmetAdi, 
                u.UrunAdi, 
                hu.KullanilanMiktar,
                hu.RandevuBasinaOran
            FROM tbl_HizmetUrunleri hu
            INNER JOIN tbl_Hizmetler h ON h.HizmetID = hu.HizmetID
            INNER JOIN tbl_Urunler u ON u.UrunID = hu.UrunID";

                SqlDataAdapter adapter = new SqlDataAdapter(sorgu, baglanti);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmet ürünlerini listelerken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return dt;
        }

        public DataTable HizmeteGoreUrunGetir(int hizmetID)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"
            SELECT 
                hu.HizmetID, 
                hu.UrunID, 
                h.HizmetAdi, 
                u.UrunAdi, 
                hu.KullanilanMiktar,
                hu.RandevuBasinaOran
            FROM tbl_HizmetUrunleri hu
            INNER JOIN tbl_Hizmetler h ON hu.HizmetID = h.HizmetID
            INNER JOIN tbl_Urunler u ON hu.UrunID = u.UrunID
            WHERE hu.HizmetID = @hizmetID";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@hizmetID", hizmetID);

                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmete ait ürünleri listelerken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return dt;
        } 
    }
}
