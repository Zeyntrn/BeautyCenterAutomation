using GuzellikMerkeziOtomasyonu;
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
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }
        MusteriIslemleri musteriIslemleri = new MusteriIslemleri();
        HizmetTuruIslemleri hizmetTuruIslemleri = new HizmetTuruIslemleri();
        UrunIslemleri urunIslemleri = new UrunIslemleri();
        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            grpYeniMusteri.Visible = !grpYeniMusteri.Visible; // Aç/kapat yapar
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string telefon = mskTelefon.Text.Trim();
            string email = txtMail.Text.Trim();
            DateTime dogumTarihi = datetimeDogumTrh.Value;

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(telefon) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Müşteri bilgileri boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            cmbMusteriSec.DataSource = musteriIslemleri.TumMusterileriListeOlarakGetir();
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

        private void Odeme_Load(object sender, EventArgs e)
        {
            MusteriListesiniYukle();
            HizmetTurleriniYukle();
            UrunleriYukle();
            cmbHizmetAdi.DataSource = null;
            dgvSepetHizmet.AllowUserToAddRows = false;
            dgvUrunSepet.AllowUserToAddRows = false;
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

               
                cmbHizmetAdi.SelectedIndexChanged -= cmbHizmetAdi_SelectedIndexChanged;

                cmbHizmetAdi.DisplayMember = "HizmetAdi";
                cmbHizmetAdi.ValueMember = "HizmetID";
                cmbHizmetAdi.DataSource = hizmetIslemleri.HizmetleriTureGoreGetir(turID);
                cmbHizmetAdi.SelectedIndex = -1;

                
                cmbHizmetAdi.SelectedIndexChanged += cmbHizmetAdi_SelectedIndexChanged;

                txtHizmetFiyat.Text = ""; // fiyat kutusunu da sıfırla
            }
        }

        private void UrunleriYukle()
        {
            try
            {
                var urunler = urunIslemleri.TumUrunleriGetir();
                cmbUrun.DataSource = urunler;
                cmbUrun.DisplayMember = "UrunAdi";
                cmbUrun.ValueMember = "UrunID";
                cmbUrun.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata oluştu:\n" + ex.Message);
            }
        }

        private void cmbHizmetAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHizmetAdi.SelectedValue != null && int.TryParse(cmbHizmetAdi.SelectedValue.ToString(), out int hizmetID))
            {
                HizmetIslemleri hizmetIslemleri = new HizmetIslemleri();
                decimal fiyat = hizmetIslemleri.GetirHizmetFiyati(hizmetID);
                txtHizmetFiyat.Text = fiyat.ToString("N2");
            }
        }

        private void btnHizmetEkle_Click(object sender, EventArgs e)
        {
            if (cmbHizmetAdi.SelectedValue == null || string.IsNullOrEmpty(txtHizmetFiyat.Text))
            {
                MessageBox.Show("Lütfen bir hizmet seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hizmetAdi = cmbHizmetAdi.Text;
            decimal fiyat = Convert.ToDecimal(txtHizmetFiyat.Text);

            dgvSepetHizmet.Rows.Add(hizmetAdi, fiyat);
            TemizleHizmetEkleFormu();
            ToplamTutariGuncelle();
        }

        private void cmbUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUrun.SelectedItem is Urun seciliUrun)
            {
                txtUrunFiyat.Text = seciliUrun.BirimFiyat.ToString("N2");
            }
            else
            {
                txtUrunFiyat.Clear();
            }
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUrun.SelectedItem == null || nudMiktar.Value <= 0)
                {
                    MessageBox.Show("Lütfen ürün ve geçerli miktar seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int urunID = Convert.ToInt32(cmbUrun.SelectedValue);
                int miktar = (int)nudMiktar.Value;

                
                int mevcutStok = urunIslemleri.GetMevcutStokFromTopluListe(urunID);
                if (mevcutStok < miktar)
                {
                    MessageBox.Show($"Stokta sadece {mevcutStok} adet var. Sepete eklenemez.", "Stok Yetersiz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Urun secilenUrun = (Urun)cmbUrun.SelectedItem;
                decimal birimFiyat = secilenUrun.BirimFiyat;
                decimal toplamFiyat = miktar * birimFiyat;

                dgvUrunSepet.Rows.Add(secilenUrun.UrunAdi, miktar, birimFiyat, toplamFiyat);

                
                TemizleUrunEkleFormu();
                ToplamTutariGuncelle(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün sepete eklenirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {


            if (dgvUrunSepet.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek bir ürün seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow satir in dgvUrunSepet.SelectedRows)
            {
                dgvUrunSepet.Rows.Remove(satir);
            }
            ToplamTutariGuncelle();
        }

        private void btnHizmetSil_Click(object sender, EventArgs e)
        {

            if (dgvSepetHizmet.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek bir ürün seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow satir in dgvSepetHizmet.SelectedRows)
            {
                dgvSepetHizmet.Rows.Remove(satir);
            }
            ToplamTutariGuncelle();
        }

        private void TemizleUrunEkleFormu()
        {
            cmbUrun.SelectedIndex = -1;
            nudMiktar.Value = 0;
            txtUrunFiyat.Clear();
        }

        private void TemizleHizmetEkleFormu()
        {
            cmbHizmetTuru.SelectedIndex = -1;
            cmbHizmetAdi.DataSource = null;
            txtHizmetFiyat.Clear();
        }

        private void ToplamTutariGuncelle()
        {
            decimal toplam = 0;

            try
            {
                
                foreach (DataGridViewRow row in dgvUrunSepet.Rows)
                {
                    if (!row.IsNewRow && row.Cells.Count > 3 &&
                        row.Cells[3].Value != null &&
                        decimal.TryParse(row.Cells[3].Value.ToString(), out decimal satirTutar))
                    {
                        toplam += satirTutar;
                    }
                }

                
                foreach (DataGridViewRow row in dgvSepetHizmet.Rows)
                {
                    if (!row.IsNewRow && row.Cells.Count > 1 &&
                        row.Cells[1].Value != null &&
                        decimal.TryParse(row.Cells[1].Value.ToString(), out decimal hizmetTutar))
                    {
                        toplam += hizmetTutar;
                    }
                }

                
                txtToplamTutar.Text = toplam.ToString("C2"); 
                ToplamTutaraGoreTaksitYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Toplam hesaplanırken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            if (cmbMusteriSec.SelectedValue == null)
            {
                MessageBox.Show("Lütfen ödeme için bir müşteri seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int musteriID = Convert.ToInt32(cmbMusteriSec.SelectedValue);
            int? calisanID = KullaniciOturumu.CalisanID; 
            int? randevuID = null; 

            
            decimal toplamTutar = 0;
            foreach (DataGridViewRow row in dgvUrunSepet.Rows)
                toplamTutar += Convert.ToDecimal(row.Cells[3].Value); 
            foreach (DataGridViewRow row in dgvSepetHizmet.Rows)
                toplamTutar += Convert.ToDecimal(row.Cells[1].Value);

            
            string odemeTuru = rbPesin.Checked ? "Peşin" : (rbTaksit.Checked ? "Taksit" : "");
            if (string.IsNullOrEmpty(odemeTuru))
            {
                MessageBox.Show("Lütfen bir ödeme türü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string odemeKaynagi = "";
            bool urunVar = dgvUrunSepet.Rows.Count > 0;
            bool hizmetVar = dgvSepetHizmet.Rows.Count > 0;
            if (urunVar && hizmetVar) odemeKaynagi = "Karma";
            else if (urunVar) odemeKaynagi = "Satış";
            else if (hizmetVar) odemeKaynagi = "Hizmet";

            
            OdemeIslemleri odemeIslemleri = new OdemeIslemleri();
            int odemeID = odemeIslemleri.OdemeEkle(musteriID, calisanID, randevuID, toplamTutar, odemeTuru, odemeKaynagi);

            
            if (odemeTuru == "Taksit")
            {
                int vadeSayisi = Convert.ToInt32(cmbTaksitSayisi.SelectedItem);
                odemeIslemleri.TaksitleriEkle(odemeID, toplamTutar, vadeSayisi);
            }

            
            if (urunVar)
            {
                int satisID = odemeIslemleri.SatisEkle(musteriID, calisanID, odemeID);

                foreach (DataGridViewRow row in dgvUrunSepet.Rows)
                {
                    string urunAdi = row.Cells[0].Value.ToString(); 
                    int miktar = Convert.ToInt32(row.Cells[1].Value); 
                    decimal tutar = Convert.ToDecimal(row.Cells[3].Value); 
                    int urunID = urunIslemleri.GetUrunIDByName(urunAdi);

                    odemeIslemleri.SatisDetayEkle(satisID, urunID, miktar, tutar);

                    
                    string aciklama = (odemeKaynagi == "Karma") ? "Karma Satış (ürün)" : "Ürün satışı (ödeme sonrası)";
                    odemeIslemleri.StokDus(urunID, miktar, calisanID ?? 0, aciklama);
                }
            }

          
            if (hizmetVar)
            {
                foreach (DataGridViewRow row in dgvSepetHizmet.Rows)
                {
                    string hizmetAdi = row.Cells[0].Value.ToString();  
                    decimal fiyat = Convert.ToDecimal(row.Cells[1].Value); 
                    HizmetIslemleri hizmetIslemleri = new HizmetIslemleri();
                    int hizmetID = hizmetIslemleri.GetHizmetIDByName(hizmetAdi); 

                    odemeIslemleri.HizmetSatisDetayEkle(odemeID, hizmetID, fiyat);
                }
            }

            MessageBox.Show("Ödeme başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvUrunSepet.Rows.Clear();
            dgvSepetHizmet.Rows.Clear();
            dgvTaksitler.DataSource = null;
            txtToplamTutar.Text = string.Empty;
            cmbMusteriSec.SelectedIndex = -1;
            cmbTaksitSayisi.SelectedIndex = -1;
            rbPesin.Checked = false;
            rbTaksit.Checked = false;
        }

        private void ToplamTutaraGoreTaksitYukle()
        {
            cmbTaksitSayisi.Items.Clear();
            cmbTaksitSayisi.SelectedIndex = -1;

            if (!decimal.TryParse(txtToplamTutar.Text, System.Globalization.NumberStyles.Currency, null, out decimal toplamTutar))
                return;

            if (toplamTutar < 3000)
            {
                // Taksit yok
                cmbTaksitSayisi.Enabled = false;
                cmbTaksitSayisi.Items.Add("Peşin ödeme (taksit yok)");
                cmbTaksitSayisi.SelectedIndex = 0;
            }
            else if (toplamTutar >= 3000 && toplamTutar < 8000)
            {
                cmbTaksitSayisi.Enabled = true;
                cmbTaksitSayisi.Items.Add(3);
                cmbTaksitSayisi.Items.Add(6);
            }
            else if (toplamTutar >= 8000)
            {
                cmbTaksitSayisi.Enabled = true;
                cmbTaksitSayisi.Items.Add(3);
                cmbTaksitSayisi.Items.Add(6);
                cmbTaksitSayisi.Items.Add(9);
                cmbTaksitSayisi.Items.Add(12);
            }



            if (cmbTaksitSayisi.Items.Count > 0 && toplamTutar >= 3000)
                cmbTaksitSayisi.SelectedIndex = 0;

            cmbTaksitSayisi.SelectedIndex = -1;
        }

        private void rbPesin_CheckedChanged(object sender, EventArgs e)
        {
            cmbTaksitSayisi.Enabled = false;
            cmbTaksitSayisi.SelectedIndex = -1;
        }

        private void rbTaksit_CheckedChanged(object sender, EventArgs e)
        {
            ToplamTutaraGoreTaksitYukle();
        }

        private void cmbMusteriSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMusteriSec.SelectedIndex != -1 && cmbMusteriSec.SelectedValue is int musteriID)
            {
                OdemeIslemleri odemeIslemleri = new OdemeIslemleri();
                List<TaksitBilgisi> taksitler = odemeIslemleri.MusteriTaksitleriniGetir(musteriID);

                if (taksitler.Any())
                {
                    dgvTaksitler.DataSource = taksitler;
                    dgvTaksitler.ClearSelection();
                    dgvTaksitler.Columns["Tutar"].DisplayIndex = 0;
                    dgvTaksitler.Columns["VadeTarihi"].DisplayIndex = 1;
                    dgvTaksitler.Columns["Durum"].DisplayIndex = 2;
                    dgvTaksitler.Columns["TaksitID"].DisplayIndex = 3;
                    dgvTaksitler.Columns["TaksitNo"].DisplayIndex = 4;
                }
                else
                {
                    dgvTaksitler.DataSource = null;
                }
            }
            this.ActiveControl = null;
            dgvUrunSepet.DataSource = null;
            dgvSepetHizmet.DataSource = null;
           // dgvUrunSepet.Rows.Clear();
            // dgvSepetHizmet.Rows.Clear();
           txtToplamTutar.Text = string.Empty;
            cmbTaksitSayisi.SelectedIndex = -1;
            rbPesin.Checked = false;
            rbTaksit.Checked = false;
        }

        private void btnSeciliTaksitiOde_Click(object sender, EventArgs e)
        {
            if (dgvTaksitler.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTaksitler.SelectedRows[0];
                string durum = selectedRow.Cells["Durum"].Value?.ToString();

                if (durum == "Ödendi")
                {
                    MessageBox.Show("Bu taksit zaten ödenmiş.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int taksitID = Convert.ToInt32(selectedRow.Cells["TaksitID"].Value);
                OdemeIslemleri odemeIslemleri = new OdemeIslemleri();

                if (odemeIslemleri.TaksitOde(taksitID))
                {
                    MessageBox.Show("Taksit ödendi olarak işaretlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Güncelle
                    if (cmbMusteriSec.SelectedValue is int musteriID)
                    {
                        var guncelListe = odemeIslemleri.MusteriTaksitleriniGetir(musteriID);
                        dgvTaksitler.DataSource = new BindingList<TaksitBilgisi>(guncelListe);
                    }
                }
                else
                {
                    MessageBox.Show("Taksit güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen ödenecek bir taksit seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvTaksitler_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            var row = dgvTaksitler.Rows[e.RowIndex];
            string durum = row.Cells["Durum"].Value?.ToString();

            if (durum == "Ödendi")
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
            }
            else if (durum == "Bekliyor")
            {
                row.DefaultCellStyle.BackColor = Color.MistyRose;
                row.DefaultCellStyle.SelectionBackColor = Color.MistyRose;
            }
        }
    }
}
