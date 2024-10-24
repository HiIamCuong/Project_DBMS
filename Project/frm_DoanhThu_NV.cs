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
using System.Windows.Forms.VisualStyles;

namespace Project
{
    public partial class frm_DoanhThu_NV : Form
    {
        public frm_DoanhThu_NV()
        {
            InitializeComponent();
        }
        string strCon = @"Data Source=DESKTOP-GIJL260;Initial Catalog=QLTraSua;Integrated Security=True";
        SqlConnection sqlCon = null;

        private void dgvHDB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM View_DoanhThuCaLamViec1", sqlCon);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvdoanhthu.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng kết nối
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        private void frm_DoanhThu_NV_Load(object sender, EventArgs e)
        {

        }
    }
}
