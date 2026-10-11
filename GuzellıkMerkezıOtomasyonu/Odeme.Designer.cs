namespace GuzellıkMerkezıOtomasyonu
{
    partial class Odeme
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            txtHizmetFiyat = new TextBox();
            label15 = new Label();
            btnHizmetSil = new Button();
            btnHizmetEkle = new Button();
            dgvSepetHizmet = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            cmbHizmetTuru = new ComboBox();
            cmbHizmetAdi = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            tabPage2 = new TabPage();
            label16 = new Label();
            nudMiktar = new NumericUpDown();
            txtUrunFiyat = new TextBox();
            btnUrunSil = new Button();
            dgvUrunSepet = new DataGridView();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            btnUrunEkle = new Button();
            label5 = new Label();
            cmbUrun = new ComboBox();
            label4 = new Label();
            label1 = new Label();
            cmbMusteriSec = new ComboBox();
            btnYeniMusteri = new Button();
            groupBox1 = new GroupBox();
            rbTaksit = new RadioButton();
            rbPesin = new RadioButton();
            btnOdemeYap = new Button();
            cmbTaksitSayisi = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            txtToplamTutar = new TextBox();
            label6 = new Label();
            dgvTaksitler = new DataGridView();
            label9 = new Label();
            btnSeciliTaksitiOde = new Button();
            button10 = new Button();
            grpYeniMusteri = new GroupBox();
            datetimeDogumTrh = new DateTimePicker();
            label10 = new Label();
            txtSoyad = new TextBox();
            label11 = new Label();
            mskTelefon = new MaskedTextBox();
            txtMail = new TextBox();
            label12 = new Label();
            txtAd = new TextBox();
            label13 = new Label();
            label14 = new Label();
            btnEkle = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSepetHizmet).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMiktar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUrunSepet).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaksitler).BeginInit();
            grpYeniMusteri.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Zeynep_turan__1_;
            pictureBox1.Location = new Point(1, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(268, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(93, 325);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(577, 566);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(255, 192, 192);
            tabPage1.Controls.Add(txtHizmetFiyat);
            tabPage1.Controls.Add(label15);
            tabPage1.Controls.Add(btnHizmetSil);
            tabPage1.Controls.Add(btnHizmetEkle);
            tabPage1.Controls.Add(dgvSepetHizmet);
            tabPage1.Controls.Add(cmbHizmetTuru);
            tabPage1.Controls.Add(cmbHizmetAdi);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(569, 533);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Hizmetler";
            // 
            // txtHizmetFiyat
            // 
            txtHizmetFiyat.Enabled = false;
            txtHizmetFiyat.Location = new Point(275, 127);
            txtHizmetFiyat.Name = "txtHizmetFiyat";
            txtHizmetFiyat.Size = new Size(153, 27);
            txtHizmetFiyat.TabIndex = 20;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.Brown;
            label15.Location = new Point(111, 130);
            label15.Name = "label15";
            label15.Size = new Size(144, 25);
            label15.TabIndex = 19;
            label15.Text = "Fiyat                 :";
            // 
            // btnHizmetSil
            // 
            btnHizmetSil.BackColor = Color.FromArgb(255, 192, 192);
            btnHizmetSil.ForeColor = Color.Brown;
            btnHizmetSil.Location = new Point(309, 454);
            btnHizmetSil.Name = "btnHizmetSil";
            btnHizmetSil.Size = new Size(223, 42);
            btnHizmetSil.TabIndex = 18;
            btnHizmetSil.Text = "Hizmeti Sil";
            btnHizmetSil.UseVisualStyleBackColor = false;
            btnHizmetSil.Click += btnHizmetSil_Click;
            // 
            // btnHizmetEkle
            // 
            btnHizmetEkle.BackColor = Color.FromArgb(255, 192, 192);
            btnHizmetEkle.ForeColor = Color.Brown;
            btnHizmetEkle.Location = new Point(129, 176);
            btnHizmetEkle.Name = "btnHizmetEkle";
            btnHizmetEkle.Size = new Size(282, 42);
            btnHizmetEkle.TabIndex = 17;
            btnHizmetEkle.Text = "HİZMET EKLE";
            btnHizmetEkle.UseVisualStyleBackColor = false;
            btnHizmetEkle.Click += btnHizmetEkle_Click;
            // 
            // dgvSepetHizmet
            // 
            dgvSepetHizmet.BackgroundColor = Color.White;
            dgvSepetHizmet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSepetHizmet.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvSepetHizmet.DefaultCellStyle = dataGridViewCellStyle1;
            dgvSepetHizmet.Location = new Point(35, 236);
            dgvSepetHizmet.Name = "dgvSepetHizmet";
            dgvSepetHizmet.RowHeadersWidth = 51;
            dgvSepetHizmet.RowTemplate.Height = 29;
            dgvSepetHizmet.Size = new Size(497, 212);
            dgvSepetHizmet.TabIndex = 16;
            // 
            // Column1
            // 
            Column1.HeaderText = "HİZMET ";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "FİYAT";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // cmbHizmetTuru
            // 
            cmbHizmetTuru.FormattingEnabled = true;
            cmbHizmetTuru.Location = new Point(277, 19);
            cmbHizmetTuru.Name = "cmbHizmetTuru";
            cmbHizmetTuru.Size = new Size(151, 28);
            cmbHizmetTuru.TabIndex = 15;
            cmbHizmetTuru.SelectedIndexChanged += cmbHizmetTuru_SelectedIndexChanged;
            // 
            // cmbHizmetAdi
            // 
            cmbHizmetAdi.FormattingEnabled = true;
            cmbHizmetAdi.Location = new Point(277, 74);
            cmbHizmetAdi.Name = "cmbHizmetAdi";
            cmbHizmetAdi.Size = new Size(151, 28);
            cmbHizmetAdi.TabIndex = 14;
            cmbHizmetAdi.SelectedIndexChanged += cmbHizmetAdi_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Brown;
            label3.Location = new Point(107, 77);
            label3.Name = "label3";
            label3.Size = new Size(144, 25);
            label3.TabIndex = 12;
            label3.Text = "Hizmet             :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Brown;
            label2.Location = new Point(107, 22);
            label2.Name = "label2";
            label2.Size = new Size(147, 25);
            label2.TabIndex = 11;
            label2.Text = "Hizmet Türü     :";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(255, 192, 192);
            tabPage2.Controls.Add(label16);
            tabPage2.Controls.Add(nudMiktar);
            tabPage2.Controls.Add(txtUrunFiyat);
            tabPage2.Controls.Add(btnUrunSil);
            tabPage2.Controls.Add(dgvUrunSepet);
            tabPage2.Controls.Add(btnUrunEkle);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(cmbUrun);
            tabPage2.Controls.Add(label4);
            tabPage2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tabPage2.ForeColor = Color.Black;
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(569, 533);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ürünler";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label16.ForeColor = Color.Brown;
            label16.Location = new Point(102, 69);
            label16.Name = "label16";
            label16.Size = new Size(84, 25);
            label16.TabIndex = 26;
            label16.Text = "Miktar  :";
            // 
            // nudMiktar
            // 
            nudMiktar.Location = new Point(211, 71);
            nudMiktar.Name = "nudMiktar";
            nudMiktar.Size = new Size(212, 27);
            nudMiktar.TabIndex = 25;
            // 
            // txtUrunFiyat
            // 
            txtUrunFiyat.Enabled = false;
            txtUrunFiyat.Location = new Point(211, 116);
            txtUrunFiyat.Name = "txtUrunFiyat";
            txtUrunFiyat.Size = new Size(212, 27);
            txtUrunFiyat.TabIndex = 24;
            // 
            // btnUrunSil
            // 
            btnUrunSil.BackColor = Color.FromArgb(255, 192, 192);
            btnUrunSil.ForeColor = Color.Brown;
            btnUrunSil.Location = new Point(318, 472);
            btnUrunSil.Name = "btnUrunSil";
            btnUrunSil.Size = new Size(230, 42);
            btnUrunSil.TabIndex = 23;
            btnUrunSil.Text = "Ürünü Sil";
            btnUrunSil.UseVisualStyleBackColor = false;
            btnUrunSil.Click += btnUrunSil_Click;
            // 
            // dgvUrunSepet
            // 
            dgvUrunSepet.BackgroundColor = Color.White;
            dgvUrunSepet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUrunSepet.Columns.AddRange(new DataGridViewColumn[] { Column3, Column4, Column5, Column6 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvUrunSepet.DefaultCellStyle = dataGridViewCellStyle2;
            dgvUrunSepet.Location = new Point(19, 249);
            dgvUrunSepet.Name = "dgvUrunSepet";
            dgvUrunSepet.RowHeadersWidth = 51;
            dgvUrunSepet.RowTemplate.Height = 29;
            dgvUrunSepet.Size = new Size(529, 208);
            dgvUrunSepet.TabIndex = 22;
            // 
            // Column3
            // 
            Column3.HeaderText = "ÜRÜN";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "MİKTAR";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "FİYAT";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // Column6
            // 
            Column6.HeaderText = "TOPLAM";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 125;
            // 
            // btnUrunEkle
            // 
            btnUrunEkle.BackColor = Color.FromArgb(255, 192, 192);
            btnUrunEkle.ForeColor = Color.Brown;
            btnUrunEkle.Location = new Point(134, 176);
            btnUrunEkle.Name = "btnUrunEkle";
            btnUrunEkle.Size = new Size(282, 42);
            btnUrunEkle.TabIndex = 21;
            btnUrunEkle.Text = "ÜRÜN EKLE";
            btnUrunEkle.UseVisualStyleBackColor = false;
            btnUrunEkle.Click += btnUrunEkle_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Brown;
            label5.Location = new Point(102, 118);
            label5.Name = "label5";
            label5.Size = new Size(84, 25);
            label5.TabIndex = 19;
            label5.Text = "Fiyat     :";
            // 
            // cmbUrun
            // 
            cmbUrun.FormattingEnabled = true;
            cmbUrun.Location = new Point(211, 23);
            cmbUrun.Name = "cmbUrun";
            cmbUrun.Size = new Size(212, 28);
            cmbUrun.TabIndex = 17;
            cmbUrun.SelectedIndexChanged += cmbUrun_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Brown;
            label4.Location = new Point(102, 26);
            label4.Name = "label4";
            label4.Size = new Size(84, 25);
            label4.TabIndex = 16;
            label4.Text = "Ürün     :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(301, 169);
            label1.Name = "label1";
            label1.Size = new Size(127, 25);
            label1.TabIndex = 7;
            label1.Text = "Müşteri Seç  :";
            // 
            // cmbMusteriSec
            // 
            cmbMusteriSec.FormattingEnabled = true;
            cmbMusteriSec.Location = new Point(434, 166);
            cmbMusteriSec.Name = "cmbMusteriSec";
            cmbMusteriSec.Size = new Size(195, 28);
            cmbMusteriSec.TabIndex = 8;
            cmbMusteriSec.SelectedIndexChanged += cmbMusteriSec_SelectedIndexChanged;
            // 
            // btnYeniMusteri
            // 
            btnYeniMusteri.BackColor = Color.RosyBrown;
            btnYeniMusteri.ForeColor = Color.Brown;
            btnYeniMusteri.Location = new Point(301, 215);
            btnYeniMusteri.Name = "btnYeniMusteri";
            btnYeniMusteri.Size = new Size(328, 42);
            btnYeniMusteri.TabIndex = 15;
            btnYeniMusteri.Text = "YENİ MÜŞTERİ EKLE";
            btnYeniMusteri.UseVisualStyleBackColor = false;
            btnYeniMusteri.Click += btnYeniMusteri_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(255, 192, 192);
            groupBox1.Controls.Add(rbTaksit);
            groupBox1.Controls.Add(rbPesin);
            groupBox1.Controls.Add(btnOdemeYap);
            groupBox1.Controls.Add(cmbTaksitSayisi);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtToplamTutar);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(752, 354);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(578, 533);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            // 
            // rbTaksit
            // 
            rbTaksit.AutoSize = true;
            rbTaksit.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            rbTaksit.ForeColor = SystemColors.ControlDarkDark;
            rbTaksit.Location = new Point(363, 119);
            rbTaksit.Name = "rbTaksit";
            rbTaksit.Size = new Size(73, 27);
            rbTaksit.TabIndex = 21;
            rbTaksit.TabStop = true;
            rbTaksit.Text = "Taksit";
            rbTaksit.UseVisualStyleBackColor = true;
            rbTaksit.CheckedChanged += rbTaksit_CheckedChanged;
            // 
            // rbPesin
            // 
            rbPesin.AutoSize = true;
            rbPesin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            rbPesin.ForeColor = SystemColors.ControlDarkDark;
            rbPesin.Location = new Point(257, 119);
            rbPesin.Name = "rbPesin";
            rbPesin.Size = new Size(70, 27);
            rbPesin.TabIndex = 20;
            rbPesin.TabStop = true;
            rbPesin.Text = "Peşin";
            rbPesin.UseVisualStyleBackColor = true;
            rbPesin.CheckedChanged += rbPesin_CheckedChanged;
            // 
            // btnOdemeYap
            // 
            btnOdemeYap.BackColor = Color.FromArgb(255, 192, 192);
            btnOdemeYap.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnOdemeYap.ForeColor = Color.Brown;
            btnOdemeYap.Location = new Point(144, 249);
            btnOdemeYap.Name = "btnOdemeYap";
            btnOdemeYap.Size = new Size(282, 42);
            btnOdemeYap.TabIndex = 19;
            btnOdemeYap.Text = "ÖDEMEYİ TAMAMLA";
            btnOdemeYap.UseVisualStyleBackColor = false;
            btnOdemeYap.Click += btnOdemeYap_Click;
            // 
            // cmbTaksitSayisi
            // 
            cmbTaksitSayisi.FormattingEnabled = true;
            cmbTaksitSayisi.Location = new Point(257, 173);
            cmbTaksitSayisi.Name = "cmbTaksitSayisi";
            cmbTaksitSayisi.Size = new Size(186, 28);
            cmbTaksitSayisi.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Brown;
            label8.Location = new Point(95, 176);
            label8.Name = "label8";
            label8.Size = new Size(138, 25);
            label8.TabIndex = 17;
            label8.Text = "Taksit Sayısı    :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Brown;
            label7.Location = new Point(90, 115);
            label7.Name = "label7";
            label7.Size = new Size(140, 25);
            label7.TabIndex = 14;
            label7.Text = "Ödeme Tipi     :";
            // 
            // txtToplamTutar
            // 
            txtToplamTutar.Enabled = false;
            txtToplamTutar.Location = new Point(254, 57);
            txtToplamTutar.Name = "txtToplamTutar";
            txtToplamTutar.Size = new Size(192, 27);
            txtToplamTutar.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Brown;
            label6.Location = new Point(90, 60);
            label6.Name = "label6";
            label6.Size = new Size(143, 25);
            label6.TabIndex = 12;
            label6.Text = "Toplam Tutar   :";
            // 
            // dgvTaksitler
            // 
            dgvTaksitler.BackgroundColor = Color.FromArgb(255, 192, 192);
            dgvTaksitler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaksitler.Location = new Point(1397, 392);
            dgvTaksitler.Name = "dgvTaksitler";
            dgvTaksitler.RowHeadersWidth = 51;
            dgvTaksitler.RowTemplate.Height = 29;
            dgvTaksitler.Size = new Size(499, 439);
            dgvTaksitler.TabIndex = 17;
            dgvTaksitler.RowPrePaint += dgvTaksitler_RowPrePaint;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Brown;
            label9.Location = new Point(1397, 354);
            label9.Name = "label9";
            label9.Size = new Size(185, 25);
            label9.TabIndex = 18;
            label9.Text = "Müşterinin Taksitleri";
            // 
            // btnSeciliTaksitiOde
            // 
            btnSeciliTaksitiOde.BackColor = Color.FromArgb(255, 192, 192);
            btnSeciliTaksitiOde.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSeciliTaksitiOde.ForeColor = Color.Brown;
            btnSeciliTaksitiOde.Location = new Point(1522, 837);
            btnSeciliTaksitiOde.Name = "btnSeciliTaksitiOde";
            btnSeciliTaksitiOde.Size = new Size(282, 42);
            btnSeciliTaksitiOde.TabIndex = 20;
            btnSeciliTaksitiOde.Text = "Seçili Taksiti Öde";
            btnSeciliTaksitiOde.UseVisualStyleBackColor = false;
            btnSeciliTaksitiOde.Click += btnSeciliTaksitiOde_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.Transparent;
            button10.FlatStyle = FlatStyle.Popup;
            button10.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button10.Location = new Point(1819, 28);
            button10.Name = "button10";
            button10.Size = new Size(77, 56);
            button10.TabIndex = 21;
            button10.Text = "X";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // grpYeniMusteri
            // 
            grpYeniMusteri.BackColor = Color.Transparent;
            grpYeniMusteri.Controls.Add(datetimeDogumTrh);
            grpYeniMusteri.Controls.Add(label10);
            grpYeniMusteri.Controls.Add(txtSoyad);
            grpYeniMusteri.Controls.Add(label11);
            grpYeniMusteri.Controls.Add(mskTelefon);
            grpYeniMusteri.Controls.Add(txtMail);
            grpYeniMusteri.Controls.Add(label12);
            grpYeniMusteri.Controls.Add(txtAd);
            grpYeniMusteri.Controls.Add(label13);
            grpYeniMusteri.Controls.Add(label14);
            grpYeniMusteri.Controls.Add(btnEkle);
            grpYeniMusteri.Location = new Point(856, 12);
            grpYeniMusteri.Name = "grpYeniMusteri";
            grpYeniMusteri.Size = new Size(366, 320);
            grpYeniMusteri.TabIndex = 22;
            grpYeniMusteri.TabStop = false;
            grpYeniMusteri.Visible = false;
            // 
            // datetimeDogumTrh
            // 
            datetimeDogumTrh.Location = new Point(184, 212);
            datetimeDogumTrh.Name = "datetimeDogumTrh";
            datetimeDogumTrh.Size = new Size(150, 27);
            datetimeDogumTrh.TabIndex = 43;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Brown;
            label10.Location = new Point(17, 212);
            label10.Name = "label10";
            label10.Size = new Size(142, 25);
            label10.TabIndex = 42;
            label10.Text = "Doğum Tarihi  :";
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(183, 71);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(151, 27);
            txtSoyad.TabIndex = 41;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.Brown;
            label11.Location = new Point(17, 70);
            label11.Name = "label11";
            label11.Size = new Size(139, 25);
            label11.TabIndex = 40;
            label11.Text = "Soyad              :";
            // 
            // mskTelefon
            // 
            mskTelefon.Location = new Point(183, 117);
            mskTelefon.Mask = "(999) 000-0000";
            mskTelefon.Name = "mskTelefon";
            mskTelefon.Size = new Size(151, 27);
            mskTelefon.TabIndex = 39;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(183, 162);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(151, 27);
            txtMail.TabIndex = 38;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.Brown;
            label12.Location = new Point(18, 28);
            label12.Name = "label12";
            label12.Size = new Size(136, 25);
            label12.TabIndex = 34;
            label12.Text = "Ad                   :";
            // 
            // txtAd
            // 
            txtAd.Location = new Point(183, 26);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(151, 27);
            txtAd.TabIndex = 37;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.Brown;
            label13.Location = new Point(17, 116);
            label13.Name = "label13";
            label13.Size = new Size(139, 25);
            label13.TabIndex = 35;
            label13.Text = "Telefon            :";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.Brown;
            label14.Location = new Point(18, 164);
            label14.Name = "label14";
            label14.Size = new Size(142, 25);
            label14.TabIndex = 36;
            label14.Text = "E-mail              :";
            // 
            // btnEkle
            // 
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.ForeColor = Color.White;
            btnEkle.Location = new Point(129, 268);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(94, 36);
            btnEkle.TabIndex = 29;
            btnEkle.Text = "EKLE ";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // Odeme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Zeynep_turan;
            ClientSize = new Size(1942, 991);
            Controls.Add(grpYeniMusteri);
            Controls.Add(button10);
            Controls.Add(btnSeciliTaksitiOde);
            Controls.Add(label9);
            Controls.Add(dgvTaksitler);
            Controls.Add(groupBox1);
            Controls.Add(btnYeniMusteri);
            Controls.Add(cmbMusteriSec);
            Controls.Add(label1);
            Controls.Add(tabControl1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Odeme";
            Text = "MusteriVeOdeme";
            WindowState = FormWindowState.Maximized;
            Load += Odeme_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSepetHizmet).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMiktar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUrunSepet).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaksitler).EndInit();
            grpYeniMusteri.ResumeLayout(false);
            grpYeniMusteri.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private ComboBox cmbMusteriSec;
        private Button btnYeniMusteri;
        private Button btnHizmetEkle;
        private DataGridView dgvSepetHizmet;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private ComboBox cmbHizmetTuru;
        private ComboBox cmbHizmetAdi;
        private Label label3;
        private Label label2;
        private ComboBox cmbUrun;
        private Label label4;
        private Button btnUrunEkle;
        private Label label5;
        private DataGridView dgvUrunSepet;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private GroupBox groupBox1;
        private Label label7;
        private TextBox txtToplamTutar;
        private Label label6;
        private Button btnOdemeYap;
        private ComboBox cmbTaksitSayisi;
        private Label label8;
        private DataGridView dgvTaksitler;
        private Label label9;
        private Button btnSeciliTaksitiOde;
        private Button btnHizmetSil;
        private Button btnUrunSil;
        private RadioButton rbTaksit;
        private RadioButton rbPesin;
        private Button button10;
        private GroupBox grpYeniMusteri;
        private DateTimePicker datetimeDogumTrh;
        private Label label10;
        private TextBox txtSoyad;
        private Label label11;
        private MaskedTextBox mskTelefon;
        private TextBox txtMail;
        private Label label12;
        private TextBox txtAd;
        private Label label13;
        private Label label14;
        private Button btnEkle;
        private TextBox txtUrunFiyat;
        private TextBox txtHizmetFiyat;
        private Label label15;
        private Label label16;
        private NumericUpDown nudMiktar;
    }
}