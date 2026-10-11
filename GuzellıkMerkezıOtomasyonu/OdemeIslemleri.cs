// OdemeIslemleri.cs
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;
using GuzellıkMerkezıOtomasyonu;

namespace GuzellikMerkeziOtomasyonu
{
    public class OdemeIslemleri
    {
        private SqlConnection conn;

        public OdemeIslemleri()
        {
            conn = SqlBaglanti.Instance.GetConnection();
        }

        public int OdemeEkle(int musteriID, int? calisanID, int? randevuID, decimal toplamTutar, string odemeTuru, string odemeKaynagi)
        {
            int odemeID = -1;
           SqlConnection conn = SqlBaglanti.Instance.GetConnection();

            try
            {
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"
        INSERT INTO tbl_Odemeler (MusteriID, CalisanID, RandevuID, ToplamTutar, OdemeTuru, OdemeKaynagi)
        VALUES (@musteriID, @calisanID, @randevuID, @toplamTutar, @odemeTuru, @odemeKaynagi);
        SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@musteriID", musteriID);
                    cmd.Parameters.AddWithValue("@calisanID", (object)calisanID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@randevuID", (object)randevuID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@toplamTutar", toplamTutar);
                    cmd.Parameters.AddWithValue("@odemeTuru", odemeTuru);
                    cmd.Parameters.AddWithValue("@odemeKaynagi", odemeKaynagi);

                    object sonuc = cmd.ExecuteScalar();
                    if (sonuc != null)
                        odemeID = Convert.ToInt32(sonuc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ödeme kaydı eklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return odemeID;
        }

        public void TaksitleriEkle(int odemeID, decimal toplamTutar, int vadeSayisi)
        {
            decimal taksitTutar = Math.Round(toplamTutar / vadeSayisi, 2);
            DateTime bugun = DateTime.Today;

            SqlConnection conn = SqlBaglanti.Instance.GetConnection();

            try
            {
                SqlBaglanti.Instance.OpenConnection();

                for (int i = 1; i <= vadeSayisi; i++)
                {
                    string sorgu = @"
                INSERT INTO tbl_Taksitler (OdemeID, TaksitNo, Tutar, VadeTarihi, Durum)
                VALUES (@odemeID, @taksitNo, @tutar, @vadeTarihi, 'Bekliyor')";

                    using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                    {
                        cmd.Parameters.AddWithValue("@odemeID", odemeID);
                        cmd.Parameters.AddWithValue("@taksitNo", i);
                        cmd.Parameters.AddWithValue("@tutar", taksitTutar);
                        cmd.Parameters.AddWithValue("@vadeTarihi", bugun.AddMonths(i));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Taksitler eklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }
        public int SatisEkle(int musteriID, int? calisanID, int? odemeID)
        {
            int satisID = -1;

            try
            {
                SqlConnection conn = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"
        INSERT INTO tbl_Satislar (MusteriID, CalisanID, OdemeID)
        VALUES (@musteriID, @calisanID, @odemeID);
        SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@musteriID", musteriID);
                    cmd.Parameters.AddWithValue("@calisanID", (object)calisanID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@odemeID", (object)odemeID ?? DBNull.Value);

                    satisID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış eklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return satisID;
        }

        public void SatisDetayEkle(int satisID, int urunID, int miktar, decimal tutar)
        {
            SqlConnection conn = SqlBaglanti.Instance.GetConnection();

            try
            {
                SqlBaglanti.Instance.OpenConnection(); 

                string sorgu = "INSERT INTO tbl_SatisDetay (SatisID, UrunID, Miktar, Tutar) VALUES (@satisID, @urunID, @miktar, @tutar)";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@satisID", satisID);
                cmd.Parameters.AddWithValue("@urunID", urunID);
                cmd.Parameters.AddWithValue("@miktar", miktar);
                cmd.Parameters.AddWithValue("@tutar", tutar);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış detay eklenirken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection(); 
            }
        }

        public void StokDus(int urunID, int miktar, int? calisanID, string Aciklama)
        {
            SqlConnection conn = SqlBaglanti.Instance.GetConnection();

            try
            {
                SqlBaglanti.Instance.OpenConnection(); 

                string sorgu = @"
            INSERT INTO tbl_StokHareketleri (UrunID, Miktar, HareketTuru, HareketTarihi,Aciklama, CalisanID)
            VALUES (@urunID, @miktar, 'Satış', GETDATE(), 'Satış İşlemleri', @calisanID)";

                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@urunID", urunID);
                cmd.Parameters.AddWithValue("@miktar", miktar);
                 cmd.Parameters.AddWithValue("@calisanID", calisanID);
                

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stok düşülürken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection(); 
            }
        }

        public List<TaksitBilgisi> MusteriTaksitleriniGetir(int musteriID)
        {
            List<TaksitBilgisi> taksitListesi = new List<TaksitBilgisi>();

            try
            {
                SqlConnection conn = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"
            SELECT t.TaksitID, t.TaksitNo, t.Tutar, t.VadeTarihi, t.Durum
            FROM tbl_Taksitler t
            INNER JOIN tbl_Odemeler o ON t.OdemeID = o.OdemeID
            WHERE o.MusteriID = @musteriID
            ORDER BY t.VadeTarihi";

                using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@musteriID", musteriID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            taksitListesi.Add(new TaksitBilgisi
                            {
                                TaksitID = reader.GetInt32(0),
                                TaksitNo = reader.GetInt32(1),
                                Tutar = reader.GetDecimal(2),
                                VadeTarihi = reader.GetDateTime(3),
                                Durum = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Taksit bilgileri alınırken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return taksitListesi;
        }
        public bool TaksitOde(int taksitID)
        {
            try
            {
                SqlConnection conn = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"UPDATE tbl_Taksitler
                         SET Durum = 'Ödendi', OdemeTarihi = GETDATE()
                         WHERE TaksitID = @taksitID";

                using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@taksitID", taksitID);
                    int etkilenen = cmd.ExecuteNonQuery();
                    return etkilenen > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Taksit ödeme işlemi sırasında hata oluştu:\n" + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public List<OdemeGecmisi> MusteriOdemeGecmisiGetir(int musteriID)
        {
            List<OdemeGecmisi> liste = new List<OdemeGecmisi>();

            try
            {
                SqlConnection conn = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();
                // peşin hizmet ödemesi
                string hizmetSorgu = @"
            SELECT o.ToplamTutar, o.OdemeTarihi,
                   STRING_AGG(h.HizmetAdi, ', ') AS Hizmetler
            FROM tbl_Odemeler o
            INNER JOIN tbl_HizmetSatisDetay hd ON o.OdemeID = hd.OdemeID
            INNER JOIN tbl_Hizmetler h ON hd.HizmetID = h.HizmetID
            WHERE o.MusteriID = @musteriID AND o.OdemeTuru = 'Peşin' AND o.OdemeKaynagi IN ('Hizmet', 'Karma')
            GROUP BY o.ToplamTutar, o.OdemeTarihi";

                using (SqlCommand cmd = new SqlCommand(hizmetSorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@musteriID", musteriID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new OdemeGecmisi
                            {
                                OdemeTipi = "Peşin",
                                Tutar = reader.GetDecimal(0),
                                OdemeTarihi = reader.GetDateTime(1),
                                Aciklama = "Hizmet: " + reader.GetString(2)
                            });
                        }
                    }
                }

               // peşin ürün ödemesi 
                string urunSorgu = @"
            SELECT o.ToplamTutar, o.OdemeTarihi,
                   STRING_AGG(u.UrunAdi + ' (' + CAST(sd.Miktar AS VARCHAR) + ')', ', ') AS Urunler
            FROM tbl_Odemeler o
            INNER JOIN tbl_Satislar s ON o.OdemeID = s.OdemeID
            INNER JOIN tbl_SatisDetay sd ON s.SatisID = sd.SatisID
            INNER JOIN tbl_Urunler u ON sd.UrunID = u.UrunID
            WHERE o.MusteriID = @musteriID AND o.OdemeTuru = 'Peşin' AND o.OdemeKaynagi IN ('Satış', 'Karma')
            GROUP BY o.ToplamTutar, o.OdemeTarihi";

                using (SqlCommand cmd = new SqlCommand(urunSorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@musteriID", musteriID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new OdemeGecmisi
                            {
                                OdemeTipi = "Peşin",
                                Tutar = reader.GetDecimal(0),
                                OdemeTarihi = reader.GetDateTime(1),
                                Aciklama = "Ürün: " + reader.GetString(2)
                            });
                        }
                    }
                }

                // Taksitli Ödenmiş Ürün ve Hizmetler
                                    string taksitSorgu = @"
                       SELECT t.Tutar, t.OdemeTarihi,
                           STRING_AGG(
                               ISNULL('Ürün: ' + u.UrunAdi + ' (' + CAST(sd.Miktar AS VARCHAR) + ')', '') +
                               CASE WHEN h.HizmetAdi IS NOT NULL THEN ', Hizmet: ' + h.HizmetAdi ELSE '' END
                           , ', ') AS Aciklama
                    FROM tbl_Taksitler t
                    INNER JOIN tbl_Odemeler o ON t.OdemeID = o.OdemeID
                    LEFT JOIN tbl_Satislar s ON o.OdemeID = s.OdemeID
                    LEFT JOIN tbl_SatisDetay sd ON s.SatisID = sd.SatisID
                    LEFT JOIN tbl_Urunler u ON sd.UrunID = u.UrunID
                    LEFT JOIN tbl_HizmetSatisDetay hs ON o.OdemeID = hs.OdemeID
                    LEFT JOIN tbl_Hizmetler h ON hs.HizmetID = h.HizmetID
                    WHERE o.MusteriID = @musteriID AND t.Durum = 'Ödendi'
                    GROUP BY t.Tutar, t.OdemeTarihi";

                using (SqlCommand cmd = new SqlCommand(taksitSorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@musteriID", musteriID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new OdemeGecmisi
                            {
                                OdemeTipi = "Taksit",
                                Tutar = reader.GetDecimal(0),
                                OdemeTarihi = reader.GetDateTime(1),
                                Aciklama = "Taksit: " + reader.GetString(2)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ödeme geçmişi alınırken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return liste.OrderByDescending(x => x.OdemeTarihi).ToList();
        }


        public void HizmetSatisDetayEkle(int odemeID, int hizmetID, decimal tutar)
        {
            try
            {
                SqlConnection conn = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"
            INSERT INTO tbl_HizmetSatisDetay (OdemeID, HizmetID, Tutar)
            VALUES (@odemeID, @hizmetID, @tutar)";

                using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@odemeID", odemeID);
                    cmd.Parameters.AddWithValue("@hizmetID", hizmetID);
                    cmd.Parameters.AddWithValue("@tutar", tutar);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmet satış detayı eklenirken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public List<TaksitBilgisi> BekleyenTaksitleriGetir(int musteriID)
        {
            List<TaksitBilgisi> liste = new List<TaksitBilgisi>();

            try
            {
                SqlConnection conn = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"
            SELECT t.Tutar, t.VadeTarihi, t.Durum
            FROM tbl_Taksitler t
            INNER JOIN tbl_Odemeler o ON t.OdemeID = o.OdemeID
            WHERE o.MusteriID = @musteriID AND t.Durum = 'Bekliyor'
            ORDER BY t.VadeTarihi";

                using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@musteriID", musteriID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new TaksitBilgisi
                            {
                                Tutar = reader.GetDecimal(0),
                                VadeTarihi = reader.GetDateTime(1),
                                Durum = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Taksitler alınırken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return liste;
        }


    }
}
