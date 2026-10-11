using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class CalisanIslemleri
    {
        public int CalisanEkle(Calisan calisan)
        {
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = "INSERT INTO tbl_Calisanlar (Ad, Soyad, Telefon, Email, KullaniciAdi, Sifre, KullaniciTuru) " +
                               "OUTPUT INSERTED.CalisanID " +
                               "VALUES (@Ad, @Soyad, @Telefon, @Email, @KullaniciAdi, @Sifre, @KullaniciTuru)";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Ad", calisan.Ad);
                komut.Parameters.AddWithValue("@Soyad", calisan.Soyad);
                komut.Parameters.AddWithValue("@Telefon", calisan.Telefon);
                komut.Parameters.AddWithValue("@Email", calisan.Email);
                komut.Parameters.AddWithValue("@KullaniciAdi", calisan.KullaniciAdi);
                komut.Parameters.AddWithValue("@Sifre", calisan.Sifre);
                komut.Parameters.AddWithValue("@KullaniciTuru", calisan.KullaniciTuru);

                int calisanID = (int)komut.ExecuteScalar();

                return calisanID;
            }
            catch (Exception ex)
            {
                throw new Exception("Çalışan eklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public bool UzmanlikAlanlariEkle(int calisanID, List<int> uzmanliklar)
        {
            if (uzmanliklar == null || uzmanliklar.Count == 0)
                return true;

            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                foreach (int turID in uzmanliklar)
                {
                    string sorgu = "INSERT INTO tbl_CalisanUzmanlikAlanlari (CalisanID, TurID) VALUES (@CalisanID, @TurID)";
                    SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                    cmd.Parameters.AddWithValue("@CalisanID", calisanID);
                    cmd.Parameters.AddWithValue("@TurID", turID);
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Uzmanlık alanı eklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public bool KullaniciAdiVeyaEmailVarMi(string kullaniciAdi, string email)
        {
            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
            try
            {
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = "SELECT COUNT(*) FROM tbl_Calisanlar WHERE KullaniciAdi = @kAdi OR Email = @Email";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@kAdi", kullaniciAdi);
                komut.Parameters.AddWithValue("@Email", email);

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

        public bool GirisYap(string kullaniciAdi, string sifre)
        {
            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();

            try
            {
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = "SELECT CalisanID, KullaniciAdi, KullaniciTuru FROM tbl_Calisanlar " +
                               "WHERE KullaniciAdi = @kAdi AND Sifre = @Sifre";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@kAdi", kullaniciAdi);
                komut.Parameters.AddWithValue("@Sifre", sifre);

                SqlDataReader reader = komut.ExecuteReader();

                if (reader.Read())
                {
                    KullaniciOturumu.CalisanID = reader.GetInt32(0);
                    KullaniciOturumu.KullaniciAdi = reader.GetString(1);
                    KullaniciOturumu.KullaniciTuru = reader.GetString(2);

                    reader.Close();
                    return true;
                }

                reader.Close();
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }
        public bool SifreDegistir(string email, string yeniSifre)
        {
            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();

            try
            {
                SqlBaglanti.Instance.OpenConnection();


                string kontrolSorgu = "SELECT Sifre FROM tbl_Calisanlar WHERE Email = @Email";
                SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, baglanti);
                kontrolKomut.Parameters.AddWithValue("@Email", email);

                object mevcutSifreObj = kontrolKomut.ExecuteScalar();

                if (mevcutSifreObj == null)
                {

                    return false;
                }

                string mevcutSifre = mevcutSifreObj.ToString();

                if (mevcutSifre == yeniSifre)
                {

                    MessageBox.Show("Yeni şifre, mevcut şifreyle aynı olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


                string guncelleSorgu = "UPDATE tbl_Calisanlar SET Sifre = @YeniSifre WHERE Email = @Email";
                SqlCommand guncelleKomut = new SqlCommand(guncelleSorgu, baglanti);
                guncelleKomut.Parameters.AddWithValue("@YeniSifre", yeniSifre);
                guncelleKomut.Parameters.AddWithValue("@Email", email);

                int sonuc = guncelleKomut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Şifre güncellenirken hata oluştu: " + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public DataTable TumKullanicilariGetir()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_Calisanlar", baglanti);
                da.Fill(dt);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
            return dt;
        }

        public DataTable AdaGoreCalisanAra(string ad)
        {
            DataTable dt = new DataTable();
            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();

            try
            {
                SqlBaglanti.Instance.OpenConnection();
                string sorgu = @"SELECT CalisanID, Ad, Soyad, Telefon, Email, KullaniciAdi, Sifre, KullaniciTuru 
                         FROM tbl_Calisanlar 
                         WHERE Ad LIKE @ad";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", "%" + ad + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return dt;
        }

        public bool CalisanSil(int calisanID)
        {
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                // Önce uzmanlıkları sil
                SqlCommand uzmanlikSil = new SqlCommand("DELETE FROM tbl_CalisanUzmanlikAlanlari WHERE CalisanID = @id", baglanti);
                uzmanlikSil.Parameters.AddWithValue("@id", calisanID);
                uzmanlikSil.ExecuteNonQuery();

                // Sonra çalışanı sil
                SqlCommand calisanSil = new SqlCommand("DELETE FROM tbl_Calisanlar WHERE CalisanID = @id", baglanti);
                calisanSil.Parameters.AddWithValue("@id", calisanID);
                int sonuc = calisanSil.ExecuteNonQuery();

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

        public bool CalisanGuncelle(Calisan calisan)
        {
            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();

            try
            {
                SqlBaglanti.Instance.OpenConnection();

                string guncelleSorgu = @"UPDATE tbl_Calisanlar 
                                 SET Ad = @ad, Soyad = @soyad, Telefon = @telefon, 
                                     Email = @mail, KullaniciAdi = @kAdi, Sifre = @sifre, KullaniciTuru = @tur 
                                 WHERE CalisanID = @calisanID";

                SqlCommand komut = new SqlCommand(guncelleSorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", calisan.Ad);
                komut.Parameters.AddWithValue("@soyad", calisan.Soyad);
                komut.Parameters.AddWithValue("@telefon", calisan.Telefon);
                komut.Parameters.AddWithValue("@mail", calisan.Email);
                komut.Parameters.AddWithValue("@kAdi", calisan.KullaniciAdi);
                komut.Parameters.AddWithValue("@sifre", calisan.Sifre);
                komut.Parameters.AddWithValue("@tur", calisan.KullaniciTuru);
                komut.Parameters.AddWithValue("@calisanID", calisan.CalisanID);

                int sonuc = komut.ExecuteNonQuery();

                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

     
        public List<int> CalisaninUzmanlikAlanlari(int calisanID)
        {
            List<int> turIDler = new List<int>();

            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
            SqlBaglanti.Instance.OpenConnection();

            string sorgu = "SELECT TurID FROM tbl_CalisanUzmanlikAlanlari WHERE CalisanID = @id";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@id", calisanID);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                turIDler.Add(Convert.ToInt32(dr["TurID"]));
            }

            dr.Close();
            SqlBaglanti.Instance.CloseConnection();
            return turIDler;
        }

        public DataTable CalisanlariHizmetTuruneGoreGetir(int turID)
        {
            DataTable dt = new DataTable();
            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(@"
        SELECT c.CalisanID, c.Ad + ' ' + c.Soyad AS AdSoyad
        FROM tbl_Calisanlar c
        INNER JOIN tbl_CalisanUzmanlikAlanlari cu ON c.CalisanID = cu.CalisanID
        WHERE cu.TurID = @turID", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@turID", turID);
            da.Fill(dt);
            return dt;
        }
    }


}
