using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuzellıkMerkezıOtomasyonu
{
    public partial class Randevular : Form
    {
        public Randevular()
        {
            InitializeComponent();
        }
        MusteriIslemleri musteriIslemleri = new MusteriIslemleri();
        HizmetTuruIslemleri hizmetTuruIslemleri = new HizmetTuruIslemleri();
        HizmetIslemleri hizmetIslemleri = new HizmetIslemleri();
        CalisanIslemleri calisanIslemleri = new CalisanIslemleri();
        RandevuIslemleri randevuIslemleri = new RandevuIslemleri();
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Randevular_Load(object sender, EventArgs e)
        {
            grpYeniMusteri.Visible = false;
            MusteriListesiniYukle();
            HizmetTurleriniYukle();
            RandevuListesiniYukle();

            cmbHizmetAdi.DataSource = null;
            dateTimePickerRandevuTrh.MinDate = DateTime.Today;
            lblSeans.Text = "0";
            randevuIslemleri.GecikenRandevulariIptalEt();
            cmbSaatSec.Items.Clear(); 
            cmbSaatSec.Text = "Saat seçiniz"; 

        }

        private void btnYeniMusteriEkle_Click(object sender, EventArgs e)
        {
            grpYeniMusteri.Visible = !grpYeniMusteri.Visible;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string telefon = mskTelefon.Text.Trim();
            string email = txtMail.Text.Trim();
            DateTime dogumTarihi = datetimeDogumTrh.Value;

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(telefon))
            {
                MessageBox.Show("Ad, Soyad ve Telefon alanları boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Musteri yeniMusteri = new Musteri
            {
                Ad = ad,
                Soyad = soyad,
                Telefon = telefon,
                Email = email,
                DogumTarihi = dogumTarihi
            };

            if (musteriIslemleri.MusteriEkle(yeniMusteri))
            {
                MessageBox.Show("Müşteri başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MusteriListesiniYukle(); 
                grpYeniMusteri.Visible = false; 
                TemizleYeniMusteriFormu();


            }
            else
            {
                MessageBox.Show("Ekleme başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MusteriListesiniYukle()
        {
            cmbMusteriSec.DataSource = null;
            cmbMusteriSec.DataSource = musteriIslemleri.TumMusterileriAdSoyadIleGetir();
            cmbMusteriSec.DisplayMember = "AdSoyad";
            cmbMusteriSec.ValueMember = "MusteriID";
            cmbMusteriSec.SelectedIndex = -1; 

            cmbMusteriSec.DropDownStyle = ComboBoxStyle.DropDown;
            cmbMusteriSec.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMusteriSec.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void TemizleYeniMusteriFormu()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            mskTelefon.Clear();
            txtMail.Clear();
            datetimeDogumTrh.Value = DateTime.Now;

        }

        private void cmbMusteriSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMusteriSec.SelectedValue != null && int.TryParse(cmbMusteriSec.SelectedValue.ToString(), out int musteriID))
            {
                MusteriIslemleri musteriIslemleri = new MusteriIslemleri();
                string telefon = musteriIslemleri.MusteriTelefonGetir(musteriID);
                maskedTextBoxTelefon.Text = telefon;
            }
            this.ActiveControl = null;

            cmbHizmetTuru.SelectedIndex = -1;
            cmbHizmetAdi.SelectedIndex = -1;
            cmbPersonelSec.SelectedIndex = -1;
            cmbSaatSec.Items.Clear();
            cmbSaatSec.Text = "Saat seçiniz";
            lblSeans.Text = "0";
            dateTimePickerRandevuTrh.Value = DateTime.Today;
            dgvRandevular.ClearSelection();
        }

        private void HizmetTurleriniYukle()
        {
            cmbHizmetTuru.DisplayMember = "TurAdi";
            cmbHizmetTuru.ValueMember = "TurID";
            cmbHizmetTuru.DataSource = hizmetTuruIslemleri.TumHizmetTurleriniGetir();
            cmbHizmetTuru.SelectedIndex = -1;
        }

        private void cmbHizmetTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHizmetTuru.SelectedValue != null && int.TryParse(cmbHizmetTuru.SelectedValue.ToString(), out int turID))
            {
                HizmetIslemleri hizmetIslemleri = new HizmetIslemleri();
                cmbHizmetAdi.DisplayMember = "HizmetAdi";
                cmbHizmetAdi.ValueMember = "HizmetID";
                cmbHizmetAdi.DataSource = hizmetIslemleri.HizmetleriTureGoreGetir(turID);
                cmbHizmetAdi.SelectedIndex = -1;

                
                cmbPersonelSec.DataSource = null;

            }
        }

        private void cmbHizmetAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHizmetTuru.SelectedValue != null && int.TryParse(cmbHizmetTuru.SelectedValue.ToString(), out int turID))
            {
                CalisanIslemleri calisanIslemleri = new CalisanIslemleri();
                cmbPersonelSec.DisplayMember = "AdSoyad";
                cmbPersonelSec.ValueMember = "CalisanID";
                cmbPersonelSec.DataSource = calisanIslemleri.CalisanlariHizmetTuruneGoreGetir(turID);
                cmbPersonelSec.SelectedIndex = -1;


            }

            if (cmbPersonelSec.SelectedIndex >= 0 && cmbHizmetAdi.SelectedIndex >= 0)
            {
                SaatleriYukle();
            }

            if (cmbHizmetAdi.SelectedValue != null && int.TryParse(cmbHizmetAdi.SelectedValue.ToString(), out int hizmetID))
            {
              
                
                int seans = hizmetIslemleri.GetirToplamSeans(hizmetID);
                lblSeans.Text = seans.ToString();

                
                if (cmbPersonelSec.SelectedIndex >= 0)
                {
                    SaatleriYukle();
                }
            }
        }
        private void SaatleriYukle()
        {
            cmbSaatSec.Items.Clear(); 
            cmbSaatSec.Text = "Saat seçiniz";

            
            if (cmbPersonelSec.SelectedValue == null || cmbHizmetAdi.SelectedValue == null)
                return;

            int calisanID = Convert.ToInt32(cmbPersonelSec.SelectedValue);
            int hizmetID = Convert.ToInt32(cmbHizmetAdi.SelectedValue);
            DateTime tarih = dateTimePickerRandevuTrh.Value.Date;

            
            int hizmetSuresi = hizmetIslemleri.GetirHizmetSuresi(hizmetID);

           
            RandevuIslemleri randevuIslemleri = new RandevuIslemleri();
            List<TimeSpan> uygunSaatler = randevuIslemleri.GetirUygunSaatler(calisanID, tarih, hizmetSuresi);

            
            foreach (TimeSpan saat in uygunSaatler)
            {
                cmbSaatSec.Items.Add(saat.ToString(@"hh\:mm"));
            }
           
            if (cmbSaatSec.Items.Count == 0)
            {
                cmbSaatSec.Text = "Uygun saat yok";
            }
            else
            {
                cmbSaatSec.SelectedIndex = -1;
            }
        
        }

        private void cmbPersonelSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPersonelSec.SelectedIndex >= 0 && cmbHizmetAdi.SelectedIndex >= 0)
            {
                SaatleriYukle();
            }
        }

        private void dateTimePickerRandevuTrh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbPersonelSec.SelectedIndex >= 0 && cmbHizmetAdi.SelectedIndex >= 0)
            {
                SaatleriYukle();
            }
        }

        private void btnRandevuEkle_Click(object sender, EventArgs e)
        {

            if (cmbMusteriSec.SelectedValue == null || cmbPersonelSec.SelectedValue == null ||
                cmbHizmetAdi.SelectedValue == null || cmbSaatSec.SelectedItem == null)
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz.");
                return;
            }

            int musteriID = Convert.ToInt32(cmbMusteriSec.SelectedValue);
            int calisanID = Convert.ToInt32(cmbPersonelSec.SelectedValue);
            int hizmetID = Convert.ToInt32(cmbHizmetAdi.SelectedValue);
            DateTime tarih = dateTimePickerRandevuTrh.Value.Date;
            string saat = cmbSaatSec.SelectedItem.ToString();
            int toplamSeans = hizmetIslemleri.GetirToplamSeans(hizmetID);
            int kalanSeans = randevuIslemleri.GetirKalanSeansDogru(musteriID, hizmetID);

            if (kalanSeans == 0)
            {
                kalanSeans = toplamSeans;

            }

            Randevu yeniRandevu = new Randevu
            {
                MusteriID = musteriID,
                CalisanID = calisanID,
                HizmetID = hizmetID,
                RandevuTarihi = tarih,
                RandevuSaati = saat,
                ToplamSeans = toplamSeans,
                KalanSeans = kalanSeans,
                Durum = "Bekliyor"
            };

            RandevuIslemleri ri = new RandevuIslemleri();
            bool eklendi = ri.RandevuEkle(yeniRandevu);

            if (eklendi)
            {
                MessageBox.Show("Randevu başarıyla oluşturuldu.");
               
                FormuTemizle();
                SaatleriYukle();
                RandevuListesiniYukle();
            }
            else
            {
                MessageBox.Show("Randevu eklenemedi.");
            }
        }
        private void FormuTemizle()
        {
            cmbMusteriSec.SelectedIndex = -1;
            mskTelefon.Clear();
            cmbHizmetTuru.SelectedIndex = -1;
            cmbHizmetAdi.SelectedIndex = -1;
            cmbPersonelSec.SelectedIndex = -1;
            cmbSaatSec.Items.Clear();
            cmbSaatSec.Text = "Saat seçiniz";
            lblSeans.Text = "0";
            dateTimePickerRandevuTrh.Value = DateTime.Today;
            
            


        }


        private void btnRandevuTamam_Click(object sender, EventArgs e)
        {
            if (dgvRandevular.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen tamamlanacak bir randevu seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            MessageBox.Show("İşlem ödemesini kontrol ediniz.\nEğer ödeme alındıysa aşağıdaki onay kutusunu işaretleyin.", "Ödeme Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            if (!rbtnOdemeOnay.Checked)
            {
                MessageBox.Show("Ödeme alınmadan işlem tamamlanamaz. Lütfen önce onay verin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int randevuID = Convert.ToInt32(dgvRandevular.SelectedRows[0].Cells["RandevuID"].Value);

            RandevuIslemleri ri = new RandevuIslemleri();

            
            bool durumGuncellendi = ri.RandevuDurumGuncelle(randevuID, "Tamamlandı");
            SaatleriYukle();

            if (durumGuncellendi)
            {
               
                ri.KalanSeansiDusur(randevuID); 

               
                ri.RandevuTamamlandiStokDusur(randevuID, KullaniciOturumu.CalisanID);

                MessageBox.Show("Randevu tamamlandı ve gerekli işlemler yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RandevuListesiniYukle(); 
            }
            else
            {
                MessageBox.Show("Randevu durumu güncellenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RandevuListesiniYukle()
        {
            dgvRandevular.DataSource = null;
            dgvRandevular.DataSource = randevuIslemleri.TumRandevulariGetir();

            dgvRandevular.Columns["RandevuID"].Visible = false; 
            dgvRandevular.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRandevular.AllowUserToAddRows = false;

            dgvRandevular.Columns["MusteriID"].Visible = false;
            dgvRandevular.Columns["CalisanID"].Visible = false;
            dgvRandevular.Columns["HizmetID"].Visible = false;
            dgvRandevular.Columns["RandevuID"].Visible = false;

        }

        private void dgvRandevular_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRandevular.SelectedRows.Count == 0)
            {
                btnRandevuTamam.Enabled = false;
                btnRandevuİptal.Enabled = false;
                btnRandevuGuncelle.Enabled = false;
                return;
            }

            var seciliSatir = dgvRandevular.SelectedRows[0];
            string durum = seciliSatir.Cells["Durum"].Value.ToString();

            bool aktif = durum == "Bekliyor";
            btnRandevuTamam.Enabled = aktif;
            btnRandevuİptal.Enabled = aktif;
            btnRandevuGuncelle.Enabled = aktif;

            try
            {
                int musteriID = Convert.ToInt32(seciliSatir.Cells["MusteriID"].Value);
                int hizmetID = Convert.ToInt32(seciliSatir.Cells["HizmetID"].Value);
                int calisanID = Convert.ToInt32(seciliSatir.Cells["CalisanID"].Value);
                DateTime seciliTarih = Convert.ToDateTime(seciliSatir.Cells["RandevuTarihi"].Value);
                string saat = seciliSatir.Cells["RandevuSaati"].Value.ToString();

                cmbMusteriSec.SelectedValue = musteriID;
                maskedTextBoxTelefon.Text = musteriIslemleri.MusteriTelefonGetir(musteriID);

                
                int turID = hizmetIslemleri.GetirHizmetTurID(hizmetID);
                cmbHizmetTuru.SelectedValue = turID;

                cmbHizmetAdi.DataSource = hizmetIslemleri.HizmetleriTureGoreGetir(turID);
                cmbHizmetAdi.DisplayMember = "HizmetAdi";
                cmbHizmetAdi.ValueMember = "HizmetID";
                cmbHizmetAdi.SelectedValue = hizmetID;

                cmbPersonelSec.DataSource = calisanIslemleri.CalisanlariHizmetTuruneGoreGetir(turID);
                cmbPersonelSec.DisplayMember = "AdSoyad";
                cmbPersonelSec.ValueMember = "CalisanID";
                cmbPersonelSec.SelectedValue = calisanID;

                if (seciliTarih >= dateTimePickerRandevuTrh.MinDate && seciliTarih <= dateTimePickerRandevuTrh.MaxDate)
                {
                    dateTimePickerRandevuTrh.Value = seciliTarih;
                }
                else
                {
                    dateTimePickerRandevuTrh.Value = DateTime.Today;
                }

                if (!cmbSaatSec.Items.Contains(saat))
                    cmbSaatSec.Items.Add(saat);

                cmbSaatSec.SelectedItem = saat;

                lblSeans.Text = seciliSatir.Cells["ToplamSeans"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevu bilgileri yüklenirken hata oluştu:\n" + ex.Message);
            }

        }

        private void btnRandevuİptal_Click(object sender, EventArgs e)
        {
            if (dgvRandevular.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen iptal edilecek bir randevu seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int randevuID = Convert.ToInt32(dgvRandevular.SelectedRows[0].Cells["RandevuID"].Value);

            DialogResult result = MessageBox.Show("Bu randevuyu iptal etmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                RandevuIslemleri ri = new RandevuIslemleri();
                bool basarili = ri.RandevuIptalEt(randevuID);

                if (basarili)
                {
                    MessageBox.Show("Randevu başarıyla iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RandevuListesiniYukle(); 
                }
                else
                {
                    MessageBox.Show("Randevu iptal edilemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRandevuGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvRandevular.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir randevuyu seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int randevuID = Convert.ToInt32(dgvRandevular.SelectedRows[0].Cells["RandevuID"].Value);

            if (cmbPersonelSec.SelectedValue == null || cmbSaatSec.SelectedItem == null)
            {
                MessageBox.Show("Lütfen geçerli bir personel ve saat seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int yeniCalisanID = Convert.ToInt32(cmbPersonelSec.SelectedValue);
            string yeniSaat = cmbSaatSec.SelectedItem.ToString();
            DateTime yeniTarih = dateTimePickerRandevuTrh.Value.Date;

            RandevuIslemleri ri = new RandevuIslemleri();

            bool sonuc = ri.RandevuBilgileriniGuncelle(randevuID, yeniTarih, yeniSaat, yeniCalisanID);

            if (sonuc)
            {
                MessageBox.Show("Randevu bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RandevuListesiniYukle();
            }
        }
    }

}
