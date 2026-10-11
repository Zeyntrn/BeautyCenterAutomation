using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class MusteriIslemleri
    {
        public DataTable TumMusterileriGetir()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_Musteriler", baglanti);
                da.Fill(dt);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
            return dt;
        }

        public bool MusteriEkle(Musteri musteri)
        {
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"INSERT INTO tbl_Musteriler (Ad, Soyad, Telefon, Email, DogumTarihi) 
                         VALUES (@Ad, @Soyad, @Telefon, @Email, @DogumTarihi)";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Ad", musteri.Ad);
                komut.Parameters.AddWithValue("@Soyad", musteri.Soyad);
                komut.Parameters.AddWithValue("@Telefon", musteri.Telefon);
                komut.Parameters.AddWithValue("@Email", musteri.Email);
                komut.Parameters.AddWithValue("@DogumTarihi", musteri.DogumTarihi);

                int sonuc = komut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri eklenirken hata oluştu: " + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public bool MusteriSil(int musteriID)
        {
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = "DELETE FROM tbl_Musteriler WHERE MusteriID = @id";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@id", musteriID);

                int sonuc = komut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri silinirken hata oluştu: " + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public bool MusteriGuncelle(Musteri musteri)
        {
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"UPDATE tbl_Musteriler 
                         SET Ad = @Ad, Soyad = @Soyad, Telefon = @Telefon, 
                             Email = @Email, DogumTarihi = @DogumTarihi 
                         WHERE MusteriID = @MusteriID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Ad", musteri.Ad);
                komut.Parameters.AddWithValue("@Soyad", musteri.Soyad);
                komut.Parameters.AddWithValue("@Telefon", musteri.Telefon);
                komut.Parameters.AddWithValue("@Email", musteri.Email);
                komut.Parameters.AddWithValue("@DogumTarihi", musteri.DogumTarihi);
                komut.Parameters.AddWithValue("@MusteriID", musteri.MusteriID);

                int sonuc = komut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri güncellenirken hata oluştu: " + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }
        public DataTable AdaGoreMusteriAra(string adSoyad)
        {
            DataTable dt = new DataTable();
            SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();

            try
            {
                SqlBaglanti.Instance.OpenConnection();
                string sorgu = @"SELECT * FROM tbl_Musteriler 
                         WHERE Ad + ' ' + Soyad LIKE @arama";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@arama", "%" + adSoyad + "%");

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

        public DataTable TumMusterileriAdSoyadIleGetir()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = "SELECT MusteriID, Ad + ' ' + Soyad AS AdSoyad FROM tbl_Musteriler ORDER BY Ad";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.Fill(dt);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return dt;
        }

        public List<Musteri> TumMusterileriListeOlarakGetir()
        {
            List<Musteri> liste = new List<Musteri>();

            SqlConnection conn = SqlBaglanti.Instance.GetConnection();
            SqlCommand cmd = new SqlCommand("SELECT MusteriID, Ad, Soyad FROM tbl_Musteriler", conn);

            SqlBaglanti.Instance.OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                liste.Add(new Musteri
                {
                    MusteriID = reader.GetInt32(0),
                    Ad = reader.GetString(1),
                    Soyad = reader.GetString(2)
                });
            }
            SqlBaglanti.Instance.CloseConnection();

            return liste;
        }

        public string MusteriTelefonGetir(int musteriID)
        {
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = "SELECT Telefon FROM tbl_Musteriler WHERE MusteriID = @id";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@id", musteriID);

                object sonuc = cmd.ExecuteScalar();
                return sonuc != null ? sonuc.ToString() : "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Telefon getirilirken hata oluştu: " + ex.Message);
                return "";
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

    }
}
