using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuzellıkMerkezıOtomasyonu
{
    public partial class Raporlar : Form
    {
        public Raporlar()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void Raporlar_Load(object sender, EventArgs e)
        {
            int buYil = DateTime.Now.Year;
            for (int yil = buYil; yil >= 2020; yil--)
                cmbYil.Items.Add(yil);

            cmbYil.SelectedItem = buYil; // varsayılan olarak bu yıl seçili
            AylikGelirleriGetir(buYil);

            dgvGelirler.AllowUserToAddRows = false;
        }
        private void AylikGelirleriGetir(int yil)  // yıl parametre olarak alınıyor
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Ay");
            dt.Columns.Add("Gelir");

            SqlConnection conn = SqlBaglanti.Instance.GetConnection();
            SqlBaglanti.Instance.OpenConnection();

            for (int ay = 1; ay <= 12; ay++)
            {
                // Peşin ödemeler
                string pesinSorgu = @"
            SELECT ISNULL(SUM(ToplamTutar), 0)
            FROM tbl_Odemeler
            WHERE OdemeTuru = 'Peşin'
              AND YEAR(OdemeTarihi) = @yil AND MONTH(OdemeTarihi) = @ay";

                SqlCommand cmd1 = new SqlCommand(pesinSorgu, conn);
                cmd1.Parameters.AddWithValue("@yil", yil);
                cmd1.Parameters.AddWithValue("@ay", ay);
                decimal pesinGelir = Convert.ToDecimal(cmd1.ExecuteScalar());

                // Ödendi durumundaki taksitler
                string taksitSorgu = @"
            SELECT ISNULL(SUM(t.Tutar), 0)
            FROM tbl_Taksitler t
            INNER JOIN tbl_Odemeler o ON t.OdemeID = o.OdemeID
            WHERE t.Durum = 'Ödendi'
              AND YEAR(t.VadeTarihi) = @yil AND MONTH(t.VadeTarihi) = @ay";

                SqlCommand cmd2 = new SqlCommand(taksitSorgu, conn);
                cmd2.Parameters.AddWithValue("@yil", yil);
                cmd2.Parameters.AddWithValue("@ay", ay);
                decimal taksitGelir = Convert.ToDecimal(cmd2.ExecuteScalar());

                decimal toplamGelir = pesinGelir + taksitGelir;

                string ayAdi = new DateTime(yil, ay, 1).ToString("MMMM", new System.Globalization.CultureInfo("tr-TR"));
                dt.Rows.Add(ayAdi, toplamGelir);
            }

            SqlBaglanti.Instance.CloseConnection();

            dgvGelirler.DataSource = dt;
            dgvGelirler.Columns["Ay"].HeaderText = "Ay";
            dgvGelirler.Columns["Gelir"].HeaderText = "Toplam Gelir (₺)";

            dgvGelirler.DefaultCellStyle.ForeColor = Color.Black;
            dgvGelirler.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        }

        private void cmbYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secilenYil = Convert.ToInt32(cmbYil.SelectedItem);
            AylikGelirleriGetir(secilenYil);
        }
    }
}
