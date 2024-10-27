using System;
using System.Collections;
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
    public partial class frm_CTHDB : Form
    {
        string connectionString = "Data Source=QUYNHTHU-PC\\QT;Initial Catalog=QLTraSua;Persist Security Info=True;User ID=sa;Password=hello";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        private int ma_HDB = -1;
        
        public frm_CTHDB(int Ma)
        {
            InitializeComponent();
            ma_HDB = Ma;
        }

        public frm_CTHDB()
        {
            InitializeComponent();
        }

        void LoadHoaDonBan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM LayThongTinHoaDonBan(@Ma_Hoa_Don_Ban)", conn))
                {
                    cmd.Parameters.AddWithValue("@Ma_Hoa_Don_Ban", ma_HDB);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgv_CTHDB.DataSource = table;
                    TongDonGia();
                }
                conn.Close();
            }                       
        }

        public void TongDonGia()
        {
            int DonGia = 0;
            int sauChietKhau = 0;
            if (ma_HDB != -1)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT dbo.TinhTongTienTheoHoaDon(@Ma_Hoa_Don_Ban)", conn))
                        {
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("@Ma_Hoa_Don_Ban", ma_HDB);

                            DonGia = (int)cmd.ExecuteScalar();
                        }
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Có lỗi: " + e.Message);
                    }
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT Thanh_Tien FROM HoaDonBan WHERE Ma_Hoa_Don_Ban =" + ma_HDB, conn))
                        {
                            sauChietKhau = (int)cmd.ExecuteScalar();
                        }
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Có lỗi: " + e.Message);
                    }                    
                }                
            }
            lbl_TongTien.Text = DonGia + " VNĐ";
            lblSauChietKhau.Text = sauChietKhau + " VNĐ";

        }

        void LoadMaSanPham()
        {
            da = new SqlDataAdapter("Select * From SanPham", conn);
            ds = new DataSet();
            da.Fill(ds, "SanPham");
            cbMaSP.DataSource = ds.Tables["SanPham"];
            cbMaSP.DisplayMember = "Ten_San_Pham";
            cbMaSP.ValueMember = "Ma_San_Pham";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ma_HDB == -1)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("TaoHoaDonBan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@So_Luong", (int)soLuong.Value);
                        cmd.Parameters.AddWithValue("@Ma_San_Pham", cbMaSP.SelectedValue.ToString());

                        // Thực thi thủ tục
                        cmd.ExecuteNonQuery();

                        using (SqlCommand command = new SqlCommand("SELECT dbo.LayMaHoaDonCuoi()", conn))
                        {
                            // Thiết lập kiểu trả về là một giá trị duy nhất
                            command.CommandType = CommandType.Text;

                            // Thực thi lệnh và lấy giá trị trả về
                            ma_HDB = (int)command.ExecuteScalar();
                        }

                        LoadHoaDonBan();
                        //MessageBox.Show("Thêm sản phẩm thành công.");

                    }
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("ThemSanPhamVaoHoaDonBan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@So_Luong", (int)soLuong.Value);
                        cmd.Parameters.AddWithValue("@Ma_San_Pham", cbMaSP.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@Ma_Hoa_Don_Ban", ma_HDB);

                        cmd.ExecuteNonQuery();
                        LoadHoaDonBan();
                        //MessageBox.Show("Thêm sản phẩm thành công.");

                    }
                }
            }
        }

        private void frm_CTHDB_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            LoadHoaDonBan();
            LoadMaSanPham();
            conn.Close();
        }


        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void dgv_CTHDB_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // phải load mã sp trước để tránh cbb bị null
            LoadMaSanPham();
            if (e.RowIndex < dgv_CTHDB.Rows.Count - 1)
            {
                soLuong.Text = dgv_CTHDB.Rows[e.RowIndex].Cells[1].Value.ToString();

                string maSP;
                DataRow[] rows = ds.Tables["SanPham"].Select("Ten_San_Pham = '" + dgv_CTHDB.Rows[e.RowIndex].Cells[0].Value.ToString() + "'");

                cbMaSP.SelectedValue = rows[0]["Ma_San_Pham"].ToString();


            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SuaChiTietHoaDonBan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ma_Hoa_Don_Ban", ma_HDB);
                    cmd.Parameters.AddWithValue("@So_Luong", (int)soLuong.Value);
                    cmd.Parameters.AddWithValue("@Ma_San_Pham", cbMaSP.SelectedValue.ToString());

                    cmd.ExecuteNonQuery();

                    LoadHoaDonBan();
                    //MessageBox.Show("Thêm sản phẩm thành công.");

                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("XoaSanPhamTrongCTHD", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ma_Hoa_Don_Ban", ma_HDB);
                    cmd.Parameters.AddWithValue("@Ma_San_Pham", cbMaSP.SelectedValue.ToString());

                    cmd.ExecuteNonQuery();                 
                    LoadHoaDonBan();
                    //MessageBox.Show("Thêm sản phẩm thành công.");

                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadHoaDonBan();
        }


        private void btn_TK_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TimKiemSanPhamTrongCTHD(@Ten_San_Pham, @Ma_Hoa_Don_Ban)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma_Hoa_Don_Ban", ma_HDB);
                        cmd.Parameters.AddWithValue("@Ten_San_Pham", cbMaSP.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "TimKiem");
                        dgv_CTHDB.DataSource = ds.Tables["TimKiem"];
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
