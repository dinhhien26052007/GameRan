using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25520531_BT03
{
    public class SanPham
    {
        string _maSanPham;
        string _tenSanPham; 
        int SoLuong;
        double DonGia;
        string _donViTinh;

        public string MaSanPham { get => _maSanPham; set => _maSanPham = value; }
        public string TenSanPham { get => _tenSanPham; set => _tenSanPham = value; }
        public int SoLuong1 { get => SoLuong; set => SoLuong = value; }
        public double DonGia1 { get => DonGia; set => DonGia = value; }
        public string DonViTinh { get => _donViTinh; set => _donViTinh = value; }
    }
}
