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
    public partial class frm_LichDaPhanCa : Form
    {
        string strCon = @"Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";
        SqlConnection sqlCon = null;
        public frm_LichDaPhanCa()
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
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM LichLamViecTuan", sqlCon))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvcalam.DataSource = dt;
                }
            }
        }
    }
}
