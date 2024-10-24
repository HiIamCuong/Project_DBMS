namespace Project
{
    partial class KetNoi
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
            this.btn_DongKetNoi = new System.Windows.Forms.Button();
            this.btn_MoKetNoi = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_DongKetNoi
            // 
            this.btn_DongKetNoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DongKetNoi.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DongKetNoi.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btn_DongKetNoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DongKetNoi.Location = new System.Drawing.Point(340, 186);
            this.btn_DongKetNoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_DongKetNoi.Name = "btn_DongKetNoi";
            this.btn_DongKetNoi.Size = new System.Drawing.Size(159, 59);
            this.btn_DongKetNoi.TabIndex = 93;
            this.btn_DongKetNoi.Text = "Đóng kết nối";
            this.btn_DongKetNoi.UseVisualStyleBackColor = true;
            this.btn_DongKetNoi.Click += new System.EventHandler(this.btn_DongKetNoi_Click);
            // 
            // btn_MoKetNoi
            // 
            this.btn_MoKetNoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MoKetNoi.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MoKetNoi.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btn_MoKetNoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MoKetNoi.Location = new System.Drawing.Point(98, 186);
            this.btn_MoKetNoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_MoKetNoi.Name = "btn_MoKetNoi";
            this.btn_MoKetNoi.Size = new System.Drawing.Size(159, 59);
            this.btn_MoKetNoi.TabIndex = 94;
            this.btn_MoKetNoi.Text = "Mở kết nối";
            this.btn_MoKetNoi.UseVisualStyleBackColor = true;
            this.btn_MoKetNoi.Click += new System.EventHandler(this.btn_MoKetNoi_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 99);
            this.panel1.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(115, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 49);
            this.label1.TabIndex = 50;
            this.label1.Text = "KẾT NỐI DATABASE";
            // 
            // KetNoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(586, 369);
            this.Controls.Add(this.btn_DongKetNoi);
            this.Controls.Add(this.btn_MoKetNoi);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "KetNoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KetNoi";
            this.Load += new System.EventHandler(this.KetNoi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_DongKetNoi;
        private System.Windows.Forms.Button btn_MoKetNoi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

