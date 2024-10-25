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
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                using (SqlConnection connection = new SqlConnection(strCon))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM DoanhThuQuanLy(@Thang,@Nam)", connection))
                    {
                        command.Parameters.AddWithValue("@Thang", cbthang1.Text);
                        command.Parameters.AddWithValue("@Nam",cbnam.Text);
                        command.ExecuteNonQuery();
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
    }
}
