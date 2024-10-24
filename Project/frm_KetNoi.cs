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
    public partial class KetNoi : Form
    {
        //Tạo biến cục bộ
        string strCon = @"Data Source=DESKTOP-GIJL260;Initial Catalog=QLTraSua;Integrated Security=True";

        //Đối tượng kết nối
        SqlConnection sqlCon = null;
        public KetNoi()
        {
            InitializeComponent();
        }

        private void btn_MoKetNoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon); //Rỗng thì tạo mới
                }
                sqlCon = new SqlConnection(strCon);
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open(); //Đóng thì mở
                    MessageBox.Show("Kết nối thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_DongKetNoi_Click(object sender, EventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
                MessageBox.Show("Đóng kết nối thành công!");
            }
            else
            {
                MessageBox.Show("Chưa tạo kết nối!");
            }
        }

        private void KetNoi_Load(object sender, EventArgs e)
        {

        }
    }
}
