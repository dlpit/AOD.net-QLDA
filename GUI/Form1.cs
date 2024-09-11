using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BLL;
using DTO;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDanhSachVatTu();
        }

        private void HienThiDanhSachVatTu()
        {
            VatTuBLL vtbll = new VatTuBLL();
            List<VatTu> ds = vtbll.HienThiDanhSachVatTu();
            lsvDanhSach.Items.Clear();
            foreach (VatTu item in ds)
            {
                ListViewItem lvi = new ListViewItem(item.MaVTu);
                lvi.SubItems.Add(item.TenVTu);
                lvi.SubItems.Add(item.DVTinh);
                lvi.SubItems.Add(item.PhanTram.ToString());
                lsvDanhSach.Items.Add(lvi);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            VatTu vt = new VatTu();
            vt.MaVTu = txtMaVT.Text.Trim();
            vt.TenVTu = txtTenVT.Text.Trim();
            vt.DVTinh = txtDVT.Text.Trim();
            vt.PhanTram = double.Parse(txtPhanTram.Text.Trim());
            VatTuBLL vtbll = new VatTuBLL();
            bool kt = vtbll.ThemVT(vt);
            if (kt)
            {
                MessageBox.Show("Thêm vật tư thành công!");
                HienThiDanhSachVatTu();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            VatTu vt = new VatTu();
            vt.MaVTu = txtMaVT.Text.Trim();
            VatTuBLL vtbll = new VatTuBLL();
            bool kt = vtbll.XoaVT(vt);
            if (kt)
            {
                MessageBox.Show("Xóa vật tư thành công!");
                HienThiDanhSachVatTu();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            VatTu vt = new VatTu();
            vt.MaVTu = txtMaVT.Text.Trim();
            vt.TenVTu = txtTenVT.Text.Trim();
            vt.DVTinh = txtDVT.Text.Trim();
            vt.PhanTram = double.Parse(txtPhanTram.Text.Trim());
            VatTuBLL vtbll = new VatTuBLL();
            bool kt = vtbll.SuaVT(vt);
            if (kt)
            {
                MessageBox.Show("Sửa vật tư thành công!");
                HienThiDanhSachVatTu();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
