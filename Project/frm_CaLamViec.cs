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
    public partial class frm_CaLamViec : Form
    {
        string strCon = @"Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";
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

        private void dgvcalam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvcalam_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= dgvcalam.Rows.Count - 1)
            {
                txtMaCa.Text = "";
                txtNgay.Text = "";
                txtGioBD.Text = "";
                txtGioKT.Text = "";
            }
            else
            {
                txtMaCa.Text = dgvcalam.Rows[e.RowIndex].Cells["Ma_Ca"].Value.ToString();
                txtNgay.Text = dgvcalam.Rows[e.RowIndex].Cells["Ngay"].Value.ToString();
                txtGioBD.Text = dgvcalam.Rows[e.RowIndex].Cells["Gio_Bat_Dau"].Value.ToString();
                txtGioKT.Text=dgvcalam.Rows[e.RowIndex].Cells["Gio_Ket_Thuc"].Value.ToString();
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtMaCa.Text = "";
            txtNgay.Text = "";
            txtGioBD.Text = "";
            txtGioKT.Text = "";
        }
    }
}
