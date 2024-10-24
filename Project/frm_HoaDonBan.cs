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
    public partial class frm_HoaDonBan : Form
    {
        string strconn = "Data Source=DELL;Initial Catalog=QLTraSua;Integrated Security=True";
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
    }
}
