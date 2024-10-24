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
        string strconn = "Data Source=QUYNHTHU-PC\\QT;Initial Catalog=QLTraSua;Persist Security Info=True;User ID=sa;Password=hello";
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
            conn = new SqlConnection(strconn);
            conn.Open();
            LoadHoaDonNhap();
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
            //if (KiemTraTrungMaSo() == true)
            //{
            //    MessageBox.Show("Hóa đơn này đã tồn tại vui lòng nhập lại");
            //    txtMaHDN.Text = "";
            //    txtMaHDN.Focus();
            //}
            //else
            //{
            //    cmd = new SqlCommandBuilder(da);
            //    DataRow row = ds.Tables["HoaDonNhap"].NewRow();
            //    row["Ma_Hoa_Don_Nhap"] = txtMaHDN.Text;
            //    row["TenSP"] = txt_tensanpham.Text;
            //    row["Donvi"] = txt_donvitinh.Text;
            //    row["Gia"] = txt_gia.Text;
            //    row["Maloai"] = cbb_loaisanpham.SelectedValue.ToString();
            //    ds.Tables["SanPham"].Rows.Add(row);
            //}
            //if (da.Update(ds, "SanPham") > 0)
            //{
            //    MessageBox.Show("Đã lưu thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Lưu không thành công");
            //}
            //LoadNhaCungCap();
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
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                try
                {
                    conn.Open();

                    // Tạo SqlCommand để gọi Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("CapNhatHoaDonNhap", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số đầu vào cho thủ tục
                        cmd.Parameters.AddWithValue("@Ma_Hoa_Don_Nhap", txtMaHDN.Text);
                        cmd.Parameters.AddWithValue("@Ngay_Nhap", dtpNgayNhap.Text);
                        cmd.Parameters.AddWithValue("@Tong_Tien", txtThanhTien.Text);
                        cmd.Parameters.AddWithValue("@Ma_Nha_Cung_Cap", cmbNCC.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@Thoi_Gian", dtpThoiGian.Text);

                        // Thực thi thủ tục
                        cmd.ExecuteNonQuery();
                        LoadHoaDonNhap();
                        MessageBox.Show("Cập nhật hóa đơn nhập thành công.");

                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
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
    }
}
