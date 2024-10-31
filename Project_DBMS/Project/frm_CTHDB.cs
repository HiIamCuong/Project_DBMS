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
    public partial class frm_CTHDB : Form
    {
        string connectionString = "Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        SqlCommandBuilder cmd = null;
        private int ma_HDB = -1;
        
        public frm_CTHDB()
        {
            InitializeComponent();
        }

        void LoadHoaDonBan()
        {
            da = new SqlDataAdapter("Select * From ChiTietDonBan where Ma_Hoa_Don_Ban ='" + ma_HDB + "'", conn);
            ds = new DataSet();
            da.Fill(ds, "ChiTietDonBan");
            dgv_CTHDB.DataSource = ds.Tables["ChiTietDonBan"];
            TongDonGia();
        }

        public void TongDonGia()
        {
            int gia = dgv_CTHDB.Rows.Count;
            float DonGia = 0;
            for (int i = 0; i < gia - 1; i++)
            {
                DonGia += float.Parse(dgv_CTHDB.Rows[i].Cells["Tong_Tien"].Value.ToString());
            }
            lbl_TongTien.Text = DonGia.ToString("#,### vnđ");
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
                        MessageBox.Show("Thêm sản phẩm thành công.");

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
                        MessageBox.Show("Thêm sản phẩm thành công.");

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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ma_HDB = -1;
            LoadHoaDonBan();
        }
    }
}
