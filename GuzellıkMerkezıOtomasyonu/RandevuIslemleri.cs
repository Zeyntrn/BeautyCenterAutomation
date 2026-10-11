using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
   public class RandevuIslemleri
    {
        public List<(TimeSpan saat, int sure)> GetirDoluSaatler(int calisanID, DateTime tarih)
        {
            List<(TimeSpan, int)> doluSaatler = new List<(TimeSpan, int)>();

            try
            {
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"
                SELECT RandevuSaati, h.Sure
                FROM tbl_Randevular r
                INNER JOIN tbl_Hizmetler h ON r.HizmetID = h.HizmetID
                WHERE 
                    r.CalisanID = @calisanID AND
                    CAST(r.RandevuTarihi AS DATE) = @tarih AND
                    r.Durum IN ('Bekliyor', 'Devam Ediyor');";

                using (SqlCommand cmd = new SqlCommand(sorgu, SqlBaglanti.Instance.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@calisanID", calisanID);
                    cmd.Parameters.AddWithValue("@tarih", tarih.Date);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            TimeSpan saat = TimeSpan.Parse(dr["RandevuSaati"].ToString());
                            int sure = Convert.ToInt32(dr["Sure"]);
                            doluSaatler.Add((saat, sure));
                        }
                    }
                }
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return doluSaatler;
        }

        public List<TimeSpan> GetirUygunSaatler(int calisanID, DateTime tarih, int hizmetSuresi)
        {
            List<TimeSpan> uygunSaatler = new List<TimeSpan>();

       
            TimeSpan baslangic = new TimeSpan(10, 0, 0);
            TimeSpan bitis = new TimeSpan(19, 0, 0);

            RandevuIslemleri ri = new RandevuIslemleri();
            var doluSaatler = ri.GetirDoluSaatler(calisanID, tarih);

            for (TimeSpan saat = baslangic; saat.Add(TimeSpan.FromMinutes(hizmetSuresi)) <= bitis; saat = saat.Add(TimeSpan.FromMinutes(hizmetSuresi)))
            {
               
                if (tarih.Date == DateTime.Today && saat <= DateTime.Now.TimeOfDay)
                    continue;

                bool cakismaVar = doluSaatler.Any(r =>
                {
                    TimeSpan rBaslangic = r.saat;
                    TimeSpan rBitis = r.saat.Add(TimeSpan.FromMinutes(r.sure));

                    TimeSpan yeniBaslangic = saat;
                    TimeSpan yeniBitis = saat.Add(TimeSpan.FromMinutes(hizmetSuresi));

                    return yeniBaslangic < rBitis && rBaslangic < yeniBitis;
                });

                if (!cakismaVar)
                    uygunSaatler.Add(saat);
            }


            return uygunSaatler;
        }

        public bool RandevuEkle(Randevu randevu)
        {
            try
            {
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"
            INSERT INTO tbl_Randevular
            (MusteriID, CalisanID, HizmetID, RandevuTarihi, RandevuSaati, ToplamSeans, KalanSeans, Durum)
            VALUES
            (@musteriID, @calisanID, @hizmetID, @tarih, @saat, @toplamSeans, @kalanSeans, @durum)";

                using (SqlCommand cmd = new SqlCommand(sorgu, SqlBaglanti.Instance.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@musteriID", randevu.MusteriID);
                    cmd.Parameters.AddWithValue("@calisanID", randevu.CalisanID);
                    cmd.Parameters.AddWithValue("@hizmetID", randevu.HizmetID);
                    cmd.Parameters.AddWithValue("@tarih", randevu.RandevuTarihi);
                    cmd.Parameters.AddWithValue("@saat", randevu.RandevuSaati);
                    cmd.Parameters.AddWithValue("@toplamSeans", randevu.ToplamSeans);
                    cmd.Parameters.AddWithValue("@kalanSeans", randevu.KalanSeans);
                    cmd.Parameters.AddWithValue("@durum", randevu.Durum);

                    int sonuc = cmd.ExecuteNonQuery();
                    return sonuc > 0;
                }
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public void RandevuTamamlandiStokDusur(int randevuID, int calisanID)
        {
            SqlConnection conn = SqlBaglanti.Instance.GetConnection();
            SqlBaglanti.Instance.OpenConnection();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
               
                string randevuSorgu = "SELECT HizmetID FROM tbl_Randevular WHERE RandevuID = @randevuID";
                SqlCommand cmdRandevu = new SqlCommand(randevuSorgu, conn, transaction);
                cmdRandevu.Parameters.AddWithValue("@randevuID", randevuID);
                int hizmetID = (int)cmdRandevu.ExecuteScalar();

                string urunSorgu = @"
            SELECT hu.UrunID, hu.KullanilanMiktar, hu.RandevuBasinaOran
            FROM tbl_HizmetUrunleri hu
            WHERE hu.HizmetID = @hizmetID";

                SqlCommand cmdUrun = new SqlCommand(urunSorgu, conn, transaction);
                cmdUrun.Parameters.AddWithValue("@hizmetID", hizmetID);
                SqlDataReader dr = cmdUrun.ExecuteReader();

                List<(int urunID, int miktar, int oran)> urunler = new List<(int, int, int)>();
                while (dr.Read())
                {
                    urunler.Add((Convert.ToInt32(dr["UrunID"]),
                                 Convert.ToInt32(dr["KullanilanMiktar"]),
                                 Convert.ToInt32(dr["RandevuBasinaOran"])));
                }
                dr.Close();

                foreach (var urun in urunler)
                {
                    string sayacSorgu = @"
                SELECT COUNT(*) FROM tbl_Randevular 
                WHERE HizmetID = @hizmetID AND Durum = 'Tamamlandı'";

                    SqlCommand cmdSayac = new SqlCommand(sayacSorgu, conn, transaction);
                    cmdSayac.Parameters.AddWithValue("@hizmetID", hizmetID);
                    int tamamlananRandevuSayisi = (int)cmdSayac.ExecuteScalar();

                    if (tamamlananRandevuSayisi % urun.oran == 0)
                    {
                        string stokHareketEkle = @"
                    INSERT INTO tbl_StokHareketleri (UrunID, HareketTuru, Miktar, Aciklama, CalisanID, HareketTarihi)
                    VALUES (@urunID, 'Seans', @miktar, 'Seans kullanımı (Randevu Tamamlandı)', @calisanID,  GETDATE())";

                        SqlCommand cmdStok = new SqlCommand(stokHareketEkle, conn, transaction);
                        cmdStok.Parameters.AddWithValue("@urunID", urun.urunID);
                        cmdStok.Parameters.AddWithValue("@miktar", urun.miktar);
                        cmdStok.Parameters.AddWithValue("@calisanID", calisanID);
                        cmdStok.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Stok hareketi kaydedilirken hata: " + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }


        public bool RandevuDurumGuncelle(int randevuID, string yeniDurum)
        {
            try
            {
                SqlConnection conn = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = "UPDATE tbl_Randevular SET Durum = @durum WHERE RandevuID = @id";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@durum", yeniDurum);
                cmd.Parameters.AddWithValue("@id", randevuID);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevu durumu güncellenirken hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public void KalanSeansiDusur(int randevuID)
        {
            SqlConnection conn = SqlBaglanti.Instance.GetConnection();
            SqlBaglanti.Instance.OpenConnection();

            try
            {
               
                string sorguSelect = "SELECT KalanSeans FROM tbl_Randevular WHERE RandevuID = @randevuID";
                SqlCommand cmdSelect = new SqlCommand(sorguSelect, conn);
                cmdSelect.Parameters.AddWithValue("@randevuID", randevuID);

                object kalanSeansObj = cmdSelect.ExecuteScalar();

                if (kalanSeansObj != null && int.TryParse(kalanSeansObj.ToString(), out int kalanSeans))
                {
                    if (kalanSeans > 0)
                    {
                    
                        string sorguUpdate = "UPDATE tbl_Randevular SET KalanSeans = @kalanSeans WHERE RandevuID = @randevuID";
                        SqlCommand cmdUpdate = new SqlCommand(sorguUpdate, conn);
                        cmdUpdate.Parameters.AddWithValue("@kalanSeans", kalanSeans - 1);
                        cmdUpdate.Parameters.AddWithValue("@randevuID", randevuID);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kalan seans düşürülürken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public DataTable TumRandevulariGetir()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlConnection conn = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                  string sorgu = @"
                    SELECT 
                    r.RandevuID,
                    r.MusteriID,
                    r.CalisanID,
                    r.HizmetID,
                    m.Ad + ' ' + m.Soyad AS MusteriAdi,
                    c.Ad + ' ' + c.Soyad AS CalisanAdi,
                    h.HizmetAdi,
                    r.RandevuTarihi,
                    r.RandevuSaati,
                    r.ToplamSeans,
                    r.KalanSeans,
                    r.Durum
                FROM tbl_Randevular r
                 INNER JOIN tbl_Musteriler m ON r.MusteriID = m.MusteriID
                INNER JOIN tbl_Calisanlar c ON r.CalisanID = c.CalisanID
                INNER JOIN tbl_Hizmetler h ON r.HizmetID = h.HizmetID
                ORDER BY r.RandevuTarihi DESC, r.RandevuSaati ASC";

                SqlDataAdapter adapter = new SqlDataAdapter(sorgu, conn);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevular getirilirken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return dt;
        }

        public bool RandevuIptalEt(int randevuID)
        {
            try
            {
                SqlConnection conn = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

               
                string kontrolSorgu = "SELECT Durum FROM tbl_Randevular WHERE RandevuID = @randevuID";
                SqlCommand kontrolCmd = new SqlCommand(kontrolSorgu, conn);
                kontrolCmd.Parameters.AddWithValue("@randevuID", randevuID);

                string mevcutDurum = kontrolCmd.ExecuteScalar()?.ToString();
                if (mevcutDurum != "Bekliyor")
                {
                    MessageBox.Show("Sadece 'Bekliyor' durumundaki randevular iptal edilebilir.");
                    return false;
                }

                string iptalSorgu = "UPDATE tbl_Randevular SET Durum = 'İptal Edildi' WHERE RandevuID = @randevuID";
                SqlCommand iptalCmd = new SqlCommand(iptalSorgu, conn);
                iptalCmd.Parameters.AddWithValue("@randevuID", randevuID);

                return iptalCmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevu iptal edilirken hata:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public bool RandevuBilgileriniGuncelle(int randevuID, DateTime yeniTarih, string yeniSaat, int yeniCalisanID)
{
    try
    {
        using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
        {
            SqlBaglanti.Instance.OpenConnection();

           
            string kontrolSorgu = @"SELECT RandevuTarihi, RandevuSaati, CalisanID FROM tbl_Randevular WHERE RandevuID = @randevuID";
            SqlCommand cmdKontrol = new SqlCommand(kontrolSorgu, conn);
            cmdKontrol.Parameters.AddWithValue("@randevuID", randevuID);

            using (SqlDataReader dr = cmdKontrol.ExecuteReader())
            {
                if (dr.Read())
                {
                    DateTime mevcutTarih = Convert.ToDateTime(dr["RandevuTarihi"]);
                    string mevcutSaat = dr["RandevuSaati"].ToString();
                    int mevcutCalisanID = Convert.ToInt32(dr["CalisanID"]);

                  
                    if (mevcutTarih.Date == yeniTarih.Date &&
                        mevcutSaat == yeniSaat &&
                        mevcutCalisanID == yeniCalisanID)
                    {
                        
                        MessageBox.Show("Herhangi bir değişiklik yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Randevu bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

           
            string guncelleSorgu = @"UPDATE tbl_Randevular 
                                     SET RandevuTarihi = @tarih, RandevuSaati = @saat, CalisanID = @calisanID 
                                     WHERE RandevuID = @randevuID";

            SqlCommand cmd = new SqlCommand(guncelleSorgu, conn);
            cmd.Parameters.AddWithValue("@tarih", yeniTarih.Date);
            cmd.Parameters.AddWithValue("@saat", yeniSaat);
            cmd.Parameters.AddWithValue("@calisanID", yeniCalisanID);
            cmd.Parameters.AddWithValue("@randevuID", randevuID);

            int sonuc = cmd.ExecuteNonQuery();
            return sonuc > 0;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevu güncellenirken hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
        }
    }


        public List<RandevuBilgisi> MusteriRandevulariniGetir(int musteriID)
        {
            List<RandevuBilgisi> liste = new List<RandevuBilgisi>();

            SqlConnection conn = SqlBaglanti.Instance.GetConnection();
            try
            {
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"
                SELECT r.RandevuTarihi, r.RandevuSaati, h.HizmetAdi, r.Durum
                FROM tbl_Randevular r
                INNER JOIN tbl_Hizmetler h ON h.HizmetID = r.HizmetID
                WHERE r.MusteriID = @musteriID
                ORDER BY r.RandevuTarihi DESC";

                using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@musteriID", musteriID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new RandevuBilgisi
                            {
                                Tarih = reader.GetDateTime(0),
                                Saat = reader.GetString(1),
                                HizmetAdi = reader.GetString(2),
                                Durum = reader.GetString(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevular getirilirken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return liste;
        }

        public void GecikenRandevulariIptalEt()
        {
            try
            {
                SqlConnection conn = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string selectQuery = @"SELECT RandevuID, RandevuTarihi, RandevuSaati 
                               FROM tbl_Randevular 
                               WHERE Durum = 'Bekliyor'";

                using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn))
                using (SqlDataReader reader = selectCmd.ExecuteReader())
                {
                    List<int> iptalEdilecekIDler = new List<int>();

                    while (reader.Read())
                    {
                        int randevuID = reader.GetInt32(0);
                        DateTime tarih = reader.GetDateTime(1);
                        if (tarih.Date < DateTime.Today)
                        {
                            iptalEdilecekIDler.Add(randevuID);
                        }

                    }

                    reader.Close();

                    foreach (int id in iptalEdilecekIDler)
                    {
                        string update = "UPDATE tbl_Randevular SET Durum = 'İptal Edildi' WHERE RandevuID = @id";
                        using (SqlCommand updateCmd = new SqlCommand(update, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@id", id);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("C# ile kontrol sırasında hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public int GetirKalanSeansDogru(int musteriID, int hizmetID)
        {
            SqlConnection conn = SqlBaglanti.Instance.GetConnection();
            try
            {
                SqlBaglanti.Instance.OpenConnection();

                
                string seansSorgu = @"
            SELECT TOP 1 ToplamSeans 
            FROM tbl_Randevular 
            WHERE MusteriID = @musteriID AND HizmetID = @hizmetID
            ORDER BY RandevuTarihi DESC";

                SqlCommand cmdSeans = new SqlCommand(seansSorgu, conn);
                cmdSeans.Parameters.AddWithValue("@musteriID", musteriID);
                cmdSeans.Parameters.AddWithValue("@hizmetID", hizmetID);
                object seansSonuc = cmdSeans.ExecuteScalar();

                if (seansSonuc == null)
                    return 0; 

                int toplamSeans = Convert.ToInt32(seansSonuc);

                string tamamlananSorgu = @"
            SELECT COUNT(*) 
            FROM tbl_Randevular 
            WHERE MusteriID = @musteriID AND HizmetID = @hizmetID AND Durum = 'Tamamlandı'";

                SqlCommand cmdTamamlanan = new SqlCommand(tamamlananSorgu, conn);
                cmdTamamlanan.Parameters.AddWithValue("@musteriID", musteriID);
                cmdTamamlanan.Parameters.AddWithValue("@hizmetID", hizmetID);
                int tamamlanan = Convert.ToInt32(cmdTamamlanan.ExecuteScalar());

                int kalan = toplamSeans - tamamlanan;
                return kalan > 0 ? kalan : 0;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

    }
}
