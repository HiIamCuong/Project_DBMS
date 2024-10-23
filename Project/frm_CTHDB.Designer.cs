namespace Project
{
    partial class frm_CTHDB
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtMaHDB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMaSP = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTenSP = new System.Windows.Forms.Label();
            this.txtDG = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvCTHDB = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnXuatHD = new System.Windows.Forms.Button();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHDB)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(210, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHI TIẾT HÓA ĐƠN BÁN HÀNG";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AliceBlue;
            this.panel4.Controls.Add(this.txtMaHDB);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.cbMaSP);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.lbTenSP);
            this.panel4.Controls.Add(this.txtDG);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.txtSL);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 62);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(980, 140);
            this.panel4.TabIndex = 32;
            // 
            // txtMaHDB
            // 
            this.txtMaHDB.Font = new System.Drawing.Font("Century", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHDB.Location = new System.Drawing.Point(194, 14);
            this.txtMaHDB.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaHDB.Name = "txtMaHDB";
            this.txtMaHDB.Size = new System.Drawing.Size(241, 34);
            this.txtMaHDB.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(16, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 26);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mã Hóa Đơn Bán";
            // 
            // cbMaSP
            // 
            this.cbMaSP.Font = new System.Drawing.Font("Century", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaSP.FormattingEnabled = true;
            this.cbMaSP.Location = new System.Drawing.Point(624, 13);
            this.cbMaSP.Margin = new System.Windows.Forms.Padding(4);
            this.cbMaSP.Name = "cbMaSP";
            this.cbMaSP.Size = new System.Drawing.Size(176, 35);
            this.cbMaSP.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label6.Location = new System.Drawing.Point(477, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mã Sản Phẩm";
            // 
            // lbTenSP
            // 
            this.lbTenSP.AutoSize = true;
            this.lbTenSP.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSP.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lbTenSP.Location = new System.Drawing.Point(808, 27);
            this.lbTenSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTenSP.Name = "lbTenSP";
            this.lbTenSP.Size = new System.Drawing.Size(33, 25);
            this.lbTenSP.TabIndex = 10;
            this.lbTenSP.Text = "---";
            // 
            // txtDG
            // 
            this.txtDG.Enabled = false;
            this.txtDG.Font = new System.Drawing.Font("Century", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDG.Location = new System.Drawing.Point(624, 56);
            this.txtDG.Margin = new System.Windows.Forms.Padding(4);
            this.txtDG.Name = "txtDG";
            this.txtDG.Size = new System.Drawing.Size(321, 34);
            this.txtDG.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label8.Location = new System.Drawing.Point(477, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 26);
            this.label8.TabIndex = 4;
            this.label8.Text = "Đơn Giá";
            // 
            // txtSL
            // 
            this.txtSL.Font = new System.Drawing.Font("Century", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSL.Location = new System.Drawing.Point(194, 56);
            this.txtSL.Margin = new System.Windows.Forms.Padding(4);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(241, 34);
            this.txtSL.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label7.Location = new System.Drawing.Point(16, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 26);
            this.label7.TabIndex = 4;
            this.label7.Text = "Số Lượng";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 62);
            this.panel1.TabIndex = 31;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSua.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSua.Location = new System.Drawing.Point(179, 0);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(67, 34);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.AliceBlue;
            this.btnLuu.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnLuu.Location = new System.Drawing.Point(117, 0);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(62, 34);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.AliceBlue;
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnThem.Location = new System.Drawing.Point(0, 0);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(117, 34);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm Mới";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // dgvCTHDB
            // 
            this.dgvCTHDB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCTHDB.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvCTHDB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCTHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTHDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCTHDB.Location = new System.Drawing.Point(0, 0);
            this.dgvCTHDB.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCTHDB.Name = "dgvCTHDB";
            this.dgvCTHDB.RowHeadersWidth = 62;
            this.dgvCTHDB.Size = new System.Drawing.Size(980, 539);
            this.dgvCTHDB.TabIndex = 33;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.AliceBlue;
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnXoa.Location = new System.Drawing.Point(246, 0);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(71, 34);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.AliceBlue;
            this.btnReload.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnReload.Location = new System.Drawing.Point(877, 0);
            this.btnReload.Margin = new System.Windows.Forms.Padding(4);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(100, 34);
            this.btnReload.TabIndex = 9;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = false;
            // 
            // btnXuatHD
            // 
            this.btnXuatHD.BackColor = System.Drawing.Color.AliceBlue;
            this.btnXuatHD.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnXuatHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatHD.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatHD.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnXuatHD.Location = new System.Drawing.Point(704, 0);
            this.btnXuatHD.Margin = new System.Windows.Forms.Padding(4);
            this.btnXuatHD.Name = "btnXuatHD";
            this.btnXuatHD.Size = new System.Drawing.Size(173, 34);
            this.btnXuatHD.TabIndex = 8;
            this.btnXuatHD.Text = "Xuất Hóa Đơn";
            this.btnXuatHD.UseVisualStyleBackColor = false;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.AliceBlue;
            this.btnQuayLai.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnQuayLai.Location = new System.Drawing.Point(388, 0);
            this.btnQuayLai.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(316, 34);
            this.btnQuayLai.TabIndex = 7;
            this.btnQuayLai.Text = "Quay Loại Giao Diện Hóa Đơn";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SaddleBrown;
            this.panel2.Controls.Add(this.btnReload);
            this.panel2.Controls.Add(this.btnXuatHD);
            this.panel2.Controls.Add(this.btnQuayLai);
            this.panel2.Controls.Add(this.btnHuyBo);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.SystemColors.Control;
            this.panel2.Location = new System.Drawing.Point(0, 539);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(980, 34);
            this.panel2.TabIndex = 34;
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.BackColor = System.Drawing.Color.AliceBlue;
            this.btnHuyBo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHuyBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyBo.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyBo.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnHuyBo.Location = new System.Drawing.Point(317, 0);
            this.btnHuyBo.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(71, 34);
            this.btnHuyBo.TabIndex = 6;
            this.btnHuyBo.Text = "Hủy";
            this.btnHuyBo.UseVisualStyleBackColor = false;
            // 
            // frm_CTHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 573);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvCTHDB);
            this.Controls.Add(this.panel2);
            this.Name = "frm_CTHDB";
            this.Text = "frm_CTHDB";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHDB)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtMaHDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMaSP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbTenSP;
        private System.Windows.Forms.TextBox txtDG;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvCTHDB;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnXuatHD;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnHuyBo;
    }
}