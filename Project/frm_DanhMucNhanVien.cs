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
    public partial class frm_DanhMucNhanVien : Form
    {
        public frm_DanhMucNhanVien()
        {
            InitializeComponent();
        }

        private void frm_DanhMucNhanVien_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM NhanVien", conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvNhanVien.DataSource = dataTable;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;
            DateTime ngaySinh = txtNgaySinh.Value.Date;
            string gioiTinh = cmbGTinh.SelectedText.ToString();
            string diaChi = txtDChi.Text;
            string sdt = txtSdt.Text;
            string maViTri = cmbMaViTri.Text;
            string maTaiKhoan = txtMaTK.Text;
            DateTime ngayTuyenDung = txtNgayTD.Value.Date;

            //MessageBox.Show(ngaySinh.ToShortDateString());
            ThemNhanVien(maNV, tenNV, ngaySinh, gioiTinh, diaChi, sdt, maViTri, maTaiKhoan, ngayTuyenDung);

        }

        private void ThemNhanVien(string maNV, string tenNV, DateTime ngaySinh, string gioiTinh, string diaChi, string sdt, string maViTri, string maTaiKhoan, DateTime ngayTuyenDung)
        {
            string connectionString = @"Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("dbo.pro_ThemNhanVien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@TenNV", tenNV);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@MaViTri", maViTri);
                    cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cmd.Parameters.AddWithValue("@NgayTuyenDung", ngayTuyenDung);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                XoaNhanVien(maNV);
            }

        }
        private void XoaNhanVien(string maNV)
        {
            string connectionString = @"Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.pro_XoaNhanVien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaNV", maNV);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;
            DateTime ngaySinh = txtNgaySinh.Value.Date;
            string gioiTinh = cmbGTinh.SelectedItem.ToString();
            string diaChi = txtDChi.Text;
            string sdt = txtSdt.Text;
            string maViTri = cmbMaViTri.Text;
            string maTaiKhoan = txtMaTK.Text;
            DateTime ngayTuyenDung = txtNgayTD.Value.Date;
            CapNhatNhanVien(maNV, tenNV, ngaySinh, gioiTinh, diaChi, sdt, maViTri, maTaiKhoan, ngayTuyenDung);

        }
        private void CapNhatNhanVien(string maNV, string tenNV, DateTime ngaySinh, string gioiTinh, string diaChi, string sdt, string maViTri, string maTaiKhoan, DateTime ngayTuyenDung)
        {
            string connectionString = @"Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("dbo.pro_CapNhatNhanVien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@TenNV", tenNV);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@MaViTri", maViTri);
                    cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cmd.Parameters.AddWithValue("@NgayTuyenDung", ngayTuyenDung);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTKKH_Click(object sender, EventArgs e)
        {
            String timKiem = txtTK.Text;
            DataTable result = TimKiemNhanVien(timKiem);
            if (result != null && result.Rows.Count > 0)

            {
                dgvNhanVienaaa.DataSource = result;
    }

            else
            {
                MessageBox.Show("Không tìm thấy nhân viên nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private DataTable TimKiemNhanVien(string timKiem)
        {
            string connectionString = @"Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TimKiemNhanVien(@TimKiem)", conn);
                    cmd.Parameters.Add("@TimKiem", SqlDbType.NVarChar).Value = timKiem;
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    return table;
}
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                finally
                {
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

        }
    }
}




