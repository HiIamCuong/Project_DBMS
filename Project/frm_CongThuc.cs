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
    public partial class frm_CongThuc : Form
    {
        public frm_CongThuc()
        {
            InitializeComponent();
            LoadSanPham();
            LoadNguyenLieu();
            LayCongThuc();
        }
        string strCon = @"Data Source=DESKTOP-GIJL260;Initial Catalog=QLTraSua;Integrated Security=True";
        SqlConnection sqlCon = null;
        private bool ThemCongThuc(string MaSP, string MaNL, int SoLuong, string DonVi)
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("proc_ThemCongThuc", sqlCon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@MaSP", SqlDbType.NChar).Value = MaSP;
                command.Parameters.Add("@MaNL", SqlDbType.NVarChar).Value = MaNL;
                command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;
                command.Parameters.Add("@DonVi", SqlDbType.NChar).Value = DonVi;

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
        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaSP = cbbMaSP.SelectedValue.ToString();
            string MaNL = cbMaNL.SelectedValue.ToString();
            int SoLuong = int.Parse(txtSoLuong.Text);
            string DonVi = cmbDonVi.SelectedText.ToString();

            bool isSuccess = ThemCongThuc(MaSP, MaNL, SoLuong, DonVi);
            if (isSuccess)
            {
                MessageBox.Show("Thêm nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayCongThuc();
                txtSoLuong.Clear();
                txtSoLuong.Clear();
            }
            else
            {
                MessageBox.Show("Thêm nguyên liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool SuaCongThuc(string MaSP, string MaNL, int SoLuong, string DonVi)
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("proc_SuaCongThuc", sqlCon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@MaSP", SqlDbType.NChar).Value = MaSP;
                command.Parameters.Add("@MaNL", SqlDbType.NChar).Value = MaNL;
                command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;
                command.Parameters.Add("@DonVi", SqlDbType.NChar).Value = DonVi;

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
            string MaSP = cbbMaSP.SelectedValue.ToString();
            string MaNL = cbMaNL.SelectedValue.ToString();
            int SoLuong = int.Parse(txtSoLuong.Text);
            string DonVi = cmbDonVi.SelectedText.ToString();

            bool isSuccess = SuaCongThuc(MaSP, MaNL, SoLuong, DonVi);
            if (isSuccess)
            {
                MessageBox.Show("Cập nhật công thức thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayCongThuc();
            }
            else
            {
                MessageBox.Show("Cập nhật công thức thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool XoaCongThuc(string MaSP, string MaNL)
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("proc_XoaCongThuc", sqlCon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@MaSP", SqlDbType.NChar).Value = MaSP;
                command.Parameters.Add("@MaNL", SqlDbType.NChar).Value = MaNL;
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
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaSP = cbbMaSP.SelectedValue.ToString();
            string MaNL = cbMaNL.SelectedValue.ToString();
            bool isSuccess = XoaCongThuc(MaSP, MaNL);
            if (isSuccess)
            {
                MessageBox.Show("Xóa công thức thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayCongThuc();
            }
            else
            {
                MessageBox.Show("Xóa công thức thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            cbbMaSP.Focus();
            cbMaNL.Focus();
            txtSoLuong.Clear();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LayCongThuc();
        }

        private void LoadSanPham()
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("SELECT Ma_San_Pham, Ten_San_Pham FROM SanPham", sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cbbMaSP.DataSource = dt;
                cbbMaSP.DisplayMember = "Ten_San_Pham";
                cbbMaSP.ValueMember = "Ma_San_Pham";
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

        private void LoadNguyenLieu()
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("SELECT Ma_Nguyen_Lieu, Ten_Nguyen_Lieu FROM NguyenLieu", sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cbMaNL.DataSource = dt;
                cbMaNL.DisplayMember = "Ten_Nguyen_Lieu";
                cbMaNL.ValueMember = "Ma_Nguyen_Lieu";
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
        private void LayCongThuc()
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM CongThuc", sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvCongthuc.DataSource = dt;
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

        private void dgvCongthuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCongthuc.Rows[e.RowIndex];
                cbbMaSP.SelectedValue = row.Cells["Ma_San_Pham"].Value.ToString();
                cbMaNL.SelectedValue = row.Cells["Ma_Nguyen_Lieu"].Value.ToString();
                txtSoLuong.Text = row.Cells["So_Luong"].Value.ToString();
                cmbDonVi.Text = row.Cells["DonVi"].Selected.ToString();
            }
        }

        private void btnHuyBo_Click_1(object sender, EventArgs e)
        {
            cbbMaSP.Focus();
            cbMaNL.Focus();
            txtSoLuong.Clear();
        }

        private void btnReload_Click_1(object sender, EventArgs e)
        {
            LayCongThuc();
        }

    }
}
