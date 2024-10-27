using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class frm_NguyenLieu : Form
    {
        public frm_NguyenLieu()
        {
            InitializeComponent();
        }

        string strconn = @"Data Source=DESKTOP-GIJL260;Initial Catalog=QLTraSua;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        void LoadNguyenLieu()
        {
            da = new SqlDataAdapter("Select * From NguyenLieu", conn);
            ds = new DataSet();
            da.Fill(ds, "NguyenLieu");
            dgvNGUYENLIEU.DataSource = ds.Tables["NguyenLieu"];
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
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("proc_ThemNguyenLieu", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaNL", txtMaNL.Text);
                        cmd.Parameters.AddWithValue("@TenNL", txtTenNL.Text);
                        cmd.Parameters.AddWithValue("@DonGia", txtDongia.Text);
                        cmd.Parameters.AddWithValue("@SoLuong", txtSoLuong.Text);
                        cmd.Parameters.AddWithValue("@DonVi", cmbDonVi.SelectedText.ToString());
                        cmd.Parameters.AddWithValue("@MaNCC", cmbNCC.SelectedValue.ToString());

                        byte[] imageBytes = null;
                        if (pictureBox1.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                                imageBytes = ms.ToArray();
                                cmd.Parameters.AddWithValue("@Anh", imageBytes);
                            }
                        }
                        cmd.ExecuteNonQuery();
                        LoadNguyenLieu();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi từ trigger hoặc cơ sở dữ liệu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("proc_SuaNguyenLieu", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaNL", txtMaNL.Text);
                        cmd.Parameters.AddWithValue("@TenNL", txtTenNL.Text);
                        cmd.Parameters.AddWithValue("@DonGia", txtDongia.Text);
                        cmd.Parameters.AddWithValue("@SoLuong", txtSoLuong.Text);
                        cmd.Parameters.AddWithValue("@DonVi", cmbDonVi.SelectedText.ToString());
                        cmd.Parameters.AddWithValue("@MaNCC", cmbNCC.SelectedValue.ToString());

                        byte[] imageBytes = null;
                        if (pictureBox1.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                                imageBytes = ms.ToArray();
                                cmd.Parameters.AddWithValue("@Anh", imageBytes);
                            }
                        }
                        cmd.ExecuteNonQuery();
                        LoadNguyenLieu();
                        txtMaNL.Enabled = true;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi từ trigger hoặc cơ sở dữ liệu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("proc_XoaNguyenLieu", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaNL", txtMaNL.Text);
                        cmd.ExecuteNonQuery();
                        LoadNguyenLieu();
                        txtMaNL.Enabled = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtMaNL.Clear();
            txtTenNL.Clear();
            txtDongia.Clear();
            txtSoLuong.Clear();
            pictureBox1.Image = null;
        }


        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadNguyenLieu();
        }

        
        private void btn_Upanh_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }


        private DataTable TimKiemNL(string tennl)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strconn))
                {
                    sqlCon.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.TimKiemBangTenNguyenLieu(@NL)", sqlCon))
                    {
                        command.Parameters.Add("@NL", SqlDbType.NVarChar).Value = "%" + tennl + "%";
                        DataTable table = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
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

        private void frm_NguyenLieu_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strconn);
            conn.Open();
            LoadNguyenLieu();
            LoadNhaCungCap();
            conn.Close();
        }

        private void dgvNGUYENLIEU_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= dgvNGUYENLIEU.Rows.Count - 1)
            {
                txtMaNL.Enabled = true;
                txtTenNL.Text = "";
                cmbDonVi.Text = "";
                txtDongia.Text = "";
                txtSoLuong.Text = "";
            }
            else
            {
                txtMaNL.Enabled = false;
                txtMaNL.Text = dgvNGUYENLIEU.Rows[e.RowIndex].Cells["Ma_Nguyen_Lieu"].Value.ToString();
                txtTenNL.Text = dgvNGUYENLIEU.Rows[e.RowIndex].Cells["Ten_Nguyen_Lieu"].Value.ToString();
                txtDongia.Text = dgvNGUYENLIEU.Rows[e.RowIndex].Cells["Don_Gia"].Value.ToString();
                txtSoLuong.Text = dgvNGUYENLIEU.Rows[e.RowIndex].Cells["So_Luong"].Value.ToString();
                cmbDonVi.Text = dgvNGUYENLIEU.Rows[e.RowIndex].Cells["Don_Vi"].Value.ToString();
                string maNCC = dgvNGUYENLIEU.Rows[e.RowIndex].Cells["Ma_Nha_Cung_Cap"].Value.ToString();
                if (cmbNCC.Items.Cast<DataRowView>().Any(item => item["Ma_Nha_Cung_Cap"].ToString() == maNCC))
                {
                    cmbNCC.SelectedValue = maNCC;
                }
                else
                {
                    cmbNCC.SelectedIndex = -1;
                }
                if (dgvNGUYENLIEU.Rows[e.RowIndex].Cells["Anh"].Value != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])dgvNGUYENLIEU.Rows[e.RowIndex].Cells["Anh"].Value;
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

    }
}