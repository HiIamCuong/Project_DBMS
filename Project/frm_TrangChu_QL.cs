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
    public partial class frm_TrangChu_QL : Form
    {
        public frm_TrangChu_QL()
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
            Form frm = kiemtratontai(typeof(frm_TaiKhoan));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_TaiKhoan fr = new frm_TaiKhoan();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void dOANHTHUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_DoanhThu_QL));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_DoanhThu_QL fr = new frm_DoanhThu_QL();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void loạiNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_LoaiNhanVien));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_LoaiNhanVien fr = new frm_LoaiNhanVien();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_DanhMucNhanVien));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_DanhMucNhanVien fr = new frm_DanhMucNhanVien();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void vịTríCôngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_ViTriCongViec));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_ViTriCongViec fr = new frm_ViTriCongViec();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void bảngPhânCaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_BangPhanCa));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_BangPhanCa fr = new frm_BangPhanCa();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void caLàmViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_CaLamViec));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_CaLamViec fr = new frm_CaLamViec();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_NCC));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_NCC fr = new frm_NCC();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void loạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_LoaiSanPham));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_LoaiSanPham fr = new frm_LoaiSanPham();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_SanPham));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_SanPham fr = new frm_SanPham();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void nguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_NguyenLieu));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_NguyenLieu fr = new frm_NguyenLieu();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void đăngxuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void frm_TrangChu_QL_Load(object sender, EventArgs e)
        {

        }

        private void chiTiếtHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(frm_CTHDN));
            if (frm != null)
                frm.Activate();
            else
            {
                frm_CTHDN fr = new frm_CTHDN();
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

        private void hóaĐơnNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
