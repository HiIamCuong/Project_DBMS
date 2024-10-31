using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class frm_TrangChu_NV : Form
    {
        public frm_TrangChu_NV()
        {
            InitializeComponent();
        }
        private Form kiemtratontai(Type formtype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formtype)
                    return f;
            }
            return null;
        }


        private void quanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_ChinhSuaTTCaNhan));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_ChinhSuaTTCaNhan fr = new frm_ChinhSuaTTCaNhan();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void frm_TrangChu_NV_Load(object sender, EventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_KhachHang));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_KhachHang fr = new frm_KhachHang();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void lỊCHPHÂNCAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_LichDaPhanCa));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_LichDaPhanCa fr = new frm_LichDaPhanCa();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void doanhthutoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_DoanhThu_NV));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_DoanhThu_NV fr = new frm_DoanhThu_NV();
                fr.MdiParent = this;
                fr.Show();
            }
        }


        private void hóaĐơnXuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_HoaDonBan));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_HoaDonBan fr = new frm_HoaDonBan();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void chiTiếtHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_CTHDB));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_CTHDB fr = new frm_CTHDB();
                fr.MdiParent = this;
                fr.Show();
            }
        }
    }
}
