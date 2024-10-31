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
    public partial class frm_CTHDN : Form
    {
        public frm_CTHDN()
        {
            InitializeComponent();
        }

        private void frm_CTHDN_Load(object sender, EventArgs e)
        {
            int maHoaDonNhap = Convert.ToInt32(txtSoHD.Text);
            LoadData(maHoaDonNhap);
            LoadNguyenLieuComboBox();

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            frm_HoaDonNhap form = new frm_HoaDonNhap();
            form.Show();

        }
        public DataTable LoadData(int maHoaDonNhap)
        {
            string connectionString = @"Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ChiTietHoaDonNhap WHERE Ma_Hoa_Don_Nhap = @maHoaDonNhap", conn);

                // Make sure to use the same parameter name here as in the query
                cmd.Parameters.AddWithValue("@maHoaDonNhap", maHoaDonNhap);

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(table);
                dgvCTHDN.DataSource = table; // Bind the data to DataGridView
                return table;
            };

        }
        public void LoadNguyenLieuComboBox()
        {
            string connectionString = @"Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Query to get the data for ComboBox
                SqlCommand cmd = new SqlCommand("SELECT Ma_Nguyen_Lieu, Ten_Nguyen_Lieu FROM NguyenLieu", conn);

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);

                // Bind the data to ComboBox
                cbMaNL.DataSource = table;
                cbMaNL.DisplayMember = "Ten_Nguyen_Lieu"; // The name displayed in ComboBox
                cbMaNL.ValueMember = "Ma_Nguyen_Lieu";    // The actual value associated with each item
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int maHoaDonNhap = Convert.ToInt32(txtSoHD.Text);
            string maNguyenLieu = cbMaNL.SelectedValue.ToString();
            int donGia = Convert.ToInt32(txtDG.Text);
            int soLuong = Convert.ToInt32(txtSL.Text);
            ThemChiTietHoaDonNhap(maHoaDonNhap, maNguyenLieu, donGia, soLuong);
            try
            {
                // Gọi procedure để cập nhật tổng tiền
                UpdateTongTienHoaDonNhap(maHoaDonNhap);

                MessageBox.Show("Tổng tiền đã được cập nhật thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData(maHoaDonNhap);
            LoadNguyenLieuComboBox();

        }
        public void ThemChiTietHoaDonNhap(int maHoaDonNhap, string maNguyenLieu, int donGia, int soLuong)
        {
            // Connection string - adjust according to your database setup
            string connString = "Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("ThemChiTietHoaDonNhap", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Ma_Hoa_Don_Nhap", maHoaDonNhap);
                        cmd.Parameters.AddWithValue("@Ma_Nguyen_Lieu", maNguyenLieu);
                        cmd.Parameters.AddWithValue("@Don_Gia", donGia);
                        cmd.Parameters.AddWithValue("@So_Luong", soLuong);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Chi tiết hóa đơn nhập đã được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtDG.Text = null;
            txtSL.Text = null;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int maHoaDonNhap = Convert.ToInt32(txtSoHD.Text);
            string maNguyenLieu = cbMaNL.SelectedValue.ToString();
            int donGia = Convert.ToInt32(txtDG.Text);
            int soLuong = Convert.ToInt32(txtSL.Text);
            SuaChiTietHoaDonNhap(maHoaDonNhap, maNguyenLieu, donGia, soLuong);
            try
            {
                // Gọi procedure để cập nhật tổng tiền
                UpdateTongTienHoaDonNhap(maHoaDonNhap);

                MessageBox.Show("Tổng tiền đã được cập nhật thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData(maHoaDonNhap);
            LoadNguyenLieuComboBox();

        }
        public void SuaChiTietHoaDonNhap(int maHoaDonNhap, string maNguyenLieu, int donGia, int soLuong)
        {
            string conn = "Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SuaChiTietHoaDonNhap", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Ma_Hoa_Don_Nhap", maHoaDonNhap);
                        cmd.Parameters.AddWithValue("@Ma_Nguyen_Lieu", maNguyenLieu);
                        cmd.Parameters.AddWithValue("@Don_Gia", donGia);
                        cmd.Parameters.AddWithValue("@So_Luong", soLuong);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Chi tiết hóa đơn nhập đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCTHDNhap_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maHoaDonNhap = Convert.ToInt32(txtSoHD.Text);
            string maNguyenLieu = cbMaNL.SelectedValue.ToString();
            XoaChiTietHoaDonNhap(maHoaDonNhap, maNguyenLieu);
            LoadData(maHoaDonNhap);
            LoadNguyenLieuComboBox();

        }
        public void XoaChiTietHoaDonNhap(int maHoaDonNhap, string maNguyenLieu)
        {
            string conn = "Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("XoaChiTietHoaDonNhap", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Ma_Hoa_Don_Nhap", maHoaDonNhap);
                        cmd.Parameters.AddWithValue("@Ma_Nguyen_Lieu", maNguyenLieu);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Chi tiết hóa đơn nhập đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {

            string maHoaDon = txtSoHD.Text.Trim();
            if (string.IsNullOrEmpty(maHoaDon))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = new DataTable();
            string query = "SELECT * FROM ChiTietHoaDonNhap WHERE Ma_Hoa_Don_Nhap = @MaHoaDon";

            using (SqlConnection conn = new SqlConnection("Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True"))
            {
                conn.Open();

                // Gọi procedure để cập nhật nguyên liệu
                using (SqlCommand cmd = new SqlCommand("XuatHoaDonNhap", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ma_Hoa_Don_Nhap", int.Parse(maHoaDon));
                    cmd.ExecuteNonQuery();
                }

                // Truy vấn dữ liệu để điền vào DataTable
                using (SqlCommand lenh = new SqlCommand(query, conn))
                {
                    lenh.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    SqlDataAdapter da = new SqlDataAdapter(lenh);
                    da.Fill(dt);
                }

                // Khởi tạo và truyền dữ liệu cho Crystal Report
                CrystalReport1 r = new CrystalReport1();
                r.Database.Tables[0].SetDataSource(dt);

                // Hiển thị báo cáo trong form
                frm_XuatHoaDon f = new frm_XuatHoaDon();
                f.crystalReportViewer1.ReportSource = r;
                f.ShowDialog();
            }

        }
        private void UpdateTongTienHoaDonNhap(int maHoaDonNhap)
        {
            string connectionString = "Data Source=TISU;Initial Catalog=QLyTraSua;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Khởi tạo lệnh SQL để gọi procedure
                using (SqlCommand cmd = new SqlCommand("sp_UpdateTongTienHoaDonNhap", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số cho procedure
                    cmd.Parameters.AddWithValue("@Ma_Hoa_Don_Nhap", maHoaDonNhap);

                    // Mở kết nối và thực thi lệnh
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void dgvCTHDN_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtSoHD.Enabled = false;
            txtDG.Text = dgvCTHDN.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSL.Text = dgvCTHDN.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbMaNL.SelectedValue = dgvCTHDN.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }

}

