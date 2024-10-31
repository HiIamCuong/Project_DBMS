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
    public partial class frm_DoanhThu_QL : Form
    {
        string strCon = @"Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";
        SqlConnection sqlCon = null;
        public frm_DoanhThu_QL()
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
            if(cbthang1.Text == ""  && cbnam.Text=="")
            {
                try
                {
                    if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM HoaDonBan", sqlCon))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvdoanhthuQL.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }    
            else
            {
                using (SqlConnection connection = new SqlConnection(strCon))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM DoanhThuQuanLy(@Thang, @Nam)", connection))
                    {
                        command.Parameters.AddWithValue("@Thang", cbthang1.Text);
                        command.Parameters.AddWithValue("@Nam", cbnam.Text);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dgvdoanhthuQL.DataSource = dataTable;
                        }
                    }
                }
            }
        }

        private void cbthang1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata();
        }

        private void cbnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata();
        }

        private void xemtatca_Click(object sender, EventArgs e)
        {
            cbthang1.Text = "";
            cbnam.Text = "";
            loaddata();
        }
    }
}
