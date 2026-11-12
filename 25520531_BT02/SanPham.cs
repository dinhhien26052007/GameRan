using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25520531_BT02
{
    public class SanPham
    {
        string _maSanPham;
        string _tenSanPham;
        double _donGia;
        int  _soLuong;    
        string _donViTinh;

        public SanPham()
        {

        }

        public SanPham(string MaSP , string TenSP, double DG, int  SL, string  DVT)
        {
            MaSanPham = MaSP;
            TenSanPham = TenSP;
            DonGia = DG;
            SoLuong = SL;
            DonViTinh = DVT;
        }

        public string MaSanPham { get => _maSanPham; set => _maSanPham = value; }
        public string TenSanPham { get => _tenSanPham; set => _tenSanPham = value; }
        public double DonGia { get => _donGia; set => _donGia = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        public string DonViTinh { get => _donViTinh; set => _donViTinh = value; }
    }
}
