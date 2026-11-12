using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25520531_BT02
{
    public class QuanLySanPham
    {
        public void HienThiDanhSachSanPham(ref List<SanPham> lstSanPham)
        {
            lstSanPham = new List<SanPham>();
            lstSanPham.Add(new SanPham("SP001", "Bột Giặt Omo", 50000, 800, "Bịch"));
            lstSanPham.Add(new SanPham("SP002", "Nước Ngọt Pepsi", 100000, 1000, "Thùng"));
            lstSanPham.Add(new SanPham("SP003", "Kem đánh răng PS", 40000, 2000, "Hộp"));
        }
        public int ThemSanPham(ref List<SanPham> lstSanPham, SanPham sp)
        {
            try
            {
                lstSanPham.Add(sp);
                return 1;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int XoaSanPham(ref List<SanPham> lstSanPham, SanPham sp)
        {
            try
            {
               lstSanPham.Remove(sp);
                return 1;
                
               
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public int SuaSanPham(ref List<SanPham> lstSanPham, SanPham spSua)
        {
            try
            {
                foreach (SanPham sp in lstSanPham)
                {
                    if (sp.MaSanPham == spSua.MaSanPham)
                    {
                        sp.TenSanPham = spSua.TenSanPham;
                        sp.DonGia = spSua.DonGia;
                        sp.SoLuong = spSua.SoLuong;
                        sp.DonViTinh = spSua.DonViTinh;
                        return 1; 
                    }
                }
                return 0; 
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<SanPham> TimKiemTheoTen(ref List<SanPham> lstSanPham, string tenTimKiem)
        {
            try
            {
                List<SanPham> lstKetQua = new List<SanPham>();
                foreach (SanPham sp in lstSanPham)
                {
                    if (sp.TenSanPham.ToLower().Contains(tenTimKiem.ToLower()))
                    {
                        lstKetQua.Add(sp);
                    }
                }
                return lstKetQua; 
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
