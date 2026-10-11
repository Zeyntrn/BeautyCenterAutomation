using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuzellıkMerkezıOtomasyonu
{
    public partial class KullaniciKayit : Form
    {
        public KullaniciKayit()
        {
            InitializeComponent();
        }
        HizmetTuruIslemleri hizmetTuruIslemleri = new HizmetTuruIslemleri();
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string telefon = maskedTelefon.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string email = txtMail.Text.Trim();
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            string kullaniciTuru = cmbKullaniciTur.SelectedItem?.ToString();

            
            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(telefon) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre) ||
                string.IsNullOrEmpty(kullaniciTuru))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            CalisanIslemleri kontrol = new CalisanIslemleri();
            if (kontrol.KullaniciAdiVeyaEmailVarMi(kullaniciAdi, email))
            {
                MessageBox.Show("Bu kullanıcı adı veya email zaten sistemde kayıtlı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            List<int> uzmanliklar = new List<int>();
            foreach (var item in checkedListUzmanlik.CheckedItems)
            {
                HizmetTuru tur = item as HizmetTuru;
                if (tur != null)
                    uzmanliklar.Add(tur.TurID);
            }

            if (kullaniciTuru == "Personel" && uzmanliklar.Count == 0)
            {
                MessageBox.Show("Personel için en az bir uzmanlık alanı seçmelisiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            Calisan yeniCalisan = new Calisan(ad, soyad, telefon, email, kullaniciAdi, sifre, kullaniciTuru, uzmanliklar);

            try
            {
                CalisanIslemleri islemler = new CalisanIslemleri();
                int calisanID = islemler.CalisanEkle(yeniCalisan);

                if (calisanID > 0)
                {
                    bool uzmanlikEklendi = islemler.UzmanlikAlanlariEkle(calisanID, uzmanliklar);

                    MessageBox.Show("Kayıt başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormuTemizle();
                }
                else
                {
                    MessageBox.Show("Kayıt işlemi sırasında hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormuTemizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            maskedTelefon.Clear();
            txtMail.Clear();
            txtKullaniciAdi.Clear();
            txtSifre.Clear();
            cmbKullaniciTur.SelectedIndex = -1;

            for (int i = 0; i < checkedListUzmanlik.Items.Count; i++)
            {
                checkedListUzmanlik.SetItemChecked(i, false);
            }
        }

        private void KullaniciKayit_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
            var hizmetTurleri = hizmetTuruIslemleri.TumHizmetTurleriniGetir(); 
            checkedListUzmanlik.Items.Clear(); 

            foreach (var tur in hizmetTurleri)
            {
                checkedListUzmanlik.Items.Add(tur, false); 
            }
        }
    }
}
