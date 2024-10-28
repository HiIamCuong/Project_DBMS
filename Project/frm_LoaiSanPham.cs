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
    public partial class frm_LoaiSanPham : Form
    {
        string strconn = "Data Source=QUYNHTHU-PC\\QT;Initial Catalog=QLTraSua;Persist Security Info=True;User ID=sa;Password=hello";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        public frm_LoaiSanPham()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiSP.Text != "")
            {
                using (SqlConnection conn = new SqlConnection(strconn))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("ThemLoaiSanPham", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Ma_Loai_San_Pham", txtMaLoaiSP.Text);
                            cmd.Parameters.AddWithValue("@Ten_Loai_San_Pham", txtTenLoaiSP.Text);

                            cmd.ExecuteNonQuery();
                            LoadLoaiSanPham();

                            txtMaLoaiSP.Text = "";
                            txtTenLoaiSP.Text = "";
                            txtMaLoaiSP.Focus();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                    }
                }
            }
            
        }

        void LoadLoaiSanPham()
        {
            da = new SqlDataAdapter("Select * From LoaiSanPham", conn);
            ds = new DataSet();
            da.Fill(ds, "LoaiSanPham");
            dgv_MaLoaiSP.DataSource = ds.Tables["LoaiSanPham"];
        }

        private void frm_LoaiSanPham_Load_1(object sender, EventArgs e)
        {
            conn = new SqlConnection(strconn);
            conn.Open();
            LoadLoaiSanPham();
            conn.Close();
        }

        private void dgv_MaLoaiSP_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dgv_MaLoaiSP.Rows.Count - 1)
            {
                txtMaLoaiSP.Enabled = false;
                txtMaLoaiSP.Text = dgv_MaLoaiSP.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenLoaiSP.Text = dgv_MaLoaiSP.Rows[e.RowIndex].Cells[1].Value.ToString();
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
                    using (SqlCommand cmd = new SqlCommand("SuaLoaiSanPham", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Ma_Loai_San_Pham", txtMaLoaiSP.Text);
                        cmd.Parameters.AddWithValue("@Ten_Loai_San_Pham", txtTenLoaiSP.Text);

                        cmd.ExecuteNonQuery();
                        LoadLoaiSanPham();
                        txtMaLoaiSP.Text = "";
                        txtTenLoaiSP.Text = "";
                        txtMaLoaiSP.Enabled = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadLoaiSanPham();
            txtMaLoaiSP.Enabled = true;
            txtMaLoaiSP.Text = "";
            txtTenLoaiSP.Text = "";
            txtMaLoaiSP.Focus();            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                try
                {
                    conn.Open();

                    // Tạo SqlCommand để gọi Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("XoaLoaiSanPham", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Ma_Loai_San_Pham", txtMaLoaiSP.Text);

                        cmd.ExecuteNonQuery();
                        LoadLoaiSanPham();
                        txtMaLoaiSP.Text = "";
                        txtTenLoaiSP.Text = "";
                        txtMaLoaiSP.Enabled = true;

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
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TimKiemLoaiSanPham(@Ten_Loai_San_Pham)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Ten_Loai_San_Pham", txtTK.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "TimKiem");
                        dgv_MaLoaiSP.DataSource = ds.Tables["TimKiem"];
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
