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
    public partial class frm_HoaDonBan : Form
    {
        string strconn = "Data Source=QUYNHTHU-PC\\QT;Initial Catalog=QLTraSua;Persist Security Info=True;User ID=sa;Password=hello";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        SqlCommandBuilder cmd = null;
        public frm_HoaDonBan()
        {
            InitializeComponent();
        }

        private void frm_HoaDonBan_Load(object sender, EventArgs e)
        {
            txtMaHDB.Enabled = false;
            txtThanhTien.Enabled = false;
            txtSĐT.Focus();
            conn = new SqlConnection(strconn);
            conn.Open();
            LoadHoaDonBan();
            conn.Close();
        }

        void LoadHoaDonBan()
        {
            da = new SqlDataAdapter("Select * From HoaDonBan", conn);
            ds = new DataSet();
            da.Fill(ds, "HoaDonBan");
            dgvHDB.DataSource = ds.Tables["HoaDonBan"];
        }

        private void btnXemCTHD_Click(object sender, EventArgs e)
        {
            if (txtMaHDB.Text != null && txtMaHDB.Text != "") {
                int Ma = Convert.ToInt32(txtMaHDB.Text);
                Form form = new frm_CTHDB(Ma);
                form.ShowDialog();
            }                  
        }

        private void dgvHDB_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= dgvHDB.Rows.Count - 1)
            {
                txtMaHDB.Text = "";
                txtSĐT.Focus();
                txtSĐT.Text = "";
                txtThanhTien.Text = "";
            }
            else
            {
                txtMaHDB.Text = dgvHDB.Rows[e.RowIndex].Cells["Ma_Hoa_Don_Ban"].Value.ToString();
                dtpNgayBan.Value = Convert.ToDateTime(dgvHDB.Rows[e.RowIndex].Cells["Ngay"].Value);
                txtSĐT.Text = dgvHDB.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
                txtThanhTien.Text = dgvHDB.Rows[e.RowIndex].Cells["Thanh_Tien"].Value.ToString();

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadHoaDonBan();
            txtMaHDB.Text = "";
            txtSĐT.Focus();
            txtSĐT.Text = "";
            txtThanhTien.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                try
                {
                    conn.Open();

                    // Tạo SqlCommand để gọi Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("ThemHoaDonBan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Thoi_gian", dtpNgayBan.Value);
                        cmd.Parameters.AddWithValue("@SDT", txtSĐT.Text);

                        cmd.ExecuteNonQuery();
                        LoadHoaDonBan();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
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
                    using (SqlCommand cmd = new SqlCommand("SuaHoaDonBan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Ma_Hoa_Don_Ban", txtMaHDB.Text);
                        cmd.Parameters.AddWithValue("@Thoi_gian", dtpNgayBan.Value);
                        cmd.Parameters.AddWithValue("@SDT", txtSĐT.Text);

                        cmd.ExecuteNonQuery();
                        LoadHoaDonBan();

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
                    using (SqlCommand cmd = new SqlCommand("XoaHoaDonBan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Ma_Hoa_Don_Ban", txtMaHDB.Text);

                        cmd.ExecuteNonQuery();
                        LoadHoaDonBan();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TimKiemHoaDonBan(@Keyword)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Keyword", txtTimKiem.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "TimKiem");
                        dgvHDB.DataSource = ds.Tables["TimKiem"];                        
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
