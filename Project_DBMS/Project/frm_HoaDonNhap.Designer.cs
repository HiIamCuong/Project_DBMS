﻿namespace Project
{
    partial class frm_HoaDonNhap
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
            this.components = new System.ComponentModel.Container();
            this.lblTenNCC = new System.Windows.Forms.Label();
            this.cmbNCC = new System.Windows.Forms.ComboBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.txtMaHDN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbHDN = new System.Windows.Forms.GroupBox();
            this.dtpThoiGian = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHDN = new System.Windows.Forms.DataGridView();
            this.Ma_Hoa_Don_Nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_Nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tong_Tien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_Nha_Cung_Cap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thoi_Gian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbHDN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTenNCC
            // 
            this.lblTenNCC.AutoSize = true;
            this.lblTenNCC.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNCC.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblTenNCC.Location = new System.Drawing.Point(196, 409);
            this.lblTenNCC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenNCC.Name = "lblTenNCC";
            this.lblTenNCC.Size = new System.Drawing.Size(40, 29);
            this.lblTenNCC.TabIndex = 27;
            this.lblTenNCC.Text = "---";
            // 
            // cmbNCC
            // 
            this.cmbNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNCC.FormattingEnabled = true;
            this.cmbNCC.Items.AddRange(new object[] {
            ""});
            this.cmbNCC.Location = new System.Drawing.Point(201, 284);
            this.cmbNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbNCC.Name = "cmbNCC";
            this.cmbNCC.Size = new System.Drawing.Size(294, 37);
            this.cmbNCC.TabIndex = 26;
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayNhap.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhap.Location = new System.Drawing.Point(201, 134);
            this.dtpNgayNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(294, 36);
            this.dtpNgayNhap.TabIndex = 25;
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThanhTien.Location = new System.Drawing.Point(201, 356);
            this.txtThanhTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(294, 36);
            this.txtThanhTien.TabIndex = 24;
            // 
            // txtMaHDN
            // 
            this.txtMaHDN.Enabled = false;
            this.txtMaHDN.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHDN.Location = new System.Drawing.Point(201, 66);
            this.txtMaHDN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaHDN.Name = "txtMaHDN";
            this.txtMaHDN.Size = new System.Drawing.Size(294, 36);
            this.txtMaHDN.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label5.Location = new System.Drawing.Point(20, 289);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 29);
            this.label5.TabIndex = 21;
            this.label5.Text = "Nhà CC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label6.Location = new System.Drawing.Point(20, 361);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 29);
            this.label6.TabIndex = 19;
            this.label6.Text = "Tổng Tiền";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(20, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 29);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mã HDN";
            // 
            // gbHDN
            // 
            this.gbHDN.BackColor = System.Drawing.Color.AliceBlue;
            this.gbHDN.Controls.Add(this.dtpThoiGian);
            this.gbHDN.Controls.Add(this.label4);
            this.gbHDN.Controls.Add(this.lblTenNCC);
            this.gbHDN.Controls.Add(this.cmbNCC);
            this.gbHDN.Controls.Add(this.dtpNgayNhap);
            this.gbHDN.Controls.Add(this.txtThanhTien);
            this.gbHDN.Controls.Add(this.txtMaHDN);
            this.gbHDN.Controls.Add(this.label5);
            this.gbHDN.Controls.Add(this.label6);
            this.gbHDN.Controls.Add(this.label3);
            this.gbHDN.Controls.Add(this.label2);
            this.gbHDN.ForeColor = System.Drawing.Color.SaddleBrown;
            this.gbHDN.Location = new System.Drawing.Point(0, 164);
            this.gbHDN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbHDN.Name = "gbHDN";
            this.gbHDN.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbHDN.Size = new System.Drawing.Size(522, 452);
            this.gbHDN.TabIndex = 50;
            this.gbHDN.TabStop = false;
            this.gbHDN.Text = "Thông tin Hóa Đơn Nhập";
            // 
            // dtpThoiGian
            // 
            this.dtpThoiGian.CustomFormat = "";
            this.dtpThoiGian.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThoiGian.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpThoiGian.Location = new System.Drawing.Point(201, 208);
            this.dtpThoiGian.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpThoiGian.Name = "dtpThoiGian";
            this.dtpThoiGian.ShowUpDown = true;
            this.dtpThoiGian.Size = new System.Drawing.Size(294, 36);
            this.dtpThoiGian.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label4.Location = new System.Drawing.Point(20, 216);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 29);
            this.label4.TabIndex = 28;
            this.label4.Text = "Thời Gian";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label3.Location = new System.Drawing.Point(20, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 29);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ngày Nhập";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Chocolate;
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(864, 92);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(112, 35);
            this.btnTimKiem.TabIndex = 47;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Font = new System.Drawing.Font("Century", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(274, 86);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(578, 39);
            this.txtTimKiem.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(441, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "HÓA ĐƠN NHẬP";
            // 
            // dgvHDN
            // 
            this.dgvHDN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHDN.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvHDN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHDN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_Hoa_Don_Nhap,
            this.Ngay_Nhap,
            this.Tong_Tien,
            this.Ma_Nha_Cung_Cap,
            this.Thoi_Gian});
            this.dgvHDN.Location = new System.Drawing.Point(520, 173);
            this.dgvHDN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvHDN.Name = "dgvHDN";
            this.dgvHDN.RowHeadersWidth = 51;
            this.dgvHDN.Size = new System.Drawing.Size(681, 414);
            this.dgvHDN.TabIndex = 49;
            this.dgvHDN.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHDN_CellDoubleClick);
            this.dgvHDN.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHDN_RowEnter);
            // 
            // Ma_Hoa_Don_Nhap
            // 
            this.Ma_Hoa_Don_Nhap.DataPropertyName = "Ma_Hoa_Don_Nhap";
            this.Ma_Hoa_Don_Nhap.HeaderText = "Mã Hóa Đơn Nhập";
            this.Ma_Hoa_Don_Nhap.MinimumWidth = 6;
            this.Ma_Hoa_Don_Nhap.Name = "Ma_Hoa_Don_Nhap";
            // 
            // Ngay_Nhap
            // 
            this.Ngay_Nhap.DataPropertyName = "Ngay_Nhap";
            this.Ngay_Nhap.HeaderText = "Ngày Nhập";
            this.Ngay_Nhap.MinimumWidth = 6;
            this.Ngay_Nhap.Name = "Ngay_Nhap";
            // 
            // Tong_Tien
            // 
            this.Tong_Tien.DataPropertyName = "Tong_Tien";
            this.Tong_Tien.HeaderText = "Tổng Tiền";
            this.Tong_Tien.MinimumWidth = 6;
            this.Tong_Tien.Name = "Tong_Tien";
            // 
            // Ma_Nha_Cung_Cap
            // 
            this.Ma_Nha_Cung_Cap.DataPropertyName = "Ma_Nha_Cung_Cap";
            this.Ma_Nha_Cung_Cap.HeaderText = "Mã Nhà Cung Cấp";
            this.Ma_Nha_Cung_Cap.MinimumWidth = 6;
            this.Ma_Nha_Cung_Cap.Name = "Ma_Nha_Cung_Cap";
            // 
            // Thoi_Gian
            // 
            this.Thoi_Gian.DataPropertyName = "Thoi_Gian";
            this.Thoi_Gian.HeaderText = "Thời Gian";
            this.Thoi_Gian.MinimumWidth = 6;
            this.Thoi_Gian.Name = "Thoi_Gian";
            // 
            // btnReload
            // 
            this.btnReload.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(70, 37);
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 42);
            // 
            // btnXoa
            // 
            this.btnXoa.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(112, 37);
            this.btnXoa.Text = "Xóa Dữ Liệu";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // btnSua
            // 
            this.btnSua.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(105, 37);
            this.btnSua.Text = "Sửa dữ liệu";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // btnThem
            // 
            this.btnThem.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(96, 37);
            this.btnThem.Text = "Thêm Mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BackColor = System.Drawing.Color.AliceBlue;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.toolStripSeparator1,
            this.toolStripSeparator4,
            this.btnSua,
            this.toolStripSeparator2,
            this.btnXoa,
            this.toolStripSeparator3,
            this.toolStripSeparator5,
            this.btnReload});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(681, 42);
            this.bindingNavigator1.TabIndex = 48;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(226)))), ((int)(((byte)(238)))));
            this.panel3.Controls.Add(this.bindingNavigator1);
            this.panel3.Location = new System.Drawing.Point(520, 574);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(681, 42);
            this.panel3.TabIndex = 48;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 191);
            this.panel1.TabIndex = 47;
            // 
            // frm_HoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 615);
            this.Controls.Add(this.gbHDN);
            this.Controls.Add(this.dgvHDN);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_HoaDonNhap";
            this.Text = "frm_HoaDonNhap";
            this.Load += new System.EventHandler(this.frm_HoaDonNhap_Load);
            this.gbHDN.ResumeLayout(false);
            this.gbHDN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTenNCC;
        private System.Windows.Forms.ComboBox cmbNCC;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbHDN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHDN;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpThoiGian;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_Hoa_Don_Nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_Nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tong_Tien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_Nha_Cung_Cap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thoi_Gian;
        public System.Windows.Forms.TextBox txtMaHDN;
    }
}