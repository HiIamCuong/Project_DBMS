using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Project
{
    public partial class frm_NguyenLieu : Form
    {

        public frm_NguyenLieu()
        {
            InitializeComponent();
            LayNguyenLieu();
            LoadNhaCungCap();
        }
        string strCon = @"Data Source=DESKTOP-GIJL260;Initial Catalog=QLTraSua;Integrated Security=True";
        SqlConnection sqlCon = null;
        private string selectedImagePath = string.Empty;
        private bool ThemNguyenLieu(string MaNL, string TenNL, string MaNCC, int DonGia, int SoLuong, string DonVi)
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("proc_ThemNguyenLieu", sqlCon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@MaNL", SqlDbType.NChar).Value = MaNL;
                command.Parameters.Add("@TenNL", SqlDbType.NVarChar).Value = TenNL;
                command.Parameters.Add("@MaNCC", SqlDbType.NChar).Value = MaNCC;
                command.Parameters.Add("@DonGia", SqlDbType.Int).Value = DonGia;
                command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;
                command.Parameters.Add("@DonVi", SqlDbType.NChar).Value = DonVi;
                command.Parameters.Add("@Anh", SqlDbType.NVarChar).Value = selectedImagePath;

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
            string MaNL = txtMaNL.Text;
            string TenNL = txtTenNL.Text;
            string MaNCC = cmbNCC.SelectedValue.ToString(); 
            int DonGia = int.Parse(txtDongia.Text);
            int SoLuong = int.Parse(txtSoLuong.Text);
            string DonVi = txtDonVi.Text;

            bool isSuccess = ThemNguyenLieu(MaNL, TenNL, MaNCC, DonGia, SoLuong, DonVi);
            if (isSuccess)
            {
                MessageBox.Show("Thêm nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayNguyenLieu();
                txtMaNL.Clear();
                txtTenNL.Clear();
                txtDongia.Clear();
                txtSoLuong.Clear();
                txtDonVi.Clear();
            }
            else
            {
                MessageBox.Show("Thêm nguyên liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CapNhatNguyenLieu(string MaNL, string TenNL, string MaNCC, int DonGia, int SoLuong, string DonVi)
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("proc_SuaNguyenLieu", sqlCon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@MaNL", SqlDbType.NChar).Value = MaNL;
                command.Parameters.Add("@TenNL", SqlDbType.NVarChar).Value = TenNL;
                command.Parameters.Add("@MaNCC", SqlDbType.NChar).Value = MaNCC;
                command.Parameters.Add("@DonGia", SqlDbType.Int).Value = DonGia;
                command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;
                command.Parameters.Add("@DonVi", SqlDbType.NChar).Value = DonVi;
                command.Parameters.Add("@Anh", SqlDbType.NVarChar).Value = selectedImagePath;

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
            string MaNL = txtMaNL.Text;
            string TenNL = txtTenNL.Text;
            string MaNCC = cmbNCC.Text;
            int DonGia = int.Parse(txtDongia.Text);
            int SoLuong = int.Parse(txtSoLuong.Text);
            string DonVi = txtDonVi.Text;
            string Anh = pic.ToString(); 

            bool isSuccess = CapNhatNguyenLieu(MaNL, TenNL, MaNCC, DonGia, SoLuong, DonVi);
            if (isSuccess)
            {
                MessageBox.Show("Cập nhật nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayNguyenLieu();
            }
            else
            {
                MessageBox.Show("Cập nhật nguyên liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvNGUYENLIEU_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNGUYENLIEU.Rows[e.RowIndex];
                txtMaNL.Text = row.Cells["Ma_Nguyen_Lieu"].Value.ToString();
                txtTenNL.Text = row.Cells["Ten_Nguyen_Lieu"].Value.ToString();
                txtDongia.Text = row.Cells["Don_Gia"].Value.ToString();
                txtSoLuong.Text = row.Cells["So_Luong"].Value.ToString();
                txtDonVi.Text = row.Cells["Don_Vi"].Value.ToString();
                cmbNCC.SelectedValue = row.Cells["Ma_Nha_Cung_Cap"].Value.ToString(); 
                string imagePath = row.Cells["Anh"].Value.ToString();
                if (File.Exists(imagePath))
                {
                    pic.Image = Image.FromFile(imagePath);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pic.Image = null;
                }
            }
        }
        private bool XoaNguyenLieu(string MaNL)
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("proc_XoaNguyenLieu", sqlCon);
                command.CommandType = CommandType.StoredProcedure;
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
            string MaNL = txtMaNL.Text;
            bool isSuccess = XoaNguyenLieu(MaNL);
            if (isSuccess)
            {
                MessageBox.Show("Xóa nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayNguyenLieu();
            }
            else
            {
                MessageBox.Show("Xóa nguyên liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtMaNL.Clear();
            txtTenNL.Clear();
            txtDongia.Clear();
            txtSoLuong.Clear();
            txtDonVi.Clear();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LayNguyenLieu();
        }
        private void LayNguyenLieu()
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM NguyenLieu", sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvNGUYENLIEU.DataSource = dt;
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

        private void btn_Upanh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"; 
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName; 
                    pic.Image = Image.FromFile(selectedImagePath);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
        private void LoadNhaCungCap()
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("SELECT Ma_Nha_Cung_Cap, Ten_Nha_Cung_Cap FROM NhaCungCap", sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbNCC.DataSource = dt; 
                cmbNCC.DisplayMember = "Ten_Nha_Cung_Cap"; 
                cmbNCC.ValueMember = "Ma_Nha_Cung_Cap"; 
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
        private DataTable TimKiemNL(string tennl)
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.TimKiemNCCBangTenNguyenLieu(@NL)", sqlCon);
                command.Parameters.Add("@NL", SqlDbType.NVarChar).Value = "%" + tennl + "%";
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

            DataTable result = TimKiemNL(timKiem);
            if (result != null && result.Rows.Count > 0)
            {
                dgvNGUYENLIEU.DataSource = result;
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
