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
    public partial class frm_KhachHang : Form
    {
        public frm_KhachHang()
        {
            InitializeComponent();
            loaddata();
        }
        string strCon = @"Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";
        SqlConnection sqlCon = null;
        private void loaddata()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM KhachHang", sqlCon))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvKHACHHANG.DataSource = dt;
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            //string maKH = txtMaKH.Text;
            string tenKH = txtTenKH.Text;
            DateTime ngaySinh = dtpNgayNhap.Value;
            string sdt = txtSDT.Text;

            ThemKhachHang(/*maKH,*/ tenKH, ngaySinh, sdt);

        }

        private void ThemKhachHang(/*string maKH,*/ string tenKH, DateTime ngaySinh, string sdt)
        {
            string connectionString = @"Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("dbo.pro_ThemKhachHang", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("@MaKH", maKH);
                    cmd.Parameters.AddWithValue("@TenKH", tenKH);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@SDT", sdt);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text;
            string tenKH = txtTenKH.Text;
            DateTime ngaySinh = dtpNgayNhap.Value;
            string sdt = txtSDT.Text;

            CapNhatKhachHang(maKH, tenKH, ngaySinh, sdt);

        }

        private void CapNhatKhachHang(string maKH, string tenKH, DateTime ngaySinh, string sdt)
        {
            string connectionString = @"Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("dbo.pro_CapNhatKhachHang", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    cmd.Parameters.AddWithValue("@TenKH", tenKH);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@SDT", sdt);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DataTable result = TimKiemKhachHang(timKiem);
            if (result != null && result.Rows.Count > 0)

            {
                dgvKH.DataSource = result;
    }

            else
            {
                MessageBox.Show("Không tìm thấy khách hàng nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private DataTable TimKiemKhachHang(string timKiem)
        {
            string connectionString = @"Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TimKiemKhachHang(@TimKiem)", conn);
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



