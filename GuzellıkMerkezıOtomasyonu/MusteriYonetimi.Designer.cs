namespace GuzellıkMerkezıOtomasyonu
{
    partial class MusteriYonetimi
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            btnTemizle = new Button();
            btnEkle = new Button();
            datetimeDogumTrh = new DateTimePicker();
            label9 = new Label();
            btnGuncelle = new Button();
            label8 = new Label();
            btnSil = new Button();
            txtSoyad = new TextBox();
            btnAra = new Button();
            label5 = new Label();
            txtAra = new TextBox();
            mskTelefon = new MaskedTextBox();
            dgvMusteriler = new DataGridView();
            txtMail = new TextBox();
            label4 = new Label();
            txtAd = new TextBox();
            label2 = new Label();
            label3 = new Label();
            groupBox3 = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            label1 = new Label();
            dgvTaksitler = new DataGridView();
            dgvOdemeler = new DataGridView();
            dgvRandevular = new DataGridView();
            btnKapat = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaksitler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOdemeler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRandevular).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Zeynep_turan__1_;
            pictureBox1.Location = new Point(1, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(268, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnTemizle);
            groupBox1.Controls.Add(btnEkle);
            groupBox1.Controls.Add(datetimeDogumTrh);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(btnGuncelle);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(btnSil);
            groupBox1.Controls.Add(txtSoyad);
            groupBox1.Controls.Add(btnAra);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtAra);
            groupBox1.Controls.Add(mskTelefon);
            groupBox1.Controls.Add(dgvMusteriler);
            groupBox1.Controls.Add(txtMail);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtAd);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(108, 122);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1734, 455);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Müşteri Listesi";
            // 
            // btnTemizle
            // 
            btnTemizle.FlatStyle = FlatStyle.Flat;
            btnTemizle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnTemizle.ForeColor = Color.White;
            btnTemizle.Location = new Point(1267, 387);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(91, 36);
            btnTemizle.TabIndex = 35;
            btnTemizle.Text = "TEMİZLE";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnEkle
            // 
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEkle.ForeColor = Color.White;
            btnEkle.Location = new Point(882, 387);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(94, 36);
            btnEkle.TabIndex = 34;
            btnEkle.Text = "EKLE";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // datetimeDogumTrh
            // 
            datetimeDogumTrh.Location = new Point(1100, 328);
            datetimeDogumTrh.Name = "datetimeDogumTrh";
            datetimeDogumTrh.Size = new Size(150, 27);
            datetimeDogumTrh.TabIndex = 33;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Brown;
            label9.Location = new Point(933, 328);
            label9.Name = "label9";
            label9.Size = new Size(142, 25);
            label9.TabIndex = 32;
            label9.Text = "Doğum Tarihi  :";
            // 
            // btnGuncelle
            // 
            btnGuncelle.FlatStyle = FlatStyle.Flat;
            btnGuncelle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuncelle.ForeColor = Color.White;
            btnGuncelle.Location = new Point(1136, 387);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(94, 36);
            btnGuncelle.TabIndex = 31;
            btnGuncelle.Text = "GÜNCELLE";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Brown;
            label8.Location = new Point(828, 56);
            label8.Name = "label8";
            label8.Size = new Size(187, 25);
            label8.TabIndex = 20;
            label8.Text = "Müşteri Ad - Soyad :";
            // 
            // btnSil
            // 
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSil.ForeColor = Color.White;
            btnSil.Location = new Point(1011, 387);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(94, 36);
            btnSil.TabIndex = 30;
            btnSil.Text = "SİL ";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(1099, 187);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(151, 27);
            txtSoyad.TabIndex = 28;
            // 
            // btnAra
            // 
            btnAra.FlatStyle = FlatStyle.Flat;
            btnAra.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAra.ForeColor = Color.White;
            btnAra.Location = new Point(1258, 51);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(92, 37);
            btnAra.TabIndex = 19;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Brown;
            label5.Location = new Point(933, 186);
            label5.Name = "label5";
            label5.Size = new Size(139, 25);
            label5.TabIndex = 27;
            label5.Text = "Soyad              :";
            // 
            // txtAra
            // 
            txtAra.Location = new Point(1021, 56);
            txtAra.Multiline = true;
            txtAra.Name = "txtAra";
            txtAra.Size = new Size(208, 31);
            txtAra.TabIndex = 1;
            // 
            // mskTelefon
            // 
            mskTelefon.Location = new Point(1099, 233);
            mskTelefon.Mask = "(999) 000-0000";
            mskTelefon.Name = "mskTelefon";
            mskTelefon.Size = new Size(151, 27);
            mskTelefon.TabIndex = 26;
            // 
            // dgvMusteriler
            // 
            dgvMusteriler.BackgroundColor = Color.White;
            dgvMusteriler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvMusteriler.DefaultCellStyle = dataGridViewCellStyle1;
            dgvMusteriler.Location = new Point(28, 56);
            dgvMusteriler.Name = "dgvMusteriler";
            dgvMusteriler.RowHeadersWidth = 51;
            dgvMusteriler.RowTemplate.Height = 29;
            dgvMusteriler.Size = new Size(651, 378);
            dgvMusteriler.TabIndex = 0;
            dgvMusteriler.SelectionChanged += dgvMusteriler_SelectionChanged;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(1099, 278);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(151, 27);
            txtMail.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Brown;
            label4.Location = new Point(934, 144);
            label4.Name = "label4";
            label4.Size = new Size(136, 25);
            label4.TabIndex = 21;
            label4.Text = "Ad                   :";
            // 
            // txtAd
            // 
            txtAd.Location = new Point(1099, 142);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(151, 27);
            txtAd.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Brown;
            label2.Location = new Point(933, 232);
            label2.Name = "label2";
            label2.Size = new Size(139, 25);
            label2.TabIndex = 22;
            label2.Text = "Telefon            :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Brown;
            label3.Location = new Point(934, 280);
            label3.Name = "label3";
            label3.Size = new Size(142, 25);
            label3.TabIndex = 23;
            label3.Text = "E-mail              :";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(dgvTaksitler);
            groupBox3.Controls.Add(dgvOdemeler);
            groupBox3.Controls.Add(dgvRandevular);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(108, 599);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1734, 381);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Müşteri Bilgileri ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Brown;
            label7.Location = new Point(1415, 34);
            label7.Name = "label7";
            label7.Size = new Size(82, 25);
            label7.TabIndex = 23;
            label7.Text = "Taksitler";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Brown;
            label6.Location = new Point(750, 34);
            label6.Name = "label6";
            label6.Size = new Size(146, 25);
            label6.TabIndex = 22;
            label6.Text = "Ödeme Geçmişi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(131, 34);
            label1.Name = "label1";
            label1.Size = new Size(212, 25);
            label1.TabIndex = 21;
            label1.Text = "Müşterinin Randevuları";
            // 
            // dgvTaksitler
            // 
            dgvTaksitler.BackgroundColor = Color.White;
            dgvTaksitler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTaksitler.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTaksitler.Location = new Point(1246, 72);
            dgvTaksitler.Name = "dgvTaksitler";
            dgvTaksitler.RowHeadersWidth = 51;
            dgvTaksitler.RowTemplate.Height = 29;
            dgvTaksitler.Size = new Size(458, 290);
            dgvTaksitler.TabIndex = 2;
            // 
            // dgvOdemeler
            // 
            dgvOdemeler.BackgroundColor = Color.White;
            dgvOdemeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvOdemeler.DefaultCellStyle = dataGridViewCellStyle3;
            dgvOdemeler.Location = new Point(579, 72);
            dgvOdemeler.Name = "dgvOdemeler";
            dgvOdemeler.RowHeadersWidth = 51;
            dgvOdemeler.RowTemplate.Height = 29;
            dgvOdemeler.Size = new Size(598, 290);
            dgvOdemeler.TabIndex = 1;
            dgvOdemeler.RowPrePaint += dgvOdemeler_RowPrePaint;
            // 
            // dgvRandevular
            // 
            dgvRandevular.BackgroundColor = Color.White;
            dgvRandevular.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvRandevular.DefaultCellStyle = dataGridViewCellStyle4;
            dgvRandevular.Location = new Point(39, 72);
            dgvRandevular.Name = "dgvRandevular";
            dgvRandevular.RowHeadersWidth = 51;
            dgvRandevular.RowTemplate.Height = 29;
            dgvRandevular.Size = new Size(474, 290);
            dgvRandevular.TabIndex = 0;
            dgvRandevular.RowPrePaint += dgvRandevular_RowPrePaint;
            // 
            // btnKapat
            // 
            btnKapat.BackColor = Color.Transparent;
            btnKapat.FlatStyle = FlatStyle.Popup;
            btnKapat.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnKapat.Location = new Point(1835, 12);
            btnKapat.Name = "btnKapat";
            btnKapat.Size = new Size(77, 56);
            btnKapat.TabIndex = 21;
            btnKapat.Text = "X";
            btnKapat.UseVisualStyleBackColor = false;
            btnKapat.Click += btnKapat_Click;
            // 
            // MusteriYonetimi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Zeynep_turan;
            ClientSize = new Size(1942, 944);
            Controls.Add(btnKapat);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MusteriYonetimi";
            Text = "MusteriYonetimi";
            WindowState = FormWindowState.Maximized;
            Load += MusteriYonetimi_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaksitler).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOdemeler).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRandevular).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private TextBox txtAra;
        private DataGridView dgvMusteriler;
        private GroupBox groupBox3;
        private Button btnAra;
        private Label label8;
        private Button btnGuncelle;
        private Button btnSil;
        private TextBox txtSoyad;
        private Label label5;
        private MaskedTextBox mskTelefon;
        private TextBox txtMail;
        private TextBox txtAd;
        private Label label3;
        private Label label2;
        private Label label4;
        private DataGridView dgvTaksitler;
        private DataGridView dgvOdemeler;
        private DataGridView dgvRandevular;
        private Label label7;
        private Label label6;
        private Label label1;
        private Button btnKapat;
        private DateTimePicker datetimeDogumTrh;
        private Label label9;
        private Button btnEkle;
        private Button btnTemizle;
    }
}