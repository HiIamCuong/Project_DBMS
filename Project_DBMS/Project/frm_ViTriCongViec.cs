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
    public partial class frm_ViTriCongViec : Form
    {
        public frm_ViTriCongViec()
        {
            InitializeComponent();
        }

        private void frm_ViTriCongViec_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maVT = txtMaViTri.Text;
            string tenVT = txtTenViTri.Text;
            int luongCD = int.TryParse(txtPCLuong.Text, out int value) ? value : 0;

            ThemViTri(maVT, tenVT, luongCD);

        }
        private void ThemViTri(string maVT, string tenVT, int luongCD)
        {
            string connectionString = @"Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("dbo.pro_ThemViTri", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaVT", maVT);
                    cmd.Parameters.AddWithValue("@TenVT", tenVT);
                    cmd.Parameters.AddWithValue("@Luong", luongCD);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm vị trí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maVT = txtMaViTri.Text;
            string tenVT = txtTenViTri.Text;
            int luongCD = int.TryParse(txtPCLuong.Text, out int value) ? value : 0;

            CapNhatViTri(maVT, tenVT, luongCD);

        }

        private void CapNhatViTri(string maVT, string tenVT, int luongCD)
        {
            string connectionString = @"Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("dbo.pro_CapNhatViTri", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaVT", maVT);
                    cmd.Parameters.AddWithValue("@TenVT", tenVT);
                    cmd.Parameters.AddWithValue("@Luong", luongCD);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thông tin vị trí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maVT = txtMaViTri.Text;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa vị trí này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                XoaViTri(maVT);
            }

        }
        private void XoaViTri(string maVT)
        {
            string connectionString = @"Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.pro_XoaViTri", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaVT", maVT);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa vị trí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}


