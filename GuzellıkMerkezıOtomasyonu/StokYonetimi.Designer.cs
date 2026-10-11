namespace GuzellıkMerkezıOtomasyonu
{
    partial class StokYonetimi
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
            label4 = new Label();
            btnUrunListele = new Button();
            dgvUrunler = new DataGridView();
            groupBox2 = new GroupBox();
            btnStokListele = new Button();
            dgvStokHareket = new DataGridView();
            label1 = new Label();
            txtUrunAdi = new TextBox();
            txtStokMik = new TextBox();
            label2 = new Label();
            txtBirimFiyat = new TextBox();
            label3 = new Label();
            btnUrunEkle = new Button();
            btnUrunSil = new Button();
            btnUrunGuncelle = new Button();
            btnStokEkle = new Button();
            btnStokGuncelle = new Button();
            btnKapat = new Button();
            btnStokGoruntu = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUrunler).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStokHareket).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Zeynep_turan__1_;
            pictureBox1.Location = new Point(0, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(268, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnAra);
            groupBox1.Controls.Add(txtAra);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnUrunListele);
            groupBox1.Controls.Add(dgvUrunler);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(61, 175);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(563, 717);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ürünler";
            // 
            // btnAra
            // 
            btnAra.BackColor = Color.RosyBrown;
            btnAra.FlatStyle = FlatStyle.Flat;
            btnAra.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAra.ForeColor = Color.White;
            btnAra.Location = new Point(338, 26);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(53, 35);
            btnAra.TabIndex = 23;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = false;
            btnAra.Click += btnAra_Click;
            // 
            // txtAra
            // 
            txtAra.Location = new Point(144, 30);
            txtAra.Name = "txtAra";
            txtAra.Size = new Size(178, 27);
            txtAra.TabIndex = 20;
            txtAra.TextChanged += txtAra_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Brown;
            label4.Location = new Point(22, 30);
            label4.Name = "label4";
            label4.Size = new Size(116, 25);
            label4.TabIndex = 19;
            label4.Text = "Ürün Adı     :";
            // 
            // btnUrunListele
            // 
            btnUrunListele.BackColor = Color.RosyBrown;
            btnUrunListele.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUrunListele.ForeColor = Color.Brown;
            btnUrunListele.Location = new Point(426, 26);
            btnUrunListele.Name = "btnUrunListele";
            btnUrunListele.Size = new Size(85, 36);
            btnUrunListele.TabIndex = 18;
            btnUrunListele.Text = "LİSTELE";
            btnUrunListele.UseVisualStyleBackColor = false;
            btnUrunListele.Click += btnUrunListele_Click;
            // 
            // dgvUrunler
            // 
            dgvUrunler.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUrunler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUrunler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Variable Display Semib", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvUrunler.DefaultCellStyle = dataGridViewCellStyle2;
            dgvUrunler.Location = new Point(22, 75);
            dgvUrunler.Name = "dgvUrunler";
            dgvUrunler.RowHeadersWidth = 51;
            dgvUrunler.RowTemplate.Height = 29;
            dgvUrunler.Size = new Size(489, 621);
            dgvUrunler.TabIndex = 0;
            dgvUrunler.SelectionChanged += dgvUrunler_SelectionChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(btnStokListele);
            groupBox2.Controls.Add(dgvStokHareket);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(1078, 175);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(808, 717);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Stok Hareketleri";
            // 
            // btnStokListele
            // 
            btnStokListele.BackColor = Color.RosyBrown;
            btnStokListele.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnStokListele.ForeColor = Color.Brown;
            btnStokListele.Location = new Point(670, 26);
            btnStokListele.Name = "btnStokListele";
            btnStokListele.Size = new Size(117, 36);
            btnStokListele.TabIndex = 18;
            btnStokListele.Text = "LİSTELE";
            btnStokListele.UseVisualStyleBackColor = false;
            btnStokListele.Click += btnStokListele_Click;
            // 
            // dgvStokHareket
            // 
            dgvStokHareket.BackgroundColor = Color.White;
            dgvStokHareket.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvStokHareket.DefaultCellStyle = dataGridViewCellStyle3;
            dgvStokHareket.Location = new Point(22, 75);
            dgvStokHareket.Name = "dgvStokHareket";
            dgvStokHareket.RowHeadersWidth = 51;
            dgvStokHareket.RowTemplate.Height = 29;
            dgvStokHareket.Size = new Size(765, 621);
            dgvStokHareket.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(696, 260);
            label1.Name = "label1";
            label1.Size = new Size(116, 25);
            label1.TabIndex = 6;
            label1.Text = "Ürün Adı     :";
            // 
            // txtUrunAdi
            // 
            txtUrunAdi.Location = new Point(818, 260);
            txtUrunAdi.Name = "txtUrunAdi";
            txtUrunAdi.Size = new Size(178, 27);
            txtUrunAdi.TabIndex = 7;
            // 
            // txtStokMik
            // 
            txtStokMik.Location = new Point(818, 496);
            txtStokMik.Name = "txtStokMik";
            txtStokMik.Size = new Size(178, 27);
            txtStokMik.TabIndex = 9;
            txtStokMik.KeyPress += txtStokMik_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Brown;
            label2.Location = new Point(696, 495);
            label2.Name = "label2";
            label2.Size = new Size(121, 25);
            label2.TabIndex = 8;
            label2.Text = "Stok Miktarı :";
            // 
            // txtBirimFiyat
            // 
            txtBirimFiyat.Location = new Point(818, 305);
            txtBirimFiyat.Name = "txtBirimFiyat";
            txtBirimFiyat.Size = new Size(180, 27);
            txtBirimFiyat.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Brown;
            label3.Location = new Point(696, 304);
            label3.Name = "label3";
            label3.Size = new Size(114, 25);
            label3.TabIndex = 10;
            label3.Text = "Birim Fiyatı :";
            // 
            // btnUrunEkle
            // 
            btnUrunEkle.BackColor = Color.RosyBrown;
            btnUrunEkle.FlatStyle = FlatStyle.Flat;
            btnUrunEkle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUrunEkle.ForeColor = Color.White;
            btnUrunEkle.Location = new Point(648, 380);
            btnUrunEkle.Name = "btnUrunEkle";
            btnUrunEkle.Size = new Size(94, 53);
            btnUrunEkle.TabIndex = 12;
            btnUrunEkle.Text = "Ürün Ekle ";
            btnUrunEkle.UseVisualStyleBackColor = false;
            btnUrunEkle.Click += btnUrunEkle_Click;
            // 
            // btnUrunSil
            // 
            btnUrunSil.BackColor = Color.RosyBrown;
            btnUrunSil.FlatStyle = FlatStyle.Flat;
            btnUrunSil.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUrunSil.ForeColor = Color.White;
            btnUrunSil.Location = new Point(790, 380);
            btnUrunSil.Name = "btnUrunSil";
            btnUrunSil.Size = new Size(94, 53);
            btnUrunSil.TabIndex = 13;
            btnUrunSil.Text = "Ürün Sil";
            btnUrunSil.UseVisualStyleBackColor = false;
            btnUrunSil.Click += btnUrunSil_Click;
            // 
            // btnUrunGuncelle
            // 
            btnUrunGuncelle.BackColor = Color.RosyBrown;
            btnUrunGuncelle.FlatStyle = FlatStyle.Flat;
            btnUrunGuncelle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUrunGuncelle.ForeColor = Color.White;
            btnUrunGuncelle.Location = new Point(939, 380);
            btnUrunGuncelle.Name = "btnUrunGuncelle";
            btnUrunGuncelle.Size = new Size(94, 53);
            btnUrunGuncelle.TabIndex = 14;
            btnUrunGuncelle.Text = "Ürün Güncelle";
            btnUrunGuncelle.UseVisualStyleBackColor = false;
            btnUrunGuncelle.Click += btnUrunGuncelle_Click;
            // 
            // btnStokEkle
            // 
            btnStokEkle.BackColor = Color.Transparent;
            btnStokEkle.FlatStyle = FlatStyle.Flat;
            btnStokEkle.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnStokEkle.ForeColor = Color.Brown;
            btnStokEkle.Location = new Point(726, 576);
            btnStokEkle.Name = "btnStokEkle";
            btnStokEkle.Size = new Size(87, 62);
            btnStokEkle.TabIndex = 15;
            btnStokEkle.Text = "Stok Ekle";
            btnStokEkle.UseVisualStyleBackColor = false;
            btnStokEkle.Click += btnStokEkle_Click;
            // 
            // btnStokGuncelle
            // 
            btnStokGuncelle.BackColor = Color.Transparent;
            btnStokGuncelle.FlatStyle = FlatStyle.Flat;
            btnStokGuncelle.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnStokGuncelle.ForeColor = Color.Brown;
            btnStokGuncelle.Location = new Point(871, 576);
            btnStokGuncelle.Name = "btnStokGuncelle";
            btnStokGuncelle.Size = new Size(87, 62);
            btnStokGuncelle.TabIndex = 16;
            btnStokGuncelle.Text = "Stok Güncelle";
            btnStokGuncelle.UseVisualStyleBackColor = false;
            btnStokGuncelle.Click += btnStokGuncelle_Click;
            // 
            // btnKapat
            // 
            btnKapat.BackColor = Color.Transparent;
            btnKapat.FlatStyle = FlatStyle.Popup;
            btnKapat.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnKapat.Location = new Point(1840, 12);
            btnKapat.Name = "btnKapat";
            btnKapat.Size = new Size(77, 56);
            btnKapat.TabIndex = 21;
            btnKapat.Text = "X";
            btnKapat.UseVisualStyleBackColor = false;
            btnKapat.Click += btnKapat_Click;
            // 
            // btnStokGoruntu
            // 
            btnStokGoruntu.BackColor = Color.RosyBrown;
            btnStokGoruntu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnStokGoruntu.ForeColor = Color.Brown;
            btnStokGoruntu.Location = new Point(684, 707);
            btnStokGoruntu.Name = "btnStokGoruntu";
            btnStokGoruntu.Size = new Size(327, 55);
            btnStokGoruntu.TabIndex = 22;
            btnStokGoruntu.Text = "STOKLARI GÖRÜNTÜLE";
            btnStokGoruntu.UseVisualStyleBackColor = false;
            btnStokGoruntu.Click += btnStokGoruntu_Click;
            // 
            // StokYonetimi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Zeynep_turan;
            ClientSize = new Size(1942, 944);
            Controls.Add(btnStokGoruntu);
            Controls.Add(btnKapat);
            Controls.Add(btnStokGuncelle);
            Controls.Add(btnStokEkle);
            Controls.Add(btnUrunGuncelle);
            Controls.Add(btnUrunSil);
            Controls.Add(btnUrunEkle);
            Controls.Add(txtBirimFiyat);
            Controls.Add(label3);
            Controls.Add(txtStokMik);
            Controls.Add(label2);
            Controls.Add(txtUrunAdi);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StokYonetimi";
            Text = "StokYonetimi";
            WindowState = FormWindowState.Maximized;
            Load += StokYonetimi_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUrunler).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStokHareket).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private DataGridView dgvUrunler;
        private GroupBox groupBox2;
        private DataGridView dgvStokHareket;
        private Label label1;
        private TextBox txtUrunAdi;
        private TextBox txtStokMik;
        private Label label2;
        private TextBox txtBirimFiyat;
        private Label label3;
        private Button btnUrunEkle;
        private Button btnUrunSil;
        private Button btnUrunGuncelle;
        private Button btnStokEkle;
        private Button btnStokGuncelle;
        private Button btnStokListele;
        private Button btnUrunListele;
        private Button btnKapat;
        private Button btnStokGoruntu;
        private Button btnAra;
        private TextBox txtAra;
        private Label label4;
    }
}