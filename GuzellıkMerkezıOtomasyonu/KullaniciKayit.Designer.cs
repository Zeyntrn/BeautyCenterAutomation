namespace GuzellıkMerkezıOtomasyonu
{
    partial class KullaniciKayit
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
            label7 = new Label();
            btnEkle = new Button();
            txtSifre = new TextBox();
            cmbKullaniciTur = new ComboBox();
            maskedTelefon = new MaskedTextBox();
            txtKullaniciAdi = new TextBox();
            txtMail = new TextBox();
            txtAd = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            checkedListUzmanlik = new CheckedListBox();
            btnKapat = new Button();
            label8 = new Label();
            txtSoyad = new TextBox();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Brown;
            label7.Location = new Point(118, 431);
            label7.Name = "label7";
            label7.Size = new Size(151, 25);
            label7.TabIndex = 16;
            label7.Text = "Uzmanlık Alanı :";
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.RosyBrown;
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEkle.ForeColor = Color.White;
            btnEkle.Location = new Point(210, 614);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(133, 44);
            btnEkle.TabIndex = 12;
            btnEkle.Text = "KAYIT OL";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += btnEkle_Click;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(275, 383);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(169, 27);
            txtSifre.TabIndex = 11;
            // 
            // cmbKullaniciTur
            // 
            cmbKullaniciTur.FormattingEnabled = true;
            cmbKullaniciTur.Items.AddRange(new object[] { "Yönetici ", "Personel" });
            cmbKullaniciTur.Location = new Point(275, 337);
            cmbKullaniciTur.Name = "cmbKullaniciTur";
            cmbKullaniciTur.Size = new Size(169, 28);
            cmbKullaniciTur.TabIndex = 10;
            // 
            // maskedTelefon
            // 
            maskedTelefon.Location = new Point(275, 183);
            maskedTelefon.Mask = "(999) 000-0000";
            maskedTelefon.Name = "maskedTelefon";
            maskedTelefon.Size = new Size(169, 27);
            maskedTelefon.TabIndex = 9;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(275, 283);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(169, 27);
            txtKullaniciAdi.TabIndex = 8;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(275, 232);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(169, 27);
            txtMail.TabIndex = 7;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(275, 94);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(169, 27);
            txtAd.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Brown;
            label6.Location = new Point(121, 383);
            label6.Name = "label6";
            label6.Size = new Size(151, 25);
            label6.TabIndex = 5;
            label6.Text = "Şifre                   :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Brown;
            label5.Location = new Point(118, 336);
            label5.Name = "label5";
            label5.Size = new Size(153, 25);
            label5.TabIndex = 4;
            label5.Text = "Kullanıcı Türü    :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Brown;
            label4.Location = new Point(118, 285);
            label4.Name = "label4";
            label4.Size = new Size(149, 25);
            label4.TabIndex = 3;
            label4.Text = "Kullanıcı Adı     :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Brown;
            label3.Location = new Point(118, 231);
            label3.Name = "label3";
            label3.Size = new Size(147, 25);
            label3.TabIndex = 2;
            label3.Text = "E-mail               :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Brown;
            label2.Location = new Point(118, 182);
            label2.Name = "label2";
            label2.Size = new Size(139, 25);
            label2.TabIndex = 1;
            label2.Text = "Telefon            :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(121, 94);
            label1.Name = "label1";
            label1.Size = new Size(136, 25);
            label1.TabIndex = 0;
            label1.Text = "Ad                   :";
            // 
            // checkedListUzmanlik
            // 
            checkedListUzmanlik.FormattingEnabled = true;
            checkedListUzmanlik.Location = new Point(275, 435);
            checkedListUzmanlik.Name = "checkedListUzmanlik";
            checkedListUzmanlik.Size = new Size(169, 136);
            checkedListUzmanlik.TabIndex = 17;
            // 
            // btnKapat
            // 
            btnKapat.BackColor = Color.Transparent;
            btnKapat.FlatStyle = FlatStyle.Flat;
            btnKapat.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnKapat.ForeColor = Color.White;
            btnKapat.Location = new Point(512, 12);
            btnKapat.Name = "btnKapat";
            btnKapat.Size = new Size(40, 35);
            btnKapat.TabIndex = 23;
            btnKapat.Text = "X";
            btnKapat.UseVisualStyleBackColor = false;
            btnKapat.Click += btnKapat_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Brown;
            label8.Location = new Point(123, 137);
            label8.Name = "label8";
            label8.Size = new Size(134, 25);
            label8.TabIndex = 24;
            label8.Text = "Soyad             :";
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(275, 135);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(169, 27);
            txtSoyad.TabIndex = 25;
            // 
            // KullaniciKayit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            ClientSize = new Size(564, 704);
            Controls.Add(txtSoyad);
            Controls.Add(label8);
            Controls.Add(btnKapat);
            Controls.Add(checkedListUzmanlik);
            Controls.Add(label7);
            Controls.Add(txtSifre);
            Controls.Add(cmbKullaniciTur);
            Controls.Add(btnEkle);
            Controls.Add(maskedTelefon);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(label4);
            Controls.Add(txtMail);
            Controls.Add(label1);
            Controls.Add(txtAd);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label5);
            FormBorderStyle = FormBorderStyle.None;
            Name = "KullaniciKayit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KullaniciKayit";
            Load += KullaniciKayit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label7;
        private Button btnEkle;
        private TextBox txtSifre;
        private ComboBox cmbKullaniciTur;
        private MaskedTextBox maskedTelefon;
        private TextBox txtKullaniciAdi;
        private TextBox txtMail;
        private TextBox txtAd;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckedListBox checkedListUzmanlik;
        private Button btnKapat;
        private Label label8;
        private TextBox txtSoyad;
    }
}