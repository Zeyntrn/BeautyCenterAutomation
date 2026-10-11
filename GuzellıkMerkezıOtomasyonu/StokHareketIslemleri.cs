using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class StokHareketIslemleri
    {
        public bool StokHareketEkle(StokHareketi hareket)
        {
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"INSERT INTO tbl_StokHareketleri (UrunID, HareketTuru, Miktar, HareketTarihi, Aciklama, CalisanID)
                 VALUES (@UrunID, @HareketTuru, @Miktar, @HareketTarihi, @Aciklama, @CalisanID)";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@UrunID", hareket.UrunID);
                komut.Parameters.AddWithValue("@HareketTuru", hareket.HareketTuru);
                komut.Parameters.AddWithValue("@Miktar", hareket.Miktar);
                komut.Parameters.AddWithValue("@HareketTarihi", hareket.HareketTarihi);
                komut.Parameters.AddWithValue("@Aciklama", (object)hareket.Aciklama ?? DBNull.Value);
                komut.Parameters.AddWithValue("@CalisanID", hareket.CalisanID);

                int sonuc = komut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stok hareketi eklenirken hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public List<StokHareketi> TumStokHareketleriniGetir()
        {


            List<StokHareketi> liste = new List<StokHareketi>();

            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
            SqlBaglanti.Instance.OpenConnection();

            string sorgu = @"
        SELECT h.HareketID, h.UrunID, u.UrunAdi, h.HareketTuru, h.Miktar, 
               h.HareketTarihi, h.Aciklama, h.CalisanID, (c.Ad + ' ' + c.Soyad) AS CalisanAdi
        FROM tbl_StokHareketleri h
        INNER JOIN tbl_Urunler u ON h.UrunID = u.UrunID
        INNER JOIN tbl_Calisanlar c ON h.CalisanID = c.CalisanID
        ORDER BY h.HareketTarihi DESC";

            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                StokHareketi hareket = new StokHareketi(
                    urunID: Convert.ToInt32(dr["UrunID"]),
                    hareketTuru: dr["HareketTuru"].ToString(),
                    miktar: Convert.ToInt32(dr["Miktar"]),
                    tarih: Convert.ToDateTime(dr["HareketTarihi"]),
                    aciklama: dr["Aciklama"].ToString(),
                    calisanID: Convert.ToInt32(dr["CalisanID"])  
                )
                {
                    HareketID = Convert.ToInt32(dr["HareketID"]),
                    UrunAdi = dr["UrunAdi"].ToString(),
                    CalisanAdi = dr["CalisanAdi"].ToString() 
                };

                liste.Add(hareket);
            }

            dr.Close();
            SqlBaglanti.Instance.CloseConnection();

            return liste;
        }

        public DataTable TumUrunlerinStokDurumu()
        {
            DataTable dt = new DataTable();
            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();

            try
            {
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"
            SELECT 
                u.UrunID,
                u.UrunAdi,
                SUM(
                    CASE 
                        WHEN s.HareketTuru = 'Giriş' THEN s.Miktar
                        WHEN s.HareketTuru IN ('Satış', 'Seans') THEN -s.Miktar
                        ELSE 0
                    END
                ) AS MevcutStok
            FROM tbl_Urunler u
            LEFT JOIN tbl_StokHareketleri s ON u.UrunID = s.UrunID
            GROUP BY u.UrunID, u.UrunAdi";

                SqlDataAdapter adapter = new SqlDataAdapter(sorgu, baglanti);
                adapter.Fill(dt);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return dt;
        }

        public bool MiktarGuncelle(int hareketID, int yeniMiktar, int calisanID)
        {
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

               
                string kontrolSorgu = "SELECT HareketTuru FROM tbl_StokHareketleri WHERE HareketID = @id";
                SqlCommand kontrolCmd = new SqlCommand(kontrolSorgu, baglanti);
                kontrolCmd.Parameters.AddWithValue("@id", hareketID);

                string hareketTuru = kontrolCmd.ExecuteScalar()?.ToString();

                if (hareketTuru == "Satış" || hareketTuru == "Seans")
                {
                    MessageBox.Show("Satış veya Seans hareketlerinin miktarı değiştirilemez!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                    
                }

                
                string sorgu = @"UPDATE tbl_StokHareketleri 
                         SET Miktar = @miktar,
                             Aciklama = @aciklama, 
                             HareketTarihi = GETDATE(),
                             CalisanID = @calisanID
                         WHERE HareketID = @id";

                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@miktar", yeniMiktar);
                cmd.Parameters.AddWithValue("@aciklama", "Stok miktarı düzenlendi");
                cmd.Parameters.AddWithValue("@calisanID", calisanID);
                cmd.Parameters.AddWithValue("@id", hareketID);

                int sonuc = cmd.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stok miktarı güncellenirken hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }
    }
}
