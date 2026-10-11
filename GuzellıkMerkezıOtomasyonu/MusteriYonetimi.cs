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
    public partial class MusteriYonetimi : Form
    {
        public MusteriYonetimi()
        {
            InitializeComponent();
        }
        MusteriIslemleri musteriIslemleri = new MusteriIslemleri();
        int seciliMusteriID = -1;
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MusteriYonetimi_Load(object sender, EventArgs e)
        {

            MusteriListele();

        }

        private void MusteriListele()
        {
            dgvMusteriler.DataSource = null;
            dgvMusteriler.DataSource = musteriIslemleri.TumMusterileriGetir();
            dgvMusteriler.ClearSelection();


            dgvMusteriler.Columns["MusteriID"].Visible = false;

            dgvMusteriler.Columns["Ad"].HeaderText = "Ad";
            dgvMusteriler.Columns["Soyad"].HeaderText = "Soyad";
            dgvMusteriler.Columns["Telefon"].HeaderText = "Telefon";
            dgvMusteriler.Columns["Email"].HeaderText = "Email";
            dgvMusteriler.Columns["DogumTarihi"].HeaderText = "Doğum Tarihi";

            dgvMusteriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMusteriler.DefaultCellStyle.ForeColor = Color.Black;
            dgvMusteriler.DefaultCellStyle.BackColor = Color.White;
            dgvMusteriler.AllowUserToAddRows = false;

        }

        private void dgvMusteriler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count > 0)
            {
                var row = dgvMusteriler.SelectedRows[0];
                seciliMusteriID = Convert.ToInt32(row.Cells["MusteriID"].Value);

                txtAd.Text = row.Cells["Ad"].Value.ToString();
                txtSoyad.Text = row.Cells["Soyad"].Value.ToString();
                mskTelefon.Text = row.Cells["Telefon"].Value.ToString();
                txtMail.Text = row.Cells["Email"].Value.ToString();

               
                if (row.Cells["DogumTarihi"].Value != DBNull.Value)
                {
                    datetimeDogumTrh.Value = Convert.ToDateTime(row.Cells["DogumTarihi"].Value);
                }
                else
                {
                    datetimeDogumTrh.Value = DateTime.Now; 
                }
            }

            if (dgvMusteriler.SelectedRows.Count > 0)
            {
                DataGridViewRow seciliSatir = dgvMusteriler.SelectedRows[0];

               
                int musteriID;

                
                if (seciliSatir.Cells["MusteriID"]?.Value != null)
                {
                    musteriID = Convert.ToInt32(seciliSatir.Cells["MusteriID"].Value);
                }
                else
                {
                    
                    if (seciliSatir.DataBoundItem is Musteri musteri)
                    {
                        musteriID = musteri.MusteriID;
                    }
                    else
                    {
                        return; 
                    }
                }

               
                MusteriRandevulariniYukle(musteriID);
                MusteriOdemeGecmisiYukle(musteriID);
                MusteriTaksitleriniYukle(musteriID);

            }
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
                MusteriListele();
                FormuTemizle();
            }
            else
            {
                MessageBox.Show("Ekleme başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormuTemizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            mskTelefon.Clear();
            txtMail.Clear();
            datetimeDogumTrh.Value = DateTime.Now;
            seciliMusteriID = -1;
            dgvMusteriler.ClearSelection();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliMusteriID <= 0)
            {
                MessageBox.Show("Lütfen silinecek müşteriyi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult cevap = MessageBox.Show("Seçili müşteriyi silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                bool sonuc = musteriIslemleri.MusteriSil(seciliMusteriID);
                if (sonuc)
                {
                    MessageBox.Show("Müşteri başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MusteriListele();
                    FormuTemizle();
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliMusteriID <= 0)
            {
                MessageBox.Show("Lütfen güncellenecek müşteriyi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string telefon = mskTelefon.Text.Trim();
            string email = txtMail.Text.Trim();
            DateTime dogumTarihi = datetimeDogumTrh.Value;

            DataGridViewRow row = dgvMusteriler.SelectedRows[0];

            string mevcutAd = row.Cells["Ad"].Value.ToString();
            string mevcutSoyad = row.Cells["Soyad"].Value.ToString();
            string mevcutTelefon = row.Cells["Telefon"].Value.ToString();
            string mevcutEmail = row.Cells["Email"].Value.ToString();
            DateTime mevcutDogumTarihi = Convert.ToDateTime(row.Cells["DogumTarihi"].Value);

            bool bilgiDegisti =
                ad != mevcutAd ||
                soyad != mevcutSoyad ||
                telefon != mevcutTelefon ||
                email != mevcutEmail ||
                dogumTarihi != mevcutDogumTarihi;

            if (!bilgiDegisti)
            {
                MessageBox.Show("Herhangi bir değişiklik yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Musteri guncellenecek = new Musteri
            {
                MusteriID = seciliMusteriID,
                Ad = ad,
                Soyad = soyad,
                Telefon = telefon,
                Email = email,
                DogumTarihi = dogumTarihi
            };

            if (musteriIslemleri.MusteriGuncelle(guncellenecek))
            {
                MessageBox.Show("Müşteri bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MusteriListele();
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
            MusteriListele();
            txtAra.Clear();

            
            dgvRandevular.DataSource = null;
            dgvOdemeler.DataSource = null;
            dgvTaksitler.DataSource = null;

            dgvRandevular.Rows.Clear();
            dgvOdemeler.Rows.Clear();
            dgvTaksitler.Rows.Clear();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {

            string aranan = txtAra.Text.Trim();

            if (string.IsNullOrWhiteSpace(aranan))
            {
                MessageBox.Show("Lütfen aramak için bir ad-soyad giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvMusteriler.DataSource = musteriIslemleri.AdaGoreMusteriAra(aranan);
        }

        private void MusteriRandevulariniYukle(int musteriID)
        {
            RandevuIslemleri randevuIslemleri = new RandevuIslemleri();
            var randevular = randevuIslemleri.MusteriRandevulariniGetir(musteriID);

            dgvRandevular.DataSource = randevular;
            dgvRandevular.ClearSelection();
        }

        private void dgvRandevular_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvRandevular.Rows[e.RowIndex];
            string durum = row.Cells["Durum"].Value?.ToString();

            row.DefaultCellStyle.ForeColor = Color.Black;
            row.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold); 
            if (durum == "Bekliyor")
            {
                dgvRandevular.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void MusteriOdemeGecmisiYukle(int musteriID)
        {
            OdemeIslemleri odemeIslemleri = new OdemeIslemleri();
            var odemeler = odemeIslemleri.MusteriOdemeGecmisiGetir(musteriID);

            dgvOdemeler.DataSource = odemeler;
            dgvOdemeler.ClearSelection();
        }

        private void dgvOdemeler_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvOdemeler.Rows[e.RowIndex];
            string tip = row.Cells["OdemeTipi"].Value?.ToString();
            row.DefaultCellStyle.ForeColor = Color.Black;
            row.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold); 


            if (tip == "Peşin")
                row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            else if (tip == "Taksit")
                row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
        }

        private void MusteriTaksitleriniYukle(int musteriID)
        {
            OdemeIslemleri odemeIslemleri = new OdemeIslemleri();
            var taksitListesi = odemeIslemleri.BekleyenTaksitleriGetir(musteriID);
            dgvTaksitler.DataSource = taksitListesi;

           
            if (dgvTaksitler.Columns.Contains("TaksitID"))
                dgvTaksitler.Columns["TaksitID"].Visible = false;
            if (dgvTaksitler.Columns.Contains("TaksitNo"))
                dgvTaksitler.Columns["TaksitNo"].Visible = false;


            dgvTaksitler.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTaksitler.DefaultCellStyle.ForeColor = Color.Black;
        }
    }
}
