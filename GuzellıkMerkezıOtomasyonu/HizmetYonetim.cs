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
    public partial class HizmetYonetim : Form
    {

        int seciliHizmetID = -1;
        public HizmetYonetim()
        {
            InitializeComponent();
        }
        HizmetTuruIslemleri hizmetTuruIslemleri = new HizmetTuruIslemleri();
        HizmetIslemleri hizmetIslemleri = new HizmetIslemleri();
        UrunIslemleri urunIslemleri = new UrunIslemleri();
        HizmetUrunIslemleri hizmetUrunIslemleri = new HizmetUrunIslemleri();

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Hizmet Türleri kısmı 
        private void btnTurEkle_Click(object sender, EventArgs e)
        {
            string ad = txtHizmetTuru.Text.Trim();
            try
            {
                if (hizmetTuruIslemleri.HizmetTuruEkle(ad))
                {
                    MessageBox.Show("Hizmet türü eklendi.");
                    HizmetTurleriniYukle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnTurGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvHizmetTurleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir hizmet türü seçiniz.");
                return;
            }

            int id = Convert.ToInt32(dgvHizmetTurleri.SelectedRows[0].Cells["TurID"].Value);
            string yeniAd = txtHizmetTuru.Text.Trim();

            try
            {
                if (hizmetTuruIslemleri.HizmetTuruGuncelle(id, yeniAd))
                {
                    MessageBox.Show("Hizmet türü güncellendi.");
                    HizmetTurleriniYukle();
                    txtHizmetTuru.Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void HizmetYonetim_Load(object sender, EventArgs e)
        {
            HizmetTurleriniYukle();
            label5.Text = "";
            HizmetleriYukle();
            UrunleriYukle();
            HizmetUrunleriniListele();

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

        private void HizmetTurleriniYukle()
        {
            var turListesi = hizmetTuruIslemleri.TumHizmetTurleriniGetir();


            dgvHizmetTurleri.AutoGenerateColumns = true;
            dgvHizmetTurleri.DefaultCellStyle.ForeColor = Color.Black;
            dgvHizmetTurleri.DefaultCellStyle.BackColor = Color.White;
            dgvHizmetTurleri.DataSource = null;
            dgvHizmetTurleri.DataSource = turListesi;
            dgvHizmetTurleri.ClearSelection();
            dgvHizmetTurleri.Columns["TurAdi"].Width = 150;


            cmbHizmetTuru.DataSource = null;
            cmbHizmetTuru.DataSource = turListesi;
            cmbHizmetTuru.DisplayMember = "TurAdi";
            cmbHizmetTuru.ValueMember = "TurID";
            cmbHizmetTuru.SelectedIndex = -1;

            if (dgvHizmetTurleri.Columns.Contains("TurID"))
                dgvHizmetTurleri.Columns["TurID"].Visible = false;

        }

        private void btnTurListele_Click(object sender, EventArgs e)
        {
            HizmetTurleriniYukle();
            txtHizmetTuru.Clear();
            label5.Text = "";
            HizmetleriYukle();
            HizmetUrunleriniListele();
        }

        private void btnTurSil_Click(object sender, EventArgs e)
        {
            if (dgvHizmetTurleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir hizmet türü seçiniz.");
                return;
            }

            int id = Convert.ToInt32(dgvHizmetTurleri.SelectedRows[0].Cells["TurID"].Value);

            DialogResult onay = MessageBox.Show("Silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                try
                {
                    if (hizmetTuruIslemleri.HizmetTuruSil(id))
                    {
                        MessageBox.Show("Hizmet türü silindi.");
                        HizmetTurleriniYukle();
                        txtHizmetTuru.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void dgvHizmetTurleri_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvHizmetTurleri.SelectedRows.Count > 0)
            {
                string secilenTurAdi = dgvHizmetTurleri.SelectedRows[0].Cells["TurAdi"].Value.ToString();
                txtHizmetTuru.Text = secilenTurAdi;
                label5.Text = secilenTurAdi;

                int turID = Convert.ToInt32(dgvHizmetTurleri.SelectedRows[0].Cells["TurID"].Value);

                HizmetIslemleri islem = new HizmetIslemleri();
                dgvHizmetler.DataSource = islem.TureGoreHizmetleriGetir(turID);
                dgvHizmetler.AllowUserToAddRows = false;
            }
        }


        // Hizmetler kısmı 
        private void HizmetleriYukle()
        {
            dgvHizmetler.AutoGenerateColumns = true;
            dgvHizmetler.DataSource = null;
            dgvHizmetler.DataSource = hizmetIslemleri.TumHizmetleriGetir();
            dgvHizmetler.Columns["TurID"].Visible = false;
            dgvHizmetler.ClearSelection();
            dgvHizmetler.DefaultCellStyle.ForeColor = Color.Black;
            dgvHizmetler.DefaultCellStyle.BackColor = Color.White;

            if (dgvHizmetler.Columns.Contains("HizmetID"))
                dgvHizmetler.Columns["HizmetID"].Visible = false;
        }

        private void btnHizmetEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Hizmet yeniHizmet = new Hizmet(
                    0,
                    txtHizmetAdi.Text.Trim(),
                    Convert.ToInt32(cmbHizmetTuru.SelectedValue),
                    cmbHizmetTuru.Text,
                    Convert.ToDecimal(txtFiyat.Text),
                    Convert.ToInt32(txtSure.Text),
                    Convert.ToInt32(txtSeansSayisi.Text)
                );

                if (hizmetIslemleri.HizmetEkle(yeniHizmet))
                {
                    MessageBox.Show("Hizmet eklendi.");
                    HizmetleriYukle();
                    HizmetAlanlariniTemizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnHizmetGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvHizmetler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir hizmet seçiniz.");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvHizmetler.SelectedRows[0].Cells["HizmetID"].Value);
                Hizmet h = new Hizmet(
                    id,
                    txtHizmetAdi.Text.Trim(),
                    Convert.ToInt32(cmbHizmetTuru.SelectedValue),
                    cmbHizmetTuru.Text,
                    Convert.ToDecimal(txtFiyat.Text),
                    Convert.ToInt32(txtSure.Text),
                    Convert.ToInt32(txtSeansSayisi.Text)
                );

                if (hizmetIslemleri.HizmetGuncelle(h))
                {
                    MessageBox.Show("Güncelleme başarılı.");
                    HizmetleriYukle();
                    HizmetAlanlariniTemizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnHizmetSil_Click(object sender, EventArgs e)
        {
            if (dgvHizmetler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek hizmeti seçiniz.");
                return;
            }

            int id = Convert.ToInt32(dgvHizmetler.SelectedRows[0].Cells["HizmetID"].Value);
            DialogResult dr = MessageBox.Show("Silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (hizmetIslemleri.HizmetSil(id))
                    {
                        MessageBox.Show("Hizmet silindi.");
                        HizmetleriYukle();
                        HizmetAlanlariniTemizle();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void HizmetAlanlariniTemizle()
        {
            txtHizmetAdi.Clear();
            txtFiyat.Clear();
            txtSure.Clear();
            txtSeansSayisi.Clear();
            cmbHizmetTuru.SelectedIndex = -1;
        }

        private void dgvHizmetler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHizmetler.SelectedRows.Count > 0)
            {
                var row = dgvHizmetler.SelectedRows[0];
                txtHizmetAdi.Text = row.Cells["HizmetAdi"].Value.ToString();
                txtFiyat.Text = row.Cells["Fiyat"].Value.ToString();
                txtSure.Text = row.Cells["Sure"].Value.ToString();
                txtSeansSayisi.Text = row.Cells["ToplamSeans"].Value.ToString();
                cmbHizmetTuru.SelectedValue = row.Cells["TurID"].Value;





                seciliHizmetID = Convert.ToInt32(row.Cells["HizmetID"].Value);
                label10.Text = row.Cells["HizmetAdi"].Value.ToString();
                HizmetUrunleriniListele();
            }
        }

        private void btnHizmetListele_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            seciliHizmetID = -1;
            label10.Text = "";
            txtHizmetTuru.Clear();
          
            HizmetleriYukle();
            HizmetAlanlariniTemizle();
            HizmetTurleriniYukle();
            label5.Text = "";
            HizmetUrunleriniListele();
        }


        // Hizmet ürün ekleme 

        private void btnHzmUrunEkle_Click(object sender, EventArgs e)
        {
            if (seciliHizmetID <= 0)
            {
                MessageBox.Show("Lütfen önce bir hizmet seçiniz.");
                return;
            }

            if (cmbUrun.SelectedItem == null || nUMiktar.Value <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir ürün ve miktar seçiniz.");
                return;
            }

            int urunID = Convert.ToInt32(cmbUrun.SelectedValue);
            int miktar = (int)nUMiktar.Value;

            // Randevu oranı alınır, eğer 0 ise null gönderilecek
            int oranDegeri = (int)nURandevuOrani.Value;
            int? randevuOrani = oranDegeri > 0 ? oranDegeri : null;

            if (hizmetUrunIslemleri.HizmeteUrunEkle(seciliHizmetID, urunID, miktar, randevuOrani))
            {
                MessageBox.Show("Ürün hizmete eklendi.");
                HizmetUrunleriniListele();
                cmbUrun.SelectedIndex = -1;
                nUMiktar.Value = 0;
                nURandevuOrani.Value = 0;
            }
        }

        private void btnHzmUrunSil_Click(object sender, EventArgs e)
        {
            if (dgvHizmetUrunleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.");
                return;
            }

            var row = dgvHizmetUrunleri.SelectedRows[0];
            int hizmetID = Convert.ToInt32(row.Cells["HizmetID"].Value);
            int urunID = Convert.ToInt32(row.Cells["UrunID"].Value);

            DialogResult dr = MessageBox.Show("Seçilen ürün silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (hizmetUrunIslemleri.HizmeteUrunSil(hizmetID, urunID))
                {
                    MessageBox.Show("Ürün silindi.");
                    HizmetUrunleriniListele();
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarısız oldu.");
                }
            }
        }

        private void btnHmzUrunGunclle_Click(object sender, EventArgs e)
        {
            if (dgvHizmetUrunleri.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek ürünü seçin.");
                return;
            }

            var row = dgvHizmetUrunleri.SelectedRows[0];
            int hizmetID = Convert.ToInt32(row.Cells["HizmetID"].Value);
            int urunID = Convert.ToInt32(row.Cells["UrunID"].Value);
            int yeniMiktar = (int)nUMiktar.Value;

            int oranDegeri = (int)nURandevuOrani.Value;
            int? yeniRandevuOrani = oranDegeri > 0 ? oranDegeri : (int?)null;

            if (hizmetUrunIslemleri.HizmeteUrunGuncelle(hizmetID, urunID, yeniMiktar, yeniRandevuOrani))
            {
                MessageBox.Show("Ürün bilgileri güncellendi.");
                HizmetUrunleriniListele();
            }
        }

        private void HizmetUrunleriniListele()
        {

            try
            {
                dgvHizmetUrunleri.AutoGenerateColumns = true;
                dgvHizmetUrunleri.AllowUserToAddRows = false;
                dgvHizmetUrunleri.DataSource = null;
                dgvHizmetUrunleri.DefaultCellStyle.ForeColor = Color.Black;
                dgvHizmetUrunleri.DefaultCellStyle.BackColor = Color.White;

                if (seciliHizmetID > 0)
                {
                    dgvHizmetUrunleri.DataSource = hizmetUrunIslemleri.HizmeteGoreUrunGetir(seciliHizmetID);
                }
                else
                {
                    dgvHizmetUrunleri.DataSource = hizmetUrunIslemleri.TumHizmetUrunleriniGetir();
                }

                dgvHizmetUrunleri.ClearSelection();


                if (dgvHizmetUrunleri.Columns.Contains("HizmetID"))
                    dgvHizmetUrunleri.Columns["HizmetID"].Visible = false;

                if (dgvHizmetUrunleri.Columns.Contains("UrunID"))
                    dgvHizmetUrunleri.Columns["UrunID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hizmet ürünleri listelenirken hata oluştu:\n" + ex.Message);
            }


        }

        private void dgvHizmetUrunleri_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHizmetUrunleri.SelectedRows.Count > 0)
            {
                var satir = dgvHizmetUrunleri.SelectedRows[0];

                string urunAdi = satir.Cells["UrunAdi"].Value.ToString();
                int miktar = Convert.ToInt32(satir.Cells["KullanilanMiktar"].Value);
                int oran = Convert.ToInt32(satir.Cells["RandevuBasinaOran"].Value);
                string hizmetAdi = satir.Cells["HizmetAdi"].Value.ToString();

                cmbUrun.SelectedIndex = cmbUrun.FindStringExact(urunAdi);
                nUMiktar.Value = miktar;
                nURandevuOrani.Value = oran;

                // 🔕 Event tetiklenmesin diye geçici olarak kaldır
                dgvHizmetler.SelectionChanged -= dgvHizmetler_SelectionChanged;

                // 🧹 Diğer seçimleri temizle
                dgvHizmetler.ClearSelection();

                // ✅ İlgili hizmeti seç
                foreach (DataGridViewRow hizmetRow in dgvHizmetler.Rows)
                {
                    if (hizmetRow.Cells["HizmetAdi"].Value.ToString() == hizmetAdi)
                    {
                        hizmetRow.Selected = true;
                        dgvHizmetler.FirstDisplayedScrollingRowIndex = hizmetRow.Index;
                        break;
                    }
                }

                // 🔔 Event geri aktif
                dgvHizmetler.SelectionChanged += dgvHizmetler_SelectionChanged;
            }

        }

        private void btnUrunListele_Click(object sender, EventArgs e)
        {
            seciliHizmetID = -1;
            HizmetUrunleriniListele();
            label10.Text = "";
            HizmetleriYukle();
            HizmetTurleriniYukle();
            cmbUrun.SelectedIndex = -1;
            nUMiktar.Value = 0;
            nURandevuOrani.Value = 0;

        }

        private void cmbHizmetTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHizmetTuru.SelectedIndex != -1)
            {

                string secilenTurAdi = cmbHizmetTuru.Text;


                label5.Text = secilenTurAdi;
            }
        }

        private void dgvHizmetler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string arananTur = txtAra.Text.Trim().ToLower();

            var tumTurler = hizmetTuruIslemleri.TumHizmetTurleriniGetir();

            if (string.IsNullOrEmpty(arananTur))
            {
                dgvHizmetTurleri.DataSource = tumTurler; // Hepsini göster
            }
            else
            {
                var filtreli = tumTurler
                    .Where(t => t.TurAdi.ToLower().Contains(arananTur))
                    .ToList();

                dgvHizmetTurleri.DataSource = filtreli;
            }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            btnAra_Click(sender, e);
        }
    }





}
