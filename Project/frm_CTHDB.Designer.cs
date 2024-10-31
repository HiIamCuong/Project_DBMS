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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_TK = new System.Windows.Forms.Button();
            this.soLuong = new System.Windows.Forms.NumericUpDown();
            this.cbMaSP = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvCTHDB = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_CTHDB = new System.Windows.Forms.DataGridView();
            this.Ten_San_Pham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.So_Luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Don_Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tong_Tien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_TongTien = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSauChietKhau = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soLuong)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHDB)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CTHDB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(86, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHI TIẾT HÓA ĐƠN BÁN HÀNG";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AliceBlue;
            this.panel4.Controls.Add(this.btn_TK);
            this.panel4.Controls.Add(this.soLuong);
            this.panel4.Controls.Add(this.cbMaSP);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 62);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(729, 140);
            this.panel4.TabIndex = 32;
            // 
            // btn_TK
            // 
            this.btn_TK.Location = new System.Drawing.Point(557, 12);
            this.btn_TK.Name = "btn_TK";
            this.btn_TK.Size = new System.Drawing.Size(109, 35);
            this.btn_TK.TabIndex = 39;
            this.btn_TK.Text = "Tìm kiếm";
            this.btn_TK.UseVisualStyleBackColor = true;
            this.btn_TK.Click += new System.EventHandler(this.btn_TK_Click);
            // 
            // soLuong
            // 
            this.soLuong.Location = new System.Drawing.Point(194, 61);
            this.soLuong.Name = "soLuong";
            this.soLuong.Size = new System.Drawing.Size(65, 22);
            this.soLuong.TabIndex = 35;
            this.soLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbMaSP
            // 
            this.cbMaSP.Font = new System.Drawing.Font("#9Slide04 Faustina", 12F);
            this.cbMaSP.FormattingEnabled = true;
            this.cbMaSP.Location = new System.Drawing.Point(194, 13);
            this.cbMaSP.Margin = new System.Windows.Forms.Padding(4);
            this.cbMaSP.Name = "cbMaSP";
            this.cbMaSP.Size = new System.Drawing.Size(329, 34);
            this.cbMaSP.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label6.Location = new System.Drawing.Point(16, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "Sản Phẩm";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label3.Location = new System.Drawing.Point(44, 495);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 26);
            this.label3.TabIndex = 36;
            this.label3.Text = "Tổng tiền:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 62);
            this.panel1.TabIndex = 31;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSua.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSua.Location = new System.Drawing.Point(117, 0);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(67, 34);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
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
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvCTHDB
            // 
            this.dgvCTHDB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCTHDB.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvCTHDB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCTHDB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCTHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCTHDB.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCTHDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCTHDB.Location = new System.Drawing.Point(0, 0);
            this.dgvCTHDB.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCTHDB.Name = "dgvCTHDB";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCTHDB.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCTHDB.RowHeadersWidth = 62;
            this.dgvCTHDB.Size = new System.Drawing.Size(729, 539);
            this.dgvCTHDB.TabIndex = 33;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.AliceBlue;
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnXoa.Location = new System.Drawing.Point(184, 0);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(71, 34);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.AliceBlue;
            this.btnReload.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnReload.Location = new System.Drawing.Point(571, 0);
            this.btnReload.Margin = new System.Windows.Forms.Padding(4);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(100, 34);
            this.btnReload.TabIndex = 9;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.AliceBlue;
            this.btnQuayLai.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnQuayLai.Location = new System.Drawing.Point(255, 0);
            this.btnQuayLai.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(316, 34);
            this.btnQuayLai.TabIndex = 7;
            this.btnQuayLai.Text = "Quay Loại Giao Diện Hóa Đơn";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SaddleBrown;
            this.panel2.Controls.Add(this.btnReload);
            this.panel2.Controls.Add(this.btnQuayLai);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.SystemColors.Control;
            this.panel2.Location = new System.Drawing.Point(0, 539);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(729, 34);
            this.panel2.TabIndex = 34;
            // 
            // dgv_CTHDB
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_CTHDB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_CTHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CTHDB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ten_San_Pham,
            this.So_Luong,
            this.Don_Gia,
            this.Tong_Tien});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_CTHDB.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_CTHDB.Location = new System.Drawing.Point(0, 177);
            this.dgv_CTHDB.Name = "dgv_CTHDB";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_CTHDB.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_CTHDB.RowHeadersWidth = 51;
            this.dgv_CTHDB.RowTemplate.Height = 24;
            this.dgv_CTHDB.Size = new System.Drawing.Size(980, 315);
            this.dgv_CTHDB.TabIndex = 35;
            this.dgv_CTHDB.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CTHDB_RowEnter);
            // 
            // Ten_San_Pham
            // 
            this.Ten_San_Pham.DataPropertyName = "Ten_San_Pham";
            this.Ten_San_Pham.HeaderText = "Tên sản phẩm";
            this.Ten_San_Pham.MinimumWidth = 6;
            this.Ten_San_Pham.Name = "Ten_San_Pham";
            this.Ten_San_Pham.Width = 125;
            // 
            // So_Luong
            // 
            this.So_Luong.DataPropertyName = "So_Luong";
            this.So_Luong.HeaderText = "Số lượng";
            this.So_Luong.MinimumWidth = 6;
            this.So_Luong.Name = "So_Luong";
            this.So_Luong.Width = 125;
            // 
            // Don_Gia
            // 
            this.Don_Gia.DataPropertyName = "Don_Gia";
            this.Don_Gia.HeaderText = "Đơn Giá";
            this.Don_Gia.MinimumWidth = 6;
            this.Don_Gia.Name = "Don_Gia";
            this.Don_Gia.Width = 125;
            // 
            // Tong_Tien
            // 
            this.Tong_Tien.DataPropertyName = "Tong_Tien";
            this.Tong_Tien.HeaderText = "Tổng tiền";
            this.Tong_Tien.MinimumWidth = 6;
            this.Tong_Tien.Name = "Tong_Tien";
            this.Tong_Tien.Width = 125;
            // 
            // lbl_TongTien
            // 
            this.lbl_TongTien.AutoSize = true;
            this.lbl_TongTien.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TongTien.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lbl_TongTien.Location = new System.Drawing.Point(225, 495);
            this.lbl_TongTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TongTien.Name = "lbl_TongTien";
            this.lbl_TongTien.Size = new System.Drawing.Size(24, 26);
            this.lbl_TongTien.TabIndex = 37;
            this.lbl_TongTien.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(395, 495);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 26);
            this.label2.TabIndex = 38;
            this.label2.Text = "Sau chiết khấu:";
            // 
            // lblSauChietKhau
            // 
            this.lblSauChietKhau.AutoSize = true;
            this.lblSauChietKhau.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSauChietKhau.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblSauChietKhau.Location = new System.Drawing.Point(609, 495);
            this.lblSauChietKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSauChietKhau.Name = "lblSauChietKhau";
            this.lblSauChietKhau.Size = new System.Drawing.Size(24, 26);
            this.lblSauChietKhau.TabIndex = 39;
            this.lblSauChietKhau.Text = "0";
            // 
            // frm_CTHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 573);
            this.Controls.Add(this.lblSauChietKhau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_TongTien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_CTHDB);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvCTHDB);
            this.Controls.Add(this.panel2);
            this.Name = "frm_CTHDB";
            this.Text = "frm_CTHDB";
            this.Load += new System.EventHandler(this.frm_CTHDB_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soLuong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHDB)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CTHDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbMaSP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvCTHDB;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown soLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_CTHDB;
        private System.Windows.Forms.Label lbl_TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_San_Pham;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_Luong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Don_Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tong_Tien;
        private System.Windows.Forms.Button btn_TK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSauChietKhau;
    }
}