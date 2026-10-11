namespace GuzellıkMerkezıOtomasyonu
{
    partial class Randevular
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            dgvRandevular = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            maskedTextBoxTelefon = new MaskedTextBox();
            dateTimePickerRandevuTrh = new DateTimePicker();
            cmbHizmetTuru = new ComboBox();
            cmbSaatSec = new ComboBox();
            groupBox1 = new GroupBox();
            lblSeans = new Label();
            label12 = new Label();
            label7 = new Label();
            cmbHizmetAdi = new ComboBox();
            label5 = new Label();
            cmbPersonelSec = new ComboBox();
            btnRandevuİptal = new Button();
            btnRandevuGuncelle = new Button();
            btnRandevuEkle = new Button();
            groupBox2 = new GroupBox();
            btnYeniMusteriEkle = new Button();
            cmbMusteriSec = new ComboBox();
            label6 = new Label();
            grpYeniMusteri = new GroupBox();
            datetimeDogumTrh = new DateTimePicker();
            label9 = new Label();
            txtSoyad = new TextBox();
            label8 = new Label();
            mskTelefon = new MaskedTextBox();
            txtMail = new TextBox();
            label10 = new Label();
            txtAd = new TextBox();
            label11 = new Label();
            label14 = new Label();
            btnEkle = new Button();
            btnRandevuTamam = new Button();
            btnKapat = new Button();
            rbtnOdemeOnay = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRandevular).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            grpYeniMusteri.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Zeynep_turan__1_;
            pictureBox1.Location = new Point(0, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(268, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // dgvRandevular
            // 
            dgvRandevular.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvRandevular.BackgroundColor = Color.White;
            dgvRandevular.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRandevular.DefaultCellStyle = dataGridViewCellStyle2;
            dgvRandevular.Location = new Point(926, 260);
            dgvRandevular.Name = "dgvRandevular";
            dgvRandevular.RowHeadersWidth = 51;
            dgvRandevular.RowTemplate.Height = 29;
            dgvRandevular.Size = new Size(971, 580);
            dgvRandevular.TabIndex = 2;
            dgvRandevular.SelectionChanged += dgvRandevular_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(6, 39);
            label1.Name = "label1";
            label1.Size = new Size(170, 23);
            label1.TabIndex = 3;
            label1.Text = "Müşteri Telefon No : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Brown;
            label2.Location = new Point(8, 108);
            label2.Name = "label2";
            label2.Size = new Size(168, 23);
            label2.TabIndex = 4;
            label2.Text = "Hizmet Türü           : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Brown;
            label3.Location = new Point(6, 300);
            label3.Name = "label3";
            label3.Size = new Size(172, 23);
            label3.TabIndex = 5;
            label3.Text = "Randevu Tarihi        : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Brown;
            label4.Location = new Point(4, 363);
            label4.Name = "label4";
            label4.Size = new Size(169, 23);
            label4.TabIndex = 6;
            label4.Text = "Randevu Saati        : ";
            // 
            // maskedTextBoxTelefon
            // 
            maskedTextBoxTelefon.Location = new Point(182, 35);
            maskedTextBoxTelefon.Mask = "(999) 000-0000";
            maskedTextBoxTelefon.Name = "maskedTextBoxTelefon";
            maskedTextBoxTelefon.Size = new Size(170, 27);
            maskedTextBoxTelefon.TabIndex = 7;
            // 
            // dateTimePickerRandevuTrh
            // 
            dateTimePickerRandevuTrh.Location = new Point(180, 297);
            dateTimePickerRandevuTrh.Name = "dateTimePickerRandevuTrh";
            dateTimePickerRandevuTrh.Size = new Size(170, 27);
            dateTimePickerRandevuTrh.TabIndex = 8;
            dateTimePickerRandevuTrh.ValueChanged += dateTimePickerRandevuTrh_ValueChanged;
            // 
            // cmbHizmetTuru
            // 
            cmbHizmetTuru.FormattingEnabled = true;
            cmbHizmetTuru.Location = new Point(182, 108);
            cmbHizmetTuru.Name = "cmbHizmetTuru";
            cmbHizmetTuru.Size = new Size(170, 28);
            cmbHizmetTuru.TabIndex = 9;
            cmbHizmetTuru.SelectedIndexChanged += cmbHizmetTuru_SelectedIndexChanged;
            // 
            // cmbSaatSec
            // 
            cmbSaatSec.FormattingEnabled = true;
            cmbSaatSec.Location = new Point(182, 358);
            cmbSaatSec.Name = "cmbSaatSec";
            cmbSaatSec.Size = new Size(170, 28);
            cmbSaatSec.TabIndex = 10;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(lblSeans);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cmbHizmetAdi);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cmbPersonelSec);
            groupBox1.Controls.Add(btnRandevuİptal);
            groupBox1.Controls.Add(btnRandevuGuncelle);
            groupBox1.Controls.Add(btnRandevuEkle);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbSaatSec);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbHizmetTuru);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dateTimePickerRandevuTrh);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(maskedTextBoxTelefon);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(496, 260);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(396, 580);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Randevu Oluştur";
            // 
            // lblSeans
            // 
            lblSeans.AutoSize = true;
            lblSeans.Location = new Point(192, 428);
            lblSeans.Name = "lblSeans";
            lblSeans.Size = new Size(58, 20);
            lblSeans.TabIndex = 19;
            lblSeans.Text = "label13";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.Brown;
            label12.Location = new Point(6, 424);
            label12.Name = "label12";
            label12.Size = new Size(163, 23);
            label12.TabIndex = 18;
            label12.Text = "Seans                    : ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Brown;
            label7.Location = new Point(6, 172);
            label7.Name = "label7";
            label7.Size = new Size(164, 23);
            label7.TabIndex = 16;
            label7.Text = "Hizmet Adı            : ";
            // 
            // cmbHizmetAdi
            // 
            cmbHizmetAdi.FormattingEnabled = true;
            cmbHizmetAdi.Location = new Point(180, 171);
            cmbHizmetAdi.Name = "cmbHizmetAdi";
            cmbHizmetAdi.Size = new Size(170, 28);
            cmbHizmetAdi.TabIndex = 17;
            cmbHizmetAdi.SelectedIndexChanged += cmbHizmetAdi_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Brown;
            label5.Location = new Point(6, 235);
            label5.Name = "label5";
            label5.Size = new Size(167, 23);
            label5.TabIndex = 14;
            label5.Text = "Personel Seçimi      : ";
            // 
            // cmbPersonelSec
            // 
            cmbPersonelSec.FormattingEnabled = true;
            cmbPersonelSec.Location = new Point(180, 235);
            cmbPersonelSec.Name = "cmbPersonelSec";
            cmbPersonelSec.Size = new Size(170, 28);
            cmbPersonelSec.TabIndex = 15;
            cmbPersonelSec.SelectedIndexChanged += cmbPersonelSec_SelectedIndexChanged;
            // 
            // btnRandevuİptal
            // 
            btnRandevuİptal.FlatStyle = FlatStyle.Flat;
            btnRandevuİptal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRandevuİptal.ForeColor = Color.White;
            btnRandevuİptal.Location = new Point(147, 482);
            btnRandevuİptal.Name = "btnRandevuİptal";
            btnRandevuİptal.Size = new Size(103, 62);
            btnRandevuİptal.TabIndex = 13;
            btnRandevuİptal.Text = "Randevu İptal";
            btnRandevuİptal.UseVisualStyleBackColor = true;
            btnRandevuİptal.Click += btnRandevuİptal_Click;
            // 
            // btnRandevuGuncelle
            // 
            btnRandevuGuncelle.FlatStyle = FlatStyle.Flat;
            btnRandevuGuncelle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRandevuGuncelle.ForeColor = Color.White;
            btnRandevuGuncelle.Location = new Point(275, 482);
            btnRandevuGuncelle.Name = "btnRandevuGuncelle";
            btnRandevuGuncelle.Size = new Size(103, 62);
            btnRandevuGuncelle.TabIndex = 12;
            btnRandevuGuncelle.Text = "Randevu Güncelle";
            btnRandevuGuncelle.UseVisualStyleBackColor = true;
            btnRandevuGuncelle.Click += btnRandevuGuncelle_Click;
            // 
            // btnRandevuEkle
            // 
            btnRandevuEkle.FlatStyle = FlatStyle.Flat;
            btnRandevuEkle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRandevuEkle.ForeColor = Color.White;
            btnRandevuEkle.Location = new Point(18, 482);
            btnRandevuEkle.Name = "btnRandevuEkle";
            btnRandevuEkle.Size = new Size(100, 62);
            btnRandevuEkle.TabIndex = 11;
            btnRandevuEkle.Text = "Randevu Kaydet";
            btnRandevuEkle.UseVisualStyleBackColor = true;
            btnRandevuEkle.Click += btnRandevuEkle_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(btnYeniMusteriEkle);
            groupBox2.Controls.Add(cmbMusteriSec);
            groupBox2.Controls.Add(label6);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(32, 260);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(431, 195);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Müşteri Kayıt ";
            // 
            // btnYeniMusteriEkle
            // 
            btnYeniMusteriEkle.BackColor = Color.RosyBrown;
            btnYeniMusteriEkle.ForeColor = Color.Brown;
            btnYeniMusteriEkle.Location = new Point(59, 112);
            btnYeniMusteriEkle.Name = "btnYeniMusteriEkle";
            btnYeniMusteriEkle.Size = new Size(289, 42);
            btnYeniMusteriEkle.TabIndex = 14;
            btnYeniMusteriEkle.Text = "YENİ MÜŞTERİ EKLE";
            btnYeniMusteriEkle.UseVisualStyleBackColor = false;
            btnYeniMusteriEkle.Click += btnYeniMusteriEkle_Click;
            // 
            // cmbMusteriSec
            // 
            cmbMusteriSec.FormattingEnabled = true;
            cmbMusteriSec.Location = new Point(178, 61);
            cmbMusteriSec.Name = "cmbMusteriSec";
            cmbMusteriSec.Size = new Size(170, 28);
            cmbMusteriSec.TabIndex = 10;
            cmbMusteriSec.SelectedIndexChanged += cmbMusteriSec_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Brown;
            label6.Location = new Point(59, 62);
            label6.Name = "label6";
            label6.Size = new Size(113, 23);
            label6.TabIndex = 4;
            label6.Text = "Müşteri Seç : ";
            // 
            // grpYeniMusteri
            // 
            grpYeniMusteri.BackColor = Color.Transparent;
            grpYeniMusteri.Controls.Add(datetimeDogumTrh);
            grpYeniMusteri.Controls.Add(label9);
            grpYeniMusteri.Controls.Add(txtSoyad);
            grpYeniMusteri.Controls.Add(label8);
            grpYeniMusteri.Controls.Add(mskTelefon);
            grpYeniMusteri.Controls.Add(txtMail);
            grpYeniMusteri.Controls.Add(label10);
            grpYeniMusteri.Controls.Add(txtAd);
            grpYeniMusteri.Controls.Add(label11);
            grpYeniMusteri.Controls.Add(label14);
            grpYeniMusteri.Controls.Add(btnEkle);
            grpYeniMusteri.Location = new Point(32, 526);
            grpYeniMusteri.Name = "grpYeniMusteri";
            grpYeniMusteri.Size = new Size(431, 367);
            grpYeniMusteri.TabIndex = 15;
            grpYeniMusteri.TabStop = false;
            // 
            // datetimeDogumTrh
            // 
            datetimeDogumTrh.Location = new Point(225, 241);
            datetimeDogumTrh.Name = "datetimeDogumTrh";
            datetimeDogumTrh.Size = new Size(150, 27);
            datetimeDogumTrh.TabIndex = 43;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Brown;
            label9.Location = new Point(58, 241);
            label9.Name = "label9";
            label9.Size = new Size(142, 25);
            label9.TabIndex = 42;
            label9.Text = "Doğum Tarihi  :";
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(224, 100);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(151, 27);
            txtSoyad.TabIndex = 41;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Brown;
            label8.Location = new Point(58, 99);
            label8.Name = "label8";
            label8.Size = new Size(139, 25);
            label8.TabIndex = 40;
            label8.Text = "Soyad              :";
            // 
            // mskTelefon
            // 
            mskTelefon.Location = new Point(224, 146);
            mskTelefon.Mask = "(999) 000-0000";
            mskTelefon.Name = "mskTelefon";
            mskTelefon.Size = new Size(151, 27);
            mskTelefon.TabIndex = 39;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(224, 191);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(151, 27);
            txtMail.TabIndex = 38;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Brown;
            label10.Location = new Point(59, 57);
            label10.Name = "label10";
            label10.Size = new Size(136, 25);
            label10.TabIndex = 34;
            label10.Text = "Ad                   :";
            // 
            // txtAd
            // 
            txtAd.Location = new Point(224, 55);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(151, 27);
            txtAd.TabIndex = 37;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.Brown;
            label11.Location = new Point(58, 145);
            label11.Name = "label11";
            label11.Size = new Size(139, 25);
            label11.TabIndex = 35;
            label11.Text = "Telefon            :";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.Brown;
            label14.Location = new Point(59, 193);
            label14.Name = "label14";
            label14.Size = new Size(142, 25);
            label14.TabIndex = 36;
            label14.Text = "E-mail              :";
            // 
            // btnEkle
            // 
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.ForeColor = Color.White;
            btnEkle.Location = new Point(160, 309);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(94, 36);
            btnEkle.TabIndex = 29;
            btnEkle.Text = "EKLE ";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnRandevuTamam
            // 
            btnRandevuTamam.BackColor = Color.Transparent;
            btnRandevuTamam.FlatStyle = FlatStyle.Flat;
            btnRandevuTamam.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnRandevuTamam.ForeColor = Color.Brown;
            btnRandevuTamam.Location = new Point(1392, 860);
            btnRandevuTamam.Name = "btnRandevuTamam";
            btnRandevuTamam.Size = new Size(277, 47);
            btnRandevuTamam.TabIndex = 16;
            btnRandevuTamam.Text = "Randevu Tamamlandı";
            btnRandevuTamam.UseVisualStyleBackColor = false;
            btnRandevuTamam.Click += btnRandevuTamam_Click;
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
            // rbtnOdemeOnay
            // 
            rbtnOdemeOnay.AutoSize = true;
            rbtnOdemeOnay.BackColor = Color.Transparent;
            rbtnOdemeOnay.Location = new Point(1100, 873);
            rbtnOdemeOnay.Name = "rbtnOdemeOnay";
            rbtnOdemeOnay.Size = new Size(270, 24);
            rbtnOdemeOnay.TabIndex = 22;
            rbtnOdemeOnay.TabStop = true;
            rbtnOdemeOnay.Text = "Ödeme alındı, işlem tamamlanabilir.";
            rbtnOdemeOnay.UseVisualStyleBackColor = false;
            // 
            // Randevular
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Zeynep_turan;
            ClientSize = new Size(1942, 991);
            Controls.Add(rbtnOdemeOnay);
            Controls.Add(btnKapat);
            Controls.Add(btnRandevuTamam);
            Controls.Add(grpYeniMusteri);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvRandevular);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Randevular";
            Text = "Randevular";
            WindowState = FormWindowState.Maximized;
            Load += Randevular_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRandevular).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            grpYeniMusteri.ResumeLayout(false);
            grpYeniMusteri.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dgvRandevular;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private MaskedTextBox maskedTextBoxTelefon;
        private DateTimePicker dateTimePickerRandevuTrh;
        private ComboBox cmbHizmetTuru;
        private ComboBox cmbSaatSec;
        private GroupBox groupBox1;
        private Button btnRandevuGuncelle;
        private Button btnRandevuEkle;
        private Button btnRandevuİptal;
        private Label label5;
        private ComboBox cmbPersonelSec;
        private Label label7;
        private ComboBox cmbHizmetAdi;
        private GroupBox groupBox2;
        private Button btnYeniMusteriEkle;
        private ComboBox cmbMusteriSec;
        private Label label6;
        private GroupBox grpYeniMusteri;
        private Button btnEkle;
        private Button btnRandevuTamam;
        private Label label12;
        private Label lblSeans;
        private Button btnKapat;
        private DateTimePicker datetimeDogumTrh;
        private Label label9;
        private TextBox txtSoyad;
        private Label label8;
        private MaskedTextBox mskTelefon;
        private TextBox txtMail;
        private Label label10;
        private TextBox txtAd;
        private Label label11;
        private Label label14;
        private RadioButton rbtnOdemeOnay;
    }
}