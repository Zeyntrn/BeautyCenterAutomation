namespace GuzellıkMerkezıOtomasyonu
{
    partial class HizmetYonetim
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            btnAra = new Button();
            txtAra = new TextBox();
            label14 = new Label();
            dgvHizmetTurleri = new DataGridView();
            btnTurSil = new Button();
            btnTurGuncelle = new Button();
            btnTurListele = new Button();
            txtHizmetTuru = new TextBox();
            label2 = new Label();
            btnTurEkle = new Button();
            txtFiyat = new TextBox();
            btnHizmetGuncelle = new Button();
            btnHizmetSil = new Button();
            cmbHizmetTuru = new ComboBox();
            txtHizmetAdi = new TextBox();
            label6 = new Label();
            label3 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnHizmetEkle = new Button();
            txtSeansSayisi = new TextBox();
            txtSure = new TextBox();
            label7 = new Label();
            label8 = new Label();
            btnHizmetListele = new Button();
            dgvHizmetler = new DataGridView();
            label5 = new Label();
            label4 = new Label();
            groupBox3 = new GroupBox();
            label13 = new Label();
            nURandevuOrani = new NumericUpDown();
            btnUrunListele = new Button();
            btnHzmUrunEkle = new Button();
            btnHmzUrunGunclle = new Button();
            btnHzmUrunSil = new Button();
            label12 = new Label();
            nUMiktar = new NumericUpDown();
            cmbUrun = new ComboBox();
            label11 = new Label();
            dgvHizmetUrunleri = new DataGridView();
            label10 = new Label();
            label9 = new Label();
            btnKapat = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHizmetTurleri).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHizmetler).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nURandevuOrani).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nUMiktar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHizmetUrunleri).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Zeynep_turan__1_;
            pictureBox1.Location = new Point(-1, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(268, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnAra);
            groupBox1.Controls.Add(txtAra);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(dgvHizmetTurleri);
            groupBox1.Controls.Add(btnTurSil);
            groupBox1.Controls.Add(btnTurGuncelle);
            groupBox1.Controls.Add(btnTurListele);
            groupBox1.Controls.Add(txtHizmetTuru);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnTurEkle);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(34, 169);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(556, 773);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hizmet Türü";
            // 
            // btnAra
            // 
            btnAra.FlatStyle = FlatStyle.Flat;
            btnAra.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAra.ForeColor = Color.White;
            btnAra.Location = new Point(317, 26);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(51, 36);
            btnAra.TabIndex = 21;
            btnAra.Text = "Ara ";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // txtAra
            // 
            txtAra.Location = new Point(127, 32);
            txtAra.Name = "txtAra";
            txtAra.Size = new Size(175, 27);
            txtAra.TabIndex = 20;
            txtAra.TextChanged += txtAra_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.Brown;
            label14.Location = new Point(19, 32);
            label14.Name = "label14";
            label14.Size = new Size(111, 25);
            label14.TabIndex = 19;
            label14.Text = "Hizmetler  :";
            // 
            // dgvHizmetTurleri
            // 
            dgvHizmetTurleri.BackgroundColor = Color.White;
            dgvHizmetTurleri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Variable Display Semib", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvHizmetTurleri.DefaultCellStyle = dataGridViewCellStyle1;
            dgvHizmetTurleri.Location = new Point(6, 75);
            dgvHizmetTurleri.Name = "dgvHizmetTurleri";
            dgvHizmetTurleri.RowHeadersWidth = 51;
            dgvHizmetTurleri.RowTemplate.Height = 29;
            dgvHizmetTurleri.Size = new Size(544, 493);
            dgvHizmetTurleri.TabIndex = 18;
            dgvHizmetTurleri.SelectionChanged += dgvHizmetTurleri_SelectionChanged;
            // 
            // btnTurSil
            // 
            btnTurSil.FlatStyle = FlatStyle.Flat;
            btnTurSil.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnTurSil.ForeColor = Color.White;
            btnTurSil.Location = new Point(336, 657);
            btnTurSil.Name = "btnTurSil";
            btnTurSil.Size = new Size(94, 65);
            btnTurSil.TabIndex = 14;
            btnTurSil.Text = "Sil";
            btnTurSil.UseVisualStyleBackColor = true;
            btnTurSil.Click += btnTurSil_Click;
            // 
            // btnTurGuncelle
            // 
            btnTurGuncelle.FlatStyle = FlatStyle.Flat;
            btnTurGuncelle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnTurGuncelle.ForeColor = Color.White;
            btnTurGuncelle.Location = new Point(208, 657);
            btnTurGuncelle.Name = "btnTurGuncelle";
            btnTurGuncelle.Size = new Size(94, 65);
            btnTurGuncelle.TabIndex = 13;
            btnTurGuncelle.Text = "Güncelle";
            btnTurGuncelle.UseVisualStyleBackColor = true;
            btnTurGuncelle.Click += btnTurGuncelle_Click;
            // 
            // btnTurListele
            // 
            btnTurListele.BackColor = Color.RosyBrown;
            btnTurListele.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnTurListele.ForeColor = Color.Brown;
            btnTurListele.Location = new Point(425, 28);
            btnTurListele.Name = "btnTurListele";
            btnTurListele.Size = new Size(125, 36);
            btnTurListele.TabIndex = 17;
            btnTurListele.Text = "LİSTELE";
            btnTurListele.UseVisualStyleBackColor = false;
            btnTurListele.Click += btnTurListele_Click;
            // 
            // txtHizmetTuru
            // 
            txtHizmetTuru.Location = new Point(240, 601);
            txtHizmetTuru.Name = "txtHizmetTuru";
            txtHizmetTuru.Size = new Size(204, 27);
            txtHizmetTuru.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Brown;
            label2.Location = new Point(86, 600);
            label2.Name = "label2";
            label2.Size = new Size(137, 25);
            label2.TabIndex = 6;
            label2.Text = "Hizmet Türü   :";
            // 
            // btnTurEkle
            // 
            btnTurEkle.FlatStyle = FlatStyle.Flat;
            btnTurEkle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnTurEkle.ForeColor = Color.White;
            btnTurEkle.Location = new Point(86, 657);
            btnTurEkle.Name = "btnTurEkle";
            btnTurEkle.Size = new Size(94, 65);
            btnTurEkle.TabIndex = 12;
            btnTurEkle.Text = "Yeni Tür Ekle";
            btnTurEkle.UseVisualStyleBackColor = true;
            btnTurEkle.Click += btnTurEkle_Click;
            // 
            // txtFiyat
            // 
            txtFiyat.Location = new Point(190, 707);
            txtFiyat.Name = "txtFiyat";
            txtFiyat.Size = new Size(151, 27);
            txtFiyat.TabIndex = 16;
            // 
            // btnHizmetGuncelle
            // 
            btnHizmetGuncelle.FlatStyle = FlatStyle.Flat;
            btnHizmetGuncelle.ForeColor = Color.White;
            btnHizmetGuncelle.Location = new Point(618, 720);
            btnHizmetGuncelle.Name = "btnHizmetGuncelle";
            btnHizmetGuncelle.Size = new Size(94, 36);
            btnHizmetGuncelle.TabIndex = 14;
            btnHizmetGuncelle.Text = "GÜNCELLE";
            btnHizmetGuncelle.UseVisualStyleBackColor = true;
            btnHizmetGuncelle.Click += btnHizmetGuncelle_Click;
            // 
            // btnHizmetSil
            // 
            btnHizmetSil.FlatStyle = FlatStyle.Flat;
            btnHizmetSil.ForeColor = Color.White;
            btnHizmetSil.Location = new Point(503, 720);
            btnHizmetSil.Name = "btnHizmetSil";
            btnHizmetSil.Size = new Size(94, 36);
            btnHizmetSil.TabIndex = 13;
            btnHizmetSil.Text = "SİL ";
            btnHizmetSil.UseVisualStyleBackColor = true;
            btnHizmetSil.Click += btnHizmetSil_Click;
            // 
            // cmbHizmetTuru
            // 
            cmbHizmetTuru.FormattingEnabled = true;
            cmbHizmetTuru.Location = new Point(190, 612);
            cmbHizmetTuru.Name = "cmbHizmetTuru";
            cmbHizmetTuru.Size = new Size(151, 28);
            cmbHizmetTuru.TabIndex = 10;
            cmbHizmetTuru.SelectedIndexChanged += cmbHizmetTuru_SelectedIndexChanged;
            // 
            // txtHizmetAdi
            // 
            txtHizmetAdi.Location = new Point(191, 659);
            txtHizmetAdi.Name = "txtHizmetAdi";
            txtHizmetAdi.Size = new Size(151, 27);
            txtHizmetAdi.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Brown;
            label6.Location = new Point(41, 709);
            label6.Name = "label6";
            label6.Size = new Size(144, 25);
            label6.TabIndex = 5;
            label6.Text = "Fiyat                 :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Brown;
            label3.Location = new Point(37, 658);
            label3.Name = "label3";
            label3.Size = new Size(148, 25);
            label3.TabIndex = 2;
            label3.Text = "Hizmet Adi       :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(37, 612);
            label1.Name = "label1";
            label1.Size = new Size(147, 25);
            label1.TabIndex = 0;
            label1.Text = "Hizmet Türü     :";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(btnHizmetEkle);
            groupBox2.Controls.Add(txtSeansSayisi);
            groupBox2.Controls.Add(txtSure);
            groupBox2.Controls.Add(btnHizmetGuncelle);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(btnHizmetSil);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(btnHizmetListele);
            groupBox2.Controls.Add(txtFiyat);
            groupBox2.Controls.Add(cmbHizmetTuru);
            groupBox2.Controls.Add(dgvHizmetler);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtHizmetAdi);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label6);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(630, 169);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(719, 773);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            groupBox2.Text = "Hizmetler";
            // 
            // btnHizmetEkle
            // 
            btnHizmetEkle.FlatStyle = FlatStyle.Flat;
            btnHizmetEkle.ForeColor = Color.White;
            btnHizmetEkle.Location = new Point(392, 720);
            btnHizmetEkle.Name = "btnHizmetEkle";
            btnHizmetEkle.Size = new Size(94, 36);
            btnHizmetEkle.TabIndex = 23;
            btnHizmetEkle.Text = "EKLE";
            btnHizmetEkle.UseVisualStyleBackColor = true;
            btnHizmetEkle.Click += btnHizmetEkle_Click;
            // 
            // txtSeansSayisi
            // 
            txtSeansSayisi.Location = new Point(517, 657);
            txtSeansSayisi.Name = "txtSeansSayisi";
            txtSeansSayisi.Size = new Size(151, 27);
            txtSeansSayisi.TabIndex = 22;
            // 
            // txtSure
            // 
            txtSure.Location = new Point(517, 609);
            txtSure.Name = "txtSure";
            txtSure.Size = new Size(151, 27);
            txtSure.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Brown;
            label7.Location = new Point(382, 611);
            label7.Name = "label7";
            label7.Size = new Size(130, 25);
            label7.TabIndex = 19;
            label7.Text = "Süre               :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Brown;
            label8.Location = new Point(382, 659);
            label8.Name = "label8";
            label8.Size = new Size(134, 25);
            label8.TabIndex = 20;
            label8.Text = "Seans Sayısı   :";
            // 
            // btnHizmetListele
            // 
            btnHizmetListele.BackColor = Color.RosyBrown;
            btnHizmetListele.ForeColor = Color.Brown;
            btnHizmetListele.Location = new Point(582, 33);
            btnHizmetListele.Name = "btnHizmetListele";
            btnHizmetListele.Size = new Size(117, 36);
            btnHizmetListele.TabIndex = 18;
            btnHizmetListele.Text = "LİSTELE";
            btnHizmetListele.UseVisualStyleBackColor = false;
            btnHizmetListele.Click += btnHizmetListele_Click;
            // 
            // dgvHizmetler
            // 
            dgvHizmetler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHizmetler.BackgroundColor = Color.White;
            dgvHizmetler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvHizmetler.DefaultCellStyle = dataGridViewCellStyle2;
            dgvHizmetler.Location = new Point(19, 75);
            dgvHizmetler.Name = "dgvHizmetler";
            dgvHizmetler.RowHeadersWidth = 51;
            dgvHizmetler.RowTemplate.Height = 29;
            dgvHizmetler.Size = new Size(680, 493);
            dgvHizmetler.TabIndex = 8;
            dgvHizmetler.CellContentClick += dgvHizmetler_CellContentClick;
            dgvHizmetler.SelectionChanged += dgvHizmetler_SelectionChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(216, 37);
            label5.Name = "label5";
            label5.Size = new Size(0, 25);
            label5.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Brown;
            label4.Location = new Point(19, 37);
            label4.Name = "label4";
            label4.Size = new Size(191, 25);
            label4.TabIndex = 6;
            label4.Text = "Seçili Hizmet Türü    :";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(nURandevuOrani);
            groupBox3.Controls.Add(btnUrunListele);
            groupBox3.Controls.Add(btnHzmUrunEkle);
            groupBox3.Controls.Add(btnHmzUrunGunclle);
            groupBox3.Controls.Add(btnHzmUrunSil);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(nUMiktar);
            groupBox3.Controls.Add(cmbUrun);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(dgvHizmetUrunleri);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(1367, 169);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(563, 773);
            groupBox3.TabIndex = 19;
            groupBox3.TabStop = false;
            groupBox3.Text = "Hizmet Ürünler";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.Brown;
            label13.Location = new Point(324, 600);
            label13.Name = "label13";
            label13.Size = new Size(239, 50);
            label13.TabIndex = 29;
            label13.Text = "  Ürün Kullanım Oranı\r\n ( Kaç seansta ürün biter ) :\r\n";
            // 
            // nURandevuOrani
            // 
            nURandevuOrani.Location = new Point(356, 658);
            nURandevuOrani.Name = "nURandevuOrani";
            nURandevuOrani.Size = new Size(150, 27);
            nURandevuOrani.TabIndex = 28;
            // 
            // btnUrunListele
            // 
            btnUrunListele.BackColor = Color.RosyBrown;
            btnUrunListele.ForeColor = Color.Brown;
            btnUrunListele.Location = new Point(429, 32);
            btnUrunListele.Name = "btnUrunListele";
            btnUrunListele.Size = new Size(117, 36);
            btnUrunListele.TabIndex = 27;
            btnUrunListele.Text = "LİSTELE";
            btnUrunListele.UseVisualStyleBackColor = false;
            btnUrunListele.Click += btnUrunListele_Click;
            // 
            // btnHzmUrunEkle
            // 
            btnHzmUrunEkle.FlatStyle = FlatStyle.Flat;
            btnHzmUrunEkle.ForeColor = Color.White;
            btnHzmUrunEkle.Location = new Point(150, 719);
            btnHzmUrunEkle.Name = "btnHzmUrunEkle";
            btnHzmUrunEkle.Size = new Size(94, 36);
            btnHzmUrunEkle.TabIndex = 26;
            btnHzmUrunEkle.Text = "EKLE";
            btnHzmUrunEkle.UseVisualStyleBackColor = true;
            btnHzmUrunEkle.Click += btnHzmUrunEkle_Click;
            // 
            // btnHmzUrunGunclle
            // 
            btnHmzUrunGunclle.FlatStyle = FlatStyle.Flat;
            btnHmzUrunGunclle.ForeColor = Color.White;
            btnHmzUrunGunclle.Location = new Point(376, 719);
            btnHmzUrunGunclle.Name = "btnHmzUrunGunclle";
            btnHmzUrunGunclle.Size = new Size(94, 36);
            btnHmzUrunGunclle.TabIndex = 25;
            btnHmzUrunGunclle.Text = "GÜNCELLE";
            btnHmzUrunGunclle.UseVisualStyleBackColor = true;
            btnHmzUrunGunclle.Click += btnHmzUrunGunclle_Click;
            // 
            // btnHzmUrunSil
            // 
            btnHzmUrunSil.FlatStyle = FlatStyle.Flat;
            btnHzmUrunSil.ForeColor = Color.White;
            btnHzmUrunSil.Location = new Point(261, 719);
            btnHzmUrunSil.Name = "btnHzmUrunSil";
            btnHzmUrunSil.Size = new Size(94, 36);
            btnHzmUrunSil.TabIndex = 24;
            btnHzmUrunSil.Text = "SİL ";
            btnHzmUrunSil.UseVisualStyleBackColor = true;
            btnHzmUrunSil.Click += btnHzmUrunSil_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.Brown;
            label12.Location = new Point(45, 661);
            label12.Name = "label12";
            label12.Size = new Size(79, 25);
            label12.TabIndex = 14;
            label12.Text = "Miktar :";
            // 
            // nUMiktar
            // 
            nUMiktar.Location = new Point(137, 662);
            nUMiktar.Name = "nUMiktar";
            nUMiktar.Size = new Size(150, 27);
            nUMiktar.TabIndex = 13;
            // 
            // cmbUrun
            // 
            cmbUrun.FormattingEnabled = true;
            cmbUrun.Location = new Point(137, 608);
            cmbUrun.Name = "cmbUrun";
            cmbUrun.Size = new Size(151, 28);
            cmbUrun.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.Brown;
            label11.Location = new Point(45, 611);
            label11.Name = "label11";
            label11.Size = new Size(74, 25);
            label11.TabIndex = 11;
            label11.Text = " Ürün  :";
            // 
            // dgvHizmetUrunleri
            // 
            dgvHizmetUrunleri.BackgroundColor = Color.White;
            dgvHizmetUrunleri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvHizmetUrunleri.DefaultCellStyle = dataGridViewCellStyle3;
            dgvHizmetUrunleri.Location = new Point(6, 75);
            dgvHizmetUrunleri.Name = "dgvHizmetUrunleri";
            dgvHizmetUrunleri.RowHeadersWidth = 51;
            dgvHizmetUrunleri.RowTemplate.Height = 29;
            dgvHizmetUrunleri.Size = new Size(540, 493);
            dgvHizmetUrunleri.TabIndex = 9;
            dgvHizmetUrunleri.SelectionChanged += dgvHizmetUrunleri_SelectionChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(150, 37);
            label10.Name = "label10";
            label10.Size = new Size(0, 25);
            label10.TabIndex = 8;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Brown;
            label9.Location = new Point(17, 36);
            label9.Name = "label9";
            label9.Size = new Size(133, 25);
            label9.TabIndex = 7;
            label9.Text = "Seçili Hizmet :";
            // 
            // btnKapat
            // 
            btnKapat.BackColor = Color.Transparent;
            btnKapat.FlatStyle = FlatStyle.Popup;
            btnKapat.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnKapat.Location = new Point(1836, 12);
            btnKapat.Name = "btnKapat";
            btnKapat.Size = new Size(77, 56);
            btnKapat.TabIndex = 21;
            btnKapat.Text = "X";
            btnKapat.UseVisualStyleBackColor = false;
            btnKapat.Click += btnKapat_Click;
            // 
            // HizmetYonetim
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Zeynep_turan;
            ClientSize = new Size(1942, 991);
            Controls.Add(btnKapat);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HizmetYonetim";
            Text = "HizmetYonetim";
            WindowState = FormWindowState.Maximized;
            Load += HizmetYonetim_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHizmetTurleri).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHizmetler).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nURandevuOrani).EndInit();
            ((System.ComponentModel.ISupportInitialize)nUMiktar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHizmetUrunleri).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Button btnHizmetGuncelle;
        private Button btnHizmetSil;
        private Button btnTurEkle;
        private ComboBox cmbHizmetTuru;
        private TextBox txtHizmetAdi;
        private Label label6;
        private Label label3;
        private Label label1;
        private TextBox txtFiyat;
        private Button btnTurListele;
        private Button btnTurSil;
        private Button btnTurGuncelle;
        private TextBox txtHizmetTuru;
        private Label label2;
        private GroupBox groupBox2;
        private Label label5;
        private Label label4;
        private DataGridView dgvHizmetler;
        private Button btnHizmetListele;
        private Button btnHizmetEkle;
        private TextBox txtSeansSayisi;
        private TextBox txtSure;
        private Label label7;
        private Label label8;
        private GroupBox groupBox3;
        private Button btnHzmUrunEkle;
        private Button btnHmzUrunGunclle;
        private Button btnHzmUrunSil;
        private Label label12;
        private NumericUpDown nUMiktar;
        private ComboBox cmbUrun;
        private Label label11;
        private DataGridView dgvHizmetUrunleri;
        private Label label10;
        private Label label9;
        private Button btnKapat;
        private DataGridView dgvHizmetTurleri;
        private Button btnUrunListele;
        private Label label13;
        private NumericUpDown nURandevuOrani;
        private TextBox txtAra;
        private Label label14;
        private Button btnAra;
    }
}