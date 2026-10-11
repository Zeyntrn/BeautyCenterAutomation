namespace GuzellıkMerkezıOtomasyonu
{
    partial class KullaniciGiris
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciGiris));
            pictureBox1 = new PictureBox();
            btncikis = new Button();
            label1 = new Label();
            label2 = new Label();
            lnkkayitOl = new LinkLabel();
            lnksifreUnuttum = new LinkLabel();
            btngiris = new Button();
            txtKullaniciAdi = new TextBox();
            txtKullaniciSifre = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(65, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(405, 381);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btncikis
            // 
            btncikis.BackColor = Color.Transparent;
            btncikis.FlatAppearance.BorderColor = Color.Black;
            btncikis.FlatStyle = FlatStyle.Flat;
            btncikis.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btncikis.ForeColor = SystemColors.Window;
            btncikis.Location = new Point(485, 12);
            btncikis.Name = "btncikis";
            btncikis.Size = new Size(64, 32);
            btncikis.TabIndex = 17;
            btncikis.Text = "X";
            btncikis.TextAlign = ContentAlignment.TopCenter;
            btncikis.UseVisualStyleBackColor = false;
            btncikis.Click += btncikis_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(79, 502);
            label1.Name = "label1";
            label1.Size = new Size(146, 28);
            label1.TabIndex = 20;
            label1.Text = "Kullanıcı Adı  : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Brown;
            label2.Location = new Point(79, 564);
            label2.Name = "label2";
            label2.Size = new Size(151, 28);
            label2.TabIndex = 21;
            label2.Text = "Kullanıcı Şifre : ";
            // 
            // lnkkayitOl
            // 
            lnkkayitOl.AutoSize = true;
            lnkkayitOl.BackColor = Color.Transparent;
            lnkkayitOl.LinkColor = Color.DimGray;
            lnkkayitOl.Location = new Point(250, 630);
            lnkkayitOl.Name = "lnkkayitOl";
            lnkkayitOl.Size = new Size(65, 20);
            lnkkayitOl.TabIndex = 22;
            lnkkayitOl.TabStop = true;
            lnkkayitOl.Text = "Kayıt Ol ";
            lnkkayitOl.LinkClicked += lnkkayitOl_LinkClicked;
            // 
            // lnksifreUnuttum
            // 
            lnksifreUnuttum.AutoSize = true;
            lnksifreUnuttum.BackColor = Color.Transparent;
            lnksifreUnuttum.LinkColor = Color.DimGray;
            lnksifreUnuttum.Location = new Point(321, 630);
            lnksifreUnuttum.Name = "lnksifreUnuttum";
            lnksifreUnuttum.Size = new Size(121, 20);
            lnksifreUnuttum.TabIndex = 23;
            lnksifreUnuttum.TabStop = true;
            lnksifreUnuttum.Text = "Şifremi Unuttum ";
            lnksifreUnuttum.LinkClicked += lnksifreUnuttum_LinkClicked;
            // 
            // btngiris
            // 
            btngiris.BackColor = Color.Transparent;
            btngiris.FlatAppearance.BorderColor = Color.Black;
            btngiris.FlatStyle = FlatStyle.Flat;
            btngiris.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btngiris.ForeColor = Color.White;
            btngiris.Location = new Point(288, 679);
            btngiris.Name = "btngiris";
            btngiris.Size = new Size(113, 31);
            btngiris.TabIndex = 24;
            btngiris.Text = "GİRİŞ";
            btngiris.TextAlign = ContentAlignment.TopCenter;
            btngiris.UseVisualStyleBackColor = false;
            btngiris.Click += btngiris_Click;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(231, 506);
            txtKullaniciAdi.Multiline = true;
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(222, 28);
            txtKullaniciAdi.TabIndex = 25;
            // 
            // txtKullaniciSifre
            // 
            txtKullaniciSifre.Location = new Point(231, 564);
            txtKullaniciSifre.Multiline = true;
            txtKullaniciSifre.Name = "txtKullaniciSifre";
            txtKullaniciSifre.Size = new Size(222, 28);
            txtKullaniciSifre.TabIndex = 26;
            // 
            // KullaniciGiris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(565, 772);
            Controls.Add(txtKullaniciSifre);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(btngiris);
            Controls.Add(lnksifreUnuttum);
            Controls.Add(lnkkayitOl);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btncikis);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "KullaniciGiris";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KullanıcıGiris";
            Load += KullaniciGiris_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btncikis;
        // private TextBox txtKullaniciAdi;
        // private TextBox txtKullaniciSifre;
        private Label label1;
        private Label label2;
        private LinkLabel lnkkayitOl;
        private LinkLabel lnksifreUnuttum;
        private Button btngiris;
        private TextBox txtKullaniciAdi;
        private TextBox txtKullaniciSifre;
    }
}