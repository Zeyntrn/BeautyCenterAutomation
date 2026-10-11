using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuzellıkMerkezıOtomasyonu
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void btnRandevuYonetım_Click(object sender, EventArgs e)
        {
            Randevular randevular = new Randevular();
            randevular.ShowDialog();
        }

        private void btnOdemeler_Click(object sender, EventArgs e)
        {
            Odeme odeme = new Odeme();
            odeme.ShowDialog();
        }

        private void btnMusterıYonetım_Click(object sender, EventArgs e)
        {
            MusteriYonetimi musteriler = new MusteriYonetimi();
            musteriler.ShowDialog();
        }

        private void btnStokYonetım_Click(object sender, EventArgs e)
        {
            StokYonetimi stoklar = new StokYonetimi();
            stoklar.ShowDialog();
        }

        private void btnKullanıcıYonetım_Click(object sender, EventArgs e)
        {
            KullaniciYonetim kullaniciYonetim = new KullaniciYonetim();
            kullaniciYonetim.ShowDialog();
        }

        private void btnHızmetYonetım_Click(object sender, EventArgs e)
        {
            HizmetYonetim hizmetYonetim = new HizmetYonetim();
            hizmetYonetim.ShowDialog();
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {
            BugunkuRandevulariListele();
            lblHosgeldin.Text = "Hoş geldiniz, " + KullaniciOturumu.KullaniciAdi;

            if (KullaniciOturumu.KullaniciTuru == "Personel")
            {
                
                btnKullanıcıYonetım.Enabled = false;
                btnRapor.Enabled = false;
            }
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            KullaniciGiris girisForm = new KullaniciGiris();
            girisForm.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            Raporlar rapor = new Raporlar();
            rapor.ShowDialog();

        }

        private void BugunkuRandevulariListele()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = SqlBaglanti.Instance.GetConnection();

            try
            {
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"
        SELECT 
            m.Ad + ' ' + m.Soyad AS MusteriAdi,
            c.Ad + ' ' + c.Soyad AS CalisanAdi,
            h.HizmetAdi,
            r.RandevuTarihi,
            r.RandevuSaati,
            r.Durum,
            CASE 
                WHEN r.HatirlatmaGonderildi = 1 THEN 'Gönderildi' 
                ELSE 'Gönderilmedi' 
            END AS HatirlatmaDurumu
        FROM tbl_Randevular r
        INNER JOIN tbl_Musteriler m ON r.MusteriID = m.MusteriID
        INNER JOIN tbl_Calisanlar c ON r.CalisanID = c.CalisanID
        INNER JOIN tbl_Hizmetler h ON r.HizmetID = h.HizmetID
        WHERE 
            CONVERT(DATE, r.RandevuTarihi) = CONVERT(DATE, GETDATE())
            AND r.Durum = 'Bekliyor'";

                SqlDataAdapter adapter = new SqlDataAdapter(sorgu, conn);
                adapter.Fill(dt);
                dgvRandevular.DataSource = dt;

                // Stil
                dgvRandevular.DefaultCellStyle.ForeColor = Color.Black;
                dgvRandevular.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                dgvRandevular.AllowUserToAddRows = false;
                dgvRandevular.ReadOnly = true;
                dgvRandevular.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bugünkü randevular listelenirken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        private void RandevuHatirlatmaKontrol()
        {
            SqlConnection conn = SqlBaglanti.Instance.GetConnection();
            SqlBaglanti.Instance.OpenConnection();

            string sorgu = @"
    SELECT 
        r.RandevuID,
        m.Email,
        m.Ad + ' ' + m.Soyad AS MusteriAdi,
        r.RandevuTarihi,
        CASE 
            WHEN r.HatirlatmaGonderildi = 1 THEN 'Gönderildi' 
            ELSE 'Gönderilmedi' 
        END AS HatirlatmaDurumu
    FROM tbl_Randevular r
    INNER JOIN tbl_Musteriler m ON r.MusteriID = m.MusteriID
    WHERE 
        CONVERT(DATE, r.RandevuTarihi) = CONVERT(DATE, DATEADD(DAY, 1, GETDATE()))
        AND r.Durum = 'Bekliyor' 
        AND r.HatirlatmaGonderildi = 0";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<int> basariliIDler = new List<int>();

            while (reader.Read())
            {
                int randevuID = Convert.ToInt32(reader["RandevuID"]);
                string email = reader["Email"].ToString();
                string adSoyad = reader["MusteriAdi"].ToString();
                string tarih = Convert.ToDateTime(reader["RandevuTarihi"]).ToString("dd.MM.yyyy");

                try
                {
                 
                    SendEmail(email, adSoyad, tarih);
                    basariliIDler.Add(randevuID);
                }
                catch
                {
                  
                }
            }
            reader.Close();

            
            foreach (int id in basariliIDler)
            {
                SqlCommand updateCmd = new SqlCommand("UPDATE tbl_Randevular SET HatirlatmaGonderildi = 1 WHERE RandevuID = @id", conn);
                updateCmd.Parameters.AddWithValue("@id", id);
                updateCmd.ExecuteNonQuery();
            }

            SqlBaglanti.Instance.CloseConnection();
        }

        private void SendEmail(string toEmail, string fullName, string randevuTarih)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("zeynepturaaan@gmail.com", "Zeynep Turan Güzellik Merkezi");
                mail.To.Add(toEmail);
                mail.Subject = "Randevu Hatırlatması";
                mail.Body = $"Sayın {fullName},\n\n" +
                    $"{randevuTarih} tarihinde güzellik merkezimizde bir randevunuz bulunmaktadır.\n" +
                    $"Lütfen randevu saatinizden önce merkezimizde hazır bulunmanız rica olunur.\n\n" +
                    "Güzelliğinize değer katmak için buradayız 🌸\n" +
                    "Zeynep Turan Güzellik Merkezi";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("zeynepturaaan@gmail.com", "jjgydzotujkyliua");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                MessageBox.Show($"Mail başarıyla {fullName}'a gönderildi.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mail gönderim hatası: {ex.Message}");
            }
        }

        private void btnMailYolla_Click(object sender, EventArgs e)
        {
            RandevuHatirlatmaKontrol();
        }

        private void btnTumRandevular_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            SqlConnection conn = SqlBaglanti.Instance.GetConnection();

            try
            {
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = @"
                      SELECT 
                    m.Ad + ' ' + m.Soyad AS MusteriAdi,
                    c.Ad + ' ' + c.Soyad AS CalisanAdi,
                    h.HizmetAdi,
                    r.RandevuTarihi,
                    r.RandevuSaati,
                    r.Durum,
                    CASE 
                        WHEN r.HatirlatmaGonderildi = 1 THEN 'Gönderildi' 
                        ELSE 'Gönderilmedi' 
                    END AS HatirlatmaDurumu
                FROM tbl_Randevular r
                INNER JOIN tbl_Musteriler m ON r.MusteriID = m.MusteriID
                INNER JOIN tbl_Calisanlar c ON r.CalisanID = c.CalisanID
                INNER JOIN tbl_Hizmetler h ON r.HizmetID = h.HizmetID
                WHERE CAST(r.RandevuTarihi AS DATETIME) > GETDATE()
                    AND r.Durum IN ('Bekliyor')
                ORDER BY r.RandevuTarihi DESC, r.RandevuSaati";


                SqlDataAdapter adapter = new SqlDataAdapter(sorgu, conn);
                adapter.Fill(dt);
                dgvRandevular.DataSource = dt;

                // Görsel ayarlar
                dgvRandevular.DefaultCellStyle.ForeColor = Color.Black;
                dgvRandevular.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                dgvRandevular.AllowUserToAddRows = false;
                dgvRandevular.ReadOnly = true;
                dgvRandevular.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tüm randevular listelenirken hata oluştu:\n" + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            BugunkuRandevulariListele();
        }
    }
}
