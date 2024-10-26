namespace Project
{
    partial class frm_LoaiSanPham
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
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.btnTKKH = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTenLoaiSP = new System.Windows.Forms.TextBox();
            this.txtMaLoaiSP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grBox = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_MaLoaiSP = new System.Windows.Forms.DataGridView();
            this.Ma_Loai_San_Pham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_Loai_San_Pham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grBox.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MaLoaiSP)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReload
            // 
            this.btnReload.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(60, 36);
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // btnXoa
            // 
            this.btnXoa.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(94, 36);
            this.btnXoa.Text = "Xóa Dữ Liệu";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnSua
            // 
            this.btnSua.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(88, 36);
            this.btnSua.Text = "Sửa dữ liệu";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnThem
            // 
            this.btnThem.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 36);
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 135);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(811, 39);
            this.bindingNavigator1.TabIndex = 46;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(163, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(492, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH MỤC LOẠI SẢN PHẨM";
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
            this.btnTKKH.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnTKKH.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTKKH.FlatAppearance.BorderSize = 0;
            this.btnTKKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTKKH.ForeColor = System.Drawing.Color.OldLace;
            this.btnTKKH.Location = new System.Drawing.Point(538, 0);
            this.btnTKKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTKKH.Name = "btnTKKH";
            this.btnTKKH.Size = new System.Drawing.Size(99, 34);
            this.btnTKKH.TabIndex = 7;
            this.btnTKKH.Text = "Tìm Kiếm";
            this.btnTKKH.UseVisualStyleBackColor = false;
            this.btnTKKH.Click += new System.EventHandler(this.btnTKKH_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTK);
            this.panel2.Controls.Add(this.btnTKKH);
            this.panel2.Location = new System.Drawing.Point(80, 62);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(637, 34);
            this.panel2.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 112);
            this.panel1.TabIndex = 37;
            // 
            // txtTenLoaiSP
            // 
            this.txtTenLoaiSP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenLoaiSP.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLoaiSP.Location = new System.Drawing.Point(199, 82);
            this.txtTenLoaiSP.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenLoaiSP.Name = "txtTenLoaiSP";
            this.txtTenLoaiSP.Size = new System.Drawing.Size(585, 32);
            this.txtTenLoaiSP.TabIndex = 4;
            // 
            // txtMaLoaiSP
            // 
            this.txtMaLoaiSP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaLoaiSP.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLoaiSP.Location = new System.Drawing.Point(199, 39);
            this.txtMaLoaiSP.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaLoaiSP.Name = "txtMaLoaiSP";
            this.txtMaLoaiSP.Size = new System.Drawing.Size(585, 32);
            this.txtMaLoaiSP.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên Loại Sản Phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã Loại Sản Phẩm";
            // 
            // grBox
            // 
            this.grBox.BackColor = System.Drawing.Color.AliceBlue;
            this.grBox.Controls.Add(this.txtTenLoaiSP);
            this.grBox.Controls.Add(this.txtMaLoaiSP);
            this.grBox.Controls.Add(this.label3);
            this.grBox.Controls.Add(this.label2);
            this.grBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.grBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBox.ForeColor = System.Drawing.Color.SaddleBrown;
            this.grBox.Location = new System.Drawing.Point(0, 0);
            this.grBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grBox.Name = "grBox";
            this.grBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grBox.Size = new System.Drawing.Size(811, 135);
            this.grBox.TabIndex = 34;
            this.grBox.TabStop = false;
            this.grBox.Text = "Thông tin Loại Sản Phẩm";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bindingNavigator1);
            this.panel3.Controls.Add(this.grBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 344);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(811, 174);
            this.panel3.TabIndex = 38;
            // 
            // dgv_MaLoaiSP
            // 
            this.dgv_MaLoaiSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MaLoaiSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_Loai_San_Pham,
            this.Ten_Loai_San_Pham});
            this.dgv_MaLoaiSP.Location = new System.Drawing.Point(58, 103);
            this.dgv_MaLoaiSP.Name = "dgv_MaLoaiSP";
            this.dgv_MaLoaiSP.RowHeadersWidth = 51;
            this.dgv_MaLoaiSP.RowTemplate.Height = 24;
            this.dgv_MaLoaiSP.Size = new System.Drawing.Size(678, 236);
            this.dgv_MaLoaiSP.TabIndex = 40;
            this.dgv_MaLoaiSP.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_MaLoaiSP_RowEnter);
            // 
            // Ma_Loai_San_Pham
            // 
            this.Ma_Loai_San_Pham.DataPropertyName = "Ma_Loai_San_Pham";
            this.Ma_Loai_San_Pham.HeaderText = "Mã Loại Sản Phẩm";
            this.Ma_Loai_San_Pham.MinimumWidth = 6;
            this.Ma_Loai_San_Pham.Name = "Ma_Loai_San_Pham";
            this.Ma_Loai_San_Pham.Width = 125;
            // 
            // Ten_Loai_San_Pham
            // 
            this.Ten_Loai_San_Pham.DataPropertyName = "Ten_Loai_San_Pham";
            this.Ten_Loai_San_Pham.HeaderText = "Tên Loại Sản Phẩm";
            this.Ten_Loai_San_Pham.MinimumWidth = 6;
            this.Ten_Loai_San_Pham.Name = "Ten_Loai_San_Pham";
            this.Ten_Loai_San_Pham.Width = 125;
            // 
            // frm_LoaiSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 518);
            this.Controls.Add(this.dgv_MaLoaiSP);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "frm_LoaiSanPham";
            this.Text = "frm_LoaiSanPham";
            this.Load += new System.EventHandler(this.frm_LoaiSanPham_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grBox.ResumeLayout(false);
            this.grBox.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MaLoaiSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Button btnTKKH;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTenLoaiSP;
        private System.Windows.Forms.TextBox txtMaLoaiSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_MaLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_Loai_San_Pham;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_Loai_San_Pham;
    }
}