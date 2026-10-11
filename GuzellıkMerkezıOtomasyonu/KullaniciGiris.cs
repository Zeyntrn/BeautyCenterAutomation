using Microsoft.VisualBasic.Logging;

namespace GuzellıkMerkezıOtomasyonu
{
    public partial class KullaniciGiris : Form
    {
        public KullaniciGiris()
        {
            InitializeComponent();
        }

        private void lnkkayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KullaniciKayit kyt = new KullaniciKayit();
            kyt.ShowDialog();
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtKullaniciSifre.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CalisanIslemleri kontrol = new CalisanIslemleri();
            bool giris = kontrol.GirisYap(kullaniciAdi, sifre);

            if (giris)
            {
                MessageBox.Show($"Hoş geldiniz, {KullaniciOturumu.KullaniciAdi}", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AnaMenu anaMenu = new AnaMenu();
                anaMenu.Show();

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void KullaniciGiris_Load(object sender, EventArgs e)
        {
            txtKullaniciSifre.PasswordChar = '*';
            txtKullaniciAdi.Text = "zeynepturan";
        }

        private void lnksifreUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum sifre = new SifremiUnuttum();
            sifre.ShowDialog();
        }
    }
}