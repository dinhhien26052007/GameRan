using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _25520531_BT02
{
    public partial class QuanLySanPhamForm : Form
    {

        List<SanPham> lstSanPham;
        SanPham spSelected;

        public QuanLySanPhamForm()
        {
            InitializeComponent();
        }
        public void LoadDuLieu()
        {
            if (lstSanPham == null || lstSanPham.Count == 0)
                tbMaSanPham.Text = "SP001";
            else
            {
                int maSoLonNhat = lstSanPham.Select(sp => int.Parse(sp.MaSanPham.Substring(2))).Max();
                int MaTiepTheo = maSoLonNhat + 1;
                tbMaSanPham.Text = "SP" + MaTiepTheo.ToString("D3");
            }

            List<string> lstDonViTinh = new List<string>() { "Thùng", "Cái", "Chai", "Hộp", "Bịch" };
            cbbDonViTinh.DataSource = lstDonViTinh;
            dgvSanPham.DataSource = null;
            dgvSanPham.DataSource = lstSanPham;


            GanDuLieuSanPham(null);
        }
        public SanPham LayDuLieuSanPham()
        {
            SanPham sp = new SanPham();
            sp.MaSanPham = tbMaSanPham.Text;
            sp.TenSanPham = tbTenSanPham.Text;
            sp.DonGia = Convert.ToDouble(tbDonGia.Text);
            sp.SoLuong = Convert.ToInt32(tbSoLuong.Text);
            sp.DonViTinh = cbbDonViTinh.SelectedItem.ToString();
            return sp;
        }
        public void GanDuLieuSanPham(SanPham sp)
        {
            if (sp != null)
            {
                tbMaSanPham.Text = sp.MaSanPham;
                tbTenSanPham.Text = sp.TenSanPham;
                tbDonGia.Text = sp.DonGia.ToString();
                tbSoLuong.Text = sp.SoLuong.ToString();
                cbbDonViTinh.SelectedItem = sp.DonViTinh;
            }
            else
            {

                tbTenSanPham.Text = "";
                tbDonGia.Text = "";
                tbSoLuong.Text = "";
                cbbDonViTinh.SelectedIndex = 0;
            }
        }

        private void QuanLySanPhamForm_Load(object sender, EventArgs e)
        {
            QuanLySanPham QLSP = new QuanLySanPham();
            QLSP.HienThiDanhSachSanPham(ref lstSanPham);
            LoadDuLieu();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SanPham sp = LayDuLieuSanPham();
                QuanLySanPham QLSP = new QuanLySanPham();
                int kq = QLSP.ThemSanPham(ref lstSanPham, sp);
                if (kq == 1)
                {
                    MessageBox.Show("Thêm sản phẩm thành công");
                    LoadDuLieu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.RowIndex.ToString());
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            spSelected = (SanPham)dgvSanPham.Rows[index].DataBoundItem;
            GanDuLieuSanPham(spSelected);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (spSelected == null)
                    return;

                QuanLySanPham QLSP = new QuanLySanPham();
                int kq = QLSP.XoaSanPham(ref lstSanPham, spSelected);
                if (kq == 1)
                {
                    MessageBox.Show("Xóa sản phẩm thành công");
                    LoadDuLieu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SanPham sp = LayDuLieuSanPham();
                QuanLySanPham QLSP = new QuanLySanPham();

                int kq = QLSP.SuaSanPham(ref lstSanPham, sp);
                if (kq == 1)
                {
                    MessageBox.Show("Sửa sản phẩm thành công");
                    LoadDuLieu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = tbTimKiem.Text.Trim();
                QuanLySanPham QLSP = new QuanLySanPham();
                List<SanPham> lstKetQua = QLSP.TimKiemTheoTen(ref lstSanPham, tuKhoa);
                LoadDuLieu();
                dgvSanPham.DataSource = lstKetQua;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
