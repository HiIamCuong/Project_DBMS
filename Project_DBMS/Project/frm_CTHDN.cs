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

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            frm_HoaDonNhap form = new frm_HoaDonNhap();

            // Option 1: Show the form non-modally
            form.Show();


        }
        
        private void frm_CTHDN_Load(object sender, EventArgs e)
        {
            int maHoaDonNhap = Convert.ToInt32(txtSoHD.Text);
            LoadData(maHoaDonNhap);
            LoadNguyenLieuComboBox();
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
            int  donGia = Convert.ToInt32(txtDG.Text);
            int soLuong = Convert.ToInt32(txtSL.Text);
            ThemChiTietHoaDonNhap(maHoaDonNhap, maNguyenLieu, donGia, soLuong);
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

        private void dgvCTHDN_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtSoHD.Enabled = false;
            txtDG.Text = dgvCTHDN.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSL.Text = dgvCTHDN.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbMaNL.SelectedValue = dgvCTHDN.Rows[e.RowIndex].Cells[1].Value.ToString();
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
    }
}
