namespace GuzellıkMerkezıOtomasyonu
{
    partial class StokDetayForm
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
            dgvStokDurum = new DataGridView();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvStokDurum).BeginInit();
            SuspendLayout();
            // 
            // btnKapat
            // 
            btnKapat.BackColor = Color.Transparent;
            btnKapat.FlatStyle = FlatStyle.Popup;
            btnKapat.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnKapat.Location = new Point(910, 12);
            btnKapat.Name = "btnKapat";
            btnKapat.Size = new Size(60, 42);
            btnKapat.TabIndex = 22;
            btnKapat.Text = "X";
            btnKapat.UseVisualStyleBackColor = false;
            btnKapat.Click += btnKapat_Click;
            // 
            // dgvStokDurum
            // 
            dgvStokDurum.BackgroundColor = Color.White;
            dgvStokDurum.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvStokDurum.DefaultCellStyle = dataGridViewCellStyle1;
            dgvStokDurum.Location = new Point(40, 83);
            dgvStokDurum.Name = "dgvStokDurum";
            dgvStokDurum.RowHeadersWidth = 51;
            dgvStokDurum.RowTemplate.Height = 29;
            dgvStokDurum.Size = new Size(891, 564);
            dgvStokDurum.TabIndex = 23;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Brown;
            label9.Location = new Point(371, 44);
            label9.Name = "label9";
            label9.Size = new Size(177, 25);
            label9.TabIndex = 24;
            label9.Text = "ÜRÜN STOK TAKİBİ";
            // 
            // StokDetayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            ClientSize = new Size(982, 684);
            Controls.Add(label9);
            Controls.Add(dgvStokDurum);
            Controls.Add(btnKapat);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StokDetayForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StokDetayForm";
            Load += StokDetayForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStokDurum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnKapat;
        private DataGridView dgvStokDurum;
        private Label label9;
    }
}