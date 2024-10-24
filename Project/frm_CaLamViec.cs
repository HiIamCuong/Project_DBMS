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
    public partial class frm_CaLamViec : Form
    {
        string strCon = "Data Source=QUYNHTHU-PC\\QT;Initial Catalog=QLTS;Persist Security Info=True;User ID=sa;Password=hello";
        SqlConnection sqlCon = null;
        public frm_CaLamViec()
        {
            InitializeComponent();
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loaddata()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM CaLamViec", sqlCon))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvcalam.DataSource = dt;
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                {
                    using (SqlConnection connection = new SqlConnection(strCon))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("Them_Ca_Lam", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@Ma_Ca", txtMaCa.Text);
                            command.Parameters.AddWithValue("@Ngay", txtNgay.Text);
                            command.Parameters.AddWithValue("@Gio_Bat_Dau", txtGioBD.Text);
                            command.Parameters.AddWithValue("@Gio_Ket_Thuc", txtGioKT.Text);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Thêm ca làm thành công");
                            loaddata();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                using (SqlConnection connection = new SqlConnection(strCon))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Xoa_Ca_Lam", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Ma_Ca", txtMaCa.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Xóa ca làm thành công");
                        loaddata();
                    }
                }
            }
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void dgvCaLamViec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
