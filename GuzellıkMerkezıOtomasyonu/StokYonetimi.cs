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
    public partial class StokYonetimi : Form
    {
        public StokYonetimi()
        {
            InitializeComponent();
        }
        UrunIslemleri urunIslemleri = new UrunIslemleri();
        StokHareketIslemleri stokIslemleri = new StokHareketIslemleri();
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StokYonetimi_Load(object sender, EventArgs e)
        {
            UrunleriListele();
            StokHareketleriListele();
        }

        private void UrunleriListele()
        {
            dgvUrunler.DataSource = null;
            dgvUrunler.AutoGenerateColumns = true;
            dgvUrunler.DefaultCellStyle.ForeColor = Color.Black;
            dgvUrunler.DefaultCellStyle.BackColor = Color.White;

            dgvUrunler.DataSource = urunIslemleri.TumUrunleriGetir();

            if (dgvUrunler.Columns.Contains("UrunID"))
                dgvUrunler.Columns["UrunID"].Visible = false;

            dgvUrunler.ClearSelection();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string ad = txtUrunAdi.Text.Trim();
                decimal fiyat = Convert.ToDecimal(txtBirimFiyat.Text);

                Urun yeni = new Urun(0, ad, fiyat);

                if (urunIslemleri.UrunEkle(yeni))
                {
                    MessageBox.Show("Ürün başarıyla eklendi.");
                    UrunleriListele();
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void Temizle()
        {
            txtUrunAdi.Clear();
            txtBirimFiyat.Clear();
            dgvUrunler.ClearSelection();
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek bir ürün seçiniz.");
                return;
            }

            int id = Convert.ToInt32(dgvUrunler.SelectedRows[0].Cells["UrunID"].Value);

            DialogResult onay = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                if (urunIslemleri.UrunSil(id))
                {
                    MessageBox.Show("Ürün başarıyla silindi.");
                    UrunleriListele();
                    Temizle();
                }
            }
        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvUrunler.SelectedRows[0].Cells["UrunID"].Value);
                string ad = txtUrunAdi.Text.Trim();
                decimal fiyat = Convert.ToDecimal(txtBirimFiyat.Text);

                Urun guncel = new Urun(id, ad, fiyat);

                if (urunIslemleri.UrunGuncelle(guncel))
                {
                    MessageBox.Show("Ürün başarıyla güncellendi.");
                    UrunleriListele();
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void dgvUrunler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count > 0)
            {
                var row = dgvUrunler.SelectedRows[0];
                txtUrunAdi.Text = row.Cells["UrunAdi"].Value.ToString();
                txtBirimFiyat.Text = row.Cells["BirimFiyat"].Value.ToString();
            }
        }

        private void btnUrunListele_Click(object sender, EventArgs e)
        {
            UrunleriListele();
            txtBirimFiyat.Clear();
            txtUrunAdi.Clear();
        }

        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtStokMik.Text) || !int.TryParse(txtStokMik.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar giriniz.");
                return;
            }

            int urunID = Convert.ToInt32(dgvUrunler.SelectedRows[0].Cells["UrunID"].Value);

            StokHareketi hareket = new StokHareketi(
                urunID,
                "Giriş",
                miktar,
                DateTime.Now,
                "Manuel stok girişi",
                KullaniciOturumu.CalisanID
            );

            if (stokIslemleri.StokHareketEkle(hareket))
            {
                MessageBox.Show("Stok girişi başarıyla kaydedildi.");
                StokHareketleriListele();
                txtStokMik.Clear();
                dgvUrunler.ClearSelection();
            }
        }
        private void txtStokMik_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void StokHareketleriListele()
        {
            dgvStokHareket.DataSource = null;
            dgvStokHareket.DataSource = stokIslemleri.TumStokHareketleriniGetir();
            dgvStokHareket.AutoGenerateColumns = true;
            dgvStokHareket.DefaultCellStyle.ForeColor = Color.Black;
            dgvStokHareket.DefaultCellStyle.BackColor = Color.White;


            dgvStokHareket.Columns["UrunAdi"].HeaderText = "Ürün Adı";
            dgvStokHareket.Columns["HareketTuru"].HeaderText = "Hareket Türü";
            dgvStokHareket.Columns["Miktar"].HeaderText = "Miktar";
            dgvStokHareket.Columns["HareketTarihi"].HeaderText = "Tarih";
            dgvStokHareket.Columns["Aciklama"].HeaderText = "Açıklama";


            dgvStokHareket.Columns["UrunID"].Visible = false;
            dgvStokHareket.Columns["HareketID"].Visible = false;
            dgvStokHareket.Columns["CalisanID"].Visible = false;

            dgvStokHareket.Columns["UrunAdi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvStokHareket.Columns["HareketTuru"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvStokHareket.Columns["Miktar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvStokHareket.Columns["HareketTarihi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvStokHareket.Columns["Aciklama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvStokHareket.Columns["UrunAdi"].DisplayIndex = 0;
            dgvStokHareket.ClearSelection();
        }

        private void btnStokGoruntu_Click(object sender, EventArgs e)
        {
            StokDetayForm stok = new StokDetayForm();
            stok.ShowDialog();
        }

        private void btnStokGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvStokHareket.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir stok hareketi seçin.");
                return;
            }

            if (!int.TryParse(txtStokMik.Text.Trim(), out int miktar) || miktar < 0)
            {
                MessageBox.Show("Geçerli bir miktar girin!");
                return;
            }

            int hareketID = Convert.ToInt32(dgvStokHareket.SelectedRows[0].Cells["HareketID"].Value);
            int calisanID = KullaniciOturumu.CalisanID;

            bool basarili = stokIslemleri.MiktarGuncelle(hareketID, miktar, calisanID);

            if (basarili)
            {
                MessageBox.Show("Stok miktarı başarıyla güncellendi.");
                StokHareketleriListele();
                txtStokMik.Clear();
            }
            else
            {
                MessageBox.Show("Güncelleme başarısız!");
                txtStokMik.Clear();
            }
        }

        private void btnStokListele_Click(object sender, EventArgs e)
        {
            StokHareketleriListele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string arananUrunAdi = txtAra.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(arananUrunAdi))
            {
                dgvUrunler.DataSource = urunIslemleri.TumUrunleriGetir(); // tüm ürünleri geri yükle
                return;
            }

            var filtrelenmisListe = urunIslemleri.TumUrunleriGetir()
                .Where(u => u.UrunAdi.ToLower().Contains(arananUrunAdi))
                .ToList();

            dgvUrunler.DataSource = filtrelenmisListe;
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            btnAra_Click(sender, e);
        }
    }
}
