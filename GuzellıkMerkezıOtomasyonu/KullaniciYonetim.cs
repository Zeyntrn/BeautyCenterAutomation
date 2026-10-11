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
    public partial class KullaniciYonetim : Form
    {
        public KullaniciYonetim()
        {
            InitializeComponent();
        }
        CalisanIslemleri islemler = new CalisanIslemleri();
        HizmetTuruIslemleri hizmetTuruIslemleri = new HizmetTuruIslemleri();

        int seciliCalisanID = -1;
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {

            // dgvKullanicilar.DataSource = islemler.TumKullanicilariGetir();
            KullaniciListele();
            FormuTemizle();
        }

        private void KullaniciListele()
        {
            CalisanIslemleri islemler = new CalisanIslemleri();
            dgvKullanicilar.DataSource = null;
            dgvKullanicilar.DataSource = islemler.TumKullanicilariGetir();

            dgvKullanicilar.Columns["Sifre"].Visible = true;

            dgvKullanicilar.Columns["CalisanID"].Visible = false;

            dgvKullanicilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgvKullanicilar.DefaultCellStyle.ForeColor = Color.Black;
            dgvKullanicilar.DefaultCellStyle.BackColor = Color.White;
            dgvKullanicilar.AllowUserToAddRows = false;

            dgvKullanicilar.ClearSelection();
        }

        private void KullaniciYonetim_Load(object sender, EventArgs e)
        {
            KullaniciListele();

            var hizmetTurleri = hizmetTuruIslemleri.TumHizmetTurleriniGetir();
            txtSifre.PasswordChar = '*';

            checkedListUzmanlik.DataSource = null;
            checkedListUzmanlik.DataSource = hizmetTurleri;
            checkedListUzmanlik.DisplayMember = "TurAdi";  // ekranda görünen
            checkedListUzmanlik.ValueMember = "TurID";     // arka planda ID
            checkedListUzmanlik.ClearSelected();
        }

        private void btnArama_Click(object sender, EventArgs e)
        {
            string aranan = txtArama.Text.Trim();

            if (string.IsNullOrWhiteSpace(aranan))
            {
                MessageBox.Show("Lütfen aramak için bir isim giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CalisanIslemleri islem = new CalisanIslemleri();
            var sonuc = islem.AdaGoreCalisanAra(aranan);
            dgvKullanicilar.DataSource = sonuc;

        }

        private void FormuTemizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            msktxbTelefon.Clear();
            txtMail.Clear();
            txtKullaniciAd.Clear();
            txtSifre.Clear();
            cmbKullaniciTür.SelectedIndex = -1;
            foreach (int i in checkedListUzmanlik.CheckedIndices)
                checkedListUzmanlik.SetItemChecked(i, false);
            checkedListUzmanlik.ClearSelected();


            dgvKullanicilar.ClearSelection();
            seciliCalisanID = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string telefon = msktxbTelefon.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string email = txtMail.Text.Trim();
            string kullaniciAdi = txtKullaniciAd.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            string kullaniciTuru = cmbKullaniciTür.SelectedItem?.ToString();


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
                    KullaniciListele();
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

        private void dgvKullanicilar_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvKullanicilar.SelectedRows.Count > 0)
            {
                var row = dgvKullanicilar.SelectedRows[0];
                seciliCalisanID = Convert.ToInt32(row.Cells["CalisanID"].Value);

                txtAd.Text = row.Cells["Ad"].Value.ToString();
                txtSoyad.Text = row.Cells["Soyad"].Value.ToString();
                msktxbTelefon.Text = row.Cells["Telefon"].Value.ToString();
                txtMail.Text = row.Cells["Email"].Value.ToString();
                txtKullaniciAd.Text = row.Cells["KullaniciAdi"].Value.ToString();
                txtSifre.Text = row.Cells["Sifre"].Value.ToString();
                cmbKullaniciTür.SelectedItem = row.Cells["KullaniciTuru"].Value.ToString();


                for (int i = 0; i < checkedListUzmanlik.Items.Count; i++)
                {
                    checkedListUzmanlik.SetItemChecked(i, false);
                }


                List<int> seciliTurler = islemler.CalisaninUzmanlikAlanlari(seciliCalisanID);


                for (int i = 0; i < checkedListUzmanlik.Items.Count; i++)
                {
                    if (checkedListUzmanlik.Items[i] is HizmetTuru tur)
                    {
                        checkedListUzmanlik.SetItemChecked(i, seciliTurler.Contains(tur.TurID));
                    }
                }

            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliCalisanID <= 0)
            {
                MessageBox.Show("Lütfen silinecek kullanıcıyı seçiniz.");
                return;
            }

            DialogResult dr = MessageBox.Show("Silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (islemler.CalisanSil(seciliCalisanID))
                {
                    MessageBox.Show("Kullanıcı silindi.");
                    KullaniciListele();
                    FormuTemizle();
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            if (seciliCalisanID <= 0)
            {
                MessageBox.Show("Lütfen bir çalışan seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string telefon = msktxbTelefon.Text;
            string email = txtMail.Text.Trim();
            string kullaniciAdi = txtKullaniciAd.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            string kullaniciTuru = cmbKullaniciTür.SelectedItem?.ToString();

            List<int> seciliUzmanliklar = new List<int>();
            foreach (var item in checkedListUzmanlik.CheckedItems)
            {
                if (item is HizmetTuru tur)
                    seciliUzmanliklar.Add(tur.TurID);
            }


            DataGridViewRow row = dgvKullanicilar.SelectedRows[0];

            string mevcutAd = row.Cells["Ad"].Value.ToString();
            string mevcutSoyad = row.Cells["Soyad"].Value.ToString();
            string mevcutTel = row.Cells["Telefon"].Value.ToString();
            string mevcutEmail = row.Cells["Email"].Value.ToString();
            string mevcutKadi = row.Cells["KullaniciAdi"].Value.ToString();
            string mevcutSifre = row.Cells["Sifre"].Value.ToString();
            string mevcutTur = row.Cells["KullaniciTuru"].Value.ToString();


            bool bilgiDegisti =
                ad != mevcutAd ||
                soyad != mevcutSoyad ||
                telefon != mevcutTel ||
                email != mevcutEmail ||
                kullaniciAdi != mevcutKadi ||
                sifre != mevcutSifre ||
                kullaniciTuru != mevcutTur;


            List<int> mevcutUzmanliklar = new CalisanIslemleri().CalisaninUzmanlikAlanlari(seciliCalisanID);
            bool uzmanlikDegisti = !mevcutUzmanliklar.OrderBy(x => x).SequenceEqual(seciliUzmanliklar.OrderBy(x => x));

            if (!bilgiDegisti && !uzmanlikDegisti)
            {
                MessageBox.Show("Herhangi bir değişiklik yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!bilgiDegisti && uzmanlikDegisti)
            {
                MessageBox.Show("Uzmanlık alanlarını değiştirmek için çalışanı silip yeniden eklemelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Calisan guncellenecek = new Calisan(ad, soyad, telefon, email, kullaniciAdi, sifre, kullaniciTuru, null);
            guncellenecek.CalisanID = seciliCalisanID;

            CalisanIslemleri islemler = new CalisanIslemleri();

            if (islemler.CalisanGuncelle(guncellenecek))
            {
                MessageBox.Show("Bilgiler güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KullaniciListele();
                FormuTemizle();
            }
            else
            {
                MessageBox.Show("Güncelleme başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormuTemizle();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {

            CalisanIslemleri calisanIslem = new CalisanIslemleri();

            string aranan = txtArama.Text.Trim();

            if (string.IsNullOrEmpty(aranan))
            {
                // TextBox boşsa tüm kullanıcıları getir
                dgvKullanicilar.DataSource = calisanIslem.TumKullanicilariGetir();
            }
            else
            {
                // Arama yap
                dgvKullanicilar.DataSource = calisanIslem.AdaGoreCalisanAra(aranan);
            }
        }
    }
}
