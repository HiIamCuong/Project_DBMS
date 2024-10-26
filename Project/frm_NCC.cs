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
    public partial class frm_NCC : Form
    {
        public frm_NCC()
        {
            InitializeComponent();
            LayNhaCungCap();
        }
        string strCon = @"Data Source = DELL; Initial Catalog = QLTraSua; Integrated Security = True";
        SqlConnection sqlCon = null;
        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaNCC = txtMaNCC.Text;
            string TenNCC = txtTenNCC.Text;
            string DiaChi = txtDChi.Text;
            string SDT = txtSdt.Text;

            bool isSuccess = ThemNCC(MaNCC, TenNCC, DiaChi, SDT);
            if (isSuccess)
            {
                MessageBox.Show("Thêm nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayNhaCungCap();
                txtMaNCC.Clear();
                txtTenNCC.Clear();
                txtDChi.Clear();
                txtSdt.Clear();
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ThemNCC(string MaNCC, string TenNCC, string DiaChi, string SDT)
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("proc_ThemNhaCungCap", sqlCon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@MaNCC", SqlDbType.NChar).Value = MaNCC;
                command.Parameters.Add("@TenNCC", SqlDbType.NVarChar).Value = TenNCC;
                command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = DiaChi;
                command.Parameters.Add("@SDT", SqlDbType.NChar).Value = SDT;
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void LayNhaCungCap()
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM NhaCungCap", sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvNCC.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }


        private bool CapNhatNCC(string MaNCC, string TenNCC, string DiaChi, string SDT)
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("proc_SuaNhaCungCap", sqlCon);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@MaNCC", SqlDbType.NChar).Value = MaNCC;
                command.Parameters.Add("@TenNCC", SqlDbType.NVarChar).Value = TenNCC;
                command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = DiaChi;
                command.Parameters.Add("@SDT", SqlDbType.NChar).Value = SDT;

                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }
        private bool XoaNCC(string MaNCC)
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("proc_XoaNhaCungCap", sqlCon);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@MaNCC", SqlDbType.NChar).Value = MaNCC;

                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string MaNCC = txtMaNCC.Text;
            string TenNCC = txtTenNCC.Text;
            string DiaChi = txtDChi.Text;
            string SDT = txtSdt.Text;

            bool isSuccess = CapNhatNCC(MaNCC, TenNCC, DiaChi, SDT);
            if (isSuccess)
            {
                MessageBox.Show("Cập nhật nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayNhaCungCap();
            }
            else
            {
                MessageBox.Show("Cập nhật nhà cung cấp thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaNCC = txtMaNCC.Text;
            bool isSuccess = XoaNCC(MaNCC);
            if (isSuccess)
            {
                MessageBox.Show("Xóa nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayNhaCungCap();
            }
            else
            {
                MessageBox.Show("Xóa nhà cung cấp thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtMaNCC.Enabled = true;
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDChi.Clear();
            txtSdt.Clear();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LayNhaCungCap();
        }

        private void dgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaNCC.Enabled = false;
                DataGridViewRow row = dgvNCC.Rows[e.RowIndex];
                txtMaNCC.Text = row.Cells["Ma_Nha_Cung_Cap"].Value.ToString();
                txtTenNCC.Text = row.Cells["Ten_Nha_Cung_Cap"].Value.ToString();
                txtDChi.Text = row.Cells["Dia_Chi"].Value.ToString();
                txtSdt.Text = row.Cells["SDT"].Value.ToString();
            }
        }
        private DataTable TimKiemNCC(string timKiem)
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.TimKiemNCCBangTenNCCVaSDT(@TimKiem)", sqlCon);
                command.Parameters.Add("@TimKiem", SqlDbType.NVarChar).Value = "%" + timKiem + "%";
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
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
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timKiem = txtTimKiem.Text;

            DataTable result = TimKiemNCC(timKiem);
            if (result != null && result.Rows.Count > 0)
            {
                dgvNCC.DataSource = result;
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
