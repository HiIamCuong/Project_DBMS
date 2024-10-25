using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class frm_TaiKhoan : Form
    {
        public frm_TaiKhoan()
        {
            InitializeComponent();
        }

        private void frm_TaiKhoan_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT NhanVien.Ma_Nhan_Vien, NhanVien.Ten_Nhan_Vien, ViTri.Ten_Vi_Tri FROM NhanVien JOIN ViTri ON NhanVien.Ma_Vi_Tri = ViTri.Ma_Vi_Tri", conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvAccount.DataSource = dataTable;
            }
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAccount.Rows[e.RowIndex];
                txtmaNV.Text = row.Cells["Ma_Nhan_Vien"].Value.ToString();
                txtUser.Text = row.Cells["Ten_Nhan_Vien"].Value.ToString();
                txtRole.Text = row.Cells["Ten_Vi_Tri"].Value.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtmaNV.Text; // TextBox cho mã nhân viên
            string matKhau = txtPassword.Text; // TextBox cho mật khẩu

            string connectionString = @"Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("AddPasswordByEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ma_Nhan_Vien", maNhanVien);
                    cmd.Parameters.AddWithValue("@Mat_Khau", matKhau);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm hoặc cập nhật mật khẩu thành công.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
        }
    }
}
