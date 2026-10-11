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
    public partial class StokDetayForm : Form
    {
        public StokDetayForm()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StokDetayForm_Load(object sender, EventArgs e)
        {
            StokHareketIslemleri stokIslemleri = new StokHareketIslemleri();
            DataTable dt = stokIslemleri.TumUrunlerinStokDurumu();
            dgvStokDurum.AllowUserToAddRows = false;

            dgvStokDurum.DataSource = dt;

            dgvStokDurum.Columns["UrunID"].Visible = false;
            dgvStokDurum.Columns["UrunAdi"].HeaderText = "Ürün Adı";
            dgvStokDurum.Columns["MevcutStok"].HeaderText = "Stok Miktarı";


            foreach (DataGridViewRow row in dgvStokDurum.Rows)
            {
                int miktar = Convert.ToInt32(row.Cells["MevcutStok"].Value);
                if (miktar <= 20)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
    }
}
