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
    public partial class frm_HoaDonNhap : Form
    {
        string strconn = "Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        SqlCommandBuilder cmd = null;
        public frm_HoaDonNhap()
        {
            InitializeComponent();
        }

        private void frm_HoaDonNhap_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM HoaDonNhap", conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvHDN.DataSource = dataTable;
            }
            conn = new SqlConnection(strconn);
            conn.Open();
            LoadNhaCungCap();
            conn.Close();

        }
        void LoadHoaDonNhap()
        {
            da = new SqlDataAdapter("Select * From HoaDonNhap", conn);
            ds = new DataSet();
            da.Fill(ds, "HoaDonNhap");
            dgvHDN.DataSource = ds.Tables["HoaDonNhap"];
        }

        void LoadNhaCungCap()
        {
            da = new SqlDataAdapter("Select * From NhaCungCap", conn);
            ds = new DataSet();
            da.Fill(ds, "NhaCungCap");
            cmbNCC.DataSource = ds.Tables["NhaCungCap"];
            cmbNCC.DisplayMember = "Ten_Nha_Cung_Cap";
            cmbNCC.ValueMember = "Ma_Nha_Cung_Cap";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime ngayNhap = dtpNgayNhap.Value;
            int tongTien = Convert.ToInt32(txtThanhTien.Text);
            string tenNCC = cmbNCC.Text;
            DateTime thoiGian = dtpThoiGian.Value.ToLocalTime();


            // Gọi phương thức thêm hóa đơn nhập
            ThemHoaDonNhap(ngayNhap, tongTien, tenNCC, thoiGian);

            LoadHoaDonNhap();
            LoadNhaCungCap();

        }
        public void ThemHoaDonNhap(DateTime ngayNhap, int tongTien, string tenNhaCungCap, DateTime thoiGian)
        {
            string conn = "Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    string maNCC;

                    // Lấy mã nhà cung cấp từ tên
                    using (SqlCommand command = new SqlCommand("SELECT dbo.GetMaNhaCungCap(@TenNhaCungCap)", connection))
                    {
                        command.Parameters.AddWithValue("@TenNhaCungCap", tenNhaCungCap);
                        var result = command.ExecuteScalar(); // Thực hiện câu lệnh và lấy kết quả

                        // Kiểm tra kiểu dữ liệu trước khi chuyển đổi
                        if (result != null && result != DBNull.Value)
                        {
                            // In ra giá trị nhận được để kiểm tra
                            MessageBox.Show($"Giá trị mã nhà cung cấp tìm thấy: {result.ToString()}", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            maNCC = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã nhà cung cấp cho tên đã cho.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Thoát nếu không tìm thấy
                        }
                    }

                    // Gọi thủ tục ThemHoaDonNhap
                    using (SqlCommand command = new SqlCommand("dbo.ThemHoaDonNhap", connection)) // Đảm bảo tên thủ tục chính xác
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Ngay_Nhap", ngayNhap);
                        command.Parameters.AddWithValue("@Tong_Tien", tongTien);
                        command.Parameters.AddWithValue("@Ma_Nha_Cung_Cap", maNCC);
                        command.Parameters.AddWithValue("@Thoi_Gian", thoiGian);

                        // Thực thi lệnh
                        command.ExecuteNonQuery(); // Thực thi lệnh và không trả về giá trị
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        private bool KiemTraTrungMaSo()
        {
            bool tmp = false;
            SqlDataAdapter da = new SqlDataAdapter("Select * From HoaDonNhap Where Ma_Hoa_Don_Nhap ='" + txtMaHDN.Text + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                tmp = true;
            return true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int maHDN = Convert.ToInt32(txtMaHDN.Text);
            DateTime ngayNhap = dtpNgayNhap.Value;
            int tongTien = Convert.ToInt32(txtThanhTien.Text);
            string tenNCC = cmbNCC.Text;
            DateTime thoiGian = dtpThoiGian.Value.ToLocalTime();


            // Gọi phương thức thêm hóa đơn nhập
            SuaHoaDonNhap(maHDN, ngayNhap, tongTien, tenNCC, thoiGian);

            LoadHoaDonNhap();
            LoadNhaCungCap();

        }

        private void dgvHDN_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHDN.Enabled = false;
            txtMaHDN.Text = dgvHDN.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtThanhTien.Text = dgvHDN.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtpNgayNhap.Value = Convert.ToDateTime(dgvHDN.Rows[e.RowIndex].Cells[1].Value);
            //dtpThoiGian.Value = Convert.ToDateTime(dgvHDN.Rows[e.RowIndex].Cells[4].Value);
            cmbNCC.SelectedValue = dgvHDN.Rows[e.RowIndex].Cells[3].Value.ToString();

            if (dgvHDN.Rows[e.RowIndex].Cells[4].Value != DBNull.Value)
            {
                object cellValue = dgvHDN.Rows[e.RowIndex].Cells[4].Value;
                if (cellValue is TimeSpan timeSpan)
                {
                    dtpThoiGian.Value = DateTime.Today.Add(timeSpan);
                }
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maHDN = Convert.ToInt32(txtMaHDN.Text);
            XoaHoaDonNhap(maHDN);
            LoadNhaCungCap();
            LoadHoaDonNhap();

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtMaHDN.Text = null;
            cmbNCC.Text = null;
            dtpNgayNhap.Value = DateTime.Now;
            dtpThoiGian.Value = DateTime.Now;
            txtThanhTien.Text = null;
            LoadNhaCungCap();
            LoadHoaDonNhap();

        }
        public void XoaHoaDonNhap(int maHDN)
        {
            string conn = "Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();

                    // Gọi thủ tục XoaHoaDonNhap
                    using (SqlCommand command = new SqlCommand("dbo.XoaHoaDonNhap", connection)) // Đảm bảo tên thủ tục chính xác
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
                        command.Parameters.AddWithValue("@Ma_Hoa_Don_Nhap", maHDN);

                        // Thực thi lệnh
                        command.ExecuteNonQuery(); // Thực thi lệnh và không trả về giá trị
                    }

                    MessageBox.Show("Xóa hóa đơn nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void SuaHoaDonNhap(int maHDN, DateTime ngayNhap, int tongTien, string tenNhaCungCap, DateTime thoiGian)
        {
            string conn = "Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    string maNCC;

                    // Lấy mã nhà cung cấp từ tên
                    using (SqlCommand command = new SqlCommand("SELECT dbo.GetMaNhaCungCap(@TenNhaCungCap)", connection))
                    {
                        command.Parameters.AddWithValue("@TenNhaCungCap", tenNhaCungCap);
                        var result = command.ExecuteScalar(); // Thực hiện câu lệnh và lấy kết quả

                        if (result != null && result != DBNull.Value)
                        {
                            // In ra giá trị nhận được để kiểm tra
                            MessageBox.Show($"Giá trị mã nhà cung cấp tìm thấy: {result.ToString()}", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            maNCC = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã nhà cung cấp cho tên đã cho.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Thoát nếu không tìm thấy
                        }
                    }

                    // Gọi thủ tục CapNhatHoaDonNhap
                    using (SqlCommand command = new SqlCommand("dbo.CapNhatHoaDonNhap", connection)) // Đảm bảo tên thủ tục chính xác
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số cho thủ tục
                        command.Parameters.AddWithValue("@Ma_Hoa_Don_Nhap", maHDN);
                        command.Parameters.AddWithValue("@Ngay_Nhap", ngayNhap);
                        command.Parameters.AddWithValue("@Tong_Tien", tongTien);
                        command.Parameters.AddWithValue("@Ma_Nha_Cung_Cap", maNCC);
                        command.Parameters.AddWithValue("@Thoi_Gian", thoiGian);

                        // Thực thi lệnh
                        command.ExecuteNonQuery(); // Thực thi lệnh và không trả về giá trị
                    }

                    MessageBox.Show("Cập nhật hóa đơn nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String timKiem = txtTimKiem.Text;
            DataTable result = TimKiemHDN(timKiem);
            if (result != null && result.Rows.Count > 0)

            {
                dgvHDN.DataSource = result;
            }

            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn nhập nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public DataTable TimKiemHDN(string timKiem)
        {
            string connectionString = @"Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TimKiemHDN(@timKiem)", conn);
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

        private void dgvHDN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvHDN.Rows[e.RowIndex];
                int maHDN = Convert.ToInt32(selectedRow.Cells["Ma_Hoa_Don_Nhap"].Value); // Adjust based on your column name

                // Create an instance of frm_CTHDN
                frm_CTHDN form = new frm_CTHDN();

                // Set the MaHDN property before showing the form
                form.txtSoHD.Text = maHDN.ToString();

                // Show the form
                form.Show();
            }
        }

    }

}
