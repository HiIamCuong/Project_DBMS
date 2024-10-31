namespace Project
{
    partial class frm_BangPhanCa
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
            this.btnHuyBo = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.btnTKKH = new System.Windows.Forms.Button();
            this.cmbMaNV = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.grBox = new System.Windows.Forms.GroupBox();
            this.cmbMaCa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvBangPhanCa = new System.Windows.Forms.DataGridView();
            this.dgvphanca = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.grBox.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangPhanCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvphanca)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnHuyBo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(61, 26);
            this.btnHuyBo.Text = "Hủy Bỏ";
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(100, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH MỤC BẢNG PHÂN CA";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNV.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblTenNV.Location = new System.Drawing.Point(164, 89);
            this.lblTenNV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(33, 25);
            this.lblTenNV.TabIndex = 48;
            this.lblTenNV.Text = "---";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtTK);
            this.panel3.Controls.Add(this.btnTKKH);
            this.panel3.Location = new System.Drawing.Point(34, 73);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(637, 34);
            this.panel3.TabIndex = 9;
            // 
            // txtTK
            // 
            this.txtTK.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTK.Location = new System.Drawing.Point(4, 2);
            this.txtTK.Margin = new System.Windows.Forms.Padding(4);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(534, 32);
            this.txtTK.TabIndex = 6;
            // 
            // btnTKKH
            // 
            this.btnTKKH.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTKKH.Location = new System.Drawing.Point(538, 0);
            this.btnTKKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTKKH.Name = "btnTKKH";
            this.btnTKKH.Size = new System.Drawing.Size(99, 34);
            this.btnTKKH.TabIndex = 7;
            this.btnTKKH.Text = "Tìm Kiếm";
            this.btnTKKH.UseVisualStyleBackColor = true;
            // 
            // cmbMaNV
            // 
            this.cmbMaNV.Font = new System.Drawing.Font("Century", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaNV.FormattingEnabled = true;
            this.cmbMaNV.Location = new System.Drawing.Point(169, 46);
            this.cmbMaNV.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMaNV.Name = "cmbMaNV";
            this.cmbMaNV.Size = new System.Drawing.Size(169, 35);
            this.cmbMaNV.TabIndex = 49;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bindingNavigator1);
            this.panel2.Controls.Add(this.grBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 444);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(699, 153);
            this.panel2.TabIndex = 51;
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
            this.btnXoa,
            this.toolStripSeparator3,
            this.btnHuyBo,
            this.toolStripSeparator5,
            this.btnReload});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 124);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(699, 29);
            this.bindingNavigator1.TabIndex = 45;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // btnThem
            // 
            this.btnThem.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 26);
            this.btnThem.Text = "Thêm Mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(94, 26);
            this.btnXoa.Text = "Xóa Dữ Liệu";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // btnReload
            // 
            this.btnReload.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(60, 26);
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // grBox
            // 
            this.grBox.BackColor = System.Drawing.Color.AliceBlue;
            this.grBox.Controls.Add(this.cmbMaNV);
            this.grBox.Controls.Add(this.lblTenNV);
            this.grBox.Controls.Add(this.cmbMaCa);
            this.grBox.Controls.Add(this.label3);
            this.grBox.Controls.Add(this.label2);
            this.grBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.grBox.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBox.ForeColor = System.Drawing.Color.SaddleBrown;
            this.grBox.Location = new System.Drawing.Point(0, 0);
            this.grBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grBox.Name = "grBox";
            this.grBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grBox.Size = new System.Drawing.Size(699, 124);
            this.grBox.TabIndex = 44;
            this.grBox.TabStop = false;
            this.grBox.Text = "Thông tin về Bảng Phân Ca";
            // 
            // cmbMaCa
            // 
            this.cmbMaCa.Font = new System.Drawing.Font("Century", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaCa.FormattingEnabled = true;
            this.cmbMaCa.Location = new System.Drawing.Point(455, 45);
            this.cmbMaCa.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMaCa.Name = "cmbMaCa";
            this.cmbMaCa.Size = new System.Drawing.Size(205, 35);
            this.cmbMaCa.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã Nhân Viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(366, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã Ca";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 142);
            this.panel1.TabIndex = 50;
            // 
            // dgvBangPhanCa
            // 
            this.dgvBangPhanCa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBangPhanCa.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvBangPhanCa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBangPhanCa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangPhanCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBangPhanCa.Location = new System.Drawing.Point(0, 0);
            this.dgvBangPhanCa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBangPhanCa.Name = "dgvBangPhanCa";
            this.dgvBangPhanCa.RowHeadersWidth = 62;
            this.dgvBangPhanCa.RowTemplate.Height = 28;
            this.dgvBangPhanCa.Size = new System.Drawing.Size(699, 597);
            this.dgvBangPhanCa.TabIndex = 52;
            // 
            // dgvphanca
            // 
            this.dgvphanca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvphanca.Location = new System.Drawing.Point(0, 140);
            this.dgvphanca.Name = "dgvphanca";
            this.dgvphanca.RowHeadersWidth = 51;
            this.dgvphanca.RowTemplate.Height = 24;
            this.dgvphanca.Size = new System.Drawing.Size(699, 299);
            this.dgvphanca.TabIndex = 53;
            this.dgvphanca.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvphanca_CellContentClick);
            this.dgvphanca.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvphanca_RowEnter);
            // 
            // frm_BangPhanCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 597);
            this.Controls.Add(this.dgvphanca);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvBangPhanCa);
            this.Name = "frm_BangPhanCa";
            this.Text = "BangPhanCa";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.grBox.ResumeLayout(false);
            this.grBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangPhanCa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvphanca)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnHuyBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Button btnTKKH;
        private System.Windows.Forms.ComboBox cmbMaNV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.GroupBox grBox;
        private System.Windows.Forms.ComboBox cmbMaCa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvBangPhanCa;
        private System.Windows.Forms.DataGridView dgvphanca;
    }
}