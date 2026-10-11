namespace GuzellıkMerkezıOtomasyonu
{
    partial class Raporlar
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
            btnKapat = new Button();
            pictureBox1 = new PictureBox();
            dgvGelirler = new DataGridView();
            cmbYil = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGelirler).BeginInit();
            SuspendLayout();
            // 
            // btnKapat
            // 
            btnKapat.BackColor = Color.Transparent;
            btnKapat.FlatStyle = FlatStyle.Popup;
            btnKapat.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnKapat.Location = new Point(762, 12);
            btnKapat.Name = "btnKapat";
            btnKapat.Size = new Size(77, 56);
            btnKapat.TabIndex = 22;
            btnKapat.Text = "X";
            btnKapat.UseVisualStyleBackColor = false;
            btnKapat.Click += btnKapat_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Zeynep_turan__1_;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(268, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // dgvGelirler
            // 
            dgvGelirler.BackgroundColor = Color.White;
            dgvGelirler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Variable Display Semib", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvGelirler.DefaultCellStyle = dataGridViewCellStyle1;
            dgvGelirler.Location = new Point(334, 143);
            dgvGelirler.Name = "dgvGelirler";
            dgvGelirler.RowHeadersWidth = 51;
            dgvGelirler.RowTemplate.Height = 29;
            dgvGelirler.Size = new Size(376, 614);
            dgvGelirler.TabIndex = 24;
            // 
            // cmbYil
            // 
            cmbYil.FormattingEnabled = true;
            cmbYil.Location = new Point(90, 226);
            cmbYil.Name = "cmbYil";
            cmbYil.Size = new Size(151, 28);
            cmbYil.TabIndex = 26;
            cmbYil.SelectedIndexChanged += cmbYil_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(110, 184);
            label1.Name = "label1";
            label1.Size = new Size(117, 25);
            label1.TabIndex = 25;
            label1.Text = "Yıl Seçiniz   :";
            // 
            // Raporlar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Zeynep_turan;
            ClientSize = new Size(889, 769);
            Controls.Add(cmbYil);
            Controls.Add(label1);
            Controls.Add(dgvGelirler);
            Controls.Add(pictureBox1);
            Controls.Add(btnKapat);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Raporlar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Raporlar";
            Load += Raporlar_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGelirler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnKapat;
        private PictureBox pictureBox1;
        private DataGridView dgvGelirler;
        private ComboBox cmbYil;
        private Label label1;
    }
}