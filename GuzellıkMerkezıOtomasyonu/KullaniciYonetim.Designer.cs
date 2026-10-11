namespace GuzellıkMerkezıOtomasyonu
{
    partial class KullaniciYonetim
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
            groupBox1 = new GroupBox();
            txtSoyad = new TextBox();
            label8 = new Label();
            checkedListUzmanlik = new CheckedListBox();
            label7 = new Label();
            btnTemizle = new Button();
            btnGuncelle = new Button();
            btnSil = new Button();
            btnEkle = new Button();
            txtSifre = new TextBox();
            cmbKullaniciTür = new ComboBox();
            msktxbTelefon = new MaskedTextBox();
            txtKullaniciAd = new TextBox();
            txtMail = new TextBox();
            txtAd = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnListele = new Button();
            btnKapat = new Button();
            txtArama = new TextBox();
            btnArama = new Button();
            dgvKullanicilar = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKullanicilar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Zeynep_turan__1_;
            pictureBox1.Location = new Point(0, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(268, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(txtSoyad);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(checkedListUzmanlik);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(btnTemizle);
            groupBox1.Controls.Add(btnGuncelle);
            groupBox1.Controls.Add(btnSil);
            groupBox1.Controls.Add(btnEkle);
            groupBox1.Controls.Add(txtSifre);
            groupBox1.Controls.Add(cmbKullaniciTür);
            groupBox1.Controls.Add(msktxbTelefon);
            groupBox1.Controls.Add(txtKullaniciAd);
            groupBox1.Controls.Add(txtMail);
            groupBox1.Controls.Add(txtAd);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(49, 196);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(489, 766);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kullanıcı İşlemleri";
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(225, 108);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(174, 27);
            txtSoyad.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Brown;
            label8.Location = new Point(69, 107);
            label8.Name = "label8";
            label8.Size = new Size(129, 25);
            label8.TabIndex = 18;
            label8.Text = "Soyad            :";
            // 
            // checkedListUzmanlik
            // 
            checkedListUzmanlik.CheckOnClick = true;
            checkedListUzmanlik.FormattingEnabled = true;
            checkedListUzmanlik.Location = new Point(218, 411);
            checkedListUzmanlik.Name = "checkedListUzmanlik";
            checkedListUzmanlik.Size = new Size(180, 158);
            checkedListUzmanlik.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Brown;
            label7.Location = new Point(61, 411);
            label7.Name = "label7";
            label7.Size = new Size(151, 25);
            label7.TabIndex = 16;
            label7.Text = "Uzmanlık Alanı :";
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = Color.RosyBrown;
            btnTemizle.ForeColor = Color.Brown;
            btnTemizle.Location = new Point(176, 703);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(150, 36);
            btnTemizle.TabIndex = 15;
            btnTemizle.Text = "TEMİZLE";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.FlatStyle = FlatStyle.Flat;
            btnGuncelle.ForeColor = Color.White;
            btnGuncelle.Location = new Point(340, 622);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(99, 51);
            btnGuncelle.TabIndex = 14;
            btnGuncelle.Text = "GÜNCELLE";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.ForeColor = Color.White;
            btnSil.Location = new Point(197, 622);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(109, 51);
            btnSil.TabIndex = 13;
            btnSil.Text = "SİL ";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnEkle
            // 
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.ForeColor = Color.White;
            btnEkle.Location = new Point(69, 622);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(98, 51);
            btnEkle.TabIndex = 12;
            btnEkle.Text = "EKLE ";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += button1_Click;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(222, 359);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(176, 27);
            txtSifre.TabIndex = 11;
            // 
            // cmbKullaniciTür
            // 
            cmbKullaniciTür.FormattingEnabled = true;
            cmbKullaniciTür.Items.AddRange(new object[] { "Yönetici ", "Personel" });
            cmbKullaniciTür.Location = new Point(222, 306);
            cmbKullaniciTür.Name = "cmbKullaniciTür";
            cmbKullaniciTür.Size = new Size(176, 28);
            cmbKullaniciTür.TabIndex = 10;
            // 
            // msktxbTelefon
            // 
            msktxbTelefon.Location = new Point(224, 158);
            msktxbTelefon.Mask = "(999) 000-0000";
            msktxbTelefon.Name = "msktxbTelefon";
            msktxbTelefon.Size = new Size(174, 27);
            msktxbTelefon.TabIndex = 9;
            // 
            // txtKullaniciAd
            // 
            txtKullaniciAd.Location = new Point(224, 258);
            txtKullaniciAd.Name = "txtKullaniciAd";
            txtKullaniciAd.Size = new Size(174, 27);
            txtKullaniciAd.TabIndex = 8;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(224, 207);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(174, 27);
            txtMail.TabIndex = 7;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(224, 57);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(174, 27);
            txtAd.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Brown;
            label6.Location = new Point(61, 361);
            label6.Name = "label6";
            label6.Size = new Size(146, 25);
            label6.TabIndex = 5;
            label6.Text = "Şifre                  :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Brown;
            label5.Location = new Point(61, 309);
            label5.Name = "label5";
            label5.Size = new Size(148, 25);
            label5.TabIndex = 4;
            label5.Text = "Kullanıcı Türü   :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Brown;
            label4.Location = new Point(61, 257);
            label4.Name = "label4";
            label4.Size = new Size(144, 25);
            label4.TabIndex = 3;
            label4.Text = "Kullanıcı Adı    :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Brown;
            label3.Location = new Point(65, 206);
            label3.Name = "label3";
            label3.Size = new Size(137, 25);
            label3.TabIndex = 2;
            label3.Text = "E-mail             :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Brown;
            label2.Location = new Point(65, 157);
            label2.Name = "label2";
            label2.Size = new Size(139, 25);
            label2.TabIndex = 1;
            label2.Text = "Telefon            :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(71, 56);
            label1.Name = "label1";
            label1.Size = new Size(136, 25);
            label1.TabIndex = 0;
            label1.Text = "Ad                   :";
            // 
            // btnListele
            // 
            btnListele.BackColor = Color.RosyBrown;
            btnListele.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnListele.ForeColor = Color.Brown;
            btnListele.Location = new Point(576, 150);
            btnListele.Name = "btnListele";
            btnListele.Size = new Size(148, 36);
            btnListele.TabIndex = 16;
            btnListele.Text = "LİSTELE";
            btnListele.UseVisualStyleBackColor = false;
            btnListele.Click += btnListele_Click;
            // 
            // btnKapat
            // 
            btnKapat.BackColor = Color.Transparent;
            btnKapat.FlatStyle = FlatStyle.Popup;
            btnKapat.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnKapat.ForeColor = Color.Black;
            btnKapat.Location = new Point(1837, 16);
            btnKapat.Name = "btnKapat";
            btnKapat.Size = new Size(77, 56);
            btnKapat.TabIndex = 22;
            btnKapat.Text = "X";
            btnKapat.UseVisualStyleBackColor = false;
            btnKapat.Click += btnKapat_Click;
            // 
            // txtArama
            // 
            txtArama.Location = new Point(1392, 155);
            txtArama.Multiline = true;
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(241, 34);
            txtArama.TabIndex = 23;
            txtArama.TextChanged += txtArama_TextChanged;
            // 
            // btnArama
            // 
            btnArama.BackColor = Color.RosyBrown;
            btnArama.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnArama.ForeColor = Color.Brown;
            btnArama.Location = new Point(1655, 153);
            btnArama.Name = "btnArama";
            btnArama.Size = new Size(111, 36);
            btnArama.TabIndex = 24;
            btnArama.Text = "ARA";
            btnArama.UseVisualStyleBackColor = false;
            btnArama.Click += btnArama_Click;
            // 
            // dgvKullanicilar
            // 
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ButtonShadow;
            dgvKullanicilar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvKullanicilar.BackgroundColor = Color.White;
            dgvKullanicilar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvKullanicilar.DefaultCellStyle = dataGridViewCellStyle2;
            dgvKullanicilar.Location = new Point(576, 211);
            dgvKullanicilar.Name = "dgvKullanicilar";
            dgvKullanicilar.RowHeadersWidth = 51;
            dgvKullanicilar.RowTemplate.Height = 29;
            dgvKullanicilar.Size = new Size(1214, 751);
            dgvKullanicilar.TabIndex = 25;
            dgvKullanicilar.SelectionChanged += dgvKullanicilar_SelectionChanged;
            // 
            // KullaniciYonetim
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Zeynep_turan;
            ClientSize = new Size(1942, 991);
            Controls.Add(dgvKullanicilar);
            Controls.Add(btnArama);
            Controls.Add(txtArama);
            Controls.Add(btnKapat);
            Controls.Add(btnListele);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "KullaniciYonetim";
            Text = "KullaniciYonetim";
            WindowState = FormWindowState.Maximized;
            Load += KullaniciYonetim_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKullanicilar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnTemizle;
        private Button btnGuncelle;
        private Button btnSil;
        private Button btnEkle;
        private TextBox txtSifre;
        private ComboBox cmbKullaniciTür;
        private MaskedTextBox msktxbTelefon;
        private TextBox txtKullaniciAd;
        private TextBox txtMail;
        private TextBox txtAd;
        private Button btnListele;
        private Label label7;
        private Button btnKapat;
        private CheckedListBox checkedListUzmanlik;
        private TextBox txtArama;
        private Button btnArama;
        private DataGridView dgvKullanicilar;
        private TextBox txtSoyad;
        private Label label8;
    }
}