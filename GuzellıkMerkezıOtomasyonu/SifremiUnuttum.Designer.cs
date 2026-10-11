namespace GuzellıkMerkezıOtomasyonu
{
    partial class SifremiUnuttum
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
            txtMail = new TextBox();
            label3 = new Label();
            txtSifre = new TextBox();
            label6 = new Label();
            btnSifreDegistir = new Button();
            btnKapat = new Button();
            SuspendLayout();
            // 
            // txtMail
            // 
            txtMail.BackColor = Color.White;
            txtMail.Location = new Point(240, 121);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(259, 27);
            txtMail.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Brown;
            label3.Location = new Point(83, 120);
            label3.Name = "label3";
            label3.Size = new Size(147, 25);
            label3.TabIndex = 8;
            label3.Text = "E-mail               :";
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(240, 175);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(259, 27);
            txtSifre.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Brown;
            label6.Location = new Point(79, 174);
            label6.Name = "label6";
            label6.Size = new Size(151, 25);
            label6.TabIndex = 12;
            label6.Text = "Şifre                   :";
            // 
            // btnSifreDegistir
            // 
            btnSifreDegistir.BackColor = Color.RosyBrown;
            btnSifreDegistir.FlatStyle = FlatStyle.Flat;
            btnSifreDegistir.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSifreDegistir.ForeColor = Color.White;
            btnSifreDegistir.Location = new Point(311, 254);
            btnSifreDegistir.Name = "btnSifreDegistir";
            btnSifreDegistir.Size = new Size(119, 36);
            btnSifreDegistir.TabIndex = 14;
            btnSifreDegistir.Text = "DEĞİŞTİR";
            btnSifreDegistir.UseVisualStyleBackColor = false;
            btnSifreDegistir.Click += button1_Click;
            // 
            // btnKapat
            // 
            btnKapat.BackColor = Color.Transparent;
            btnKapat.FlatStyle = FlatStyle.Flat;
            btnKapat.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnKapat.ForeColor = Color.White;
            btnKapat.Location = new Point(538, 12);
            btnKapat.Name = "btnKapat";
            btnKapat.Size = new Size(40, 35);
            btnKapat.TabIndex = 24;
            btnKapat.Text = "X";
            btnKapat.UseVisualStyleBackColor = false;
            btnKapat.Click += btnKapat_Click;
            // 
            // SifremiUnuttum
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            ClientSize = new Size(590, 367);
            Controls.Add(btnKapat);
            Controls.Add(btnSifreDegistir);
            Controls.Add(txtSifre);
            Controls.Add(label6);
            Controls.Add(txtMail);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SifremiUnuttum";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SifremiUnuttum";
            Load += SifremiUnuttum_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMail;
        private Label label3;
        private TextBox txtSifre;
        private Label label6;
        private Button btnSifreDegistir;
        private Button btnKapat;
    }
}