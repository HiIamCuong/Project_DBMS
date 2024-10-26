using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class frm_SanPham : Form
    {
        string strconn = "Data Source=DESKTOP-GIJL260;Initial Catalog=QLTraSua;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        public frm_SanPham()
        {
            InitializeComponent();
        }

        private void btn_TaiAnh_Click(object sender, EventArgs e)
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

        private void frm_SanPham_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strconn);
            conn.Open();
            LoadSanPham();
            LoadLoaiSanPham();
            conn.Close();
        }

        void LoadSanPham()
        {
            da = new SqlDataAdapter("Select * From SanPham", conn);
            ds = new DataSet();
            da.Fill(ds, "SanPham");
            dgvSANPHAM.DataSource = ds.Tables["SanPham"];
        }

        void LoadLoaiSanPham()
        {
            da = new SqlDataAdapter("Select * From LoaiSanPham", conn);
            ds = new DataSet();
            da.Fill(ds, "LoaiSanPham");
            cmbMaLoaiSP.DataSource = ds.Tables["LoaiSanPham"];
            cmbMaLoaiSP.DisplayMember = "Ten_Loai_San_Pham";
            cmbMaLoaiSP.ValueMember = "Ma_Loai_San_Pham";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("ThemSanPham", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Ma_San_Pham", txtMaSP.Text);
                        cmd.Parameters.AddWithValue("@Ten_San_Pham", txtTenSP.Text);
                        cmd.Parameters.AddWithValue("@Don_Gia", txtDonGia.Text);
                        cmd.Parameters.AddWithValue("@Ma_Loai_San_Pham", cmbMaLoaiSP.SelectedValue.ToString());

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
                        LoadSanPham();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void dgvSANPHAM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= dgvSANPHAM.Rows.Count - 1)
            {
                txtMaSP.Enabled = true;
                txtMaSP.Text = "";
                txtMaSP.Focus();
                txtTenSP.Text = "";
                txtDonGia.Text = "";
            }
            else
            {
                txtMaSP.Enabled = false;
                txtMaSP.Text = dgvSANPHAM.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenSP.Text = dgvSANPHAM.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDonGia.Text = dgvSANPHAM.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbMaLoaiSP.SelectedValue = dgvSANPHAM.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (dgvSANPHAM.Rows[e.RowIndex].Cells["Anh"].Value != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])dgvSANPHAM.Rows[e.RowIndex].Cells["Anh"].Value;

                    // Chuyển đổi byte[] thành MemoryStream để hiển thị ảnh
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                try
                {
                    conn.Open();

                    // Tạo SqlCommand để gọi Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("SuaSanPham", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Ma_San_Pham", txtMaSP.Text);
                        cmd.Parameters.AddWithValue("@Ten_San_Pham", txtTenSP.Text);
                        cmd.Parameters.AddWithValue("@Don_Gia", txtDonGia.Text);
                        cmd.Parameters.AddWithValue("@Ma_Loai_San_Pham", cmbMaLoaiSP.SelectedValue.ToString());

                        byte[] imageBytes = null;
                        if (pictureBox1.Image != null)
                        {
                            // Chuyển đổi ảnh từ PictureBox thành mảng byte
                            using (MemoryStream ms = new MemoryStream())
                            {
                                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                                imageBytes = ms.ToArray();
                                cmd.Parameters.AddWithValue("@Anh", imageBytes);
                            }
                        }


                        cmd.ExecuteNonQuery();
                        LoadSanPham();
                        txtMaSP.Enabled = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
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

                    // Tạo SqlCommand để gọi Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("XoaSanPham", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số đầu vào cho thủ tục
                        cmd.Parameters.AddWithValue("@Ma_San_Pham", txtMaSP.Text);

                        // Thực thi thủ tục
                        cmd.ExecuteNonQuery();
                        LoadSanPham();
                        txtMaSP.Enabled = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void btnTKKH_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TimKiemSanPham(@Ten_San_Pham)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Ten_San_Pham", txtTK.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "TimKiem");
                        dgvSANPHAM.DataSource = ds.Tables["TimKiem"];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }




    }

}
